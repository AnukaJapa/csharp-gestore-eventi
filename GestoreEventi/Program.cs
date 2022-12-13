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

