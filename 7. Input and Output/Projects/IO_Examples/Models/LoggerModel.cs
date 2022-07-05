using System.IO;

namespace IO_Examples.Models
{
  public class LoggerModel
  {
    public static void LogInformation(string logMessage, string logFilePath)
    {
      File.AppendAllText(logFilePath, logMessage);
    }
  }
}
