using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult greek() => View();
        public IActionResult egypt() => View();

        public IActionResult nordik() => View();

        public IActionResult chat() => View();
        public IActionResult contact() => View();



    }
}