using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ucydni_hidTervezes.Class;
using ucydni_hidTervezes.Exeption;

namespace ucydni_hidTervezes {
    public class Program {
        static void Main(string[] args) {
            //Hid h = new Hid();
            //h.Nev = "Teszt";
            //h.KoltsegMillio = 2.4;
            //h.Hossz = 16.31;
            //Console.WriteLine(h.ToString());

            Folyo f = new Folyo(
                "Maros", 
                new double[] { 10.1, 25, 13, 14 }, 
                null, 
                2)
            ;

            LancoltLista lancoltLista = new LancoltLista(f);

            Hid h1 = new Hid("Alma", 12, 1.1); //név, hossz, koltseg
            Hid h2 = new Hid("Eper", 14, 4.4);
            Hid h3 = new Hid("Körte", 28, 2.01);
            Hid h4 = new Hid("Barack", 24, 3.0);

            //Hid h5 = new Hid("CSeresznya", 11, 0.5);
            //Hid h6 = new Hid("Szilva", 13.5, 0.9);


            // azonos nev
            //Hid h5 = new Hid("h1", 5, 3);
            // negativ hossz
            //Hid h6 = new Hid("h6", -1, 3);

            try{
                lancoltLista.RendezettBeszuras(h1);
                lancoltLista.RendezettBeszuras(h2);
                lancoltLista.RendezettBeszuras(h3);
                lancoltLista.RendezettBeszuras(h4);
                // ERROR
                //lancoltLista.RendezettBeszuras(h5);
                //lancoltLista.RendezettBeszuras(h6);

                lancoltLista.BejarasKirat();
                
                Hid[] hidak = Backtrack.ListabolTomb(lancoltLista.BTSListaHid);
                bool van = false;

                //
                //Folyo.BTS(0, ref hidak, ref van, f.Hely,R);

                
            }
            catch (EgyezesKivetel e) { Console.WriteLine(e.Message); }
            catch (NegativHidhosszKivetel e) { Console.WriteLine(e.Message); }

            Console.WriteLine(f);
            Console.ReadLine();
        }
    }
}
