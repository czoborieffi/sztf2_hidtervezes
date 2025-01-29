using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ucydni_hidTervezes.Exeption {
    public class EgyezesKivetel : Exception {
        public EgyezesKivetel(string message):base(message) { }
    }
}
