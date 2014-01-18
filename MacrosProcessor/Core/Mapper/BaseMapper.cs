using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacrosProcessor.Core.Mapper
{
    [Serializable]
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
            try
            {
                if (Filter != null)
                    return Filter(Map());
                return Map();
            }
            catch (MapingException)
            {
                if (OnMapFailed != null)
                {
                    var args = new MapFailedEventArgs();
                    OnMapFailed(this, args);
                    if (args.Supress && args.Result != null)
                    {
                        return args.Result;
                    }
                }
                throw;
            }

        }

        public event EventHandler<MapFailedEventArgs> OnMapFailed;

        protected virtual void OnOnMapFailed(MapFailedEventArgs e)
        {
            EventHandler<MapFailedEventArgs> handler = OnMapFailed;
            if (handler != null) handler(this, e);
        }

        public object Clone()
        {
            return Helper.Clone(this);
        }
    }

    public class MapFailedEventArgs : EventArgs
    {
        public string Result { get; set; }
        public bool Supress { get; set; }

        public MapFailedEventArgs()
        {
            Supress = false;
            Result = null;
        }
    }
}
