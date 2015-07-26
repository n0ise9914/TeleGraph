using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleGraph.Plugin.Client;

namespace TeleGraph
{
    class ClientAdapter : Plugin.IClient
    {
        public delegate void _OnError(object sender, Exception ex);
        public event _OnError OnError;

        private Parser MessageParser = new Parser();
        private Telegram.Bot.Api api;
        public Telegram.Bot.Api Api
        {
            set
            {
                api = value;
            }
        }
        private int id;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public delegate void _OnTaskDone(Task<Telegram.Bot.Types.Message> task);
        public event _OnTaskDone OnTaskDone;
        private Parser parser = new Parser();
        public void SendTextMessage(int chatId, string text, bool disableWebPagePreview = false, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                var res = api.SendTextMessage(chatId, text, disableWebPagePreview, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup));
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void ForwardMessage(int chatId, int fromChatId, int messageId)
        {
            try
            {
                OnTaskDone(api.ForwardMessage(chatId, fromChatId, messageId));
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }

        }
        public void SendPhoto(int chatId, FileToSend photo, string caption = "", int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                Telegram.Bot.Types.FileToSend File = new Telegram.Bot.Types.FileToSend();
                File.Content = photo.Content;
                File.Filename = photo.Filename;

                OnTaskDone(api.SendPhoto(chatId, File, caption, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }

        }
        public void SendPhoto(int chatId, string photo, string caption = "", int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                OnTaskDone(api.SendPhoto(chatId, photo, caption, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendAudio(int chatId, FileToSend audio, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                Telegram.Bot.Types.FileToSend File = new Telegram.Bot.Types.FileToSend();
                File.Content = audio.Content;
                File.Filename = audio.Filename;

                OnTaskDone(api.SendAudio(chatId, File, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendAudio(int chatId, string audio, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                OnTaskDone(api.SendAudio(chatId, audio, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendDocument(int chatId, FileToSend document, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                Telegram.Bot.Types.FileToSend File = new Telegram.Bot.Types.FileToSend();
                File.Content = document.Content;
                File.Filename = document.Filename;

                OnTaskDone(api.SendDocument(chatId, File, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendDocument(int chatId, string document, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                OnTaskDone(api.SendDocument(chatId, document, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendSticker(int chatId, FileToSend sticker, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                Telegram.Bot.Types.FileToSend File = new Telegram.Bot.Types.FileToSend();
                File.Content = sticker.Content;
                File.Filename = sticker.Filename;

                OnTaskDone(api.SendSticker(chatId, File, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendSticker(int chatId, string sticker, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                OnTaskDone(api.SendSticker(chatId, sticker, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendVideo(int chatId, FileToSend video, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                Telegram.Bot.Types.FileToSend File = new Telegram.Bot.Types.FileToSend();
                File.Content = video.Content;
                File.Filename = video.Filename;

                OnTaskDone(api.SendVideo(chatId, File, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendVideo(int chatId, string video, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                OnTaskDone(api.SendVideo(chatId, video, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendLocation(int chatId, float latitude, float longitude, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null)
        {
            try
            {
                OnTaskDone(api.SendLocation(chatId, latitude, longitude, replyToMessageId, parser.ParseReplyKeyboardMarkup(ReplyKeyboardMarkup)));

            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
        public void SendChatAction(int chatId, ChatAction chatAction)
        {
            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    OnError(this, ex);
            //}
        }
        public UserProfilePhotos GetUserProfilePhotos(int userId, int? offset = default(int?), int limit = 100)
        {
            //try
            //{
            //    object o = await api.GetUserProfilePhotos(userId, offset, limit);
            //}
            //catch (Exception ex)
            //{
            //    OnError(this, ex);
            //}
            return null;
        }

    }
}
