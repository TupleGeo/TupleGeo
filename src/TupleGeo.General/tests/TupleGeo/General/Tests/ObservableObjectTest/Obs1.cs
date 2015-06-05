using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TupleGeo.General.ComponentModel;

namespace TupleGeo.General.Tests.ObservableObjectTest {
  
  /// <summary>
  /// 
  /// </summary>
  public class Obs1 : ObservableObject<Obs1> {

    private int _int1;

    /// <summary>
    /// 
    /// </summary>
    public int Int1 {
      get {
        return _int1;
      }
      set {
        _int1 = value;
        this.OnPropertyChanged(p => p.Int1);
      }
    }

    private double _double1;

    /// <summary>
    /// 
    /// </summary>
    public double Double1 {
      get {
        return _double1;
      }
      set {
        _double1 = value;
        this.OnPropertyChanged(p => p.Double1);
      }
    }

    private string _string1;

    /// <summary>
    /// 
    /// </summary>
    public string String1 {
      get {
        return _string1;
      }
      set {
        _string1 = value;
        this.OnPropertyChanged(p => p.String1);
      }
    }

  }

}
