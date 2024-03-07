using MvcCoreApp.Models.Db;
using static System.Net.Mime.MediaTypeNames;

namespace CoreStartApp.MiddleWare
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IBlogRepository _blogRepository;

        public LoggingMiddleware(RequestDelegate next, IBlogRepository blogRepository)
        {
            _next = next;
            _blogRepository = blogRepository;
        }

        public void ShowLog(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }
        public async void SaveLogInTxt(HttpContext context)
        {
            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "LogInfo.txt");
            string LogValue = $"{context.Request.Host.Value + context.Request.Path}\n";
            await File.AppendAllTextAsync(pathFile, LogValue);
        }
        public async Task InvokeAsync(HttpContext context)
        {
           
            ShowLog(context);
            SaveLogInTxt(context);
            await _next.Invoke(context);
        }
    }
}
