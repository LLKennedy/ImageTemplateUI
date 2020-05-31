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
                    await RenderTemplate.Render(CanvasReference, new Dictionary<string, object>{
                    { "count", Count },
                    });
                }
                catch (Exception ex)
                {
                    Logger.LogError("Exception rendering incremented count: {0}, {1}", ex.Message, ex.StackTrace);
                }
            }

            private Canvas2DContext CanvasContext;

            protected BECanvasComponent CanvasReference;

            protected override async Task OnAfterRenderAsync(bool firstRender)
            {
                if (firstRender)
                {
                    var firstTemplate = new Template();
                    firstTemplate.Components = new List<ConditionalComponent>
                    {
                        new ConditionalComponent
                        {
                            Component = new ImageTemplate.Components.Rectangle()
                            {
                                Colour = System.Drawing.Color.Gold,
                                Height = 30,
                                Width = 20,
                                StartX = 5,
                                StartY = 7,
                            }
                        }
                    };
                    await firstTemplate.Render(CanvasReference);
                    CanvasContext = await CanvasReference.CreateCanvas2DAsync();
                    await CanvasContext.SetFillStyleAsync("green");

                    await CanvasContext.FillRectAsync(10, 100, 100, 100);

                    await CanvasContext.SetFontAsync("48px serif");
                    await CanvasContext.StrokeTextAsync("Hello Blazor!!!", 10, 100);
                }
            }

            new public void Dispose()
            {
                base.Dispose();
                if (CanvasContext != null)
                {
                    CanvasContext.Dispose();
                    CanvasContext = null;
                }
            }
        }
    }
}