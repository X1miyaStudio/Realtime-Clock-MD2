using NeoRune;
using UE.CoreUObject;
using UE.Engine;
using UE.InputCore;
using UE.Minimap;
using UE.UMG;

namespace RealtimeClock;

/// <summary>Floating non-interactive real-time clock widget styled to match Minecraft Dungeons II.</summary>
public class ClockOverlayWidget : ScreenWidget
{
    UBorder? innerPanel;
    UTextBlock? label;

    public override void OnInitialized()
    {
        var tree = Ui.Tree(this);
        if (tree == null) return;

        label = Ui.Text(tree, "00:00", 20);
        if (label != null)
        {
            label.SetShadowOffset(new FVector2D { X = 1.0, Y = 1.0 });
            label.SetShadowColorAndOpacity(Ui.Color(0.03f, 0.03f, 0.05f, 0.95f));
        }

        innerPanel = Ui.Panel(tree, label, Ui.Color(0.08f, 0.10f, 0.135f, 0.88f), 6f);
        var bevel = Ui.Panel(tree, innerPanel, Ui.Color(0.24f, 0.28f, 0.35f, 0.92f), 1f);
        var outline = Ui.Panel(tree, bevel, Ui.Color(0.035f, 0.04f, 0.055f, 0.95f), 2f);
        if (outline != null)
        {
            outline.SetVisibility(ESlateVisibility.HitTestInvisible);
            tree.RootWidget = outline;
        }
        SetVisibility(ESlateVisibility.HitTestInvisible);
    }

    public void UpdateDisplay(string text, int fontSize, FLinearColor textColor, float bgOpacity)
    {
        if (label != null)
        {
            label.SetText(text);
            var font = UMinimapHelpersLibrary.GetDefaultFont();
            if (font.FontObject == null) font = label.Font;
            font.Size = fontSize;
            label.SetFont(font);
            label.SetColorAndOpacity(Ui.SlateColor(textColor));
        }
        if (innerPanel != null)
        {
            innerPanel.SetBrushColor(Ui.Color(0.08f, 0.10f, 0.135f, bgOpacity));
        }
    }
}

[ModSetting.Heading("Realtime Clock")]
[ModSetting.Toggle("enabled", "Enable Clock", Default = true, Description = "Show or hide the real-time clock overlay.")]
[ModSetting.Keybind("toggle_key", "Toggle Hotkey", Default = "F9", Description = "Quickly show or hide the clock during gameplay.")]
[ModSetting.Toggle("show_in_menus", "Show on Main Menu", Default = true, Description = "Keep the clock visible on the main menu screen.")]
[ModSetting.Toggle("above_ui", "Show Over Pause & Inventory", Default = true, Description = "Render above game menus without blocking mouse clicks.")]
[ModSetting.Heading("Appearance")]
[ModSetting.Toggle("format_24h", "24-Hour Format", Default = true, Description = "Use 24-hour time (17:30) instead of 12-hour AM/PM.")]
[ModSetting.Toggle("show_seconds", "Show Seconds", Default = false, Description = "Display seconds (HH:MM:SS).")]
[ModSetting.Select("position", "Screen Position", "Top Right", "Top Left", "Bottom Right", "Bottom Left", "Top Center")]
[ModSetting.Slider("offset_x", "Horizontal Margin", Default = 16, Min = 0, Max = 300, Step = 4)]
[ModSetting.Slider("offset_y", "Vertical Margin", Default = 16, Min = 0, Max = 300, Step = 4)]
[ModSetting.Slider("font_size", "Font Size", Default = 20, Min = 12, Max = 42, Step = 1)]
[ModSetting.Colour("text_color", "Text Color", Default = "#FFFFFF", HexInput = true)]
[ModSetting.Slider("bg_opacity", "Background Opacity", Default = 0.88, Min = 0.0, Max = 0.98, Step = 0.05)]
public class ModActor : AActor, IModSettings
{
    bool enabled = true;
    FKey toggleKey = new FKey { KeyName = "F9" };
    bool showInMenus = true;
    bool aboveUi = true;
    bool format24h = true;
    bool showSeconds = false;
    int position = 0;
    double offsetX = 16;
    double offsetY = 16;
    double fontSize = 20;
    FLinearColor textColor = new FLinearColor { R = 1f, G = 1f, B = 1f, A = 1f };
    double bgOpacity = 0.88;

