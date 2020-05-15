using System;
using UnityEngine;

[Serializable]
public enum ColorType
{
    None = 0,
    Red = 4,
    Green = 2,
    Blue = 1,
    Yellow = Red | Green,
    Magenta = Red | Blue,
    Cyan = Green | Blue,
    White = Red | Green | Blue,
}

public class Colors
{
    public static Color GetRGBAColor(ColorType colorType)
    {
        switch (colorType)
        {
            case ColorType.Red:
                return Color.red;
            case ColorType.Green:
                return Color.green;
            case ColorType.Blue:
                return Color.blue;
            case ColorType.Yellow:
                return Color.yellow;
            case ColorType.Magenta:
                return Color.magenta;
            case ColorType.Cyan:
                return Color.cyan;
            case ColorType.White:
                return Color.white;
            case ColorType.None:
            default:
                return Color.black;
        }
    }
}
