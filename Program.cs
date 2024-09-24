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

Man tar bort fält baserat på index på inlägget 

Gästbokens inlägg ska serialiseras/deserialiseras samt sparas på fil antingen 
binärt eller som json, så att tidigare inmatad data finns lagrad.

Efter varje genomfört menyval ska skärmen skrivas om. Rensar konsollen och sen skriver om den. 
*/

using System; 

class Program
{
    static void Main()
    {
        Console.WriteLine("Ange 1 för att skapa en post");
        Console.WriteLine("Ange 2 för att radera en post"); 
        string args = Console.ReadLine(); 
        //generell kod för programmet 

        if(args.Length > 0)
        {
            int option; 
            if(int.TryParse(args, out option))
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
        if(option == 1)
        {
            CreatePost(); 
        }
        else if(option == 2)
        {
            DeletePost(); 
        }
    }

    static void CreatePost()
    {
        Console.WriteLine("SKAPA POST");
        Console.WriteLine("Skriv ditt meddelande här:"); 
        string message = Console.ReadLine(); 

        Console.WriteLine("Skriv ditt namn här:"); 
        string name = Console.ReadLine(); 

        if(message.Length == 0 || name.Length == 0)
        {
            Console.WriteLine("Du måste ange meddelande och namn"); 
        }
        else
        {
            SavePost(); 
        }
        //för att skapa en post. Här kontrolleras ifall all info är med.
    } 

    static void SavePost()
    {
        Console.WriteLine("sparar meddelande"); 
        //för att spara ner i binärt eller JSON 
    }

    static void DeletePost()
    {
        Console.WriteLine("TA BORT POST"); 
        //för att radera en post 
    }

    static void GetPosts() 
    {
        //hämtar posterna från där de är sparade 
    }
} 


