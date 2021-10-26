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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Execute(ScriptContext context /*, System.Windows.Window window, ScriptEnvironment environment*/)
    {
      // Truth Statements
      // - If, else if, else
      // - switch case
      // - one liners


      // if statements
      if (context.Patient == null || context.StructureSet == null || context.PlanSetup == null)
      {
        MessageBox.Show("Please open a patient and structure set...");
        return;
      }

      // filter structures into different lists
      List<Structure> gtvs = new List<Structure>();
      List<Structure> ctvs = new List<Structure>();
      List<Structure> ptvs = new List<Structure>();
      List<Structure> oars = new List<Structure>();


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
          oars.Add(s);
        }
        //}
      }

      // clear the lists of structures
      gtvs.Clear();
      ctvs.Clear();
      ptvs.Clear();
      oars.Clear();

      // switch case statement - or case switch

      // loop through structures that have a segment and are not empty
      foreach (var s in context.StructureSet.Structures.Where(x => x.IsEmpty == false && x.HasSegment == true))
      {
        switch (s.DicomType)
        {
          case "GTV":
            gtvs.Add(s);
            break;
          case "CTV":
            ctvs.Add(s);
            break;
          case "PTV":
            ptvs.Add(s);
            break;

          default:
            oars.Add(s);
            break;
        }
      }


      // example one liners
      foreach (var s in context.StructureSet.Structures)
      {

        // long way 
        string isEmpty = string.Empty;
        if (s.IsEmpty == true)
        {
          isEmpty = "Yes";
        }
        else
        {
          isEmpty = "No";
        }

        // one line truth test
        isEmpty = s.IsEmpty == true ? "Yes" : "No";
        string isPTV = s.DicomType == "PTV" ? "Yes" : "No";
        bool isPTVBoolean = s.DicomType == "PTV" ? true : false;
        bool isPTVBooleanSimplified = s.DicomType == "PTV";
      }
    }
  }
}
