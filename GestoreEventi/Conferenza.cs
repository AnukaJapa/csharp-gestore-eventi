using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Conferenza : Evento
    {
        string relatore;
        double prezzo;

        public Conferenza(string titolo, string data, int capienzaMassima, string relatore, double prezzo) : base(titolo, data, capienzaMassima)
        {
            this.relatore = relatore;
            this.prezzo = prezzo;

        }

        //GETTERS
        public string GetRelatore()
        {
            return this.relatore;   
        }

        public double GetPrezzo()
        {
            return this.prezzo; 
        }
        //SETTER

        //Metodi

        public string PrezzoFormattato(double prezzo)
        {
            return $"{prezzo} Euro";
        }

        public override string ToString()
        {
            return base.ToString() + $@"- {relatore} - {PrezzoFormattato(this.prezzo)}";
        }

    }

}
