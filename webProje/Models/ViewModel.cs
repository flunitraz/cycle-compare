using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webProje.Models
{
    public class ViewModel
    {
        public IEnumerable<Bisiklet> BisikletVM { get; set; }

        public IEnumerable<KullaniciFavori> KullaniciFavoriVM { get; set; }

        public IEnumerable<Karsilastirma> KarsilastirmaVM { get; set; }
    }
}
