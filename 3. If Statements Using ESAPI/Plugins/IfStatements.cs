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
      // truth test
      // if statement
      // if patient not open in eclipse
      if (context.Patient == null) // will enter logic if true
      {
        MessageBox.Show("Please open a patient");
        return;
      }
      // if a structure set not open in eclipse
      if (context.StructureSet == null) // will enter logic if true
      {
        MessageBox.Show("Please open a structureset");
        return;
      }

      // list of gtvs
      List<Structure> gtvs = new List<Structure>();
      // list of ctvs
      List<Structure> ctvs = new List<Structure>();
      // list of ptvs
      List<Structure> ptvs = new List<Structure>();
      // list of all other structures
      List<Structure> oars = new List<Structure>();

      // filter structures using if statment
      foreach (var s in context.StructureSet.Structures)
      {
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
      }


      // clear lists
      gtvs.Clear();
      ctvs.Clear();
      ptvs.Clear();
      oars.Clear();

      




    }
  }
}
