using System;

namespace ImageTemplateUI
{
    namespace Components
    {
        public class Counter
        {
            public int Count { get; set; }
            public Counter(int startCount = 0)
            {
                Count = startCount;
            }

            public void IncrementCount()
            {
                Count++;
            }
        }
    }
}