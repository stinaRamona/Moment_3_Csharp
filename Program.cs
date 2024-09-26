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
using System.Text.Json;

namespace GusetbookMessages
{
    class Program
    {
        //generell kod för programmet
        static void Main()
        {
            Console.WriteLine("Ange 1 för att skapa en post");
            Console.WriteLine("Ange 2 för att radera en post");
            string args = Console.ReadLine()!; 
            
            if (args.Length > 0)
            {
                int option;
                if (int.TryParse(args, out option))
                {
                    CheckArgs(option);
                }
            }
            else
            {
                Console.WriteLine("Ange ett 1 för att skapa inlägg och 2 för att ta bort inlägg");
            }

        }

        static void CheckArgs(int option)
        {
            
            if (option == 1)
            {
                CreatePost();
            }
            else if (option == 2)
            {
                DeletePost();
            }
        }

        //för att skapa en post. Här kontrolleras ifall all info är med.
        static void CreatePost()
        {
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
                SavePost(message, name);
            }
            
        }

        //för att spara ner i JSON
        static void SavePost(string message, string name)
        {
            Message myMessage = new Message(message, name); 

            //Console.WriteLine($"Meddelande: {myMessage.GuestMsg}");
            //Console.WriteLine($"Av:{myMessage.GuestName}"); 

            string jsonMessage = JsonSerializer.Serialize<Message>(myMessage); 

            Console.WriteLine(jsonMessage);

            //skickar med jsonMessage till GetPosts
            GetPosts(jsonMessage); 

             
        }

        //för att radera en post
        static void DeletePost()
        {
            Console.WriteLine("TA BORT POST");
             
        }

        //hämtar posterna från där de är sparade
        static void GetPosts(string jsonMessage)
        {
            Console.WriteLine("Mottagen JSON-sträng:");
            Console.WriteLine(jsonMessage); 

            //för felsökning varför deserialisering inte fungerar 
            try 
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

                Message savedMessage = JsonSerializer.Deserialize<Message>(jsonMessage)!; 
                Console.WriteLine($"Meddelande: {savedMessage.GuestMsg}"); 
                Console.WriteLine($"Av: {savedMessage.GuestName}");  
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialiseringfel: {ex.Message}"); 
            }
        }
    }

}
