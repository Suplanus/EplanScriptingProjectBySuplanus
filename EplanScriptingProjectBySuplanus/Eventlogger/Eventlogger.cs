using System;
using System.Collections.Generic;
using System.IO;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;
using EventHandler = Eplan.EplApi.ApplicationFramework.EventHandler;

public class EventLogger
{
  EventHandler eventHandler = new EventHandler();

  [DeclareRegister]
  public void Register()
  {
    eventHandler.SetEvent("*");
    EventHandlerNameFunction eventHandlerNameFunction = Event;
    eventHandler.EplanNameEvent += eventHandlerNameFunction;
  }

  [DeclareUnregister]
  public void UnRegister()
  {
    eventHandler.Dispose();
  }

  private void Event(IEventParameter eventParameter, string eventName)
  {
    // Check Blacklist
    List<string> blackList = new List<string>
    {
      "onIdle.Bool.App",
      "onLastIdle.Bool.App",
      "onTimer.UInt.App"
    };

    if (blackList.Contains(eventName))
    {
      return;
    }

    // Get Parameter
    string parameter;
    try
    {
      EventParameterString eventParameterString = new EventParameterString(eventParameter);
      parameter = eventParameterString.String;
    }
    catch
    {
      parameter = string.Empty;
    }

    // Write log
    FileInfo fileInfo = new FileInfo(@"C:\Test\Events.txt");
    using (StreamWriter streamWriter = fileInfo.AppendText())
    {
      string line = string.Format("{1}{0}{2}{0}{3}",
        "\t",
        DateTime.Now.ToString("HH:mm:ss"),
        eventName,
        parameter);

      streamWriter.WriteLine(line);
    }
  }
}