using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using ImageTemplate.Operators;

namespace ImageTemplate
{
    public interface IConditionalComponent : ICondition, IComponent
    { }
    public interface ICondition
    {
        bool ShouldRender(IDictionary<string, object> props);
    }
    public partial class ConditionalComponent : IConditionalComponent
    {
        public IComponent Component;
        public ICondition Condition;
        public bool ShouldRender(IDictionary<string, object> props)
        {
            if (Condition != null)
            {
                return Condition.ShouldRender(props);
            }
            return true;
        }
        public async Task Render(IDictionary<string, object> props = null)
        {
            await Component.Render(props);
        }
        public async Task Render(Canvas2DContext context, IDictionary<string, object> props = null)
        {
            await Component.Render(context, props);
        }
    }
    public partial class Condition : ICondition
    {
        public PureCondition Pure;
        public IEnumerable<ICondition> NestedConditions;
        public GroupOperator NestedOperator;
        public Condition()
        {
        }
        public bool ShouldRender(IDictionary<string, object> props)
        {
            bool shouldRenderNested = true;
            Func<bool, ICondition, IDictionary<string, object>, bool> nestedCheck = (bool current, ICondition nested, IDictionary<string, object> props) => { return current; };
            if (NestedConditions != null)
            {
                (shouldRenderNested, nestedCheck) = NestedOperator.GetCheckFunction();
                foreach (var nestedCondition in NestedConditions)
                {
                    shouldRenderNested = nestedCheck(shouldRenderNested, nestedCondition, props);
                }
            }
            return nestedCheck(shouldRenderNested, Pure, props);
        }
        public class PureCondition : ICondition
        {
            public string Name;
            public string Value;
            public bool Not = false;
            public ConditionalOperator Operator;
            public bool ShouldRender(IDictionary<string, object> props)
            {
                var propVal = props.Where(prop => { return prop.Key == Name; }).Select(prop => { return prop.Value; }).FirstOrDefault();
                if (propVal == null)
                {
                    // The condition we need doesn't exist, we can't compare it to anything
                    return false;
                }
                return Not ^ Operator.Compare(Value, propVal);
            }
        }
    }

}