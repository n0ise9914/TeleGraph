# About
TeleGraph is a Telegram bot manager that support Plugins, each plugin can do everything with telegram.

#Library
DLL | Summery
--- | ---
**TeleGraph.dll** | Main Application (bot manager) use it.
**TeleGraph.Plugin.dll** | Plugins use this to connect to Main App.

#Make Plugin
+Each plugin should have a main.cs class implemented from TeleGram.Plugin.Imain.
+All message's from Telegram come into OnReviceMessage() method in plugin.
```csharp
public void OnReviceMessage(Message message)
{
    //this line send message to application console.
    pluginadaptor.OnMessage(this, message.Text);    
}
```
+You can send message's by Client
```csharp
pluginadaptor.Client.SendTextMessage(message.Chat.Id, "Your Message.");
```
TeleGraph
