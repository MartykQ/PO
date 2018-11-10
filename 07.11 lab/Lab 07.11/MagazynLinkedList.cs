using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07._11
{
    class MagazynLinkedList:IMagazynujeTablice
    {
        string nazwa;
        int iloscPaczek;
        LinkedList<Paczka> listaWiazanaPaczek;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        internal LinkedList<Paczka> ListaWiazanaPaczek { get => listaWiazanaPaczek; set => listaWiazanaPaczek = value; }


        public MagazynLinkedList()
        {
            listaWiazanaPaczek = new LinkedList<Paczka>();
            iloscPaczek = 0;
        }

        public void Wyczysc()
        {
            listaWiazanaPaczek.Clear();
        }

        public int PodajIlosc()
        {
            return listaWiazanaPaczek.Count();
        }

        public void UmiescNaPoczatku(Paczka pIN)
        {
            listaWiazanaPaczek.AddFirst(pIN);
            iloscPaczek++;
        }

        public void UmiescPrzed(Paczka pB, Paczka pIN)
        {
            LinkedListNode<Paczka> node = listaWiazanaPaczek.Find(pB);
            listaWiazanaPaczek.AddBefore(node, pIN);
            iloscPaczek++;
        }

        public void UmiescPo(Paczka pA, Paczka pIN)
        {
            LinkedListNode<Paczka> node = listaWiazanaPaczek.Find(pA);
            listaWiazanaPaczek.AddAfter(node, pIN);
            iloscPaczek++;
        }

        public void UmiescOstatni(Paczka pIN)
        {
            listaWiazanaPaczek.AddLast(pIN);
            iloscPaczek++;
        }

        public void UsunPierwszeWystapienie(Paczka pOUT)
        {
            iloscPaczek--;
            listaWiazanaPaczek.Remove(pOUT);
        }

        public void UsunPierwszy()
        {
            iloscPaczek--;
            listaWiazanaPaczek.RemoveFirst();

        }

        public void UsunOstatni()
        {
            iloscPaczek--;
            listaWiazanaPaczek.RemoveLast();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PACZKI W MAGAZYNIE kolejkowym");
            foreach (Paczka p in listaWiazanaPaczek)
            {
                sb.AppendLine(p.NumerPaczki + " NADAWCA: " + p.Nadawca);
            }
            return sb.ToString();
        }
    }
}
