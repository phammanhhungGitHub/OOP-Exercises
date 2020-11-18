using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BOOKMANAGER.ConsoleApp.DataServices
{
    using Models;
    public class JsonDataAccess : IDataAccess
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

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader stream = new StreamReader(_path))
            {
                using (JsonReader jReader = new JsonTextReader(stream))
                {
                    Books = serializer.Deserialize<List<Book>>(jReader);
                }
            }
        }

        public void SaveChanges()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter stream = new StreamWriter(_path))
            {
                using (JsonWriter jWriter = new JsonTextWriter(stream))
                {
                    serializer.Serialize(jWriter, Books);
                }
            }
        }
    }
}
