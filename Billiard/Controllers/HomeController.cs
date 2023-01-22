using Billiard.Data;
using Billiard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Billiard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            int userCount = _userManager.Users.Count();
            int tableCount = _context.BilliardTable.Count();
            int reservationsToBe = _context.Reservation.Where(r => r.ReservationTime >= DateTime.Today).Count();
            int reservationsPast = _context.Reservation.Where(r => r.ReservationTime < DateTime.Today).Count();
            ViewData["UserCount"] = userCount;
            ViewData["TableCount"] = tableCount;
            ViewData["ReservationsToBe"] = reservationsToBe;
            ViewData["ReservationsPast"] = reservationsPast;
            return View();
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