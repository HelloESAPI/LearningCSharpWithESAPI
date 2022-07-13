using EsapiDataLibrary.Models;
using EsapiDataLibrary.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_Examples.Models
{
  public class CsvModel
  {

    public static List<GenericBeam> LoadBeams(string csvBeamDataPath)
    {
      List<GenericBeam> beams = new List<GenericBeam>();

      foreach (var line in File.ReadAllLines(csvBeamDataPath))
      {
        string[] data = line.Split(',');
        if (data[0] != "BeamType") // ignore the header row
        {
          BeamType beamType;
          switch (data[0])
          {
            case "MlcBeam":
              beamType = BeamType.MlcBeam;
              break;
            case "MlcArcBeam":
              beamType = BeamType.MlcArcBeam;
              break;
            case "StaticBeam":
              beamType = BeamType.StaticBeam;
              break;
            case "SetupBeam":
              beamType = BeamType.SetupBeam;
              break;
            default:
              beamType = BeamType.StaticBeam;
              break;
          }
          GantryDirection gantryDirection;
          switch (data[16])
          {
            case "None":
              gantryDirection = GantryDirection.None;
              break;
            case "Clockwise":
              gantryDirection = GantryDirection.Clockwise;
              break;
            case "CounterClockwise":
              gantryDirection = GantryDirection.CounterClockwise;
              break;
            default:
              gantryDirection = GantryDirection.None;
              break;
          }
          List<int> validDoseRates = new List<int> { 100,200,300,400,600 };
          bool doseRateIsValidInteger = Int32.TryParse(data[5], out int doseRate);
          if (validDoseRates.Contains(doseRate) == false || doseRateIsValidInteger == false)
          {
            doseRate = 600;
          }

          bool x1IsValid = double.TryParse(data[9], out double x1);
          bool x2IsValid = double.TryParse(data[10], out double x2);
          bool y1IsValid = double.TryParse(data[11], out double y1);
          bool y2IsValid = double.TryParse(data[12], out double y2);
          //x1 = x1IsValid ? x1 : 10;
          if (x1IsValid == false || x2IsValid == false)
          {
            x1 = 10;
            x2 = 10;
          }
          if (y1IsValid == false || y2IsValid == false)
          {
            y1 = 10;
            y2 = 10;
          }
          VRect<double> jawPositions = new VRect<double> { X1 = x1, X2 = x2, Y1 = y1, Y2 = y2 };
          // would probably want to validate these others as well in a real application
          VVector iso = new VVector { x = double.Parse(data[18]), y = double.Parse(data[19]), z = double.Parse(data[20])};


          beams.Add(
          new GenericBeam
          {
            BeamType = beamType,
            Id = data[1],
            Comment = data[2],
            MachineParameters = new MachineParametersModel(data[3], data[4], doseRate, data[6], data[7]),
            LeafPositions = null, // should result in default leaf positions when null
            JawPositions = jawPositions,
            // would probably want to validate these others as well in a real application
            CollimatorAngle = double.Parse(data[13]), 
            GantryAngle = double.Parse(data[14]),
            GantryStop = double.Parse(data[15]),
            GantryDirection = gantryDirection,
            PatientSupportAngle = double.Parse(data[17]),
          }
          );
        }
        
      }

      return beams;
    }
  }
}
