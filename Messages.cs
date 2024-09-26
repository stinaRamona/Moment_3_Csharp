/*
Fil för classen message.
*/

namespace GusetbookMessages
{
    //Definition av klassen
    public class Message
    {
        public string GuestMsg = ""; 
        public string GuestName = ""; 
        //Constructor
        public Message(string msg, string name)
        {
            GuestMsg = msg; 
            GuestName = name; 
        }
    }
}
