﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BOOKMANAGER.ConsoleApp.DataServices
{
    using Models;
    public class BinaryDataAccess : IDataAccess
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

            using (FileStream stream = File.OpenRead(_path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Books = formatter.Deserialize(stream) as List<Book>;
            }
        }


        public void SaveChanges()
        {
            using (FileStream stream = File.OpenWrite(_path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Books);
            }
        }

        
    }
}
