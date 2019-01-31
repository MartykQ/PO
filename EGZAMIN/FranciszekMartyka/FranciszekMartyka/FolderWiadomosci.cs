using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranciszekMartyka
{
    public class FolderWiadomosci: ICloneable
    {
        private Queue<Wiadomosc> kolejkaWiadomosci;

        public Queue<Wiadomosc> KolejkaWiadomosci { get => kolejkaWiadomosci; set => kolejkaWiadomosci = value; }

        public FolderWiadomosci()
        {
            kolejkaWiadomosci = new Queue<Wiadomosc>();
        }

        public void DodajWiadomosc(Wiadomosc w1)
        {
            kolejkaWiadomosci.Enqueue(w1);
        }

        public Wiadomosc PobierzWiadomosc()
        {
            return kolejkaWiadomosci.Dequeue(); 
        }

        public void WyczyscWiadomosci()
        {
            kolejkaWiadomosci.Clear();
        }

        public List<Wiadomosc> Wyszukaj(string mail)
        {
            List<Wiadomosc> zwracanaLista = new List<Wiadomosc>();

            foreach(Wiadomosc w in kolejkaWiadomosci)
            {
                if(w.Email.Equals(mail))
                {
                    zwracanaLista.Add(w);
                }
            }

            return zwracanaLista;
        }

        public object Clone()
        {
            FolderWiadomosci sklonowanyFolder = new FolderWiadomosci();
            Queue<Wiadomosc> nowaKolejka = new Queue<Wiadomosc>();

            foreach(Wiadomosc w in kolejkaWiadomosci)
            {
                Wiadomosc kopiowanaWiadomosc = (Wiadomosc)w.Clone();
                nowaKolejka.Enqueue(kopiowanaWiadomosc);
            }
            sklonowanyFolder.KolejkaWiadomosci = nowaKolejka;
            return sklonowanyFolder;
        }

    }
}
