using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacrosProcessor.Common;

namespace MacrosProcessor.Core.Mapper
{
    public class FileNameMapper : BaseMapper, IBaseDirectory
    {
        private readonly string _filePattern;

        public FileNameMapper(string filePattern, string name)
            : this(filePattern, name, null)
        {
        }

        public FileNameMapper(string filePattern, string name, Func<string, string> filter)
            : base(name, filter)
        {
            _filePattern = filePattern;
        }

        protected override string Map()
        {
            var name = Directory.GetFiles(Path.Combine(BaseDirectory, ""), _filePattern).FirstOrDefault();
            if (name != null)
                return Path.GetFileName(name);
            throw new MapingException(string.Format("FileNameMapper {0} pattern not found",_filePattern));
        }

        public override object Clone()
        {
            return new FileNameMapper(_filePattern, Name, Filter);
        }

        public string BaseDirectory { get; set; }
    }
}
