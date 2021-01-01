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

            ViewModel vm = new ViewModel();
            vm.BisikletVM = bisikletListe.ToList();

            return View(vm);
        }

        public IActionResult KadroBoyu()
        {
            return View();
        }

        public IActionResult DagBisikletleri()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.Where(
                dbBisiklet => dbBisiklet.KullanimAlani.Contains("mtb")).ToList();

            var favoriler = dbBisiklet.KullaniciFavorileri.ToList();

            ViewModel vm = new ViewModel();
            vm.BisikletVM = bisikletListe.ToList();
            return View(vm);
        }

        public IActionResult YolBisikletleri()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.Where(
                dbBisiklet => dbBisiklet.KullanimAlani.Contains("yol")).ToList();

            ViewModel vm = new ViewModel();
            vm.BisikletVM = bisikletListe.ToList();

            return View(vm);
        }

        public IActionResult SehirBisikletleri()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.Where(
                dbBisiklet => dbBisiklet.KullanimAlani.Contains("sehir")).ToList();

            ViewModel vm = new ViewModel();
            vm.BisikletVM = bisikletListe.ToList();

            return View(vm);
        }

        public IActionResult FavorilereEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FavorilereEkle([Bind("KullaniciId", "BisikletId")] KullaniciFavori a)
        {
            dbBisiklet.Add(a);
            dbBisiklet.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
