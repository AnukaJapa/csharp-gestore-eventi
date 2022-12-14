// See https://aka.ms/new-console-template for more information

using GestoreEventi;
using System.Runtime.InteropServices;

//Console.WriteLine("perfavore inserisci il nome del Evento");
//string titoloDellEvento = Console.ReadLine();

//Console.WriteLine("perfavore inserisci il data del Evento come mese/giorno/anno");
//string dataDellEvento = Console.ReadLine();

//Console.WriteLine("perfavore inserisci capienza massima dell'evento");
//int capienzaMassimaDellEvento = int.Parse(Console.ReadLine());

//Evento compleanno = new Evento(titoloDellEvento, dataDellEvento, capienzaMassimaDellEvento);

//Console.WriteLine("quante prenotazioni vuoi effettuare?");
//int prenotazioniDaEffettuare = int.Parse(Console.ReadLine());
//compleanno.PrenotaPosti(prenotazioniDaEffettuare);

//Console.WriteLine($@"
//il numero di posti prenotati: {compleanno.GetPostiPrenotati()}
//il numero di posti disponibili: {compleanno.GetCapienzaMassima() - compleanno.GetPostiPrenotati()}
//");

//bool vuoleDisdirre = false;
//do
//{
//    Console.WriteLine("vuoi disdirre i Posti? (si/no)");
//    string rispostaClienteDisdirre = Console.ReadLine();

//    if (rispostaClienteDisdirre == "si")
//    {
//        vuoleDisdirre = true;
//        Console.WriteLine("indica quanti posti vuoi disdirre");
//        int postiDaDisdirreUtente = int.Parse(Console.ReadLine());
//        compleanno.DisdiciPosti(postiDaDisdirreUtente);

//        Console.WriteLine($@"
//          il numero di posti prenotati: {compleanno.GetPostiPrenotati()}
//          il numero di posti disponibili: {compleanno.GetCapienzaMassima() - compleanno.GetPostiPrenotati()}
//");
//    }
//    else
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
        Console.WriteLine($"inserisci nome dell'evento {programmaEventiUtente.NumeroDiEventiPresenti() + 1} °: ");
        Console.WriteLine(programmaEventiUtente.NumeroDiEventiPresenti());
        string nomeEvento = Console.ReadLine();

        Console.WriteLine("inserisci data dell'evento in formato mm/gg/yyyy");
        string dataEvento = Console.ReadLine();

        Console.WriteLine("inserisci numeroPostiTotali");
       
        string numeroPostiDaInserire = Console.ReadLine();
       int numeroPostiDaInserireNumerico =  Evento.StringaContieneNumero(numeroPostiDaInserire);
       
            Evento nuovoEvento = new Evento(nomeEvento, dataEvento, numeroPostiDaInserireNumerico);
          
                programmaEventiUtente.AggiungiEvento(nuovoEvento);

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    
} while (programmaEventiUtente.NumeroDiEventiPresenti() != NumeroEventiDaInserire);

Console.WriteLine("il numero di eventi nel programmaè :" + programmaEventiUtente.NumeroDiEventiPresenti());



foreach (Evento evento in programmaEventiUtente.GetEventi())
{
    Console.WriteLine(evento.ToString());
} ;

Console.WriteLine("inserisci data da quale vuoi stampare gli eventi");
string dataUtente = Console.ReadLine();
Evento.VerificaFormatto(dataUtente);

List <Evento> listaEventiUtente = programmaEventiUtente.RestituisciListaDiEventiPerCertaData(dataUtente);
Console.WriteLine(ProgrammaEventi.RestituisciListaDiEventi(listaEventiUtente));


Console.WriteLine("qua stamperai tutti gli elementi della lista");
programmaEventiUtente.AggiungiEvento(new Conferenza("sole", "12/12/2023",34,"Core Lin", 23.12));
Console.WriteLine(ProgrammaEventi.RestituisciListaDiEventi(programmaEventiUtente.GetEventi()));









