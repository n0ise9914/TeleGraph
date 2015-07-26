namespace TeleGraph.Plugin.Client
{
    public class User : IConversation
    {
        public int Id { get; set; }
        public string FirstName;
        public string LastName;
        public string Username;
    }
}
