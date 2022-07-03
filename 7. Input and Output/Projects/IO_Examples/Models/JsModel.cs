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
    public static Stopwatch SaveTestDataWithStringBuilder(StructureSet structureSet, int loopSize, string pathToWriteTo)
    {
      StringBuilder jsData = new StringBuilder();
      jsData.Append("let stringBuilderData = {\"StructureData\" : [");

      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; i < loopSize; i++)
      {
        foreach (var s in structureSet.Structures)
        {
          AppendStringDataToStringBuilder(jsData, s);
        }
      }
      jsData.Length--; // essentially removes the last index by reducing its length by one
      // close structure data list
      jsData.Append("]");
      // stop the clock
      sw.Stop();
      // add the elapsed seconds and minutes to the js data object
      jsData.Append($",\"Elapsed\":{{\"Seconds\" : {sw.Elapsed.TotalSeconds},\"Milliseconds\":{sw.Elapsed.Milliseconds}}},\"NumberOfLoops\": {loopSize}" +
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
    }
    /// <summary>
    /// Saves/Writes data using string +=... - returns stopwatch that only accounts for time to compile the string data
    /// </summary>
    /// <param name="structureSet"></param>
    /// <param name="loopSize"></param>
    /// <param name="pathToWriteTo"></param>
    /// <returns></returns>
    public static Stopwatch SaveTestDataWithString(StructureSet structureSet, int loopSize, string pathToWriteTo)
    {
      string jsData = "let stringAdditionData = {\"StructureData\" : [";
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; i < loopSize; i++)
      {
        foreach (var s in structureSet.Structures)
        {
          jsData = GetStructureDataString(jsData, s);
        } 
      }
      // remove the last comma
      jsData.TrimEnd(',');
      // close the structure list
      jsData += "]";
      // stop the clock
      sw.Stop();
      // add the elapsed seconds and minutes to the js data object
      jsData += $",\"Elapsed\":{{\"Seconds\" : {sw.Elapsed.TotalSeconds},\"Milliseconds\":{sw.Elapsed.Milliseconds}}}," + $"\"NumberOfLoops\": {loopSize}" +
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
  }
}
