
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

#endregion

namespace TupleGeo.General.Serialization {

  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public static class LinqXmlSerializer<T> where T : class, new() {

    private static Dictionary<Type, PropertyInfo[]> props = new Dictionary<Type, PropertyInfo[]>();

    public static string Serialize(T instance) {
      Type t = typeof(T);
      PropertyInfo[] pis = null;
      lock (props) {
        if (!props.TryGetValue(t, out pis)) {
          PropertyInfo[] ps = t.GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
          props.Add(t, ps);
        }
        pis = props[t];
      }

      XElement xd = new XElement(t.Name);
      pis.ForEach(p => {

        object val = null;
        PropertyCaller<T>.GenGetter g = PropertyCaller<T>.CreateGetMethod(p);
        val = g(instance);
        if (val == null)
          val = "null";
        XAttribute xa = new XAttribute(p.Name, val);
        xd.Add(xa);
      });

      return xd.ToString();
    }

    public static T Deserialize(XElement xd) {
      Type t = typeof(T);
      PropertyInfo[] pis = null;
      lock (props) {
        if (!props.TryGetValue(t, out pis)) {
          PropertyInfo[] ps = t.GetProperties(BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance);
          props.Add(t, ps);
        }
        pis = props[t];
      }
      IEnumerable<XAttribute> ix = xd.Attributes();

      T lilt = new T();
      pis.ForEach(p => {
        string propname = p.Name;
        var att = (from xat in ix
                   where xat.Name.LocalName == p.Name
                   select xat).FirstOrDefault();
        if (att != null) {
          PropertyCaller<T>.GenSetter s = PropertyCaller<T>.CreateSetMethod(p);
          object val = Converter(p.PropertyType, att.Value);
          s(lilt, val);
        }
      });
      return lilt;
    }

    public static object Converter(Type t, string value) {
      object retval = null;
      string checkType = string.Empty;
      bool valueset = false;
      if (t.IsGenericType) {
        checkType = t.GetGenericArguments()[0].FullName;
        if (value == "null") {
          valueset = true;
          retval = null;
        }
      }
      else
        checkType = t.FullName;

      if (!valueset) {
        switch (t.FullName) {
          case "System.Int32":
            retval = new Int32Converter().ConvertFrom(value);
            break;
          case "System.Double":
            retval = new DoubleConverter().ConvertFrom(value);
            break;
          case "System.Decimal":
            retval = new DecimalConverter().ConvertFrom(value);
            break;
          case "System.Boolean":
            retval = new BooleanConverter().ConvertFrom(value);
            break;
          case "System.DateTime":
            retval = new DateTimeConverter().ConvertFrom(value);
            break;
          default:
            retval = value;
            break;
        }
      }
      return retval;
    }
  }
}
