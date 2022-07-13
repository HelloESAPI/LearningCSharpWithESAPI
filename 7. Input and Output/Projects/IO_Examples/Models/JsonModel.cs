using EsapiDataLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_Examples.Models
{
  public class JsonModel
  {
    public static List<Patient> LoadPatients(string jsonFilePath)
    {
      using (StreamReader r = new StreamReader(jsonFilePath))
      {
        string json = r.ReadToEnd();
        return JsonConvert.DeserializeObject<List<Patient>>(json);
      }
    }

    public static List<GenericBeam> LoadBeams(string jsonFilePath)
    {
      using (StreamReader r = new StreamReader(jsonFilePath))
      {
        string json = r.ReadToEnd();
        return JsonConvert.DeserializeObject<List<GenericBeam>>(json);
      }
    }
  }
}
