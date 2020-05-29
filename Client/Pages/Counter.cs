using System;
using System.Threading.Tasks;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using ImageTemplate;

namespace ImageTemplateUI
{
    namespace Components
    {
        public class Counter : PageBase
        {
            [Parameter]
            public int Initial { get; set; } = 0;
            [Parameter]
            public string StringInitial { get; set; } = null;
            public int Count { get; set; }
            public string ImageData { get; set; } = "";
            public Counter() : base()
            {
            }
            protected override void OnInitialized()
            {
                Count = Initial;
                var template = new Template();
                using (var rendered = template.Render(null))
                {
                    try
                    {
                        ImageData = rendered.B64();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Error converting image to string: " + ex.Message);
                    }
                }
            }
            public void IncrementCount()
            {
                Count++;
            }

            private Canvas2DContext _context;

            protected BECanvasComponent _canvasReference;

            protected override async Task OnAfterRenderAsync(bool firstRender)
            {
                this._context = await this._canvasReference.CreateCanvas2DAsync();
                await this._context.SetFillStyleAsync("green");

                await this._context.FillRectAsync(10, 100, 100, 100);

                await this._context.SetFontAsync("48px serif");
                await this._context.StrokeTextAsync("Hello Blazor!!!", 10, 100);
            }
        }
    }
}