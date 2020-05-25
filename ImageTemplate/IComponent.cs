using System;

namespace ImageTemplate
{
    ///<summary> IComponent is a renderable, configurable component of an image template (and the subsequent image), such as a rectangle, circle or text element. </summary>
    public interface IComponent
    {
        // TODO: input JSON data here
        public void Configure();
    }
}
