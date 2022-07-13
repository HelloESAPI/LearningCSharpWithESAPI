using EsapiDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_Examples.Models
{
  public class JsModel
  {
    /// <summary>
    /// Saves/Writes using string builder - returns stopwatch that only accounts for time to compile the string data
    /// </summary>
    /// <param name="structureSet"></param>
    /// <param name="loopSize"></param>
    /// <param name="pathToWriteTo"></param>
    /// <returns></returns>
    public static Stopwatch SaveTestDataWithStringBuilder(ConsoleX.ConsoleUI ui, StructureSet structureSet, int loopSize, string pathToWriteTo)
    {
      // timer
      Stopwatch sw = new Stopwatch();
      sw.Start();

      // stringbuilder to hold string data
      StringBuilder jsData = new StringBuilder();
      jsData.Append("let stringBuilderData = {\"StructureData\" : [");

      // set ui progress bar color
      ui.ProgressBarColor = ConsoleColor.Cyan;

      // add structure list info for each iteration through loop
      for (int i = 0; i < loopSize; i++)
      {
        foreach (var s in structureSet.Structures)
        {
          AppendStringDataToStringBuilder(jsData, s);
        }
        // update progress
        ui.WriteProgressBar(((i + 1) * 100) / loopSize, true);
      }
      // remove last comma
      jsData.Length--; // essentially removes the last index by reducing its length by one
      // close structure data list
      jsData.Append("]");
      // stop the clock
      sw.Stop();
      // add the elapsed seconds and minutes to the js data object
      jsData.Append($",\"Elapsed\":{{\"Seconds\" : {sw.Elapsed.TotalSeconds},\"Milliseconds\":{sw.Elapsed.TotalMilliseconds}}},\"NumberOfLoops\": {loopSize}" +
        $"}}"); // have to close the js object
      // write the data to file
      File.WriteAllText(pathToWriteTo, jsData.ToString()); // have to call the ToString() method

      // return the stopwatch in case want to print the time in the application
      return sw;
    }
    /// <summary>
    /// Helper Method to test using stringbuilder
    /// </summary>
    /// <param name="stringBuilder"></param>
    /// <param name="s"></param>
    private static void AppendStringDataToStringBuilder(StringBuilder stringBuilder, Structure s)
    {
      stringBuilder.Append($"{{\"Id\":\"{s.Id}\"," +
                        $"\"DicomType\":\"{s.DicomType}\"," +
                        $"\"Volume\":\"{s.Volume}\"," +
                        $"\"Color\":\"{s.Color}\"," +
                        $"\"RGBColorString\":\"{s.RGBString}\"," +
                        $"\"MaxDose\":\"{s.MaxDose}\"," +
                        $"\"MeanDose\":\"{s.MeanDose}\"" +
                        $"}},");
      //string.Format("{\"Id\":{0},\"DicomType\":{1}", s.Id, s.DicomType, ....);
    }
    /// <summary>
    /// Saves/Writes data using string +=... - returns stopwatch that only accounts for time to compile the string data
    /// </summary>
    /// <param name="structureSet"></param>
    /// <param name="loopSize"></param>
    /// <param name="pathToWriteTo"></param>
    /// <returns></returns>
    public static Stopwatch SaveTestDataWithString(ConsoleX.ConsoleUI ui, StructureSet structureSet, int loopSize, string pathToWriteTo, string pathToLogProgressTo = "", bool logProgress = false)
    {
      // timer
      Stopwatch sw = Stopwatch.StartNew();

      // string data
      string jsData = "let stringAdditionData = {\"StructureData\" : [";

      // set ui progress bar color
      ui.ProgressBarColor = ConsoleColor.DarkCyan;

      // add structure list info for each iteration through loop
      for (int i = 0; i < loopSize; i++)
      {
        // if user wants to log progress 
        if (logProgress)
        {
          // get the data for each structure, timing each one
          foreach (var s in structureSet.Structures)
          {
            // use a timer to log the time it takes for each iteration
            // create and start the timer
            Stopwatch stopwatch = Stopwatch.StartNew();
            jsData = GetStructureDataString(jsData, s);
            // stop the timer
            stopwatch.Stop();
            File.AppendAllText(pathToLogProgressTo, $"loop={i};characters={jsData.Length};seconds={stopwatch.Elapsed.TotalSeconds};\n");
          }
        }
        else // if not logging the progress, just do the work
        {
          foreach (var s in structureSet.Structures)
          {
            jsData = GetStructureDataString(jsData, s);
          }
        }

        // update progress
        ui.WriteProgressBar(((i + 1) * 100) / loopSize, true);
      }

      // remove the last comma
      jsData.TrimEnd(',');
      // close the structure list
      jsData += "]";
      // stop the clock
      sw.Stop();
      // add the elapsed seconds and minutes to the js data object
      jsData += $",\"Elapsed\":{{\"Seconds\" : {sw.Elapsed.TotalSeconds},\"Milliseconds\":{sw.Elapsed.TotalMilliseconds}}},\"NumberOfLoops\": {loopSize}" +
        $"}}"; // have to close the js object
      // write the data to file
      File.WriteAllText(pathToWriteTo, jsData);


      // return the stopwatch in case want to print the time in the application
      return sw;
    }
    /// <summary>
    /// Helper Method to get basic structure data
    /// </summary>
    /// <param name="jsData"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    private static string GetStructureDataString(string structureDataString, Structure s)
    {
      structureDataString += $"{{\"Id\": \"{s.Id}\"," +
                  $"\"DicomType\":\"{s.DicomType}\"," +
                  $"\"Volume\":\"{s.Volume}\"," +
                  $"\"Color\":\"{s.Color}\"," +
                  $"\"RGBColorString\":\"{s.RGBString}\"," +
                  $"\"MaxDose\":\"{s.MaxDose}\"," +
                  $"\"MeanDose\":\"{s.MeanDose}\"" +
                  $"}},";
      return structureDataString;
    }
    // string data types are immutable - cannot be edited
    // stringbuilder objects are mutable - can be edited
  }
}
