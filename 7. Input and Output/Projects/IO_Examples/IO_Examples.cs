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
    private static string _pathToFile;

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
        string patientDataPath = projectDir + @"\ExampleFileData\ExamplePatientData.json";
        string beamDataPath = projectDir + @"\ExampleFileData\ExampleBeamData.json";

        List<EsapiDataLibrary.Models.Patient> patients = JsonModel.LoadPatients(patientDataPath);
        Console.WriteLine("Patients collected from JSON");

        List<EsapiDataLibrary.Models.GenericBeam> beams = JsonModel.LoadBeams(beamDataPath);
        Console.WriteLine("Beams collected from JSON");


      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
      }


      Console.WriteLine("Done...");
      Console.ReadLine();

    }


  }
}
