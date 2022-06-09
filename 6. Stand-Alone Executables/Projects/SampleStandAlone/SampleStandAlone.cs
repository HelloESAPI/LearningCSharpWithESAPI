using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using ConsoleX;
using System.Threading;

// TODO: Replace the following version attributes by creating AssemblyInfo.cs. You can do this in the properties of the Visual Studio project.
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]
[assembly: AssemblyInformationalVersion("1.0")]

// TODO: Uncomment the following line if the script requires write access.
// [assembly: ESAPIScript(IsWriteable = true)]

namespace SampleStandAlone
{
  class Program
  {
    // patient id
    private static string _patientId;
    // state of whether patient is open
    private static bool _patientIsOpen = false;
    // patient
    private static Patient _patient;

    // debug mode
    private static bool DEBUG = true;
    // console
    private static ConsoleUI _ui;
    // continue?
    private static bool _continue = true;


    [STAThread]
    static void Main(string[] args)
    {
      try
      {
        if (DEBUG)
        {
          ExecuteWithOptions(null);
          //Execute(null);
        }
        else
        {
          using (Application app = Application.CreateApplication())
          {
            Execute(app);
          }
        }
      }
      catch (Exception e)
      {
        Console.Error.WriteLine(e.ToString());
      }
    }
    static void Execute(Application app)
    {

      _ui = new ConsoleUI();

      // TODO: Add your code here.
      //IEnumerable<PatientSummary> pSummaries = app.PatientSummaries;
      //IEnumerable<string> patientIds = app.PatientSummaries.Select(x => x.Id);

      // open the patient
      //foreach (var id in patientIds)
      //{
      // close if another patient is already open

      GetPatientOfInterest(app);

      if (_patientIsOpen)
      {
        if (DEBUG)
        {
          _ui.Write("Pretending to do work....");
          _ui.SkipLines(2);
        }
        else
        {
          try
          {
            // do stuff...
            if (_patient.Courses.Any(x => x.PlanSetups.Any(y => y.IsTreated && y.CreationDateTime >= DateTime.Now.AddDays(-7))))
            {
              // get or process patient data...

              // close patient
              ClosePatientIfOpen(app);
            }
            else
            {
              ClosePatientIfOpen(app);
            }
          }
          catch (Exception)
          {
            ClosePatientIfOpen(app);
          }
        }
      }
      _ui.Write("Work complete\n\nPress enter to exit...");
      Console.ReadLine();

    }

    private static void GetPatientOfInterest(Application app)
    {
      _ui.SkipLines(2);
      _patientId = _ui.GetStringInput("Please Enter a valid PATIENT ID...");
      _ui.Write($"attempting to open Patient with ID ({_patientId}) ");
      _patientIsOpen = ValidatePatientIdAndOpenIfValid(app);
      if (!_patientIsOpen)
      {
        GetPatientOfInterest(app);
      }
    }

    private static bool ValidatePatientIdAndOpenIfValid(Application app)
    {
      if (DEBUG)
      {
        _ui.Write($"Patient with ID ({_patientId}) has been opened....");
        return true;
      }
      else
      {


        // close other patient if still open
        ClosePatientIfOpen(app);

        // open the patient
        _patient = app.OpenPatientById(_patientId);

        // validate the patient
        if (_patient == null)
        {
          // alert user if patient id was invalid or the patient was not found
          _ui.WriteError("Invalid Patient ID - or could not open patient...");

          return false;
        }
        else
        {
          return true;
        }
      }
    }

    private static void ClosePatientIfOpen(Application app)
    {
      if (_patientIsOpen)
      {
        if (DEBUG)
        {
          _ui.Write($"Patient with ID {_patientId} closed....");
          _ui.SkipLines(2);
        }
        else
        {
          app.ClosePatient();
          _patientIsOpen = false;
        }
      }
    }

    static void ExecuteWithOptions(Application app)
    {
      while (_continue)
      {
        // create ui
        _ui = new ConsoleUI();

        // options for console app
        var options = new Dictionary<string, Action>();

        // add options w/ corresponding functions/tasks
        options.Add("Open Patient Of Interest", () => GetPatientOfInterest(app));
        options.Add("Get Patients With New Plans From The Last Week", () => GetRecentPatients());
        // can add more options
        options.Add("Save Recent Patient List To CSV", () => SaveDataToCsv());

        // exit option
        options.Add("Exit", () => { Exit(app); });

        _ui.GetResponseAndDoAction(options);
        _ui.SkipLines(2);
      }
    }

    /// <summary>
    /// Exits the application
    /// </summary>
    /// <param name="app"></param>
    private static void Exit(Application app)
    {
      if (DEBUG)
      {
        ClosePatientIfOpen(app);
        _ui.Write("Exiting....\n\nPress enter to exit...");
        _continue = false;
        Console.ReadLine();
      }
      else
      {
        _ui.Write("Exiting Application....\n\nPress enter to exit...");
        ClosePatientIfOpen(app);
        app.Dispose();
        _continue = false;
        Console.ReadLine();
      }
    }

    /// <summary>
    /// Saves data to file (csv)
    /// </summary>
    private static void SaveDataToCsv()
    {
      if (DEBUG)
      {
        _ui.Write("Pretending to save data...");
        _ui.ProgressBarColor = ConsoleColor.DarkCyan;
        for (int i = 0; i <= 100; i++)
        {
          Thread.Sleep(25);
          _ui.WriteProgressBar(i, true);
        }
      }
      else
      {
        // do actual work...
      }
    }

    /// <summary>
    /// Gets the recent patients that have been treated....
    /// </summary>
    private static void GetRecentPatients()
    {
      if (DEBUG)
      {
        _ui.Write("Pretending to look up recent patients that have been treated...");
        _ui.ProgressBarColor = ConsoleColor.Cyan;
        for (int i = 0; i <= 100; i++)
        {
          Thread.Sleep(50);
          _ui.WriteProgressBar(i, true);
        }
      }
      else
      {
        // do actual work...
      }
    }

  }
}
