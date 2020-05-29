using System;
using System.Threading.Tasks;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using ImageTemplate;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace ImageTemplateUI
{
    namespace Components
    {
        public class Counter : PageBase, IDisposable
        {
            [Parameter]
            public int Initial { get; set; } = 0;
            [Parameter]
            public string StringInitial { get; set; } = null;
            public int Count { get; set; }
            public ITemplate RenderTemplate;
            public string ImageData { get; set; } = "";
            public Counter() : base()
            {
            }
            protected override void OnInitialized()
            {
                Count = Initial;
                RenderTemplate = new Template();
            }
            public async void IncrementCount()
            {
                Count++;
                try
                {
                    await RenderTemplate.Render(this._canvasReference, new Dictionary<string, object>{
                    { "count", Count },
                    });
                }
                catch (Exception ex)
                {
                    Logger.LogError("Exception rendering incremented count: {0}, {1}", ex.Message, ex.StackTrace);
                }
            }

            private Canvas2DContext _context;

            protected BECanvasComponent _canvasReference;

            protected override async Task OnAfterRenderAsync(bool firstRender)
            {
                if (firstRender)
                {
                    await RenderTemplate.Render(this._canvasReference);
                    this._context = await this._canvasReference.CreateCanvas2DAsync();
                    await this._context.SetFillStyleAsync("green");

                    await this._context.FillRectAsync(10, 100, 100, 100);

                    await this._context.SetFontAsync("48px serif");
                    await this._context.StrokeTextAsync("Hello Blazor!!!", 10, 100);
                }
            }

            new public void Dispose()
            {
                base.Dispose();
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }
}