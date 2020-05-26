using System;
using ImageTemplate;

namespace ImageTemplateUI
{
    namespace Components
    {
        public class Counter
        {
            public int Count { get; set; }
            public string ImageData { get; set; } = "";
            public Counter(int startCount = 0)
            {
                Count = startCount;
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