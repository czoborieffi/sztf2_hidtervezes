using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ucydni_hidTervezes.Class {
    public class Folyo {
        string Nev { get; set; }
        double[] Szelesseg { get; set; } // azon a helyem hány méter hosszú hídra van szükség
        Hid[] Hidak { get; set; } // a folyóra megépített hidek vannak benne
        public int Hely;

        public Folyo(string nev, double[] szelesseg, Hid[] hidak, int hely) {
            Nev = nev;
            Szelesseg = szelesseg;
            Hidak = hidak;
            Hely = hely;

            Hidak = new Hid[hely];
            Szelesseg = new double[hely];
        }
        /*Legyen még egy hely tulajdonsága, amely megadja, hogy összesen hány helyen kell hidat építeni. Ez legyen a szélesség és hidak tömb hossza. */

        public static void BTS(int szint, ref Hid[] E, ref bool van, int[] M, Hid[,] R){
            int i = -1;
            while (!van && i < M[szint]) {
                i++;
                if (Ft(szint, R[szint, i].ToString())){// adott szinten i. hid alkalmas-e a szerepre
                    if (Fk(E, R[szint, i], szint)){// adott hid foglalt-e már

                        E[szint] = R[szint, i];

                        if (szint == (R.GetLength(0) - 1)) van = true;
                        else BTS(szint + 1, ref E, ref van, M, R);
                    }
                }

            }
        }
        public static bool Ft(int szint, string xHid) {

            return true;
        }

        public static bool Fk(Hid[] eredmenyek, Hid hid, int szint) {
            for (int i = 0; i < szint; i++)  // szint fontos, hogy csak eddig nézzük az eredményeket is
                if (eredmenyek[i].Hossz <= hid.Hossz)
                    return false;

            return true;
        }
    }
}
