using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using SixLabors.ImageSharp;

namespace ImageTemplate
{
    public interface IComponent
    {
        Task Render(IDictionary<string, object> props = null);
        Task Render(Canvas2DContext context, IDictionary<string, object> props = null);
    }
    public class Component
    {
    }
}
