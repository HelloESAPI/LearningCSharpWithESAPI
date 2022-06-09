using System.Reflection;
using System.Runtime.CompilerServices;
using VMS.TPS.Common.Model.API;
using System.Diagnostics;

[assembly: AssemblyVersion("1.0.0.1")]

namespace VMS.TPS
{
  public class Script
  {
    private string _pathToTheStandaloneExecutable = @"\\Path\To\Executable.exe";

    public Script()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Execute(ScriptContext context /*, System.Windows.Window window, ScriptEnvironment environment*/)
    {
      // TODO : Add here the code that is called when the script is launched from Eclipse.
      Process.Start(_pathToTheStandaloneExecutable);
    }
  }
}
