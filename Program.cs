/*
Moment 3 i Programmering i C#.NET, HT24, Mittuniversitetet 
Kod skriven av Stina Persson stpe1901
Senast uppdaterad 18/9 - 24
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
using System.Text.Json;

namespace GusetbookMessages
{
    class Program
    {
        //generell kod för programmet
        static void Main()
        {
            //Förbereder variabel för listan samt construktor för gästboken 
            GuestBook guestbook = new GuestBook();
            int i = 0;

            while (true)
            {
                Console.WriteLine("❤️ Stinas gästbok ❤️\n");
                Console.WriteLine("Ange 1 för att skapa en post");
                Console.WriteLine("Ange 2 för att radera en post");
                Console.WriteLine("Ange X för att avsluta programmet");

                i = 0;
                foreach (Message message in guestbook.GetPosts())
                {
                    Console.WriteLine($"[{i++}] {guestbook.GuestMsg} - {guestbook.GuestName}"); //kommer fixas när Guestbook ordnas upp.
                }

                int key = (int)Console.ReadKey(true).Key;
                switch (key)
                {
                    case '1':
                        //kod för att skapa
                        Console.WriteLine("SKAPA POST");
                        Console.WriteLine("Skriv ditt meddelande här:");
                        string message = Console.ReadLine()!;

                        Console.WriteLine("Skriv ditt namn här:");
                        string name = Console.ReadLine()!;

                        if (message.Length == 0 || name.Length == 0)
                        {
                            Console.WriteLine("Du måste ange meddelande och namn");
                        }
                        else
                        {
                            AddPost(message, name); //kommer skickas till guestbook och läggas till där
                        }
                        break;

                    case '2':
                        //Kod för att ta bort
                        Console.WriteLine("Skriv nummret på meddelandet du vill radera:");
                        string index = Console.ReadLine()!;
                        if (string.IsNullOrEmpty(index))
                            try
                            {
                                guestbook.DeletePost(Convert.ToInt32(index)); //skickar till delete post i guestbook 
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Det nummret du anget är inget meddelande!");
                                Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                                Console.ReadKey();
                            }
                        break;

                    case 88:
                        //Kod för att avsluta programmet
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
