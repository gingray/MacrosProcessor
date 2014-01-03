using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacrosProcessor.Core.Mapper;

namespace MacrosProcessor.Core
{
    public class Template
    {
        private string _template;
        private readonly MapCollection _mapCollection;

        public Template(string template, MapCollection mapCollection)
        {
            _template = template;
            _mapCollection = mapCollection;
        }

        public string Process()
        {
            foreach (var map in _mapCollection)
            {
                string searchVal = string.Format("{{{0}}}", map.Name);
                _template = _template.Replace(searchVal, map.Value);
            }
            return _template;
        }
    }
}
