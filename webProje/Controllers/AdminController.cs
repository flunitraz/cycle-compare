using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webProje.Data;
using webProje.Models;

namespace webProje.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext dbBisiklet;

        public AdminController(ApplicationDbContext context)
        {
            dbBisiklet = context;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.ToList();
            return View(bisikletListe);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult KullaniciListesi()
        {
            var kullanicilar = dbBisiklet.Users.ToList();
            return View(kullanicilar);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult RolTanimla()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RolTanimla([Bind("UserId", "RoleId")] IdentityUserRole<string> a)
        {
            dbBisiklet.Add(a);
            dbBisiklet.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Marka", "Model", "Materyal", "JantCapi", "VitesSayisi", "KullanimAlani", "FrenTuru", "SuspansiyonTuru")] Bisiklet a)
        {
            dbBisiklet.Add(a);
            dbBisiklet.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Bisiklet bis)
        {
            var dbBis = dbBisiklet.Bisikletler.Find(bis.ID);
            dbBisiklet.Bisikletler.Remove(dbBis);
            dbBisiklet.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
