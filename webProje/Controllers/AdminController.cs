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

        public AdminController(ApplicationDbContext context, RoleManager<IdentityRole> _roleManager)
        {
            dbBisiklet = context;
        }


        //       [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Bisiklet> bisikletListe = dbBisiklet.Bisikletler.ToList();
            return View(bisikletListe);
        }

        public IActionResult KullaniciListesi()
        {
            var kullanicilar = dbBisiklet.Users.ToList();
            return View(kullanicilar);
        }

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
    }
}
