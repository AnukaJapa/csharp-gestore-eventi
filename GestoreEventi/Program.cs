﻿// See https://aka.ms/new-console-template for more information

using GestoreEventi;
using System.Runtime.InteropServices;

string jello = "1234";
int numericValue;
Console.WriteLine(int.TryParse(jello, out numericValue));


//string[] array = hello.Split("/");
//Console.WriteLine(array.Length);


//Console.WriteLine("perfavore inserisci il nome del Evento");
//string titoloDellEvento = Console.ReadLine(); 

//Console.WriteLine("perfavore inserisci il data del Evento come mese/giorno/anno");
//string dataDellEvento = Console.ReadLine();

//Console.WriteLine("perfavore inserisci capienza massima dell'evento");
//int capienzaMassimaDellEvento= int.Parse(Console.ReadLine());

//Evento compleanno = new Evento(titoloDellEvento, dataDellEvento,capienzaMassimaDellEvento);

//Console.WriteLine("quante prenotazioni vuoi effettuare?");
//int prenotazioniDaEffettuare = int.Parse(Console.ReadLine());
//compleanno.PrenotaPosti(prenotazioniDaEffettuare);

//Console.WriteLine($@"
//il numero di posti prenotati: {compleanno.GetPostiPrenotati()}
//il numero di posti disponibili: {compleanno.GetCapienzaMassima() -compleanno.GetPostiPrenotati()}
//");

//bool vuoleDisdirre = false;
//do
//{
//    Console.WriteLine("vuoi disdirre i Posti? (si/no)");
//    string rispostaClienteDisdirre = Console.ReadLine();

//    if (rispostaClienteDisdirre == "si")
//    {
//        vuoleDisdirre=true;  
//        Console.WriteLine("indica quanti posti vuoi disdirre");
//        int postiDaDisdirreUtente = int.Parse(Console.ReadLine());
//        compleanno.DisdiciPosti(postiDaDisdirreUtente);

//        Console.WriteLine($@"
//          il numero di posti prenotati: {compleanno.GetPostiPrenotati()}
//          il numero di posti disponibili: {compleanno.GetCapienzaMassima() - compleanno.GetPostiPrenotati()}
//");
//    }else
//    {
//        vuoleDisdirre = false;
//    }

//} while (vuoleDisdirre);

Console.WriteLine("crea il tuo programma eventi");
Console.WriteLine("fornisci il titolo");

string titoloProgrammaEventiUtente = Console.ReadLine();
ProgrammaEventi programmaEventiUtente = new ProgrammaEventi(titoloProgrammaEventiUtente);


Console.WriteLine("quanti eventi vuoi inserire?");
int NumeroEventiDaInserire =int.Parse(Console.ReadLine());

do {
    try
    {
        Console.WriteLine($"inserisci nome dell'evento {programmaEventiUtente.GetEventi().Count() + 1} °: ");
        Console.WriteLine(programmaEventiUtente.GetEventi().Count());
        string nomeEvento = Console.ReadLine();

        Console.WriteLine("inserisci data dell'evento in formato mm/gg/yyyy");
        string dataEvento = Console.ReadLine();

        Console.WriteLine("inserisci numeroPostiTotali");
        int stringaContieneNumero;
        string numeroPostiDaInserire = Console.ReadLine();


        if (int.TryParse(numeroPostiDaInserire, out stringaContieneNumero))
        {
            int numeroPostiTotali = int.Parse(numeroPostiDaInserire);
            Evento nuovoEvento = new Evento(nomeEvento, dataEvento, numeroPostiTotali);
          
                programmaEventiUtente.AggiungiEvento(nuovoEvento);

        };

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    
} while (programmaEventiUtente.GetEventi().Count() != NumeroEventiDaInserire);

Console.WriteLine("il numero di eventi nel programmaè :" + programmaEventiUtente.GetEventi().Count());



foreach (Evento evento in programmaEventiUtente.GetEventi())
{
    Console.WriteLine(evento.ToString());
} ;

Console.WriteLine("inserisci data da quale vuoi stampare gli eventi");
string dataUtente = Console.ReadLine();
List <Evento> listaEventiUtente = programmaEventiUtente.RestituisciListaDiEventi(dataUtente);


ProgrammaEventi.StampaListaDiEventi(listaEventiUtente);