    ClockOverlayWidget? widget;
    PausableTimer? tickTimer;
    KeyListener? keyListener;
    bool isMenuLevel;

    protected override void ReceiveBeginPlay()
    {
        isMenuLevel = World.LevelName(this).StartsWith("Menu");
        Log.Write($"RealtimeClock started on level '{World.LevelName(this)}'.");

        ListenToKey();

        tickTimer = PausableTimer.Start(this, 0.5f, loop: true);
        if (tickTimer != null) tickTimer.Fired += RefreshClock;

        ApplyVisibilityAndLayout();
        RefreshClock();
    }

    protected override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
    {
        keyListener?.Stop();
        tickTimer?.Stop();
        widget?.Hide();
    }

    public void OnSettingChanged(string id, string value)
    {
        if (id == "enabled") enabled = ModSettings.ToBool(value);
        else if (id == "show_in_menus") showInMenus = ModSettings.ToBool(value);
        else if (id == "above_ui") aboveUi = ModSettings.ToBool(value);
        else if (id == "format_24h") format24h = ModSettings.ToBool(value);
        else if (id == "show_seconds") showSeconds = ModSettings.ToBool(value);
        else if (id == "position") position = ModSettings.ToInt(value);
        else if (id == "offset_x") offsetX = ModSettings.ToNumber(value);
        else if (id == "offset_y") offsetY = ModSettings.ToNumber(value);
        else if (id == "font_size") fontSize = ModSettings.ToNumber(value);
        else if (id == "text_color") textColor = ModSettings.ToColour(value);
        else if (id == "bg_opacity") bgOpacity = ModSettings.ToNumber(value);

        ApplyVisibilityAndLayout();
        RefreshClock();
    }

    public void OnKeybindChanged(string id, FKey key, FKey secondaryKey)
    {
        if (id != "toggle_key") return;
        toggleKey = key;
        ListenToKey();
    }

    public void OnSettingsReset()
    {
        enabled = true;
        toggleKey = new FKey { KeyName = "F9" };
        showInMenus = true;
        aboveUi = true;
        format24h = true;
        showSeconds = false;
        position = 0;
        offsetX = 16;
        offsetY = 16;
        fontSize = 20;
        textColor = new FLinearColor { R = 1f, G = 1f, B = 1f, A = 1f };
        bgOpacity = 0.88;

        ListenToKey();
        ApplyVisibilityAndLayout();
        RefreshClock();
    }

    void ListenToKey()
    {
        keyListener?.Stop();
        keyListener = Input.OnKey(this, toggleKey);
        if (keyListener != null) keyListener.Pressed += OnToggleKeyPressed;
    }

    void OnToggleKeyPressed()
    {
        enabled = !enabled;
        ModSettings.SetBool(this, "enabled", enabled);
        ApplyVisibilityAndLayout();
        RefreshClock();
    }

    bool ShouldShow() => enabled && (!isMenuLevel || showInMenus);

    void ApplyVisibilityAndLayout()
    {
        if (!ShouldShow())
        {
            widget?.Hide();
            return;
        }

        if (widget == null)
        {
            widget = Ui.Create(this, Unreal.ClassOf<ClockOverlayWidget>()) as ClockOverlayWidget;
            if (widget == null) return;
        }
        else
        {
            widget.Hide();
        }

        var anchor = ClockLogic.GetAnchor(position);
        var offset = ClockLogic.GetSignedOffset(position, offsetX, offsetY);
        int zOrder = (aboveUi || isMenuLevel) ? ScreenWidget.AboveGameUI : ScreenWidget.UnderGameUI;
        widget.ShowAt(offset, anchor, zOrder);
    }

    void RefreshClock()
    {
        if (widget == null || !ShouldShow()) return;

        var now = UKismetMathLibrary.Now();
        UKismetMathLibrary.BreakDateTime(now, out _, out _, out _, out int hour, out int minute, out int second, out _);
        string formatted = ClockLogic.FormatTime(hour, minute, second, format24h, showSeconds);
        widget.UpdateDisplay(formatted, (int)fontSize, textColor, (float)bgOpacity);
    }
}
