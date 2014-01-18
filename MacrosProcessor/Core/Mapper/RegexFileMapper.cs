using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MacrosProcessor.Common;

namespace MacrosProcessor.Core.Mapper
{
    [Serializable]
    public class RegexFileMapper : BaseMapper,IBaseDirectory
    {
        private readonly string _filename;
        private Regex _regex;


        public RegexFileMapper(string regexPattern, string filename, string name)
            : this(regexPattern, filename, name, null)
        {
        }

        public RegexFileMapper(string regexPattern, string filename, string name, Func<string, string> filter)
            : base(name, filter)
        {
            _regex = new Regex(regexPattern);
            _filename = filename;
        }

        protected override string Map()
        {
            var content = File.ReadAllText(Path.Combine(BaseDirectory, _filename));
            var match = _regex.Match(content);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            throw new MapingException(string.Format("Name: {0} Regex : {1} doesn't match filename {2}", Name, _regex, _filename));
        }

        public string BaseDirectory { get; set; }
    }
}
