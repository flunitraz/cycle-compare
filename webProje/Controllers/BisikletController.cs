using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        public IActionResult KadroBoyu()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Favoriler()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.ToList();
            return View(bisikletListe);
        }

        public IActionResult DagBisikletleri()
        {
            //IdentityUser kullanici;
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.Where(
                dbBisiklet => dbBisiklet.KullanimAlani.Contains("mtb")).ToList();
            return View(bisikletListe);
        }

        public IActionResult YolBisikletleri()
        {
            //IdentityUser kullanici;
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.Where(
                dbBisiklet => dbBisiklet.KullanimAlani.Contains("yol")).ToList();
            return View(bisikletListe);
        }

        public IActionResult SehirBisikletleri()
        {
            //IdentityUser kullanici;
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.Where(
                dbBisiklet => dbBisiklet.KullanimAlani.Contains("sehir")).ToList();
            return View(bisikletListe);
        }
    }
}
