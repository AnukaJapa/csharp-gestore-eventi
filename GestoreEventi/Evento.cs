using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        private string titolo;
        private DateTime data;
        private int capienzaMassima;
        private int postiPrenotati;

        public Evento(string titolo, string data, int capienzaMassima)
        {
            SetTitolo(titolo);
            SetData(data);
            this.capienzaMassima = EValidaCapienzaMassima(capienzaMassima);
            this.postiPrenotati = 0;
        }

        //GETTER
        public string GetTitolo()
        {
            return this.titolo;
        }
        public string GetData()
        {   
            string date = this.data.ToString("MM/dd/yyyy");
            if(date == "01/01/0001")
            {
                return "la data dell'evento non è ancora passata";
            }
            return date;
        }

        public int GetCapienzaMassima()
        {
            return this.capienzaMassima;
        }

        public int GetPostiPrenotati()
        {
            return this.postiPrenotati;
        }

        //SETTER
        public void SetTitolo(string titolo)
        {
            if (titolo.Trim() == "" && this.titolo != null)
            {
                Console.WriteLine("non hai modificato il titolo perchè il tuo titolo passato è vuoto");
            } else if(titolo.Trim()=="" && this.titolo == null)
            {
                throw new Exception("non puoi creare evento dove il titolo dell'evento è vuoto");
            }else
            {
                this.titolo = titolo;
            }
        }

        public void SetData(string data)
        {
            DateTime stringToDataType = DateTime.Parse(data);

            if(stringToDataType <= DateTime.Now)
            {
                throw new Exception("evento non può avere una data che sia gia passata");
            } else
            {
                this.data = stringToDataType;
            }
        }

       //public methods
       public void PrenotaPosti(int numeroPostiDaPrenotare)
        {
            if(this.postiPrenotati + numeroPostiDaPrenotare > this.capienzaMassima)
            {
                int postiDisponibili = this.capienzaMassima - this.postiPrenotati;
                throw new Exception($"non puoi prenotare perhcè hai ragigunto il limite di capienza massima dell'evento evento disponibili sono {postiDisponibili}");
            }
            else if (this.data <= DateTime.Now)
            {
                throw new Exception("l'evento è gia passato non puoi prenotare!");
            }
            else
            {
                this.postiPrenotati += numeroPostiDaPrenotare;
            }

        }

        public void DisdiciPosti(int postiDaDisdire)
        {
            if (this.data <= DateTime.Now)
            {
                throw new Exception("l'evento è gia passato non puoi disdire i posti!");
            }
            else if(postiPrenotati - postiDaDisdire < 0)
            {
                throw new Exception("non puoi disdirre i posti maggiore di quanti sono gia prenotati");
            } else
            {
                this.postiPrenotati -= postiDaDisdire;
            }
        }

        // private methods 
        private int makePositive(int numero)
        {
            if (numero < 0)
            {
                numero = (-1) * numero;
            }
            return numero;
        }

        private int EValidaCapienzaMassima(int numero)
        {
            makePositive(numero);
            if (numero == 0)
            {
                throw new Exception("capienza massima non può essere 0 persone");
            }
            return numero;
        }

        public override string ToString()
        {
            string dataETitolo = @$"
            Titolo:{titolo} 
            Data: {this.data.ToString("MM/dd/yyyy")}";
             return dataETitolo;
        }

    }
}
