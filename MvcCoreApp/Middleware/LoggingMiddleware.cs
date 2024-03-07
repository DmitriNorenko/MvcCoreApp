using MvcCoreApp.Models.Db;
using static System.Net.Mime.MediaTypeNames;

namespace CoreStartApp.MiddleWare
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repository;

        public LoggingMiddleware(RequestDelegate next,IRequestRepository repository)
        {
            _next = next;
            _repository = repository;
        }

        public async void SaveLogInDb(HttpContext context)
        {
            string LogValue = $"{context.Request.Host.Value + context.Request.Path}";
            await _repository.AddLog(LogValue);
        }
        public async Task InvokeAsync(HttpContext context)
        {
            SaveLogInDb(context);
            await _next.Invoke(context);
        }
    }
}
