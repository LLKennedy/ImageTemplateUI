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
            public BaseImage BaseImage;
            public String Components; // Raw JSON
            public TopLevel()
            { }
            public TopLevel(string data)
            {
                TopLevel o = JsonConvert.DeserializeObject<TopLevel>(data);
                this.BaseImage = o.BaseImage;
                this.Components = o.Components;
            }
        }
        public class BaseImage
        {
            public String FileName;
            public String Data;
            public RGBA BaseColour;
            public String BaseWidth;
            public String BaseHeight;
            public String PPI;
            public class RGBA
            {
                public string R, G, B, A;
            }
        }
    }
}