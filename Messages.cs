/*
Fil för classen message.
*/

namespace GusetbookMessages
{
    //Definition av klassen
    public class Message
    {
        public string GuestMsg {get; set;} 
        public string GuestName {get; set;} 
        //Constructor
        public Message(string msg, string name)
        {
            GuestMsg = msg; 
            GuestName = name; 
        }

        //test ifall det funkar med deserialisering
        public Message(){ }
    }
}
