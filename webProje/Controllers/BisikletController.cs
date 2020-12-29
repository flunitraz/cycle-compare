using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webProje.Data;
using webProje.Models;

namespace webProje.Controllers
{
    public class BisikletController : Controller
    {
        private readonly ApplicationDbContext dbBisiklet;

        public BisikletController(ApplicationDbContext context)
        {
            dbBisiklet = context;
        }


        public IActionResult Index()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.ToList();
            return View(bisikletListe);
        }
    }
}
