using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.Windows.Media;
using IO_Examples.Models;
using EsapiDataLibrary.Models;
using System.Diagnostics;
using ConsoleX;
using System.IO;

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
    private static string _projectDir;
    private static string _logFilePath;
    private static int _loopSize;
    private static bool _logException = false;

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

      // Reading/Writing Files:
      // using System.IO; -> input / output operations
      //byte[] bytes = File.ReadAllBytes(_pathToFile);
      //string[] lines = File.ReadAllLines(_pathToFile/*, encoding*/);
      //string text = File.ReadAllText(_pathToFile/*, encoding*/);

      #region Variable Definitions

      // ui
      ConsoleUI ui = new ConsoleUI();
      // timer used to log time required to run program
      Stopwatch swTotalLogTime = Stopwatch.StartNew();

      // get the current project directory so it can be used to write the data
      _projectDir = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\debug", "");

      // log file path
      _logFilePath = _projectDir + @"\ExampleFileData\Logs\log.txt";

      // read
      string jsonPatientDataPath = _projectDir + @"\ExampleFileData\ExamplePatientData.json";
      string jsonBeamDataPath = _projectDir + @"\ExampleFileData\ExampleBeamData.json";
      string csvBeamDataPath = _projectDir + @"\ExampleFileData\ExampleBeamData.csv";
      // write
      string jsDataStringPath = _projectDir + @"\ExampleFileData\Output\jsDataString.js";
      string jsDataStringBuilderPath = _projectDir + @"\ExampleFileData\Output\jsDataStringBuilder.js";

      // timer used for individual tasks
      Stopwatch sw = new Stopwatch();

      #endregion

      try
      {

        #region CSV -> .csv

        // .csv -> CSV File: Comma Separated Value - think simplified spreadsheet where a comma defines a new column (unless wrapped in quotes)

        // very useful for reading/writing data as it can be visualized/made using an excel spreadsheet

        // limited as it can be challenging to read/write nested levels of data, e.g., an object that has another object as a property 

        // to save something like plan data to a csv, all of the data for a plan would have to be in a single column or in a separate file

        // for saving this info, you would need a solution that works for you, perhaps a folder for each course, then each plan, etc. and then in each folder have a file for each of the objects in the plan, e.g., beams, structures, etc. 

        // one solution is to include each level of data descriptor in every row...e.g., patient id, course id, plan id, structure set id, structure id, etc. in every single row...so that when you're analyzing your data, you know how to group it. this leads to a lot of duplicated information

        // CSV files lend especially well to saving or reading specific object data that doesn't need to be nested/layered
        // e.g., reading beam template data, constraint data, etc...
        sw.Start();
        List<GenericBeam> beamsFromCsv = CsvModel.LoadBeams(csvBeamDataPath);
        sw.Stop();

        ui.Write($"  {beamsFromCsv.Count} beams collected from .csv in {sw.ElapsedMilliseconds} ms");



        #endregion


        #region JSON -> .json


        // .json -> JSON File : JavaScript object notation - similar to a key : value pair where the value can be one of the following: 
        // string -> ""
        // number
        // another object -> { }
        // array -> [ ]
        // boolean -> true, false
        // null

        // json files lend well to reading nested object data, e.g., Plan has a structure set which has structures, etc. 
        // JSON files are data only files - this means they only contain data in the form of json objects...comments, other code, etc. is not allowed - that's where js files come in

        // add space between csv section
        ui.SkipLines(2);


        // example 1: loading a dummy patient object - nested data objects
        // restart the timer for this task
        sw.Restart();
        List<EsapiDataLibrary.Models.Patient> patientsFromJson = JsonModel.LoadPatients(jsonPatientDataPath);
        sw.Stop();
        // example of string interpolation
        ui.Write($"  {patientsFromJson.Count} patients collected from .json in {sw.Elapsed.TotalMilliseconds} ms");
        // string.Format()
        //ui.Write(string.Format("\n\n  {0} patients collected from .json in {1} ms", patientsFromJson.Count, sw.ElapsedMilliseconds));

        // example 2: beam template data from JSON - e.g., inserted beams for use in autoplanning
        sw.Restart();
        List<GenericBeam> beamsFromJson = JsonModel.LoadBeams(jsonBeamDataPath);
        sw.Stop();
        ui.Write($"  {beamsFromJson.Count} beams collected from .json in {sw.Elapsed.TotalMilliseconds} ms");




        #endregion


        #region JS -> .js

        // .js -> JavaScript file -> a file that contains javascript code - these are useful when reading data for static html documents when you don't have a web server running

        // js - JavaScript files - these are similar to JSON files but can have comments, other javascript code, and can be read by static html documents that don't have a running web server
        // get a test structureset
        EsapiDataLibrary.Models.StructureSet testStructureSet = EsapiDataLibrary.Data.Structures.GetSampleStructureSet("ProstateTest",
          EsapiDataLibrary.Data.Structures.GetStructureSet("Prostate"), new Random());

        // add some space
        ui.SkipLines(2);

        // get loop size from the user
        _loopSize = ui.GetIntInput("How big should our loop be?");

        // add some space
        ui.SkipLines(2);


        // test saving the structure data using the string addition method
        Stopwatch stringAdditionStopwatch = JsModel.SaveTestDataWithString(ui, testStructureSet, _loopSize, jsDataStringPath);
        ui.SkipLines(1);
        ui.Write($"  {_loopSize} iterations of structure data saved using string addition ( += ): {stringAdditionStopwatch.Elapsed.TotalSeconds} total seconds");
        ui.SkipLines(2);


        // test saving the structure data using the string concatenation method (string builder)
        Stopwatch stringBuilderStopwatch = JsModel.SaveTestDataWithStringBuilder(ui, testStructureSet, _loopSize, jsDataStringBuilderPath);
        ui.SkipLines(1);
        ui.Write($"  {_loopSize} iterations of structure data saved using string builder (concatenation): {stringBuilderStopwatch.Elapsed.TotalSeconds} total seconds");
        ui.SkipLines(2);


        ////create and throw an exception as a test
        //Exception exception = new Exception();
        //throw exception;


        // now let's test why the string addition takes longer...
        // path to log the progress of string addition for each iteration
        string jsDataStringLogPath = _projectDir + $@"\ExampleFileData\Logs\log.progresslog.{_loopSize}.txt";

        // test saving the structure data using the string addition method but while logging the progress
        Stopwatch stringAdditionStopwatchWithLog = JsModel.SaveTestDataWithString(ui, testStructureSet, _loopSize, jsDataStringPath, jsDataStringLogPath, true);
        ui.SkipLines(1);
        ui.Write($"  {_loopSize} iterations of structure data saved using string addition (with progress log): {stringAdditionStopwatchWithLog.Elapsed.TotalSeconds} total seconds\n  - Check the progress log for more information:\n  {jsDataStringLogPath.Replace(_projectDir, "")}");


        // recap
        // add space
        ui.SkipLines(3);
        ui.Write($"  Summary:\n\n  {_loopSize} iterations took \n\t{stringAdditionStopwatch.Elapsed.TotalSeconds} total seconds using string addition ( += )\n\t{stringBuilderStopwatch.Elapsed.TotalSeconds} total seconds for string builder (concatenation)\n\t{stringAdditionStopwatchWithLog.Elapsed.TotalSeconds} total seconds for string addition ( += ) with a progress log");
        // add space
        ui.SkipLines(3);






        #endregion


        #region Stopwatch

        // stop total log time
        swTotalLogTime.Stop();

        #endregion

      }
      catch (Exception ex)
      {
        _logException = true;

        ui.Write(ex.Message);
        ui.Write(ex.StackTrace);

        swTotalLogTime.Stop();
        LoggerModel.LogInformation(string.Format("applicationsuccess=false;{0};totalseconds={1};\n--begin exception detail--\nMessage:\n{2}\nInnerException:\n{3}\n\nStackTrace:\n{4}\n--end exception detail--\n\n", DateTime.Now.ToString(), swTotalLogTime.Elapsed.TotalSeconds, ex.Message, ex.InnerException, ex.StackTrace), _logFilePath);
      }

      #region TXT -> .txt

      // .txt -> Text File - useful for logging, etc. and you don't care about columns, etc. 
      // parsing these requires the knowledge of how the file is structured/formatted when written

      // if the timer is still running, there was an error that occurred...
      if (_logException == false)
      {
        LoggerModel.LogInformation(string.Format("applicationsuccess=true;{0};totalseconds={1};\n\n", DateTime.Now.ToString(), swTotalLogTime.Elapsed.TotalSeconds), _logFilePath);
      }

      #endregion

      ui.Write("\n\n  Done. Press any key to exit...");
      Console.ReadKey();
    }


  }
}
