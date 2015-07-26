# About
+ C# [telegram](http://telegram.com/) bot manager library that support plugins.
+ this library uses [telegram.bot](https://github.com/MrRoundRobin/telegram.bot)

#Library
DLL | Summery
--- | ---
**TeleGraph.dll** | Main Application (bot manager) use it.
**TeleGraph.Plugin.dll** | Plugins use this to connect to Main App.

#Make Plugin

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
TeleGraph
