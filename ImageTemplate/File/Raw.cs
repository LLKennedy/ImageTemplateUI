using System;
using System.Drawing;
using Newtonsoft.Json;
namespace ImageTemplate.File
{
    namespace Raw
    {
        ///<summary>Overarching file structure for image template files</summary>
        public class TopLevel
        {
            public BaseImage baseImage;
            public String components; // Raw JSON
        }
        public class BaseImage
        {
            public String fileName;
            public String data;
            public RGBA baseColour;
            public String width;
            public String height;
            public String ppi;
        }
        public class RGBA
        {
            public string R, G, B, A;
        }
    }
}