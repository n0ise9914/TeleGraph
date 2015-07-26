using System;
using System.Threading.Tasks;
using TeleGraph.Plugin;
using Telegram.Bot.Types;
using TeleGraph.Plugin.Client;

namespace TeleGraph
{
    public class Parser
    {
        public delegate void _OnError(object sender, Exception ex);
        public event _OnError OnError;
        TeleGraph.Plugin.Client.Message ParsedMessage = new TeleGraph.Plugin.Client.Message();
        public TeleGraph.Plugin.Client.Message ParseMessage(Telegram.Bot.Types.Message message)
        {
            try
            {
                if (!string.IsNullOrEmpty(message.Text))
                {
                    ParsedMessage.MessageId = message.MessageId;
                    ParsedMessage.Date = message.Date;
                    ParsedMessage.From.FirstName = message.From.FirstName;
                    ParsedMessage.From.Id = message.From.Id;
                    ParsedMessage.From.LastName = message.From.LastName;
                    ParsedMessage.From.Username = message.From.Username;
                    ParsedMessage.Chat.Id = message.Chat.Id;
                    ParsedMessage.ForwardFrom.FirstName = message.ForwardFrom.FirstName;
                    ParsedMessage.ForwardFrom.Id = message.ForwardFrom.Id;
                    ParsedMessage.ForwardFrom.LastName = message.ForwardFrom.LastName;
                    ParsedMessage.ForwardFrom.Username = message.ForwardFrom.Username;
                    //public Message ReplayToMessage;
                    ParsedMessage.Text = message.Text;
                    ParsedMessage.NewChatParticipant.FirstName = message.NewChatParticipant.FirstName;
                    ParsedMessage.NewChatParticipant.Id = message.NewChatParticipant.Id;
                    ParsedMessage.NewChatParticipant.LastName = message.NewChatParticipant.LastName;
                    ParsedMessage.NewChatParticipant.Username = message.NewChatParticipant.Username;
                    ParsedMessage.LeftChatParticipant.FirstName = message.LeftChatParticipant.FirstName;
                    ParsedMessage.LeftChatParticipant.Id = message.LeftChatParticipant.Id;
                    ParsedMessage.LeftChatParticipant.LastName = message.LeftChatParticipant.LastName;
                    ParsedMessage.LeftChatParticipant.Username = message.LeftChatParticipant.Username;
                    ParsedMessage.NewChatTitle = message.NewChatTitle;
                    ParsedMessage.DeleteChatPhoto = message.DeleteChatPhoto;
                    ParsedMessage.GroupChatCreated = message.DeleteChatPhoto;
                }
                else if (message.Audio != null)
                {
                    ParsedMessage.Audio.Duration = message.Audio.Duration;
                    ParsedMessage.Audio.FileId = message.Audio.FileId;
                    ParsedMessage.Audio.FileSize = message.Audio.FileSize;
                    ParsedMessage.Audio.MimeType = message.Audio.MimeType;
                }
                else if (message.Document != null)
                {
                    ParsedMessage.Document.FileId = message.Document.FileId;
                    ParsedMessage.Document.FileName = message.Document.FileName;
                    ParsedMessage.Document.FileSize = message.Document.FileSize;
                    ParsedMessage.Document.MimeType = message.Document.MimeType;
                    ParsedMessage.Document.Thumb.FileId = message.Document.Thumb.FileId;
                    ParsedMessage.Document.Thumb.FileSize = message.Document.Thumb.FileSize;
                    ParsedMessage.Document.Thumb.Height = message.Document.Thumb.Height;
                    ParsedMessage.Document.Thumb.Width = message.Document.Thumb.Width;
                }
                else if (message.Photo != null)
                {
                    for (int i = 0; i < message.Photo.Length; i++)
                    {
                        ParsedMessage.Photo[i].FileId = message.Photo[i].FileId;
                        ParsedMessage.Photo[i].FileSize = message.Photo[i].FileSize;
                        ParsedMessage.Photo[i].Height = message.Photo[i].Height;
                        ParsedMessage.Photo[i].Width = message.Photo[i].Width;
                    }
                    for (int i = 0; i < message.NewChatPhoto.Length; i++)
                    {
                        ParsedMessage.NewChatPhoto[i].FileId = message.NewChatPhoto[i].FileId;
                        ParsedMessage.NewChatPhoto[i].FileSize = message.NewChatPhoto[i].FileSize;
                        ParsedMessage.NewChatPhoto[i].Height = message.NewChatPhoto[i].Height;
                        ParsedMessage.NewChatPhoto[i].Width = message.NewChatPhoto[i].Width;

                    }
                }
                else if (message.Sticker != null)
                {
                    ParsedMessage.Sticker.FileId = message.Sticker.FileId;
                    ParsedMessage.Sticker.FileSize = message.Sticker.FileSize;
                    ParsedMessage.Sticker.Height = message.Sticker.Height;
                    ParsedMessage.Sticker.Thumb.FileId = message.Sticker.Thumb.FileId;
                    ParsedMessage.Sticker.Thumb.FileSize = message.Sticker.Thumb.FileSize;
                    ParsedMessage.Sticker.Thumb.Height = message.Sticker.Thumb.Height;
                    ParsedMessage.Sticker.Thumb.Width = message.Sticker.Thumb.Width;
                    ParsedMessage.Sticker.Width = message.Sticker.Width;
                }
                else if (message.Video != null)
                {
                    ParsedMessage.Video.Caption = message.Video.Caption;
                    ParsedMessage.Video.Duration = message.Video.Duration;
                    ParsedMessage.Video.FileId = message.Video.FileId;
                    ParsedMessage.Video.FileSize = message.Video.FileSize;
                    ParsedMessage.Video.Height = message.Video.Height;
                    ParsedMessage.Video.MimeType = message.Video.MimeType;
                    ParsedMessage.Video.Thumb.FileId = message.Video.Thumb.FileId;
                    ParsedMessage.Video.Thumb.FileSize = message.Video.Thumb.FileSize;
                    ParsedMessage.Video.Thumb.Height = message.Video.Thumb.Height;
                    ParsedMessage.Video.Thumb.Width = message.Video.Thumb.Width;
                    ParsedMessage.Video.Width = message.Video.Width;
                }
                else if (message.Contact != null)
                {
                    ParsedMessage.Contact.FirstName = message.Contact.FirstName;
                    ParsedMessage.Contact.LastName = message.Contact.LastName;
                    ParsedMessage.Contact.PhoneNumber = message.Contact.PhoneNumber;
                    ParsedMessage.Contact.UserId = message.Contact.UserId;
                }
                else if (message.Location != null)
                {
                    ParsedMessage.Location.Latitude = message.Location.Latitude;
                    ParsedMessage.Location.Longitude = message.Location.Longitude;
                }
                return ParsedMessage;
            }
            catch (Exception ex)
            {
                OnError(this, ex);
                return null;
            }

        }
        Telegram.Bot.Types.Message DeParsedMessage = new Telegram.Bot.Types.Message();
        public Telegram.Bot.Types.Message DeParseMessage(Plugin.Client.Message message)
        {
            try
            {
                if (!string.IsNullOrEmpty(message.Text))
                {
                    DeParsedMessage.MessageId = message.MessageId;
                    DeParsedMessage.Date = message.Date;
                    DeParsedMessage.From.FirstName = message.From.FirstName;
                    DeParsedMessage.From.Id = message.From.Id;
                    DeParsedMessage.From.LastName = message.From.LastName;
                    DeParsedMessage.From.Username = message.From.Username;
                    DeParsedMessage.Chat.Id = message.Chat.Id;
                    DeParsedMessage.ForwardFrom.FirstName = message.ForwardFrom.FirstName;
                    DeParsedMessage.ForwardFrom.Id = message.ForwardFrom.Id;
                    DeParsedMessage.ForwardFrom.LastName = message.ForwardFrom.LastName;
                    DeParsedMessage.ForwardFrom.Username = message.ForwardFrom.Username;
                    //public Message ReplayToMessage;
                    DeParsedMessage.Text = message.Text;
                    DeParsedMessage.NewChatParticipant.FirstName = message.NewChatParticipant.FirstName;
                    DeParsedMessage.NewChatParticipant.Id = message.NewChatParticipant.Id;
                    DeParsedMessage.NewChatParticipant.LastName = message.NewChatParticipant.LastName;
                    DeParsedMessage.NewChatParticipant.Username = message.NewChatParticipant.Username;
                    DeParsedMessage.LeftChatParticipant.FirstName = message.LeftChatParticipant.FirstName;
                    DeParsedMessage.LeftChatParticipant.Id = message.LeftChatParticipant.Id;
                    DeParsedMessage.LeftChatParticipant.LastName = message.LeftChatParticipant.LastName;
                    DeParsedMessage.LeftChatParticipant.Username = message.LeftChatParticipant.Username;
                    DeParsedMessage.NewChatTitle = message.NewChatTitle;
                    DeParsedMessage.DeleteChatPhoto = message.DeleteChatPhoto;
                    DeParsedMessage.GroupChatCreated = message.DeleteChatPhoto;
                }
                else if (message.Audio != null)
                {
                    DeParsedMessage.Audio.Duration = message.Audio.Duration;
                    DeParsedMessage.Audio.FileId = message.Audio.FileId;
                    DeParsedMessage.Audio.FileSize = message.Audio.FileSize;
                    DeParsedMessage.Audio.MimeType = message.Audio.MimeType;
                }
                else if (message.Document != null)
                {
                    DeParsedMessage.Document.FileId = message.Document.FileId;
                    DeParsedMessage.Document.FileName = message.Document.FileName;
                    DeParsedMessage.Document.FileSize = message.Document.FileSize;
                    DeParsedMessage.Document.MimeType = message.Document.MimeType;
                    DeParsedMessage.Document.Thumb.FileId = message.Document.Thumb.FileId;
                    DeParsedMessage.Document.Thumb.FileSize = message.Document.Thumb.FileSize;
                    DeParsedMessage.Document.Thumb.Height = message.Document.Thumb.Height;
                    DeParsedMessage.Document.Thumb.Width = message.Document.Thumb.Width;
                }
                else if (message.Photo != null)
                {
                    for (int i = 0; i < message.Photo.Length; i++)
                    {
                        DeParsedMessage.Photo[i].FileId = message.Photo[i].FileId;
                        DeParsedMessage.Photo[i].FileSize = message.Photo[i].FileSize;
                        DeParsedMessage.Photo[i].Height = message.Photo[i].Height;
                        DeParsedMessage.Photo[i].Width = message.Photo[i].Width;
                    }
                    for (int i = 0; i < message.NewChatPhoto.Length; i++)
                    {
                        DeParsedMessage.NewChatPhoto[i].FileId = message.NewChatPhoto[i].FileId;
                        DeParsedMessage.NewChatPhoto[i].FileSize = message.NewChatPhoto[i].FileSize;
                        DeParsedMessage.NewChatPhoto[i].Height = message.NewChatPhoto[i].Height;
                        DeParsedMessage.NewChatPhoto[i].Width = message.NewChatPhoto[i].Width;

                    }
                }
                else if (message.Sticker != null)
                {
                    DeParsedMessage.Sticker.FileId = message.Sticker.FileId;
                    DeParsedMessage.Sticker.FileSize = message.Sticker.FileSize;
                    DeParsedMessage.Sticker.Height = message.Sticker.Height;
                    DeParsedMessage.Sticker.Thumb.FileId = message.Sticker.Thumb.FileId;
                    DeParsedMessage.Sticker.Thumb.FileSize = message.Sticker.Thumb.FileSize;
                    DeParsedMessage.Sticker.Thumb.Height = message.Sticker.Thumb.Height;
                    DeParsedMessage.Sticker.Thumb.Width = message.Sticker.Thumb.Width;
                    DeParsedMessage.Sticker.Width = message.Sticker.Width;
                }
                else if (message.Video != null)
                {
                    DeParsedMessage.Video.Caption = message.Video.Caption;
                    DeParsedMessage.Video.Duration = message.Video.Duration;
                    DeParsedMessage.Video.FileId = message.Video.FileId;
                    DeParsedMessage.Video.FileSize = message.Video.FileSize;
                    DeParsedMessage.Video.Height = message.Video.Height;
                    DeParsedMessage.Video.MimeType = message.Video.MimeType;
                    DeParsedMessage.Video.Thumb.FileId = message.Video.Thumb.FileId;
                    DeParsedMessage.Video.Thumb.FileSize = message.Video.Thumb.FileSize;
                    DeParsedMessage.Video.Thumb.Height = message.Video.Thumb.Height;
                    DeParsedMessage.Video.Thumb.Width = message.Video.Thumb.Width;
                    DeParsedMessage.Video.Width = message.Video.Width;
                }
                else if (message.Contact != null)
                {
                    DeParsedMessage.Contact.FirstName = message.Contact.FirstName;
                    DeParsedMessage.Contact.LastName = message.Contact.LastName;
                    DeParsedMessage.Contact.PhoneNumber = message.Contact.PhoneNumber;
                    DeParsedMessage.Contact.UserId = message.Contact.UserId;
                }
                else if (message.Location != null)
                {
                    DeParsedMessage.Location.Latitude = message.Location.Latitude;
                    DeParsedMessage.Location.Longitude = message.Location.Longitude;
                }
            }
            catch (Exception ex)
            {
                OnError(this, ex);
                return null;
            }
            return DeParsedMessage;
        }
        public Telegram.Bot.Types.ReplyMarkup ParseReplyKeyboardMarkup(TeleGraph.Plugin.Client.ReplyKeyboardMarkup ReplyKeyboardMarkup)
        {
            try
            {
                Telegram.Bot.Types.ReplyKeyboardMarkup R = new Telegram.Bot.Types.ReplyKeyboardMarkup();
                R.Keyboard = ReplyKeyboardMarkup.Keyboard;
                R.OneTimeKeyboard = ReplyKeyboardMarkup.OneTimeKeyboard;
                R.ResizeKeyboard = ReplyKeyboardMarkup.ResizeKeyboard;
                R.Selective = ReplyKeyboardMarkup.Selective;
                return R;
            }
            catch (Exception ex)
            {
                OnError(this, ex);
                return null;
            }

        }
    }
}
