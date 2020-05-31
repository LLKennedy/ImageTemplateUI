using System.Drawing;
namespace ImageTemplate.Components
{
    public static partial class Extensions
    {
        ///<summary>Converts a colour to an HTML-compatible RGBA hex string</summary>
        public static string ToRGBAHexString(this Color Colour)
        {
            return "#" + Colour.R.ToString("X2") + Colour.G.ToString("X2") + Colour.B.ToString("X2") + Colour.A.ToString("X2");
        }
    }
}