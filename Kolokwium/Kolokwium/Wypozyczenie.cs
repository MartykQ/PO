using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    [Serializable]
    class Wypozyczenie: ICloneable
    {
        public static int biezaceWypozyczenie = 100;
        private string numerWypozyczenia;
        private string nazwaKlienta;
        private Samochod wypozyczonySamochod;
        private DateTime dataWypozyczenia;
        private DateTime dataZwrotu;

        public string NumerWypozyczenia { get => numerWypozyczenia; set => numerWypozyczenia = value; }
        public string NazwaKlienta { get => nazwaKlienta; set => nazwaKlienta = value; }
        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }
        public DateTime DataZwrotu { get => dataZwrotu; set => dataZwrotu = value; }
        internal Samochod WypozyczonySamochod { get => wypozyczonySamochod; set => wypozyczonySamochod = value; }
        
        public Wypozyczenie(string nKl, Samochod wypSam, string dataStart, string dataKoniec)
        {
            numerWypozyczenia = biezaceWypozyczenie.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

            DateTime dS;
            DateTime dK;
            bool r = DateTime.TryParseExact(dataStart, new[] { "yyyy/MM/dd", "MM/dd/yy", "yyyy-MM-dd", "dd-MMM-yy" }, null, DateTimeStyles.None, out dS);
            if (r) dataWypozyczenia = dS;
            bool r2 = DateTime.TryParseExact(dataKoniec, new[] { "yyyy/MM/dd", "MM/dd/yy", "yyyy-MM-dd", "dd-MMM-yy" }, null, DateTimeStyles.None, out dK);
            if (r2) dataZwrotu = dK;

            nazwaKlienta = nKl;
            wypozyczonySamochod = wypSam;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Wyp.Numer" + numerWypozyczenia + ", Klient: "+nazwaKlienta+", samochod: " + wypozyczonySamochod.MarkaSamochodu + " "+wypozyczonySamochod.ModelSamochodu);
            sb.AppendLine("Nr Rejestracyjny: " + wypozyczonySamochod.NrRejstracyjny + ", Data wyp: " + dataWypozyczenia.ToShortDateString() + ", Data zwrotu: " + dataZwrotu.ToShortDateString());

            return sb.ToString();

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
