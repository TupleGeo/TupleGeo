
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TupleGeo.Apps;
using TupleGeo.General.ComponentModel;

#endregion

namespace TupleGeo.Apps.Presentation.Tests.ObserverTests {

  /// <summary>
  /// 
  /// </summary>
  public sealed class CarModel : ObservableObject<CarModel>, IModel {

    #region Member Variables

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CarModel"/>.
    /// </summary>
    public CarModel() {

    }

    #endregion

    #region Public Properties

    private int _id;

    /// <summary>
    /// 
    /// </summary>
    public int Id {
      get {
        return _id;
      }
      set {
        if (_id != value) {
          _id = value;
          this.OnPropertyChanged(m => m.Id);
        }
      }
    }

    private string _brand;

    /// <summary>
    /// 
    /// </summary>
    public string Brand {
      get {
        return _brand;
      }
      set {
        if (_brand != value) {
          _brand = value;
          this.OnPropertyChanged(m => m.Brand);
        }
      }
    }

    private int _weight;

    /// <summary>
    /// 
    /// </summary>
    public int Weight {
      get {
        return _weight;
      }
      set {
        if (_weight != value) {
          _weight = value;
          this.OnPropertyChanged(m => m.Weight);
        }
      }
    }

    private string _colour;

    /// <summary>
    /// 
    /// </summary>
    public string Colour {
      get {
        return _colour;
      }
      set {
        if (_colour != value) {
          _colour = value;
          this.OnPropertyChanged(m => m.Colour);
        }
      }
    }

    #endregion

    #region Event Procedures

    #endregion

    #region Private Procedures

    #endregion

    #region IModel Members

    private const string _modelName = "CarModel";

    /// <summary>
    /// Gets the name of the model.
    /// </summary>
    public string ModelName {
      get {
        return _modelName;
      }
    }

    #endregion

  }

}
