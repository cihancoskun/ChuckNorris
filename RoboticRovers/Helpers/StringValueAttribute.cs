using System;

namespace RoboticRovers.Helpers
{
    /// <summary>Attribute class for storing String Values</summary>
    public class StringValueAttribute : Attribute
    {
        private string _value;

        /// <summary>Creates a new instance</summary> 
        public StringValueAttribute(string value)
        {
            _value = value;
        }

        /// <summary>Gets the value</summary> 
        public string Value
        {
            get { return _value; }
        }
    }
}