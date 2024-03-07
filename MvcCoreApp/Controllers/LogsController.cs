using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.Models.Db;

namespace MvcCoreApp.Controllers
{
    public class LogsController: Controller
    {
        public readonly IRequestRepository _request;
        public readonly ILogger<LogsController> _logger;
        public LogsController(IRequestRepository request, ILogger<LogsController> logger)
        {
            _request = request;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var requests = await _request.ShowLog();
            return View(requests);
        }
    }
}
