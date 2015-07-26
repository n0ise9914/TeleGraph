using System;
using System.Threading;
using Telegram.Bot.Types;

namespace TeleGraph
{
    public class Client
    {
        public delegate void _OnUpdateRecived(object sender, Telegram.Bot.Types.Message message);
        public event _OnUpdateRecived OnUpdateRecived;
        public delegate void _OnConnected(object sender, User me);
        public event _OnConnected OnConnected;
        public delegate void _OnError(object sender, Exception ex);
        public event _OnError OnError;
        public Telegram.Bot.Api Api;
        public Client(string _token)
        {
            token = _token;
            Api = new Telegram.Bot.Api(token);         
        }
        private int updatedelay;
        public int UpdateDelay
        {
            get
            {
                return updatedelay;
            }
            set
            {
                updatedelay = value;
            }
        }
        private string token;
        public async void Connect()
        {
            try
            {
                var me = await Api.GetMe();
                OnConnected(this, me);
                Thread trd = new Thread(this.GetUpdates);
                trd.Start();
            }
            catch (Exception Ex)
            {
                OnError(this, Ex);
            }

        }
        private int lastupdate_id;
        public int LastUpdate_ID
        {
            get
            {
                return lastupdate_id;
            }
            set
            {
                lastupdate_id = value;
            }
        }
        private async void GetUpdates()
        {
            try
            {
                while (true)
                {
                    Update[] updates = await Api.GetUpdates(lastupdate_id, 100);
                    if (updates.Length != 0) lastupdate_id = updates[updates.Length - 1].Id + 1;
                    foreach (Update update in updates)
                    {
                        OnUpdateRecived(this, update.Message);
                    }
                    Thread.Sleep(updatedelay);
                }
            }
            catch (Exception ex)
            {
                OnError(this, ex);
            }
        }
    }
}
