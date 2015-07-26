using System;
namespace TeleGraph.Plugin.Client
{
    public class Message
    {
        public int MessageId = new int();
        public User From = new User();
        public DateTime Date = new DateTime();
        public Chat Chat = new Chat();
        public User ForwardFrom = new User();
        public DateTime ForwardDate = new DateTime();
        public Message ReplayToMessage;
        public string Text;
        public Audio Audio = new Audio();
        public Document Document = new Document();
        public PhotoSize[] Photo = new PhotoSize[0];
        public Sticker Sticker = new Sticker();
        public Video Video = new Video();
        public Contact Contact = new Contact();
        public Location Location = new Location();
        public User NewChatParticipant = new User();
        public User LeftChatParticipant = new User();
        public string NewChatTitle;
        public PhotoSize[] NewChatPhoto = new PhotoSize[0];
        public bool DeleteChatPhoto = new bool();
        public bool GroupChatCreated = new bool();

        public MessageType Type
        {
            get
            {
                if (!string.IsNullOrEmpty(Text))
                    return MessageType.TextMessage;

                if (Audio != null)
                    return MessageType.AudioMessage;

                if (Document != null)
                    return MessageType.DocumentMessage;

                if (Photo != null)
                    return MessageType.PhotoMessage;

                if (Sticker != null)
                    return MessageType.StickerMessage;

                if (Video != null)
                    return MessageType.VideoMessage;

                if (Contact != null)
                    return  MessageType.ContactMessage;

                if (Location != null)
                    return MessageType.LocationMessage;

                throw new FormatException("MessageType unknown");
            }
        }
    }
}
