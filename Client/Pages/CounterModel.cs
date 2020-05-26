using System;

namespace ImageTemplateUI
{
    namespace Components
    {
        public class CounterModel
        {
            public int Count { get; set; }
            public CounterModel(int startCount = 0)
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