using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webProje.Models
{
    public class KullaniciFavori
    {
        [Key]
        public int FavId { get; set; }
        public string KullaniciId { get; set; }
        public int BisikletId { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string KullanimAlani { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual Microsoft.AspNetCore.Identity.IdentityUser Id { get; set; }

        [ForeignKey("BisikletId")]
        public virtual Bisiklet ID { get; set; }
    }
}
