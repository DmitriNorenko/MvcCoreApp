using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.Models.Db;

namespace MvcCoreApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IBlogRepository repo, ILogger<UsersController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var Users = await _repo.GetUsers();
            return View(Users);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(User newUser) 
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }
    }
}
