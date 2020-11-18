using System;


namespace BOOKMANAGER.ConsoleApp.Controllers
{
    using Framework;
    internal class ConfigController : ControllerBase
    {
        public void ConfigPromtText(string text)
        {
            Config.Instance.PromtText = text;
            Success("The command will change next time");
        }

        public void ConfigPromtColor(string color)
        {
            if (Enum.TryParse(color, out ConsoleColor color1))
            {
                Config.Instance.PromtColor = color1;
                Success("The command promt color will change next time");
            }
        }

        public void CurrentDataAccess()
        {
            Information($"Current data access engine : {Config.Instance.DataAccess}\nCurrent data file {Config.Instance.DataFile}");
            
        }

        public void ConfigDataAccess(string dataAccess, string dataFile)
        {
            Config.Instance.DataAccess = dataAccess;
            Config.Instance.DataFile = dataFile;
            Success("The changes will be available next time");
        }
    }
}
