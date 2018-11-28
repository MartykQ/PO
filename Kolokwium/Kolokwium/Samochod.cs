using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    //Franciszek Martyka IiE gr. 2
    [Serializable]
    class Samochod: ICloneable
    {
        private string markaSamochodu;
        private string modelSamochodu;
        private string rokProdukcji;
        private string nrRejestracyjny;
        private int liczbaOsob;
        private bool wolny;
        public static double cenaPodstawowa;


        public string MarkaSamochodu { get => markaSamochodu; set => markaSamochodu = value; }
        public string ModelSamochodu { get => modelSamochodu; set => modelSamochodu = value; }
        public string RokProdukcji { get => rokProdukcji; set => rokProdukcji = value; }
        public int LiczbaOsob { get => liczbaOsob; set => liczbaOsob = value; }
        public bool Wolny { get => wolny; set => wolny = value; }
        public string NrRejstracyjny
        {
            get
            {
                return nrRejestracyjny;
            }
            set
            {
                if (value.Length < 5)
                {
                    nrRejestracyjny = value;
                }
                else
                {
                    throw new Exception("nr za dlugi");
                }
            }
        }

        public Samochod()
        {
            markaSamochodu = null;
            modelSamochodu = null;
            rokProdukcji = null;
            nrRejestracyjny = null;
            wolny = true;
        }
        
        public Samochod(string marka, string model, string rej, int lOsob, bool czywolny)
        {
            markaSamochodu = marka;
            modelSamochodu = model;
            nrRejestracyjny = rej;
            liczbaOsob = lOsob;
            wolny = czywolny;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Samochod marki: ");
            sb.Append(markaSamochodu);
            sb.AppendLine(" ");
            sb.AppendLine("Model: ");
            sb.Append(modelSamochodu);
            sb.AppendLine(" ");
            sb.AppendLine("Jest: ");
            if (wolny == true) sb.AppendLine("wolny");
            else sb.AppendLine("zajety");

            return sb.ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
