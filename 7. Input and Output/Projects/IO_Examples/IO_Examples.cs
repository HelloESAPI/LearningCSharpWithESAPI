using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.IO;
using System.Windows.Media;
using IO_Examples.Models;
using EsapiDataLibrary.Models;
using System.Diagnostics;

// TODO: Replace the following version attributes by creating AssemblyInfo.cs. You can do this in the properties of the Visual Studio project.
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]
[assembly: AssemblyInformationalVersion("1.0")]

// TODO: Uncomment the following line if the script requires write access.
// [assembly: ESAPIScript(IsWriteable = true)]

namespace IO_Examples
{
  class Program
  {
    private static bool _debug = true;

    [STAThread]
    static void Main(string[] args)
    {
      try
      {

        using (Application app = _debug ? null : Application.CreateApplication())
        {
          Execute(app);
        }
      }
      catch (Exception e)
      {
        Console.Error.WriteLine(e.ToString());
      }
    }
    static void Execute(Application app)
    {
      // Topics: 
      // WHY?
      // data collection, loading data from files, e.g., beam data
      
      // loading data from files vs hard coding
      // -> using data from files means things can be changed easily
      // -> when data is hard coded, the script must be edited, rebuilt, and reapproved in order to be useful again
      

      // File types?
      // .csv, .json, .js, and .txt

      // .csv -> CSV File: Comma Separated Value - think simplified spreadsheet where a comma defines a new column (unless wrapped in quotes)

      // .json -> JSON File : JavaScript object notation - similar to a key : value pair where the value can be one of the following: 
      // string -> ""
      // number
      // another object -> { }
      // array -> [ ]
      // boolean -> true, false
      // null
      // .js -> JavaScript file -> a file that contains javascript code - these are useful when reading data for static html documents when you don't have a web server running

      // .txt -> Text File - useful for logging, etc. and you don't care about columns, etc. 
      // parsing these requires the knowledge of how the file is structured/formatted when written


      // Reading Files:
      // using System.IO; -> input / output operations

      //byte[] bytes = File.ReadAllBytes(_pathToFile);
      //string[] lines = File.ReadAllLines(_pathToFile/*, encoding*/);
      //string text = File.ReadAllText(_pathToFile/*, encoding*/);

      // json...

      try
      {
        string projectDir = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\debug", "");
        string jsonPatientDataPath = projectDir + @"\ExampleFileData\ExamplePatientData.json";
        string jsonBeamDataPath = projectDir + @"\ExampleFileData\ExampleBeamData.json";
        string csvBeamDataPath = projectDir + @"\ExampleFileData\ExampleBeamData.csv";
        string jsDataStringPath = projectDir + @"\ExampleFileData\Output\jsDataString.js";
        string jsDataStringBuilderPath = projectDir + @"\ExampleFileData\Output\jsDataStringBuilder.js";
        string textLogFilePath = projectDir + @"\ExampleFileData\Output\log.txt";

        Stopwatch sw = new Stopwatch();

        // to save something like this in a csv, all of the structure data for a plan would have to be in a single column or in a separate file
        // for saving this info, you would likely have a folder for each course, then each plan, etc. and then in each folder have a file for each of the objects in the plan, e.g., beams, structures, etc. 
        // csv files can be limiting when you want layered/nested data...unless you include each level of data descriptor in every row...e.g., patien id, course id, plan id, structure set id, structure id, etc. in every single row...so that when you're analysing your data, you know how to group it.

        // CSV files lend well, though, to saving or reading specific object data that doesn't need to be nested/layered
        // e.g., reading beam template data, constraint data, etc...
        sw.Start();
        List<GenericBeam> beamsFromCsv = CsvModel.LoadBeams(csvBeamDataPath);
        sw.Stop();

        Console.WriteLine($"{beamsFromCsv.Count} beams collected from .csv in {sw.ElapsedMilliseconds} ms");


        // json files lend well to reading nested object data, e.g., Plan has a structure set which has structures, etc. 
        // JSON files are data only files - this means they only contain data in the form of json objects...comments, other code, etc. is not allowed - that's where js files come in
        sw.Restart();
        List<EsapiDataLibrary.Models.Patient> patientsFromJson = JsonModel.LoadPatients(jsonPatientDataPath);
        sw.Stop();
        Console.WriteLine($"{patientsFromJson.Count} patients collected from .json in {sw.ElapsedMilliseconds} ms");

        // beam template data from JSON - e.g., inserted beams for use in autoplanning
        sw.Restart();
        List<GenericBeam> beamsFromJson = JsonModel.LoadBeams(jsonBeamDataPath);
        sw.Stop();
        Console.WriteLine($"{beamsFromJson.Count} beams collected from .json in {sw.ElapsedMilliseconds} ms");

        // js - JavaScript files - these are similar to JSON files but can have comments, other javascript code, and can be read by static html documents that don't have a running web server
        // get a test structureset
        EsapiDataLibrary.Models.StructureSet testStructureSet = EsapiDataLibrary.Data.Structures.GetSampleStructureSet("ProstateTest",
          EsapiDataLibrary.Data.Structures.GetStructureSet("Prostate"), new Random());

        int loopSize = 1000;

        Stopwatch stringAdditionStopwatch = JsModel.SaveTestDataWithString(testStructureSet, loopSize, jsDataStringPath);
        Stopwatch stringBuilderStopwatch = JsModel.SaveTestDataWithStringBuilder(testStructureSet, loopSize, jsDataStringBuilderPath);

        Console.WriteLine($"{loopSize} iterations took \n\t{stringAdditionStopwatch.Elapsed.TotalSeconds} total seconds using string addition ( += )\n\t{stringBuilderStopwatch.Elapsed.TotalSeconds} total seconds for string builder (concatenation)");


      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
      }


      Console.WriteLine("Done. Press any key to exit...");
      Console.ReadKey();

    }


  }
}
