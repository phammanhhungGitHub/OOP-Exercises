using System;
using System.Text;

namespace BOOKMANAGER.ConsoleApp
{
    using DataServices;
    using Controllers;
    using Framework;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string text = Config.Instance.PromtText;
            ConsoleColor color = Config.Instance.PromtColor;

            ConfigRouter();

            while (true)
            {
                ViewHelp.Write(text, color);
                string request = Console.ReadLine();

                try
                {
                    Router.Instance.Forward(request);
                }
                catch (Exception e)
                {
                    ViewHelp.WriteLine(e.Message, ConsoleColor.Red);
                }
                finally
                {
                    Console.WriteLine();
                }

                if (request.ToLower() == "quit")
                    break;
            }
        }

        private static void ConfigRouter()
        {
            IDataAccess context = Config.Instance.IDataAccess;
            BookController controller = new BookController(context);
            ShellController shell = new ShellController(context);
            ConfigController config = new ConfigController();

            Router.Instance.Register("about", About);
            Router.Instance.Register("help", Help);
            Router.Instance.Register
                (
                route: "create",
                action: p => controller.Create(),
                help: "[create] : bắt đầu nhập sách mới"
                );
            Router.Instance.Register
                (
                route: "do create",
                action: p => controller.Create(ToBook(p)),
                help: "[do create] : this route should only be used code"
                );
            Router.Instance.Register
                (
                route: "update",
                action: p => controller.Update(Int32.Parse(p["id"])),
                help: "[update ? id = <value>] : tìm và cập nhật sách theo id"
                );
            Router.Instance.Register
                (
                route: "do update",
                action: p => controller.Update(Int32.Parse(p["id"]), ToBook(p)),
                help: "[do update] : this route should only be used code"
                );
            Router.Instance.Register
                (
                route: "list",
                action: p => controller.List(),
                help: "[list] : hiển thị tất cả sách"
                );
            Router.Instance.Register
                (
                route: "single",
                action: p => controller.Single(Int32.Parse(p["id"])),
                help: "[single ? id = <value>] : hiển thị thông tin 1 cuốn sách theo id"
                );
            Router.Instance.Register
                (
                route: "single file",
                action: p => controller.Single(Int32.Parse(p["id"]), p["path"]),
                help: "[single file ? id = <value> & path = <value>] : hiển thị thông tin 1 cuốn sách theo id, xuất thông tin ra file theo đường dẫn path"
                );
            Router.Instance.Register
                (
                route: "list file",
                action: p => controller.List(p["path"]),
                help: "[list file ? path = <value>] : xuất thông tin các cuốn sách ra file theo đường dẫn path"
                );
            Router.Instance.Register
                (
                route: "delete",
                action: p => controller.Delete(Int32.Parse(p["id"])),
                help: "[delete ? id = <value>] : xóa sách theo id"
                );
            Router.Instance.Register
                (
                route: "do delete",
                action: p => controller.Delete(Int32.Parse(p["id"]), true),
                help: "[do delete] : this route should ony be used in code"
                );
            Router.Instance.Register
                (
                route: "filter",
                action: p => controller.Filter(p["key"]),
                help: "[filter ? key = <value>] : lọc sách theo key"
                );
            Router.Instance.Register
                (
                route: "add shell",
                action: p => shell.Shell(p["path"], p["format"]),
                help: "[add shell ? path = <value>] : thêm các sách trong thư mục theo đường dẫn"
                );
            Router.Instance.Register
                (
                route: "read",
                action: p => shell.Read(Int32.Parse(p["id"])),
                help: "[read ? id = <value>] : đọc sách theo id"
                );
            Router.Instance.Register
                (
                route: "mark",
                action: p => controller.Mark(Int32.Parse(p["id"])),
                help: "[mark ? id = <value>] : đánh dấu sách đang đọc theo id"
                );
            Router.Instance.Register
                (
                route: "unmark",
                action: p => controller.Mark(Int32.Parse(p["id"]), false),
                help: "[unmark ? id = <value>] : bỏ đánh dấu sách đang đọc theo id"
                );
            Router.Instance.Register
                (
                route: "show mark",
                action: p => controller.ShowMarks(),
                help: "[show mark] : hiển thị danh sách các cuốn sách đang đọc"
                );
            Router.Instance.Register
                (
                route: "clear",
                action: p => controller.Clear(),
                help: "[clear] : xóa toàn bộ sách"
                );
            Router.Instance.Register
                (
                route: "do clear",
                action: p => controller.Clear(true),
                help: "[do clear] : this route should only be used in code"
                );
            Router.Instance.Register
                (
                route: "save",
                action: p => shell.Save(),
                help: "[save] : lưu thay đổi"
                );
            Router.Instance.Register
                (
                route: "show stats by folder",
                action: p => controller.StatsByFolder(),
                help: "[show stats by folder] : thống kê sách theo thư mục"
                );
            Router.Instance.Register
                (
                route: "config promt text",
                action: p => config.ConfigPromtText(p["text"]),
                help: "[config promt text ? text = <value>]"
                );
            Router.Instance.Register
                (
                route: "config promt color",
                action: p => config.ConfigPromtColor(p["color"]),
                help: "[config promt color ? color = <value>]"
                );
            Router.Instance.Register
                (
                route: "current data access",
                action: p => config.CurrentDataAccess(),
                help: "[current data access]"
                );
            Router.Instance.Register
                (
                route: "config data access",
                action: p => config.ConfigDataAccess(p["da"], p["file"]),
                help: "[config data access ? da = <value: json, xml, binary> & file = <value>]"
                );

            #region Helper
            Models.Book ToBook(Parameter p)
            {
                Models.Book b = new Models.Book();
                if (p.IsContain("id")) b.Id = Int32.Parse(p["id"]);
                if (p.IsContain("title")) b.Title = p["title"];
                if (p.IsContain("authors")) b.Authors = p["authors"];
                if (p.IsContain("publisher")) b.Publisher = p["publisher"];
                if (p.IsContain("year")) b.Year = Int32.Parse(p["year"]);
                if (p.IsContain("edition")) b.Edition = Int32.Parse(p["edition"]);
                if (p.IsContain("isbn")) b.Isbn = p["isbn"];
                if (p.IsContain("tags")) b.Tags = p["tags"];
                if (p.IsContain("description")) b.Description = p["description"];
                if (p.IsContain("rate")) b.Rating = Int32.Parse(p["rate"]);
                if (p.IsContain("reading")) b.Reading = p["reading"].ToBool();
                if (p.IsContain("file")) b.File = p["file"];
                return b;
            }
            #endregion
        }

        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("BOOK MANAGER VERSION 1.0", ConsoleColor.Green);
        }

        private static void Help(Parameter parameter)
        {
            if (parameter == null)
            {
                ViewHelp.WriteLine("SUPPORTED COMMANDS : ", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("type: help ? cmd = <command> to get command details");
                return;
            }

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}
