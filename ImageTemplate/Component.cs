using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using SixLabors.ImageSharp;

namespace ImageTemplate
{
    public interface IComponent
    {
        Task Render(IDictionary<string, object> props = null); // TODO: work out a drawing interface for an in-progress SixLabors image to inject here, maybe just wrap both under one interface
        Task Render(Canvas2DContext context, IDictionary<string, object> props = null);
    }
    public class Component : IComponent
    {
        public Task Render(IDictionary<string, object> props = null)
        {
            throw new Exception("Unimplemented");
        }
        public Task Render(Canvas2DContext context, IDictionary<string, object> props = null)
        {
            throw new Exception("Unimplemented");
        }
    }
}
