using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

[assembly: AssemblyVersion("1.0.0.1")]

namespace VMS.TPS
{
  public class Script
  {
    public Script()
    {
    }


    // structure lists -- used for filtering
    private List<Structure> gtvs = new List<Structure>();
    private List<Structure> ctvs = new List<Structure>();
    private List<Structure> ptvs = new List<Structure>();
    private List<Structure> oars = new List<Structure>();
    private List<Structure> structures = new List<Structure>();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Execute(ScriptContext context /*, System.Windows.Window window, ScriptEnvironment environment*/)
    {
      // Conditional Statements -> Truth Statements
      // - If, else if, else
      // - switch
      // - one liners -- aka conditional operators

      // if statements
      if (context.Patient == null || context.StructureSet == null || context.PlanSetup == null)
      {
        MessageBox.Show("Please open a patient and structure set...");
        return;
      }


      // OR => ||
      // AND => &&



      //foreach (var s in context.StructureSet.Structures)
      foreach (var s in context.StructureSet.Structures.Where(x => x.IsEmpty == false && x.HasSegment == true)) // one liner
      {
        //if (s.HasSegment == true && s.IsEmpty == false)
        //{
        if (s.Id.ToUpper().Contains("GTV"))
        {
          gtvs.Add(s);
        }
        else if (s.Id.ToUpper().Contains("CTV"))
        {
          ctvs.Add(s);
        }
        else if (s.Id.ToUpper().Contains("PTV"))
        {
          ptvs.Add(s);
        }
        else
        {
          if (s.Id.ToUpper().Contains("COUCH") == false) 
          { 
            oars.Add(s); 
            structures.Add(s); 
          }
        }
        //}
      }

      // clear the lists of structures
      //gtvs.Clear();
      //ctvs.Clear();
      //ptvs.Clear();
      //oars.Clear();

      // switch statement - or case switch
      // loop through structures that have a segment and are not empty
      foreach (var s in context.StructureSet.Structures.Where(x => x.IsEmpty == false && x.HasSegment == true))
      {
        switch (s.DicomType)
        {
          case "GTV":
            if (gtvs.Contains(s) == false) // example of ignoring duplicates
            {
              gtvs.Add(s);
            }
            break;
          case "CTV":
            ctvs.Add(s);
            break;
          case "PTV":
            ptvs.Add(s);
            break;
          case "ORGAN":
            oars.Add(s);
            break;

          default:
            //structures.Add(s);
            break;
        }
      }

      // example of filtering out duplicates
      //foreach (var gtv in gtvs.Distinct())
      //{

      //}


      // conditional operators -> ?:
      foreach (var s in context.StructureSet.Structures)
      {

        // long way 
        //string isEmpty = string.Empty;
        //if (s.IsEmpty == true)
        //{
        //  isEmpty = "Yes";
        //}
        //else
        //{
        //  isEmpty = "No";
        //}

        // one line truth test
        string isEmpty = (s.IsEmpty == true) ? "Yes" : "No";
        string isPTV = s.DicomType == "PTV" ? "Yes" : "No";
        string targetType = s.DicomType == "PTV" ? "PTV" : s.DicomType == "CTV" ? "CTV" : "Other";
        bool isPTVBoolean = s.DicomType == "PTV" ? true : false;

        if (isPTVBoolean == true)
        {
          // do stuff...
        }

        bool isPTVBooleanSimplified = s.DicomType == "PTV";
      }
    }
  }
}
