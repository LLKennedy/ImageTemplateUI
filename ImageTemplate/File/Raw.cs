using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
namespace ImageTemplate.File
{
    ///<summary>Raw structure for JSON data - ALL bottom-level values are strings because they need to be replacable with variables</summary>
    namespace Raw
    {
        ///<summary>Overarching file structure for image template files</summary>
        public class TopLevel
        {
            ///<summary>The base content of the template</summary>
            public BaseImage baseImage;
            ///<summary>The components of the template with conditional logic</summary>
            public IEnumerable<ConditionalComponent> components; // Raw JSON
        }
        ///<summary>The background content for the image template</summary>
        public class BaseImage
        {
            ///<summary>The name of an image file to load</summary>
            public String fileName;
            ///<summary>Raw image data to render</summary>
            public String data;
            ///<summary>A base colour to fill the specified width and height with</summary>
            public RGBA baseColour;
            ///<summary>A width to scale the specified image to, or to fill the base colour for</summary>
            public String width;
            ///<summary>A height to scale the specified image to, or to fill the base colour for</summary>
            public String height;
            ///<summary>The pixels per inch at which to render the image</summary>
            public String ppi;
        }
        ///<summary>RGBA values in JSON</summary>
        public class RGBA
        {
            ///<summary>A raw RGBA component</summary>
            public String R, G, B, A;
        }
        ///<summary>A partially parsed component with conditional logic</summary>
        public class ConditionalComponent
        {
            ///<summary>The type ID of the component, must match to a registered component type</summary>
            public String type;
            ///<summary>The conditional logic for rendering this component</summary>
            public ConditionLogic conditional;
            ///<summary>The unparsed component properties</summary>
            public String properties;
        }
        ///<summary>The logic for a conditional</summary>
        public class ConditionLogic
        {
            ///<summary>The variable name to use for conditional processing</summary>
            public String name;
            ///<summary>Whether to negate the result of this condition</summary>
            public bool boolNot;
            ///<summary>The operator to use for comparison of the variable to the specified value</summary>
            public String conditionalOperator;
            ///<summary>The value to compare with the specified variable</summary>
            public String value;
            ///<summary>A nested group of further conditions</summary>
            public ConditionalGroup group;
        }
        ///<summary>A group of nested conditionals</summary>
        public class ConditionalGroup
        {
            ///<summary>The operator for the conditional group (and, or, nand, nor, xor)</summary>
            public String groupOperator;
            ///<summary>The list of conditions</summary>
            public IEnumerable<ConditionLogic> conditionals;
        }
    }
}