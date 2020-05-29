using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;

namespace ImageTemplate
{
    public static class Extensions
    {
        public static string B64(this Image image)
        {
            IImageFormat format = SixLabors.ImageSharp.Formats.Bmp.BmpFormat.Instance;
            return image.ToBase64String(format);
        }
    }

}
