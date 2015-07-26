# TeleGraph
TeleGraph is a Telegram bot manager that support Plugins, each plugin can do everything with telegram.
test
   public void OnReviceMessage(Message message)
        {
            try
            {
                if (message.Type == MessageType.TextMessage)
                {
                    if (message.Text.StartsWith(config.Commands.GetName("start")))
                    {
                        string[][] Keyboard = new string[4][];
                        Keyboard[0] = new string[3] { "⭕️ 7", "⭕️ 8", "⭕️ 9" };
                        Keyboard[1] = new string[3] { "⭕️ 4", "⭕️ 5", "⭕️ 6" };
                        Keyboard[2] = new string[3] { "⭕️ 1", "⭕️ 2", "⭕️ 3" };
                        Keyboard[3] = new string[1] { "⭕️ 0" };

                        ReplyKeyboardMarkup ReplayMarkup = new ReplyKeyboardMarkup();
                        ReplayMarkup.Keyboard = Keyboard;
                        ReplayMarkup.OneTimeKeyboard = true;
                        ReplayMarkup.ResizeKeyboard = false;
                        ReplayMarkup.Selective = false;

                        client.SendTextMessage(message.Chat.Id, message.From.FirstName + " sent " + message.Text + " command", true, 0, ReplayMarkup);
                    }
                    else if (message.Text.StartsWith(config.Commands.GetName("finish")))
                        client.SendTextMessage(message.Chat.Id, message.From.FirstName + " sent " + message.Text + " command", true, 0);
                    else if (message.Text.StartsWith(config.Commands.GetName("roll")))
                        client.SendTextMessage(message.Chat.Id, message.From.FirstName + " sent " + message.Text + " command", true, 0);
                }
                //this line send message to bot (its just for testing and internal reasens)
                pluginadaptor.OnMessage(this, "From: " + message.From.FirstName + " Chat_ID: " + message.Chat.Id + Environment.NewLine +
                                              "Message: " + message.Text + Environment.NewLine);
            }
            catch(Exception ex)
            {
                pluginadaptor.OnError(this, ex);
            }      
        }
