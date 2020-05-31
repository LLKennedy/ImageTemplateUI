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
        public string GetVariableString(String raw)
        {
            if (raw.StartsWith("$") && raw.EndsWith("$") && raw.Length > 2)
            {
                return raw.Substring(1, raw.Length - 2);
            }
            return null;
        }
        public void ParseRawRGBA(RGBA raw, Action<Color> setColour)
        {
            string varR = GetVariableString(raw.R);
            string varG = GetVariableString(raw.G);
            string varB = GetVariableString(raw.B);
            string varA = GetVariableString(raw.A);
            Dictionary<string, string> rgbaVars = new Dictionary<string, string> { };
            if (varR != null)
            {
                rgbaVars.Add("R", varR);
            }
            if (varG != null)
            {
                rgbaVars.Add("G", varG);
            }
            if (varB != null)
            {
                rgbaVars.Add("B", varB);
            }
            if (varA != null)
            {
                rgbaVars.Add("A", varA);
            }
            if (rgbaVars.Count == 0)
            {
                // No variables, we just parse the colour immediately
                setColour(raw.ToColour());
            }
            foreach ()
        }
    }
}
