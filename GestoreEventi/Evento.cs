﻿using System;
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
        private bool errore;

        public Evento(string titolo, string data, int capienzaMassima)
        {
            SetTitolo(titolo);
            SetData(data);
            this.capienzaMassima = EZeroCapienzaMassimaONo(capienzaMassima);
            this.postiPrenotati = 0;
        }

        //GETTER
        public bool GetErrore()
        {
            return this.errore;
        }
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
                Console.WriteLine("non hai modificato il titolo perchè il tuo titolo inserito è vuoto");
                this.errore = true;

            } else if(titolo.Trim()=="" && this.titolo == null)
            {
                Console.WriteLine("non puoi creare evento dove il titolo dell'evento è vuoto");
                this.errore = true;
            }else
            {
                this.titolo = titolo;
            }
        }

        public void SetData(string data)
        {
            if (VerificaFormatto(data))
            {
                DateTime stringToDateType = DateTime.Parse(data);
                
                if (stringToDateType <= DateTime.Now)
                {
                    Console.WriteLine("evento non può avere una data che sia gia passata");
                    errore = true;
                }
                else
                {
                    this.data = stringToDateType;
                }

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
        private bool VerificaFormatto(string data)
        {
            string[] array = data.Split("/");
            if (array.Length != 3)
            {
                Console.WriteLine("formattazione inserita è sbagliata bisogna inserire i dati in formatto mm/gg/yyyy");
                this.errore = true;
                return false;

            }
            else if (int.Parse(array[0]) >= 12 || int.Parse(array[0]) <= 0)
            {
                Console.WriteLine("formattazione del mese è sbagliata non può avere più di 12 mesi o meno d 0");
                this.errore = true;
                return false;


            }
            else if (int.Parse(array[1]) >= 31 || int.Parse(array[1]) <= 0)
            {
                Console.WriteLine("formattazione del giorno è sbagliata non può avere più di 31 giorni o meno d 0");
                this.errore = true;
                return false;

            }
            else
            {
                return true;
            }
        }
        private int makePositive(int numero)
        {
            if (numero < 0)
            {
                numero = (-1) * numero;
            }
            return numero;
        }

        private int EZeroCapienzaMassimaONo(int numero)
        {
            makePositive(numero);
            if (numero == 0)
            {
                Console.WriteLine("capienza massima non può essere 0 persone");
                errore = true;
            }
            return numero;
        }

        private void StringaContieneNumero(string numero)
        {
            int numericValue;  
           
            if (int.TryParse(numero, out numericValue))
            {
                return numericValue;
            } else
            {

            }
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
