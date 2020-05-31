using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;

namespace ImageTemplate.Components
{
    public class Image : IComponent
    {
        public Color Colour;
        public int StartX, StartY;
        public double Radius;
        public Task Render(IDictionary<string, object> props = null)
        {
            throw new Exception("Not implemented");
        }
        public Task Render(Canvas2DContext context, IDictionary<string, object> props = null)
        {
            throw new Exception("Not implemented");
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
    }
}