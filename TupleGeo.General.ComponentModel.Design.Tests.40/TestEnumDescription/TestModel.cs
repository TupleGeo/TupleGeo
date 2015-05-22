using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace TupleGeo.General.ComponentModel.Design.Tests.TestEnumDescription {

  /// <summary>
  /// 
  /// </summary>
  public sealed class TestModel {

    private int _anInteger;

    /// <summary>
    /// 
    /// </summary>
    [CategoryAttribute("Numbers")]
    public int AnInteger {
      get {
        return _anInteger;
      }
      set {
        _anInteger = value;
      }
    }

    private string _aString;

    /// <summary>
    /// 
    /// </summary>
    [CategoryAttribute("Strings")]
    public string AString {
      get {
        return _aString;
      }
      set {
        _aString = value;
      }
    }

    private double _aDouble;

    /// <summary>
    /// 
    /// </summary>
    [CategoryAttribute("Numbers")]
    public double ADouble {
      get {
        return _aDouble;
      }
      set {
        _aDouble = value;
      }
    }

    private string _aSecondString;

    /// <summary>
    /// 
    /// </summary>
    [CategoryAttribute("Strings")]
    public string ASecondString {
      get {
        return _aSecondString;
      }
      set {
        _aSecondString = value;
      }
    }

    private TestEnum _testEnumValue;

    /// <summary>
    /// 
    /// </summary>
    [Editor(typeof(EnumDescriptionEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(EnumDescriptionConverter))]
    [CategoryAttribute("Enumerations")]
    public TestEnum TestEnumValue {
      get {
        return _testEnumValue;
      }
      set {
        _testEnumValue = value;
      }
    }

    private float _aFloat;

    /// <summary>
    /// 
    /// </summary>
    [CategoryAttribute("Numbers")]
    public float AFloat {
      get {
        return _aFloat;
      }
      set {
        _aFloat = value;
      }
    }

  }

}
