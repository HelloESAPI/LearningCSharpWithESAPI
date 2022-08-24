using EsapiDataLibrary.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWithPrism.Events
{
  public class UpdateStructureDetailsEvent : PubSubEvent<Structure>
  {
  }
}
