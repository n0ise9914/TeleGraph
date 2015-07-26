using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleGraph.Plugin;
using TeleGraph.Plugin.Client;

namespace TeleGraph.Plugin
{
    public interface IClient : IConversation
    {
       // void SendMessage(int chatId, string text, bool disableWebPagePreview = false, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendTextMessage(int chatId, string text, bool disableWebPagePreview = false, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void ForwardMessage(int chatId, int fromChatId, int messageId);
        void SendPhoto(int chatId, FileToSend photo, string caption = "", int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendPhoto(int chatId, string photo, string caption = "", int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
       // void ReSendPhoto(int chatId, string photo, string caption = "", int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
       // void SendAudio(int chatId, FileToSend audio, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendAudio(int chatId, string audio, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
      //  void ReSendAudio(int chatId, string audio, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendDocument(int chatId, FileToSend document, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendDocument(int chatId, string document, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
      //  void ReSendDocument(int chatId, string document, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendSticker(int chatId, FileToSend sticker, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendSticker(int chatId, string sticker, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
       // void ReSendSticker(int chatId, string sticker, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendVideo(int chatId, FileToSend video, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendVideo(int chatId, string video, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
      //  void ReSendVideo(int chatId, string video, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendLocation(int chatId, float latitude, float longitude, int replyToMessageId = 0, ReplyKeyboardMarkup ReplyKeyboardMarkup = null);
        void SendChatAction(int chatId, ChatAction chatAction);
        UserProfilePhotos GetUserProfilePhotos(int userId, int? offset = null, int limit = 100);    
    }
}
