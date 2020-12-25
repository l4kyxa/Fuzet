using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Füzet
{
   public class Elemek
    {
        private int sorSzam;
        public int SorSzam
        {
            get 
            {
                return sorSzam;
            }
            set
            {
                if (value>0)
                    sorSzam = value;
                else
                    throw new Exception("Hiba");
            } 
        }
        private string datum;
        public string Datum
        {
            get
            {
                return datum;
            }
            set
            {
                datum = value;
            }
        }

        private string tema;
        public string Tema
        {
            get 
            {
                return tema;
            }
            set
            {
                if (value != "")
                    tema = value;
                else
                    throw new Exception("Hiba");
            }
        }
        private string leiras;
        public string Leiras
        {
            get
            {
                return leiras; 
            }
            set
            {
                if (value != "")
                    leiras = value;
                else
                    throw new Exception("Hiba");
            }
        }
        private string megjegyzes;
        public string Megjegyzes
        {
            get
            {
                return megjegyzes;
            }
            set
            {
                if (value != "")
                    megjegyzes = value;
                else
                    throw new Exception("Hiba");
            }
        }
        //public Elemek(int sorszam, string datum, string tema, string leiras, string megjegyzes)
        //{
        //    this.SorSzam = sorSzam;
        //    this.Datum = datum;
        //    this.Tema = tema;
        //    this.Leiras = leiras;
        //    this.Megjegyzes = megjegyzes;

        //}
    }
}
