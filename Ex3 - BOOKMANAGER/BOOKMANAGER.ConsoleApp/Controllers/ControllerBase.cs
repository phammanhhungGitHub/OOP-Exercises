using System;


namespace BOOKMANAGER.ConsoleApp.Controllers
{
    using Framework;
    public class ControllerBase
    {

        /// <summary>
        /// Gọi tới chức năng Render hoặc RenderToFile của View hoặc cả hai
        /// </summary>
        /// <param name="view"></param>
        /// <param name="path">đường dẫn file</param>
        /// <param name="both">xác định xem có thực hiện cả hai chức năng hay không</param>
        public virtual void Render<T>(ViewBase<T> view, string path = "", bool both = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                view.Render();
                return;
            }

            if (both)
            {
                view.Render();
                view.RenderToFile(path);
                return;
            }

            view.RenderToFile(path);
        }

        public virtual void Render(Message message) => Render(new MessageView(message));
        public virtual void Success(string text, string label = "SUCCESS")
            => Render(new Message() { Text = text, Label = label, Type = MessageType.Success });
        public virtual void Error(string text, string label = "ERROR")
            => Render(new Message() { Text = text, Label = label, Type = MessageType.Error });
        public virtual void Information(string text, string label = "INFORMATION")
            => Render(new Message() { Text = text, Label = label, Type = MessageType.Information });
        public virtual void Confirmation(string text, string route, string label = "CONFIRMATION")
            => Render(new Message() { Text = text, Label = label, Type = MessageType.Confirmation, BackRoute = route });
    }
}
