<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:0D1117,50:2563EB,100:00FF88&height=180&section=header&text=Realtime%20Clock%20Overlay&fontSize=38&fontColor=ffffff&fontAlignY=40" width="100%" alt="Realtime Clock Overlay Banner" />

[![Game](https://img.shields.io/badge/Minecraft_Dungeons_II-UE_5.6-00FF88?style=for-the-badge)](https://github.com/X1miyaStudio/Realtime-Clock-MD2)
[![Release](https://img.shields.io/badge/GitHub_Release-v1.0.0-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/X1miyaStudio/Realtime-Clock-MD2/releases/tag/v1.0.0)
[![CurseForge](https://img.shields.io/badge/CurseForge-Download-F16436?style=for-the-badge&logo=curseforge&logoColor=white)](https://www.curseforge.com/minecraft-dungeons-II/mods/realtime-clock-overlay)
[![Loader](https://img.shields.io/badge/Blueprint_Loader-2.0%2B-blueviolet?style=for-the-badge)](https://www.nexusmods.com/minecraftdungeons2/mods/2)
[![SDK](https://img.shields.io/badge/Built_with-NeoRune-00BFFF?style=for-the-badge)](https://github.com/X1miyaStudio/Realtime-Clock-MD2)
[![Studio](https://img.shields.io/badge/Studio-X1miyaStudio-064E3B?style=for-the-badge)](https://t.me/X1miyaStudio)

<p align="center">
  <b>Customizable real-time clock HUD overlay for Minecraft Dungeons II.</b><br/>
  Styled to match the native in-game UI frame with 12h/24h formats, seconds, custom positioning, colors, and Blueprint Loader 2.0+ settings.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Language-English-00FF88?style=flat-square" alt="English" />
  <a href="README_RU.md">
    <img src="https://img.shields.io/badge/%D0%AF%D0%B7%D1%8B%D0%BA-%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9-0D1117?style=flat-square&logo=googletranslate&logoColor=white" alt="Русская версия" />
  </a>
</p>

</div>

---

## ✨ Features

* **Real-Time Local Clock** — displays your system clock in-game and keeps ticking even while paused (`PausableTimer`).
* **Non-Intrusive Overlay** — uses `HitTestInvisible` so it never blocks mouse clicks in menus, inventory, or combat.
* **Native Minecraft Dungeons II Frame** — triple-layer slate/stone border with drop-shadowed text.
* **Full In-Game Settings (`Settings → Mods`)**:
  * Enable/disable clock and bind a quick toggle hotkey (`F9` by default).
  * Show on the Main Menu and over Pause/Inventory screens.
  * 24-hour (`17:30`) or 12-hour (`5:30 PM`) format + optional seconds (`HH:MM:SS`).
  * 5 screen anchors (`Top Right`, `Top Left`, `Bottom Right`, `Bottom Left`, `Top Center`) with X/Y margin sliders.
  * Custom font size, text color (hex picker), and background opacity.

---

## 📥 Requirements & Installation

1. Install **Blueprint Loader 2.0+** into `Dungeons\Content\Paks\~mods\BlueprintLoader\`.
2. Download `RealtimeClockOverlay-1.0.0.zip` from [GitHub Releases](https://github.com/X1miyaStudio/Realtime-Clock-MD2/releases).
3. Close **Minecraft Dungeons II** and extract the `RealtimeClock` folder into:
   * **Steam:** `<SteamLibrary>\steamapps\common\Minecraft Dungeons II\Dungeons\Content\Paks\~mods\RealtimeClock\`
   * **Xbox App / Game Pass:** `<Drive>:\XboxGames\Minecraft Dungeons II\Content\Dungeons\Content\Paks\~mods\RealtimeClock\`
4. Launch the game and configure the mod under **Settings → Mods → Realtime Clock Overlay**.

---

## 🛠️ Building from Source

Requires **.NET 10 SDK**, `NeoRune.Templates`, and `NeoRune.Tool`:

```powershell
dotnet build -c Release
neorune pack
```

---

<div align="center">
  <b>— X1miyaStudio🧪</b><br/>
  <a href="https://t.me/X1miyaStudio">Telegram</a> · <a href="https://discord.gg/pwk6X8ecNJ">Discord</a> · <a href="https://www.youtube.com/@X1miyaStudio">YouTube</a>
</div>
