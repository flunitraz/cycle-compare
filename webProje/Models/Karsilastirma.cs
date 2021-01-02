using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace webProje.Models
{
    public class Karsilastirma
    {

        [Key]
        public int KarsId { get; set; }
        public string KullaniciIp { get; set; }
        public int BisikletId { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Materyal { get; set; }
        public int JantCapi { get; set; }
        public int VitesSayisi { get; set; }
        public string KullanimAlani { get; set; }
        public string FrenTuru { get; set; }
        public string SuspansiyonTuru { get; set; }

        [ForeignKey("BisikletId")]
        public virtual Bisiklet ID { get; set; }
    }
}
