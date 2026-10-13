using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class OkosKozpontiRiaszto : OkosEszkoz, IIdozitheto, IHangjelzo, IStatisztika
    {
        private int risztasiIdo;
        private bool risztasInditva;

        public OkosKozpontiRiaszto(string azonosito, string nev, int risztasiIdo, bool risztasInditva) : base(azonosito, nev)
        {
            this.risztasiIdo = risztasiIdo;
            this.risztasInditva = risztasInditva;
        }

        public int RisztasiIdo { get => risztasiIdo; set => risztasiIdo = value; }
        public bool RisztasInditva { get => risztasInditva; set => risztasInditva = value; }


        public override void ParancsVegrehajtasa(string parancs)
        {
            if(parancs == "RIASZTAS_INDITASA")
            {
                this.risztasInditva = true;
            }
            else if (parancs == "RIASZTAS_LEALLITASA")
            {
                this.risztasInditva = false;
            }
        }
        public override string AllapotJelentes()
        {
            return this.risztasInditva ? "A riasztás aktív." : "A riasztás inaktív.";
        }
        protected override bool OnTesztFuttatasa()
        {
            return this.risztasiIdo > 0;
        }


        public void Csipog(int hosszu)
        {
            throw new NotImplementedException();
        }

        public int GetMaradtIdo()
        {
            throw new NotImplementedException();
        }

        public void IdozitestBeallit(int perc)
        {
            throw new NotImplementedException();
        }

        public string StatisztikatKeszit()
        {
            throw new NotImplementedException();
        }

        public void VeszjelzesInditasa()
        {
            throw new NotImplementedException();
        }
    }
}
