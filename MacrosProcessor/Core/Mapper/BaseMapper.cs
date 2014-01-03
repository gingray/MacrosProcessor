using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacrosProcessor.Core.Mapper
{
    public abstract class BaseMapper : ICloneable
    {
        protected BaseMapper(string name, Func<string, string> filter)
        {
            Name = name;
            Filter = filter;
        }

        public string Name { get; set; }
        private string _value;
        public Func<string, string> Filter;
        public string Value
        {
            get { return _value ?? (_value = GetValue()); }
        }
        protected abstract string Map();

        private string GetValue()
        {
            if (Filter != null)
                return Filter(Map());
            return Map();
        }
        public abstract object Clone();
    }
}
