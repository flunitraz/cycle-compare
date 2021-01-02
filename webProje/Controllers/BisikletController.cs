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

            ViewModel viewModel = new ViewModel();
            ViewModel vm = viewModel;
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

            ViewModel viewModel = new ViewModel();
            ViewModel vm = viewModel;
            vm.BisikletVM = bisikletListe.ToList();
            return View(vm);
        }

        public IActionResult YolBisikletleri()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.Where(
                dbBisiklet => dbBisiklet.KullanimAlani.Contains("yol")).ToList();

            ViewModel viewModel = new ViewModel();
            ViewModel vm = viewModel;
            vm.BisikletVM = bisikletListe.ToList();

            return View(vm);
        }

        public IActionResult SehirBisikletleri()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.Where(
                dbBisiklet => dbBisiklet.KullanimAlani.Contains("sehir")).ToList();

            ViewModel viewModel = new ViewModel();
            ViewModel vm = viewModel;
            vm.BisikletVM = bisikletListe.ToList();

            return View(vm);
        }

        public IActionResult Favoriler()
        {
            var bisikletListe = dbBisiklet.KullaniciFavorileri.ToList();

            ViewModel viewModel = new ViewModel();
            ViewModel vm = viewModel;
            vm.KullaniciFavoriVM = bisikletListe.ToList();
            return View(vm);
        }
        public IActionResult Karsilastir()
        {
            var bisikletListe = dbBisiklet.Karsilastirmalar.ToList();
            ViewModel viewModel = new ViewModel();
            ViewModel vm = viewModel;
            vm.KarsilastirmaVM = bisikletListe.ToList();
            return View(vm);
        }
        public IActionResult KarsilastirmayaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KarsilastirmayaEkle([Bind("KullaniciIp", "BisikletId", "Marka", "Model", "Materyal", "JantCapi", "VitesSayisi", "KullanimAlani", "FrenTuru", "SuspansiyonTuru")] Karsilastirma a)
        {
            dbBisiklet.Add(a);
            dbBisiklet.SaveChanges();
            return RedirectToAction("Karsilastir");
        }

        public IActionResult FavorilereEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FavorilereEkle([Bind("KullaniciId", "BisikletId", "KullanimAlani", "Marka", "Model")] KullaniciFavori a)
        {
            dbBisiklet.Add(a);
            dbBisiklet.SaveChanges();
            return RedirectToAction("Favoriler");
        }

        public IActionResult FavoriCikar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FavoriCikar(KullaniciFavori fav)
        {
            var dbFav = dbBisiklet.KullaniciFavorileri.Find(fav.FavId);
            dbBisiklet.KullaniciFavorileri.Remove(dbFav);
            dbBisiklet.SaveChanges();
            return RedirectToAction("Favoriler");
        }

        public IActionResult KarsCikar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KarsCikar(Karsilastirma kars)
        {
            var dbKars = dbBisiklet.Karsilastirmalar.Find(kars.KarsId);
            dbBisiklet.Karsilastirmalar.Remove(dbKars);
            dbBisiklet.SaveChanges();
            return RedirectToAction("Karsilastir");
        }
    }
}
