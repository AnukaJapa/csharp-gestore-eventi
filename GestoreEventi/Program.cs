// See https://aka.ms/new-console-template for more information

using GestoreEventi;

Console.WriteLine("perfavore inserisci il nome del Evento");
string titoloDellEvento = Console.ReadLine(); 

Console.WriteLine("perfavore inserisci il data del Evento come mese/giorno/anno");
string dataDellEvento = Console.ReadLine();

Console.WriteLine("perfavore inserisci capienza massima dell'evento");
int capienzaMassimaDellEvento= int.Parse(Console.ReadLine());

Evento event1 = new Evento(titoloDellEvento, dataDellEvento,capienzaMassimaDellEvento);


