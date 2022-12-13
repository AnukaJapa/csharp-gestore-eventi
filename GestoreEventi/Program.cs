// See https://aka.ms/new-console-template for more information

using GestoreEventi;

Console.WriteLine("perfavore inserisci il nome del Evento");
string titoloDellEvento = Console.ReadLine(); 

Console.WriteLine("perfavore inserisci il data del Evento come mese/giorno/anno");
string dataDellEvento = Console.ReadLine();

Console.WriteLine("perfavore inserisci capienza massima dell'evento");
int capienzaMassimaDellEvento= int.Parse(Console.ReadLine());

Evento event1 = new Evento(titoloDellEvento, dataDellEvento,capienzaMassimaDellEvento);

Console.WriteLine("quante prenotazioni vuoi effettuare?");
int prenotazioniDaEffettuare = int.Parse(Console.ReadLine());
event1.PrenotaPosti(prenotazioniDaEffettuare);

Console.WriteLine($@"
il numero di posti prenotati: {event1.GetPostiPrenotati()}
il numero di posti disponibili: {event1.GetCapienzaMassima() -event1.GetPostiPrenotati()}
");

bool vuoleDisdirre = false;
do
{
    Console.WriteLine("vuoi disdirre i Posti? (si/no)");
    string rispostaClienteDisdirre = Console.ReadLine();

    if (rispostaClienteDisdirre == "si")
    {
        vuoleDisdirre=true;  
        Console.WriteLine("indica quanti posti vuoi disdirre");
        int postiDaDisdirreUtente = int.Parse(Console.ReadLine());
        event1.DisdiciPosti(postiDaDisdirreUtente);

        Console.WriteLine($@"
          il numero di posti prenotati: {event1.GetPostiPrenotati()}
          il numero di posti disponibili: {event1.GetCapienzaMassima() - event1.GetPostiPrenotati()}");
    }else
    {
        vuoleDisdirre = false;
    }


} while (vuoleDisdirre);





