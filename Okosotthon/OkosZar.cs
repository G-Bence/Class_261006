using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz, IHangjelzo, IStatisztika
    {
        public bool ZartE { get; private set; }
        private string pinKod;
        public bool OnlineE { get; private set; }

        private int nyitasokSzama;
        private int rosszPinkodokSzama;

        public OkosZar(string azonosito, string nev, string pinKod)
            : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.ZartE = true;
            this.OnlineE = false;
        }


        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == "ZARAS")
            {
                this.ZartE = true;  
            }
            else if (parancs != null && parancs.StartsWith("NYITAS:"))
            {
                string megadottPin = parancs.Substring("NYITAS:".Length);
                if (megadottPin == this.pinKod)
                {
                    this.ZartE = false;
                    this.nyitasokSzama++;
                    rosszPinkodokSzama = 0;
                }
                else if (megadottPin != this.pinKod && rosszPinkodokSzama < 3)
                {
                    Console.WriteLine("Hibás PIN kód! A zár nem nyílt ki.");
                    rosszPinkodokSzama++;
                }
                else if (rosszPinkodokSzama >= 3)
                {
                    this.VeszjelzesInditasa();
                    rosszPinkodokSzama++;
                }
            }
        }


        public override string AllapotJelentes()
        {
            return this.ZartE ? "A zár ZÁRVA van." : "A zár NYITVA van.";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.pinKod = "0000";
            this.ZartE = true;
        }

        public void Csipog(int hosszu)
        {
            Console.WriteLine($"*Csipogás {hosszu} másodpercig*");
        }

        public void VeszjelzesInditasa()
        {
            Console.WriteLine("*Vészjelzés indítása*");
        }

        public string StatisztikatKeszit()
        {
            return $"Nyitások száma: {this.nyitasokSzama}, Rossz PIN kódok száma: {this.rosszPinkodokSzama}";
        }
    }
}
