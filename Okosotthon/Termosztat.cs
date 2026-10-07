using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        private double jelenlegiHomerseklet;
        private double celHomerseklet;
        private bool onlineE;

        public double JelenlegiHomerseklet { get => jelenlegiHomerseklet; set => jelenlegiHomerseklet = value; }
        public double CelHomerseklet { get => celHomerseklet; set => celHomerseklet = value; }
        public bool OnlineE { get => onlineE; set => onlineE = value; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            this.jelenlegiHomerseklet = 21.0;
            this.celHomerseklet = celHomerseklet;
            this.onlineE = false;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            const string parancsEleje = "BEALLIT_HOMERSEKLET:";

            if (parancs != null || parancs.StartsWith(parancsEleje))
            {
                string ertek = parancs.Substring(parancsEleje.Length);
                this.celHomerseklet = Convert.ToDouble(ertek);
            }
        }

        public override string AllapotJelentes()
        {
            return $"Jelenlegi hőmérséklet: {this.jelenlegiHomerseklet} °C, célhőmérséklet: {this.celHomerseklet} °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.celHomerseklet >= 5.0 && this.celHomerseklet <= 35.0;
        }

    }
}
