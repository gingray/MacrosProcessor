using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacrosProcessor.Core.Mapper
{
    public abstract class BaseMapper : ICloneable
    {
        protected BaseMapper(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        private string _value;
        public string Value {
            get { return _value ?? (_value = Map()); }
        }
        protected abstract string Map();
        public abstract object Clone();
    }
}
