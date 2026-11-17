using NeoRune;
using UE.CoreUObject;

namespace RealtimeClock;

/// <summary>Pure formatting and layout math for the clock overlay (unit-tested outside the game).</summary>
public static class ClockLogic
{
    public static string Pad2(int value) => value < 10 ? "0" + value.ToString() : value.ToString();

    public static string FormatTime(int hour24, int minute, int second, bool use24Hour, bool showSeconds)
    {
        string minStr = Pad2(minute);
        string secPart = showSeconds ? ":" + Pad2(second) : "";

        if (use24Hour)
            return Pad2(hour24) + ":" + minStr + secPart;

        bool isPm = hour24 >= 12;
        int hour12 = hour24 % 12;
        if (hour12 == 0) hour12 = 12;
        string suffix = isPm ? " PM" : " AM";
        return hour12.ToString() + ":" + minStr + secPart + suffix;
    }

    public static FVector2D GetAnchor(int positionIndex)
    {
        if (positionIndex == 1) return new FVector2D { X = 0.0, Y = 0.0 };   // Top Left
        if (positionIndex == 2) return new FVector2D { X = 1.0, Y = 1.0 };   // Bottom Right
        if (positionIndex == 3) return new FVector2D { X = 0.0, Y = 1.0 };   // Bottom Left
        if (positionIndex == 4) return new FVector2D { X = 0.5, Y = 0.0 };   // Top Center
        return new FVector2D { X = 1.0, Y = 0.0 };                           // Top Right (default)
    }

    public static FVector2D GetSignedOffset(int positionIndex, double offsetX, double offsetY)
    {
        double x = offsetX;
        double y = offsetY;

        if (positionIndex == 0 || positionIndex == 2) x = -offsetX; // Right edge moves inward
        else if (positionIndex == 4) x = 0.0;                       // Top Center stays centered

        if (positionIndex == 2 || positionIndex == 3) y = -offsetY; // Bottom edge moves upward

        return new FVector2D { X = x, Y = y };
    }
}

[ModTests]
public class ClockLogicTests
{
    public void Formats24HourWithAndWithoutSeconds()
    {
        ModAssert.Equal("07:05", ClockLogic.FormatTime(7, 5, 9, true, false));
        ModAssert.Equal("17:05:09", ClockLogic.FormatTime(17, 5, 9, true, true));
        ModAssert.Equal("00:00:00", ClockLogic.FormatTime(0, 0, 0, true, true));
    }

    public void Formats12HourMidnightNoonAndAfternoon()
    {
        ModAssert.Equal("12:05 AM", ClockLogic.FormatTime(0, 5, 9, false, false));
        ModAssert.Equal("12:00 PM", ClockLogic.FormatTime(12, 0, 0, false, false));
        ModAssert.Equal("5:09:03 PM", ClockLogic.FormatTime(17, 9, 3, false, true));
    }

    public void ComputesAnchorsAndInwardOffsets()
    {
        var topRightAnchor = ClockLogic.GetAnchor(0);
        ModAssert.Near(1.0, topRightAnchor.X, 0.001);
        ModAssert.Near(0.0, topRightAnchor.Y, 0.001);

        var topRightOffset = ClockLogic.GetSignedOffset(0, 16, 20);
        ModAssert.Near(-16.0, topRightOffset.X, 0.001);
        ModAssert.Near(20.0, topRightOffset.Y, 0.001);

        var bottomLeftOffset = ClockLogic.GetSignedOffset(3, 16, 20);
        ModAssert.Near(16.0, bottomLeftOffset.X, 0.001);
        ModAssert.Near(-20.0, bottomLeftOffset.Y, 0.001);

        var topCenterOffset = ClockLogic.GetSignedOffset(4, 24, 12);
        ModAssert.Near(0.0, topCenterOffset.X, 0.001);
        ModAssert.Near(12.0, topCenterOffset.Y, 0.001);
    }
}
