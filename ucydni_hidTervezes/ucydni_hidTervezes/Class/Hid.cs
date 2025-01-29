using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ucydni_hidTervezes.Class {
    public class Hid {
        public string Nev { get;  set; }
        public double Hossz { get;  set; }
        public double KoltsegMillio { get; set; }
        public Hid(string nev, double hossz, double koltsegMillio) {
            Nev = nev;
            Hossz = hossz;
            KoltsegMillio = koltsegMillio;
        }
        public override string ToString() {
            return Nev + ":\n- Hossz: " + Hossz.ToString().Replace(',','.') + "m \n- Ár: " + KoltsegMillio.ToString().Replace(',', '.') + "M Ft";
        }
    }
}