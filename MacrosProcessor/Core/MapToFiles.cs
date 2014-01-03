using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MacrosProcessor.Common;
using MacrosProcessor.Core.Mapper;

namespace MacrosProcessor.Core
{
    public class MapToFiles
    {
        private readonly string _template;
        private readonly string _folder;
        private string _workFolder;
        private readonly MapCollection _mapCollection;
        public event EventHandler<MapFileArgs> FileMaping;

        protected virtual void OnFileMaping(MapFileArgs e)
        {
            EventHandler<MapFileArgs> handler = FileMaping;
            if (handler != null) handler(this, e);
        }

        public MapToFiles(string template,string folder,MapCollection mapCollection)
        {
            _template = template;
            _folder = folder;
            _mapCollection = mapCollection;
        }

        public void Process()
        {
            var folders = Directory.GetDirectories(_folder);
            string originalFolder = Directory.GetCurrentDirectory();
            foreach (var folder in folders)
            {
                _workFolder = Path.Combine(originalFolder, folder);
                var clonedCollection = (MapCollection)_mapCollection.Clone();
                PreProcessMapCollection(clonedCollection);
                var template = new Template(_template, clonedCollection);
                var result = template.Process();
                OnFileMaping(new MapFileArgs(result, _workFolder));
            }
        }

        private void PreProcessMapCollection(IEnumerable<BaseMapper> mapCollection)
        {
            foreach (var baseDir in mapCollection.OfType<IBaseDirectory>())
            {
                baseDir.BaseDirectory = _workFolder;
            }
        }
    }

    public class MapFileArgs : EventArgs
    {
        public string MapResult { get; private set; }
        public string Folder { get; private set; }

        public MapFileArgs(string mapResult,string folder)
        {
            MapResult = mapResult;
            Folder = folder;
        }
    }
}
