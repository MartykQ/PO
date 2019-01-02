using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw8
{
    [Serializable]
    public class KierownikZespolu:Osoba,ICloneable
    {
        private int doswiadczenie;
        public int Doswiadczenie
        {
            get { return doswiadczenie; }
            set { doswiadczenie = value; }
        }
        public KierownikZespolu() { }

        public KierownikZespolu(string i, string n, string d, string p, Plcie plec, int dosw)
            : base(i, n, d, p, plec)
        {
            this.doswiadczenie = dosw;
        }
        public override string ToString()
        {
            return base.ToString() + " " + this.doswiadczenie;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
