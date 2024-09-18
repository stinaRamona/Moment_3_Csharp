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

class Program()
{
    static void Main()
    {
        Console.WriteLine("Moment 3!"); 
        //generell kod för programmet 
    }

    static void CheckArgs() 
    {
        //kontrollerar argument och på vad som ska göras (visa, skapa, ta bort)
    }

    static void CreatePost()
    {
        //för att skapa en post. Här kontrolleras ifall all info är med.
    } 

    static void SavePost()
    {
        //för att spara ner i binärt eller JSON 
    }

    static void DeletePost()
    {
        //för att radera en post 
    }

    static void GetPosts() 
    {
        //hämtar posterna från där de är sparade 
    }
} 


