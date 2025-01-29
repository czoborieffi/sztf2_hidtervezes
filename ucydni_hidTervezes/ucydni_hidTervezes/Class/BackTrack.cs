using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ucydni_hidTervezes.Exeption;

namespace ucydni_hidTervezes.Class {
    public static class Backtrack {
        /*public static void BTS(int szint, ref string[] E, ref bool van, int[] M, string[,] R) {
            int i = -1;
            while (!van && i < M[szint]) {
                i++;
                if (Ft(szint, R[szint, i])) {// adott szinten i. hid alkalmas-e a szerepre
                    if (Fk(E, R[szint, i], szint)) {// adott hid foglalt-e már

                        E[szint] = R[szint, i];

                        if (szint == (R.GetLength(0) - 1))  van = true;
                        else BTS(szint + 1, ref E, ref van, M, R);
                    }
                }

            }
        }
        public static bool Ft(int szint, string xHid) {
           
            return true;
        }

        public static bool Fk(string[] eredmenyek, string hid, int szint) {
            for (int i = 0; i < szint; i++)  // szint fontos, hogy csak eddig nézzük az eredményeket is
                if (eredmenyek[i] == hid)
                    return false;

            return true;
        }*/

        public static Hid[] ListabolTomb(List<Hid> lista){
            Hid[] tomb = new Hid[lista.Count];

            for (int i = 0; i < lista.Count; i++)
                tomb[i] = lista[i];


            return tomb;
        }
    }
}
