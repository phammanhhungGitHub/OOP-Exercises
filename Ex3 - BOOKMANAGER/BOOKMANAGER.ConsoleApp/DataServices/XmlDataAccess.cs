using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BOOKMANAGER.ConsoleApp.DataServices
{
    using Models;
    public class XmlDataAccess : IDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();
        private readonly string _path = Config.Instance.DataFile;
        public void Load()
        {
            if (!File.Exists(_path))
            {
                SaveChanges();
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Book));
            using (var reader = XmlReader.Create(_path))
            {
                Books = serializer.Deserialize(reader) as List<Book>;
            }
        }

        public void SaveChanges()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Book));
            using (var writer = XmlWriter.Create(_path))
            {
                serializer.Serialize(writer, Books);
            }
        }
    }
}
