using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using Newtonsoft.Json;
using ImageTemplate.File.Raw;

namespace ImageTemplate.Components
{
    public class Rectangle : IComponent
    {
        public Color Colour;
        public int StartX, StartY;
        public uint Width, Height;
        public Task InjectJSON(string propertiesData)
        {
            return Task.Run(() =>
            {
                var raw = JsonConvert.DeserializeObject<Raw>(propertiesData);

            });
        }
        public async Task Render(Canvas2DContext context, IDictionary<string, object> props = null)
        {
            await context.SetFillStyleAsync(Colour.ToRGBAHexString());
            await context.FillRectAsync(StartX, StartY, Width, Height);
        }
        public static void Initialise()
        {
            var componentIDs = new List<string>
                {
                    "rectangle",
                    "rect",
                };
            foreach (string id in componentIDs)
            {
                ComponentFactory.Register<Rectangle>(id);
            }
        }
        public class Raw
        {
            public String topLeftX;
            public String topLeftY;
            public String width;
            public String height;
            public RGBA colour;
        }
    }
}