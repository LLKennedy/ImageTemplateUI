using System.Collections.Generic;
using System.Linq;

namespace ImageTemplate
{
    public interface ICondition
    {
        bool ShouldRender(IDictionary<string, object> props);
    }
    public class ConditionalComponent
    {
        public IComponent Component;
        public IEnumerable<ICondition> conditions;
    }
    public class Condition : ICondition
    {
        public enum ConditionalOperator
        {
            Unknown,
            Equals,
            Contains,
            StartsWith,
            EndsWidth,
            CaseInsensitiveEquals,
            CaseInsenstiveContains,
            CaseInsensitiveStartsWith,
            CaseInsensitiveEndsWith,
            NumericEquals,
            LessThan,
            GreaterThan,
            LessOrEqual,
            GreaterOrEqual,
        }
        public static ConditionalOperator StringToOperator(string operatorString)
        {
            switch (operatorString)
            {
                case "equals":
                    return ConditionalOperator.Equals;
                case "contains":
                    return ConditionalOperator.Contains;
                case "startswith":
                    return ConditionalOperator.StartsWith;
                case "endswith":
                    return ConditionalOperator.EndsWidth;
                case "ci_equals":
                    return ConditionalOperator.CaseInsensitiveEquals;
                case "ci_contains":
                    return ConditionalOperator.CaseInsenstiveContains;
                case "ci_startswith":
                    return ConditionalOperator.CaseInsensitiveStartsWith;
                case "ci_endswith":
                    return ConditionalOperator.CaseInsensitiveEndsWith;
                case "numequals":
                    return ConditionalOperator.NumericEquals;
                case "lessthan":
                    return ConditionalOperator.LessThan;
                case "greaterthan":
                    return ConditionalOperator.GreaterThan;
                case "lessorequal":
                    return ConditionalOperator.LessOrEqual;
                case "greaterorequal":
                    return ConditionalOperator.GreaterOrEqual;
                default:
                    return ConditionalOperator.Unknown;
            }
        }
        public string Name;
        public bool Not;
        public ConditionalOperator Operator;
        public Condition()
        {
        }
        public bool ShouldRender(IDictionary<string, object> props)
        {
            //FIXME: not implemented
            return true;
        }
    }

}