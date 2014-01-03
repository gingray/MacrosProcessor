using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MacrosProcessor.Core.Mapper
{
    [Serializable]
    public class MapingException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public MapingException()
        {
        }

        public MapingException(string message) : base(message)
        {
        }

        public MapingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MapingException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
