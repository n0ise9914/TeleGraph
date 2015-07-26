# About
TeleGraph is a Telegram bot manager that support Plugins, each plugin can do everything with telegram.

#Library
+ TeleGraph.dll: It's for main Application (bot manager) , in include PluginManager, Telegram API...
+ TeleGraph.Plugin.dll: It's for Plugins

#Plugin

```csharp
public void OnReviceMessage(Message message)
{
    //this line send message to application console.
    pluginadaptor.OnMessage(this, message.Text);    
}
```
TeleGraph
