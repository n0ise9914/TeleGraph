# About
TeleGraph is a Telegram bot manager that support Plugins, each plugin can do everything with telegram.

#Library
+ TeleGraph.dll: Main Application (bot manager) use it.
+ TeleGraph.Plugin.dll: Plugins use this to connect to Main App.

#Plugin

```csharp
public void OnReviceMessage(Message message)
{
    //this line send message to application console.
    pluginadaptor.OnMessage(this, message.Text);    
}
```
TeleGraph
