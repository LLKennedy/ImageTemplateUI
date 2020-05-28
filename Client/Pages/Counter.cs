using System;
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
                var builder = new Builder();
                using(var rendered = builder.Render(null))
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
        }
    }
}