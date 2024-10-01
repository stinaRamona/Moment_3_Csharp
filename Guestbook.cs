/*fil för gästboken. Ska hantera att skapa meddelanden m.m.*/

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace GuestbookMessages
{   
    public class GuestBook 
    {
        public string jsonfile = @"guestbook.json"; //filen där meddelandena sparas 
        private List<Message> messages = new List<Message>(); //variabel för list med meddelanden. 
        
        //om det finns innehåll i filen så deserialiseras dom i GuestBook. 
        public GuestBook()
        {
            if(File.Exists(jsonfile))
            {
                string jsonstring = File.ReadAllText(jsonfile); 
                messages = JsonSerializer.Deserialize<List<Message>>(jsonstring)!; 
            }
        }
        
        //kod för att lägga till meddelande till filen 
        public void AddPost(string message, string name)
        {  
            Message post = new Message();

            post.GuestMsg = message; 
            post.GuestName = name; 

            messages.Add(post); 
            marshal();     
        }
        
        //Kod för att ta bort meddelande genom index. 
        public int DeletePost(int index)
        {
            messages.RemoveAt(index); 
            marshal(); 
            return index;        
        }

        //hämtar posterna från där de är sparade
        public List<Message> GetPosts()
        {
            return messages; 
        }
        
        //serialiserar innehåll och sparar ner i jsonfilen
        private void marshal()
        {
            var jsonstring = JsonSerializer.Serialize(messages); 
            File.WriteAllText(jsonfile, jsonstring); 
        }
    }
}