using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ucydni_hidTervezes.Exeption;

namespace ucydni_hidTervezes.Class {
    public delegate void HidMuveletek(object obj);
    public class LancoltLista {
        public event HidMuveletek Epites;
        public event HidMuveletek Bontas;
        // beszúrás hossz szerint rendezve
        private ListaElem fej;
        public List<Hid> BTSListaHid; // BTS miatt kiszedjuk az elemeket
        private Folyo _folyo;

        public class ListaElem {
            public Hid hid;
            //public double ar;
            public ListaElem kovetkezo;
        }

        public LancoltLista(Folyo folyo) {
            BTSListaHid = new List<Hid>(); // letrehozzuk a listat
        }
       
        public void RendezettBeszuras(Hid elem) {
            this.RendezettBeszuras(ref fej, elem.Hossz, elem);
        }
        private void RendezettBeszuras(ref ListaElem fej, double kulcs, Hid elem){
            
            ListaElem uj = new ListaElem();
            uj.hid = elem;
            uj.hid.Hossz = kulcs;

            if (fej == null){ uj.kovetkezo = null;fej = uj;}
            else {
                if (fej.hid.Hossz > kulcs){ uj.kovetkezo = fej; fej = uj;}
                else {
                    ListaElem p = fej;
                    ListaElem e = null;

                    while (p != null && p.hid.Hossz <= kulcs) {
                        if (uj.hid.Hossz <= 0)throw new Exeption.NegativHidhosszKivetel("[WARNING] - Negatív ívhossz");
                        if (uj.hid.Nev == p.hid.Nev)  throw new EgyezesKivetel("[WARNING] - Ilyen híd már van!");

                        e = p;
                        p = p.kovetkezo;
                    }

                    if (p == null){  uj.kovetkezo = null;  e.kovetkezo = uj;}
                    else { uj.kovetkezo = p; e.kovetkezo = uj;}
                }
            }
        }
        public void Torles (Hid hid) {
            ListaElem p = fej;
            ListaElem e = null; 
            while(!ListaElemNull(p) && !p.hid.Equals(hid)) {
                e = p;
                p = p.kovetkezo;
            }
            if (!ListaElemNull(p)) {
                if (ListaElemNull(e)) fej = p.kovetkezo; // megtaláltuk
                else e.kovetkezo = p.kovetkezo;
                p = null;
                Bontas?.Invoke(p);
            }
            else throw new Exeption.NemTalalhatoIlyenHid("[WARNING] - Nem található ilyen híd");
        }
        public ListaElem Kereses(string nev) {
            ListaElem p = fej;
            while(!ListaElemNull(p) && p.hid.Nev != nev) { p = p.kovetkezo;}
            bool van = false;
            if(!ListaElemNull(p) && p.hid.Nev == nev) van = true;
            if (van) return p;
            else {
                return null;
                throw new Exeption.NemTalalhatoIlyenHid("[WARNING] - Nem található ilyen híd");
            }
        }
        public void BejarasKirat() {
            ListaElem p = fej;
            while (p != null) {
                Console.WriteLine(p.hid.ToString());
                BTSListaHid.Add(p.hid);
                p = p.kovetkezo;
            }
        }
        private bool ListaElemNull(ListaElem elem) {
            if (elem == null) return true;
            else return false;
        }
    }
}