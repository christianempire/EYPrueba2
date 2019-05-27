using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba2.Data;
using Prueba2.ViewModels;

namespace Prueba2.Controllers
{
    public class HomeController : Controller
    {
        private readonly SupermarketContext _context;

        public HomeController(SupermarketContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
                Items = await _context.Items.ToArrayAsync()
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
