using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MacrosProcessor.Core.Mapper
{
    public class RegexMapper : BaseMapper
    {
        private readonly string _content;
        private Regex _regex;


        public RegexMapper(string regexPattern, string content, string name)
            : this(regexPattern, content, name, null)
        {
        }

        public RegexMapper(string regexPattern, string content, string name, Func<string, string> filter)
            : base(name, filter)
        {
            _regex = new Regex(regexPattern);
            _content = content;
        }

        protected override string Map()
        {
            var match = _regex.Match(_content);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            throw new MapingException(string.Format("Name: {0} Regex : {1} doesn't match content {2}", Name, _regex, _content));
        }

        public override object Clone()
        {
            return new RegexMapper(_regex.ToString(), _content, Name);
        }
    }
}
