using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gierunia
{
    class Karta
    {
        public string znak; // pik, kier, trefl, karo
        public string symbol; //
        public int wartosc; // 2-10 as warty 11
        public string img ="";

        public Karta(int z, int w)
        {
            switch (z)
            {
                case 0:
                    this.znak = "Pik";
                    this.img += "C";
                    break;
                case 1:
                    this.znak = "Kier";
                    this.img += "B";
                    break;
                case 2:
                    this.znak = "Trefl";
                    this.img += "A";
                    break;
                case 3:
                    this.znak = "Karo";
                    this.img += "D";
                    break;
                default:
                    this.znak = "Pik";
                    this.img = "UNKNOWN";
                    break;
            }

            switch (w)
            {
                case 13:
                    this.symbol = "K";
                    this.wartosc = 10;
                    break;
                case 12:
                    this.symbol = "Q";
                    this.wartosc = 10;
                    break;
                case 11:
                    this.symbol = "J";
                    this.wartosc = 10;
                    break;
                case 1:
                    this.symbol = "A";
                    this.wartosc = 11;
                    break;
                default:
                    this.symbol = w.ToString();
                    this.wartosc = w;
                    break;
            }

            if (w >= 10)
            {
                this.img += w.ToString();
            }
            else
            {
                this.img += "0"+w.ToString();
            }
            this.img += ".jpg";

           
        }

    }
}
