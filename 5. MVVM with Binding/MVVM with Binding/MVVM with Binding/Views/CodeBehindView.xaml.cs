using EsapiDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_with_Binding.Views
{
  /// <summary>
  /// Interaction logic for CodeBehindView.xaml
  /// </summary>
  public partial class CodeBehindView : Window
  {

    #region Private Properties

    private Random _random { get; set; }

    private Structure _selectedStructure;
    private StructureSet _structureSet;
    private List<Structure> _structures;
    private List<string> _availableStructureSetIds;
    private string _selectedStructureSetId;

    #endregion

    public CodeBehindView()
    {
      InitializeComponent();
      SetRandom();
      SetTitle();
      GetAvailableStructureSetIds();
    }

    #region Methods

    /// <summary>
    /// Sets the title
    /// </summary>
    private void SetTitle()
    {
      tb_Title.Text = "Simple Binding Example";
    }

    /// <summary>
    /// Creates an instance of a random to be used throughout -> a single instance is used to ensure numbers are different
    /// </summary>
    private void SetRandom()
    {
      _random = new Random();
    }

    /// <summary>
    /// Gets the list of ordered structures from the structure set
    /// </summary>
    private void GetStructures()
    {
      if (_structureSet != null)
      {
        _structures = _structureSet.Structures.OrderBy(x => x.Id).ToList();
        cmb_Structures.ItemsSource = _structures;
        cmb_Structures.SelectedIndex = 0;

        SetStructurePropertiesInView();
      }
    }

    private void SetStructurePropertiesInView()
    {
      if (cmb_Structures.SelectedItem != null)
      {
        _selectedStructure = cmb_Structures.SelectedItem as Structure;

        tb_StructureId.Text = _selectedStructure.Id;
        tb_StructureColor.Fill = _selectedStructure.Color;
        tb_StructureDicomType.Text = _selectedStructure.DicomType;
        tb_StructureMaxDose.Text = _selectedStructure.MaxDose.ToString();
        tb_StructureMeanDose.Text = _selectedStructure.MeanDose.ToString();
        tb_StructureVolume.Text = _selectedStructure.Volume.ToString();
      }
      
    }

    /// <summary>
    /// Gets a structure set from the esapi data library 
    /// </summary>
    private void SetSelectedStructureSet()
    {
      _selectedStructureSetId = cmb_AvailableStructureSets.SelectedItem.ToString();
      _structureSet = EsapiDataLibrary.Data.Structures.GetSampleStructureSet(_selectedStructureSetId, EsapiDataLibrary.Data.Structures.GetStructureSet(_selectedStructureSetId), _random);
      tb_SelectedStructureSetId.Text = _selectedStructureSetId.ToString();
      GetStructures();
    }

    /// <summary>
    /// Gets the list of structure set ids that are currently available in the dummy data library
    /// </summary>
    private void GetAvailableStructureSetIds()
    {
      _availableStructureSetIds = EsapiDataLibrary.Data.Structures.GetAvailableStructureSetIds();
      cmb_AvailableStructureSets.ItemsSource = _availableStructureSetIds;
    }

    #endregion

    #region View Event Methods

    /// <summary>
    /// Event that fires when a selection is made in the ComboBox containing the available 
    /// structure set ids
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cmb_AvailableStructureSets_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      SetSelectedStructureSet();
    }

    /// <summary>
    /// Event that fires when a selection is made in the ComboBox containing the available 
    /// structures
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cmb_Structures_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      SetStructurePropertiesInView();
    }

    #endregion

  }
}
