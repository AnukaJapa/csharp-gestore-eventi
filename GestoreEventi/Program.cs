// See https://aka.ms/new-console-template for more information

using GestoreEventi;

Console.WriteLine("THIS IS STRING OF DATA");
Evento event1 = new Evento("primoEvento","02/02/2024",34);

event1.PrenotaPosti(23);
Console.WriteLine(event1.ToString());
