﻿using System;
using System.Collections.Generic;


namespace BOOKMANAGER.ConsoleApp.DataServices
{
    using Models;
    public interface IDataAccess
    {
        List<Book> Books { get; set; }
        void Load();
        void SaveChanges();
    }
}
