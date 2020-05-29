using System;
using System.Collections.Generic;

namespace ImageTemplate
{
    public partial class Condition : ICondition
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
        public enum GroupOperator
        {
            Unknown,
            Or,
            And,
            Nor,
            Nand,
            Xor,
        }
    }
    namespace Operators
    {
        public static class Extensions
        {
            ///<summary>Converts a string to a conditional operator, or Unknown if the string is not a valid operator</summary>
            public static Condition.ConditionalOperator ToConditionalOperator(this string operatorString)
            {
                switch (operatorString)
                {
                    case "equals":
                        return Condition.ConditionalOperator.Equals;
                    case "contains":
                        return Condition.ConditionalOperator.Contains;
                    case "startswith":
                        return Condition.ConditionalOperator.StartsWith;
                    case "endswith":
                        return Condition.ConditionalOperator.EndsWidth;
                    case "ci_equals":
                        return Condition.ConditionalOperator.CaseInsensitiveEquals;
                    case "ci_contains":
                        return Condition.ConditionalOperator.CaseInsenstiveContains;
                    case "ci_startswith":
                        return Condition.ConditionalOperator.CaseInsensitiveStartsWith;
                    case "ci_endswith":
                        return Condition.ConditionalOperator.CaseInsensitiveEndsWith;
                    case "numequals":
                        return Condition.ConditionalOperator.NumericEquals;
                    case "lessthan":
                        return Condition.ConditionalOperator.LessThan;
                    case "greaterthan":
                        return Condition.ConditionalOperator.GreaterThan;
                    case "lessorequal":
                        return Condition.ConditionalOperator.LessOrEqual;
                    case "greaterorequal":
                        return Condition.ConditionalOperator.GreaterOrEqual;
                    default:
                        return Condition.ConditionalOperator.Unknown;
                }
            }
            ///<summary>Converts the operator to the string for a template file, must not be Unknown</summary>
            public static string ToTemplateString(this Condition.ConditionalOperator op)
            {
                switch (op)
                {
                    case Condition.ConditionalOperator.Equals:
                        return "equals";
                    case Condition.ConditionalOperator.Contains:
                        return "contains";
                    case Condition.ConditionalOperator.StartsWith:
                        return "startswith";
                    case Condition.ConditionalOperator.EndsWidth:
                        return "endswith";
                    case Condition.ConditionalOperator.CaseInsensitiveEquals:
                        return "ci_equals";
                    case Condition.ConditionalOperator.CaseInsenstiveContains:
                        return "ci_contains";
                    case Condition.ConditionalOperator.CaseInsensitiveStartsWith:
                        return "ci_startswith";
                    case Condition.ConditionalOperator.CaseInsensitiveEndsWith:
                        return "ci_endswith";
                    case Condition.ConditionalOperator.NumericEquals:
                        return "numequals";
                    case Condition.ConditionalOperator.LessThan:
                        return "lessthan";
                    case Condition.ConditionalOperator.GreaterThan:
                        return "greaterthan";
                    case Condition.ConditionalOperator.LessOrEqual:
                        return "lessorequal";
                    case Condition.ConditionalOperator.GreaterOrEqual:
                        return "greaterorequal";
                    default:
                        throw new Exception("Invalid operator " + op + ", cannot convert to string");
                }
            }
            ///<summary>Compares two values according to the operator's logic</summary>
            public static bool Compare(this Condition.ConditionalOperator op, string firstValue, object secondValue)
            {
                switch (op)
                {
                    default:
                        throw new Exception("Invalid operator " + op + ", cannot use for comparisons");
                }
            }
            ///<summary>Converts a string to a group operator, or Unknown if the string is not a valid operator</summary>
            public static Condition.GroupOperator ToGroupOperator(this string operatorString)
            {
                switch (operatorString)
                {
                    case "or":
                        return Condition.GroupOperator.Or;
                    case "and":
                        return Condition.GroupOperator.And;
                    case "nor":
                        return Condition.GroupOperator.Nor;
                    case "nand":
                        return Condition.GroupOperator.Nand;
                    case "xor":
                        return Condition.GroupOperator.Xor;
                    default:
                        return Condition.GroupOperator.Unknown;
                }
            }
            ///<summary>Converts the operator to the string for a template file, must not be Unknown</summary>
            public static string ToTemplateString(this Condition.GroupOperator op)
            {
                switch (op)
                {
                    case Condition.GroupOperator.Or:
                        return "or";
                    case Condition.GroupOperator.And:
                        return "and";
                    case Condition.GroupOperator.Nor:
                        return "nor";
                    case Condition.GroupOperator.Nand:
                        return "nand";
                    case Condition.GroupOperator.Xor:
                        return "xor";
                    default:
                        throw new Exception("Invalid operator " + op + ", cannot convert to string");
                }
            }
            ///<summary>Creates a function for building boolean chains from a group operator</summary>
            public static (bool, Func<bool, ICondition, IDictionary<string, object>, bool>) GetCheckFunction(this Condition.GroupOperator op)
            {
                switch (op)
                {
                    case Condition.GroupOperator.And:
                        return (true, (bool current, ICondition next, IDictionary<string, object> props) => { return current && next.ShouldRender(props); });
                    case Condition.GroupOperator.Or:
                        return (false, (bool current, ICondition next, IDictionary<string, object> props) => { return current || next.ShouldRender(props); });
                    case Condition.GroupOperator.Nand:
                        return (false, (bool current, ICondition next, IDictionary<string, object> props) => { return current || !next.ShouldRender(props); });
                    case Condition.GroupOperator.Nor:
                        return (true, (bool current, ICondition next, IDictionary<string, object> props) => { return current && !next.ShouldRender(props); });
                    case Condition.GroupOperator.Xor:
                        return (false, (bool current, ICondition next, IDictionary<string, object> props) => { return current ^ next.ShouldRender(props); });
                    default:
                        throw new Exception("Invalid operator " + op + ", cannot get check function");
                }
            }
        }
    }

}