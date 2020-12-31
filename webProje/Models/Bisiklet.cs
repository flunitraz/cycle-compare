using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webProje.Models
{
    public class Bisiklet
    {
        [Key]
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Materyal { get; set; }
        public int JantCapi { get; set; }
        public int VitesSayisi { get; set; }
        public string KullanimAlani { get; set; }
        public string FrenTuru { get; set; }
        public string SuspansiyonTuru { get; set; }
    }
}
