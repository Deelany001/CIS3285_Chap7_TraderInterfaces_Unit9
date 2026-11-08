
using System;
using System.IO;
using System.Xml.Linq;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class ConsoleLogger : ILogger
{
    public void LogMessage(string message, params object[] args)
    {
        Console.WriteLine(message, args);

        string logMessage = string.Format(message, args);
        string filePath = "trade-log.xml";

        XDocument document;

        if (File.Exists(filePath))
        {
            document = XDocument.Load(filePath);
        }
        else
        {
            document = new XDocument(new XElement("Logs"));
        }

        document.Root!.Add(
            new XElement("Log",
                new XElement("Date", DateTime.Now),
                new XElement("Message", logMessage)
            )
        );

        document.Save(filePath);
    }
}
