using System;
using System.Collections.Generic;
using System.Linq;
using ImageTemplate.Operators;

namespace ImageTemplate
{
    public interface ICondition
    {
        bool ShouldRender(IDictionary<string, object> props);
    }
    public partial class ConditionalComponent
    {
        public IComponent Component;
        ICondition Condition;
    }
    public partial class Condition : ICondition
    {
        public string Name;
        public bool Not;
        public ConditionalOperator Operator;
        public IEnumerable<ICondition> NestedConditions;
        public GroupOperator NestedOperator;
        public Condition()
        {
        }
        public bool ShouldRender(IDictionary<string, object> props)
        {
            bool shouldRenderNested = true;
            if (NestedConditions != null)
            {
                Func<bool, ICondition, IDictionary<string, object>, bool> nestedCheck;
                (shouldRenderNested, nestedCheck) = NestedOperator.GetCheckFunction();
                foreach (var nestedCondition in NestedConditions)
                {
                    shouldRenderNested = nestedCheck(shouldRenderNested, nestedCondition, props);
                }
            }
            //FIXME: not implemented
            return true;
        }
    }

}