using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    [Serializable]
    public class KierownikZespolu:Osoba,ICloneable
    {
        [Key]
        public int kierownikZespoluId { get; set; }

        private int doswiadczenie;
        public int Doswiadczenie
        {
            get { return doswiadczenie; }
            set { doswiadczenie = value; }
        }
        public int liczbaProjektow { get; set; }
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
