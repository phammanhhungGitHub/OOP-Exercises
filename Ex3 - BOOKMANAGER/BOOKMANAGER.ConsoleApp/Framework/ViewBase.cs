using System;


namespace BOOKMANAGER.ConsoleApp.Framework
{
    /// <summary>
    /// Lớp cha của tất cả các lớp View
    /// </summary>
    public abstract class ViewBase
    {
        public ViewBase() { }

        /// <summary>
        /// Xuất thông tin model ra console
        /// </summary>
        public abstract void Render();
        
    }


    /// <summary>
    /// Lớp ViewBase sử dụng generic, kế thừa lớp ViewBase non-generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ViewBase<T> : ViewBase
    {
        protected T Model;
        public ViewBase(T model) => Model = model;



        /// <summary>
        /// Xuất thông tin model ra file theo đường dẫn
        /// </summary>
        /// <param name="path">đường dẫn file</param>
        public virtual void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving data to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            System.IO.File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done!");
        }
    }
}
