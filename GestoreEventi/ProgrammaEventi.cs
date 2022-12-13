using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        private string titolo;
        private List<Evento> eventi;

        public ProgrammaEventi(string titolo)
        {

            this.titolo = titolo;
            this.eventi = new List<Evento>();

        }

        //METODI
        public void AggiungiEvento(Evento evento)
        {
            this.eventi.Add(evento);
        }

        public void RestituisciListaDiEventi(string data)
        {
            if (eventi.Exists(evento => evento.GetData() == data))
            {
                Console.WriteLine("questi sono eventi di questa data");
                foreach (Evento evento in eventi)
                {
                    if (evento.GetData() == data)
                    {
                        Console.WriteLine("-" + evento.GetTitolo());
                    }
                }

            }
            else
            {
                Console.WriteLine("non è stato trovato nessun evento in questa data");
            }

        }

        public static void StampaListaDiEventi(List<Evento> listaEventi)
        {
            string listaDiEventiInStringa = "";
            foreach (Evento evento in listaEventi)
            {
                listaDiEventiInStringa += $@" - {evento.GetTitolo()}";
            }
            Console.WriteLine(listaDiEventiInStringa);
        }

        public void SvuotaListaDiEventi(List<Evento> listaEventi)
        {
            listaEventi.Clear();
        }

        public string MostraTitoloDelProgrammaEEventi()
        {
            string programmaDescrizione = $@"{this.titolo}";
            for (int i = 0; i < eventi.Count; i++)
            {
                programmaDescrizione += $@"data{i + 1} - {eventi[i].GetTitolo()}
";
            }
            return programmaDescrizione;
        }
    }
}
