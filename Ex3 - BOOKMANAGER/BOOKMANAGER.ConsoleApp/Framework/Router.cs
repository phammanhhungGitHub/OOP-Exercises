using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKMANAGER.ConsoleApp.Framework
{
    using RoutingTable = Dictionary<string, ControllerAction>;

    public delegate void ControllerAction(Parameter parameter = null);
    
    /// <summary>
    /// Lớp cho phép ánh xạ truy vấn với phương thức
    /// </summary>
    public class Router
    {
        private RoutingTable _routingTable;
        private Dictionary<string, string> _helpTable;

        // Áp dụng Singleton Design Pattern
        private static Router _instance;
        private Router()
        {
            _routingTable = new RoutingTable();
            _helpTable = new Dictionary<string, string>();
        }
        public static Router Instance => _instance ?? (_instance = new Router());


        /// <summary>
        /// Lấy ra danh sách các route trong danh sách
        /// </summary>
        /// <returns></returns>
        public string GetRoutes()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in _routingTable.Keys)
            {
                sb.AppendFormat("{0}, ", key);
            }
            return sb.ToString();
        }


        /// <summary>
        /// Lấy ra thông tin về key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetHelp(string key)
        {
            if (_helpTable.ContainsKey(key))
                return _helpTable[key];
            else
                return "Documentation not ready yet!";
        }


        /// <summary>
        /// Đăng kí 1 route mới, ánh xạ 1 chuỗi truy vấn với 1 phương thức
        /// </summary>
        /// <param name="route"></param>
        /// <param name="action"></param>
        /// <param name="help"></param>
        public void Register(string route, ControllerAction action, string help = "")
        {
            // nếu _routingTable đã chứa route này thì bỏ qua
            if (!_routingTable.ContainsKey(route))
            {
                _routingTable[route] = action;
                _helpTable[route] = help;
            }
        }


        /// <summary>
        /// Phân tích chuỗi truy vấn và gọi phương thức tương ứng với chuỗi truy vấn đó
        /// </summary>
        /// <param name="request"></param>
        public void Forward(string request)
        {
            Request req = new Request(request);
            if (!_routingTable.ContainsKey(req.Route))
            {
                throw new Exception("Command not found");
            }

            if (req.Parameter == null)
                _routingTable[req.Route]?.Invoke();
            else
                _routingTable[req.Route]?.Invoke(req.Parameter);
        }
        /// <summary>
        /// Lớp xử lý truy vấn
        /// </summary>
        private class Request
        {
            /// <summary>
            /// Thành phần lệnh của truy vấn
            /// </summary>
            public string Route { get; private set; }

            /// <summary>
            /// Thành phần tham số của truy vấn
            /// </summary>
            public Parameter Parameter { get; private set; }

            public Request(string request)
            {
                Analyze(request);
            }


            /// <summary>
            /// Phân tích truy vấn ra thành phần lệnh và tham số
            /// </summary>
            /// <param name="request">truy vấn cần phân tích</param>
            private void Analyze(string request)
            {
                // tìm xem trong truy vấn có phần tham số không
                int firstIndex = request.IndexOf('?');
                // nếu không có phần tham số
                if (firstIndex < 0)
                {
                    Route = request.ToLower().Trim();
                    return;
                }
                else // nếu có phần tham số
                {
                    // kiểm tra chuỗi lỗi (chỉ chứa tham số, không chứ lệnh)
                    if (firstIndex <= 1) throw new Exception("Invalid request paramter");

                    // cắt chuỗi truy vấn lấy mốc ?
                    // kết quả là mảng 2 phần tử gồm phần route và phần parameter
                    string[] tokens = request.Split(new[] { '?'}, 2, StringSplitOptions.RemoveEmptyEntries);
                    Route = tokens[0].ToLower().Trim();
                    string parameterPart = tokens[1].Trim();
                    Parameter = new Parameter(parameterPart);
                }    
            }
        }
    }
}
