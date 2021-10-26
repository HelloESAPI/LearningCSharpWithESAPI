using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

namespace IntroToBinaryPlugins
{
  public class MainViewModel
  {
    public string CurrentPlan { get; set; }

    // constructor
    public MainViewModel(PlanSetup planSetup)
    {
      CurrentPlan = planSetup.Id;
    }
  }
}
