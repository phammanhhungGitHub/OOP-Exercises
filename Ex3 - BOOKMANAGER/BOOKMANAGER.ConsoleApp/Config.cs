using System;


namespace BOOKMANAGER.ConsoleApp
{
    using DataServices;
    internal class Config
    {
        private static Config _instance;
        public static Config Instance = _instance ?? (_instance = new Config());
        private Config() { }

        private Properties.Settings _s = Properties.Settings.Default;
        public void Reload() => _s.Reload();
        public IDataAccess IDataAccess
        {
            get
            {
                switch (_s.DataAccess.ToLower())
                {
                    case "binary":
                        return new BinaryDataAccess();
                        
                    case "xml":
                        return new XmlDataAccess();
                        
                    case "json":
                        return new JsonDataAccess();
                        
                    default:
                        return new BinaryDataAccess();
                        
                }
            }
        }
        public string DataAccess
        {
            get => _s.DataAccess;
            set
            {
                _s.DataAccess = value;
                _s.Save();
            }
        }
        public string PromtText
        {
            get => _s.PromtText;
            set
            {
                _s.PromtText = value;
                _s.Save();
            }
        }
        public ConsoleColor PromtColor
        {
            get => _s.PromtColor;
            set
            {
                _s.PromtColor = value;
                _s.Save();
            }
        }
        public string DataFile
        {
            get => _s.DataFile;
            set
            {
                _s.DataFile = value;
                _s.Save();
            }
        }
    }
}
