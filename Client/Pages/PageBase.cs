using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace ImageTemplateUI
{
    namespace Components
    {
        // BasePage is a class to build pages from, it includes injected logging and JSRuntime for interop
        public class PageBase : ComponentBase
        {
            [Inject]
            public ILogger<PageBase> Logger { get; set; }
            [Inject]
            public IJSRuntime JSRuntime { get; set; }
        }
    }
}