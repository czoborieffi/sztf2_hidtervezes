using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ucydni_hidTervezes.Exeption {
    internal class NegativHidhosszKivetel:System.Exception {
        public NegativHidhosszKivetel(string message):base(message) { }
    }
}
