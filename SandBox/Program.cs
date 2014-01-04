using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacrosProcessor.Core;
using MacrosProcessor.Core.Mapper;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapCollection = new MapCollection();
            BaseMapper item = new FileMapper("title.txt", "title");
            mapCollection.Add(item);
            item = new FileMapper("description.txt", "description");
            mapCollection.Add(item);
            item = new FileNameMapper("im*.txt", "image");
            mapCollection.Add(item);
            var action = new MapToFiles(File.ReadAllText("template.txt"), "test", mapCollection);
            action.FileMaping += ActionFileMaping;
            action.Process();
        }

        static void ActionFileMaping(object sender, MapFileArgs e)
        {
            File.WriteAllText(Path.Combine(e.Folder,"result.txt"), e.MapResult);
        }
    }
}
