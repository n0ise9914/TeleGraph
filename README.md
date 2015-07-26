# About
+ C# [telegram](http://telegram.com/) bot manager library that support plugins.
+ this library uses [telegram.bot](https://github.com/MrRoundRobin/telegram.bot)
+ **comment and issues: [https://telegram.me/joinchat/060d07870156dae55c15917453296746](https://telegram.me/joinchat/060d07870156dae55c15917453296746)**
 
#Library
DLL | Summery
--- | ---
**TeleGraph.dll** | main application (bot manager) use it.
**TeleGraph.Plugin.dll** | plugins use this to connect to main app.

#Make Plugin
+ [Plugin Sample](https://github.com/MaxbuzzTM/TeleGraph/tree/master/Sample/Sample_Plugin)
+ Each plugin should have a main.cs class implemented from TeleGram.Plugin.Imain.
+ All message's from Telegram come into OnReviceMessage() method in plugin.
```csharp
public void OnReviceMessage(Message message)
{
    //this line send message to application console.
    pluginadaptor.OnMessage(this, message.Text);    
}
```
+ Sending messages from plugin is using pluginadaptor.Client
```csharp
pluginadaptor.Client.SendTextMessage(message.Chat.Id, "Your Message.");
```
