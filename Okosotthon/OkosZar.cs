using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar: OkosEszkoz
    {
        public bool ZartE { get; private set; }
        private string pinKod;
        public bool OnlineE { get; private set; }

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


    }
}
