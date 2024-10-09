/*
Moment 3 i Programmering i C#.NET, HT24, Mittuniversitetet 
Kod skriven av Stina Persson stpe1901
Senast uppdaterad 01/10 - 24
*/

/*
Uppgiften går ut på att skapa en gästbok där man ska kunna lägga till 
en post, ta bort en post samt visa alla poster. Posterna innehåller ägare till innlägget 
och texten för inlägget. 

Ett enklare menysystem ska implementeras där man väljer vad som ska göras 

Om man vill lägga in post ska man kunna lägga till ägare, dessa fält ska ej lämnas tomma 

Man tar bort fält baserat på index på inlägget (ska sparas som en array)

Gästbokens inlägg ska serialiseras/deserialiseras samt sparas på fil antingen 
binärt eller som json, så att tidigare inmatad data finns lagrad.

Efter varje genomfört menyval ska skärmen skrivas om. Rensar konsollen och sen skriver om den. 
*/

using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace GuestbookMessages
{
    class Program
    {
        //generell kod för programmet
        static void Main()
        {
            //Förbereder variabel för listan samt construktor för gästboken 
            GuestBook guestbook = new GuestBook();
            int i = 0;

            //While-loop som gör att programmet körs tills det stängs ner 
            while (true)
            {   
                Console.Clear(); //konsollen rensas vid omstart av programmet eller nytt menyval 

                //Kommer står som meny när programmet startas
                Console.WriteLine("📜 Stinas gästbok 📜\n");
                Console.WriteLine("Ange 1 för att skapa en post");
                Console.WriteLine("Ange 2 för att radera en post");
                Console.WriteLine("Ange X för att avsluta programmet");

                //Varje meddelande som finns i sparade i jsonfilen skrivs ut, tsm med index som börjar på noll 
                i = 0;
                foreach (Message message in guestbook.GetPosts())
                {
                    Console.WriteLine($"[{i++}] {message.GuestMsg} - {message.GuestName}");
                }

                //För de olika alternativen: lägga till, ta bort stäng av. 
                string? key = Console.ReadLine()!;
                switch (key)
                {
                    case "1":
                        //kod för att skapa
                        Console.WriteLine("SKAPA POST");
                        Console.WriteLine("Skriv ditt meddelande här:");
                        string message = Console.ReadLine()!;

                        Console.WriteLine("Skriv ditt namn här:");
                        string name = Console.ReadLine()!;

                        if (!string.IsNullOrWhiteSpace(message) && !string.IsNullOrWhiteSpace(name)) //kontrollerar innehåll, även mellanslag
                        {
                            guestbook.AddPost(message, name); //kommer skickas till guestbook och läggas till där
                        }
                        else
                        {
                            Console.WriteLine("Du måste ange meddelande och namn");
                            Console.WriteLine("Tryck på valfri tangent för att fortsätta"); 
                            Console.ReadKey(); 
                        } 
                        break;

                    case "2":
                        //Kod för att ta bort
                        Console.WriteLine("Skriv nummret på meddelandet du vill radera:");
                        string index = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(index)) //om det finns innehåll fortsätter koden
                            try
                            {
                                guestbook.DeletePost(Convert.ToInt32(index)); //skickar till delete post i guestbook 
                            }
                            catch (Exception) //ifall numret inte finns sparat fångas det upp här
                            {
                                Console.WriteLine("Det nummret du anget är inget meddelande!");
                                Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                                Console.ReadKey();
                            } 
                        break;

                    case "x":
                        //Kod för att avsluta programmet
                        Console.Clear(); //rensar konsollen innan avslut av programmet

                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
