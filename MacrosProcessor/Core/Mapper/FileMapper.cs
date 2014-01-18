using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacrosProcessor.Common;

namespace MacrosProcessor.Core.Mapper
{
    [Serializable]
    public class FileMapper : BaseMapper, IBaseDirectory
    {
        private readonly string _filename;

        public FileMapper(string filename, string name)
            : this(filename, name, null)
        {
        }

        public FileMapper(string filename, string name, Func<string, string> filter)
            : base(name, filter)
        {
            _filename = filename;
            BaseDirectory = "";
        }

        protected override string Map()
        {
            string content = File.ReadAllText(Path.Combine(BaseDirectory, _filename));
            return content;
        }

        public string BaseDirectory { get; set; }
    }
}
