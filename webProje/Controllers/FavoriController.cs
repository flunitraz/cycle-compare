using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webProje.Controllers
{
    public class FavoriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
