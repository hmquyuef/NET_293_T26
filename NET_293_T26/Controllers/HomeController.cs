using Microsoft.AspNetCore.Mvc;
using NET_293_T26.Models;
using NET_293_T26.Models.Entities;
using System.Diagnostics;

namespace NET_293_T26.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ToDoTasksContext _context;

        public HomeController(ILogger<HomeController> logger, ToDoTasksContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var rows = _context.ToDoTasks.ToList();
            return View(rows);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
