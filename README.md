MacrosProcessor
===============

Библиотекта, которая помогает мапить данные из нескольких файлов в один на основе макро подстановок.

К примеру у тебя вот такая структура каталогов
test
|-- 1\title.txt
|-- 1\description.txt
|-- 1\image.txt
|-- 2\title.txt
|-- 2\description.txt
|-- 2\image.txt
|-- 3\title.txt
|-- 3\description.txt
|-- 3\image.txt

есть шаблон вида

{title}
{description}
{image}

<code>
namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapCollection = new MapCollection();
            var item = new FileMapper("title.txt", "title");
            mapCollection.Add(item);
            item = new FileMapper("description.txt", "description");
            mapCollection.Add(item);
            item = new FileMapper("image.txt", "image");
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
</code>

теперь в каждой директории будет создам файл result.txt где будет подставлен контент из указанных файлов.