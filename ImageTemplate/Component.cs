using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using ImageTemplate.File.Raw;

namespace ImageTemplate
{
    public interface IComponent
    {
        ///<summary>Add properties data from the unparsed JSON</summary>
        Task InjectJSON(string propertiesData);
        // Task Render(IDictionary<string, object> props = null); // TODO: work out a drawing interface for an in-progress SixLabors image to inject here, maybe just wrap both under one interface
        Task Render(Canvas2DContext context, IDictionary<string, object> props = null);
    }
    ///<summary></summary>
    public class BaseComponent
    {
        public IDictionary<string, object> NeededVariables = new Dictionary<string, object> { };
        public IList<Func<bool>> VariableSetChecks = new List<Func<bool>> { };
        public static string GetVariableString(String raw)
        {
            if (raw.StartsWith("$") && raw.EndsWith("$") && raw.Length > 2)
            {
                return raw.Substring(1, raw.Length - 2);
            }
            return null;
        }
        public void ParseDouble(String raw, Action<double> setReal)
        {
            string foundVar = GetVariableString(raw);
            if (foundVar == null)
            {
                // No variables, parse immediately
                setReal(double.Parse(raw));
                return;
            }
            NeededVariables.Add(foundVar, null);
            VariableSetChecks.Add(() =>
            {
                object propValue;
                if (!NeededVariables.TryGetValue(foundVar, out propValue) || propValue == null)
                {
                    // Needed value isn't set yet
                    return false;
                }
                switch (propValue)
                {
                    case string convertedObj:
                        setReal(double.Parse(convertedObj));
                        break;
                    case byte convertedObj:
                        setReal((double)convertedObj);
                        break;
                    case Int16 convertedObj:
                        setReal((double)convertedObj);
                        break;
                    case UInt16 convertedObj:
                        setReal((double)convertedObj);
                        break;
                    case int convertedObj:
                        setReal((double)convertedObj);
                        break;
                    case uint convertedObj:
                        setReal((double)convertedObj);
                        break;
                    case long convertedObj:
                        setReal((double)convertedObj);
                        break;
                    case ulong convertedObj:
                        setReal((double)convertedObj);
                        break;
                    case float convertedObj:
                        setReal((double)convertedObj);
                        break;
                    case double convertedObj:
                        setReal((double)convertedObj);
                        break;
                    default:
                        throw new Exception("Invalid object " + propValue + " of type " + propValue.GetType() + ", must be numeric or string");
                }
                return true;
            });
        }
        public void ParseRawString(String raw, Action<object> setReal)
        {
            string foundVar = GetVariableString(raw);
            if (foundVar == null)
            {
                // No variables, parse immediately
                setReal(raw);
                return;
            }
            NeededVariables.Add(foundVar, null);
            VariableSetChecks.Add(() =>
            {
                object propValue;
                if (!NeededVariables.TryGetValue(foundVar, out propValue) || propValue == null)
                {
                    // Needed value isn't set yet
                    return false;
                }
                setReal(propValue);
                return true;
            });
        }
        private const string rgbaR = "R";
        private const string rgbaG = "G";
        private const string rgbaB = "B";
        private const string rgbaA = "A";
        public void ParseRawRGBA(RGBA raw, Action<Color> setColour)
        {
            string varR = GetVariableString(raw.R);
            string varG = GetVariableString(raw.G);
            string varB = GetVariableString(raw.B);
            string varA = GetVariableString(raw.A);
            IDictionary<string, string> rgbaVars = new Dictionary<string, string> { };
            if (varR != null)
            {
                rgbaVars.Add(rgbaR, varR);
            }
            if (varG != null)
            {
                rgbaVars.Add(rgbaG, varG);
            }
            if (varB != null)
            {
                rgbaVars.Add(rgbaB, varB);
            }
            if (varA != null)
            {
                rgbaVars.Add(rgbaA, varA);
            }
            if (rgbaVars.Count == 0)
            {
                // No variables, we just parse the colour immediately
                setColour(raw.ToColour());
                return;
            }
            foreach (var rgbaVar in rgbaVars)
            {
                NeededVariables.Add(rgbaVar.Value, null);
            }
            VariableSetChecks.Add(() =>
            {
                foreach (var rgbaVar in rgbaVars)
                {
                    object propValue;
                    if (!NeededVariables.TryGetValue(rgbaVar.Value, out propValue) || propValue == null)
                    {
                        // Needed value isn't set yet
                        return false;
                    }
                }
                int R = varR == null ? int.Parse(rgbaVars[rgbaR]) : int.Parse(raw.R);
                int G = varG == null ? int.Parse(rgbaVars[rgbaG]) : int.Parse(raw.G);
                int B = varB == null ? int.Parse(rgbaVars[rgbaB]) : int.Parse(raw.B);
                int A = varA == null ? int.Parse(rgbaVars[rgbaA]) : int.Parse(raw.A);
                setColour(Color.FromArgb(A, R, G, B));
                return true;
            });
        }
    }
}
