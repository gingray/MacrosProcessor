using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacrosProcessor.Core.Mapper
{
    [Serializable]
    public class MapCollection : IEnumerable<BaseMapper>, IEqualityComparer<BaseMapper>, ICloneable
    {
        private readonly HashSet<BaseMapper> _collection;

        public MapCollection()
        {
            _collection = new HashSet<BaseMapper>((IEqualityComparer<BaseMapper>)this);
        }

        public IEnumerator<BaseMapper> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(BaseMapper item)
        {
            _collection.Add(item);
        }

        public bool Equals(BaseMapper x, BaseMapper y)
        {
            return x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(BaseMapper obj)
        {
            return 0;
        }

        public object Clone()
        {
            var clone = new MapCollection();
            foreach (var baseMapper in _collection)
            {
                clone.Add((BaseMapper)baseMapper.Clone());
            }
            return clone;
        }
    }
}
