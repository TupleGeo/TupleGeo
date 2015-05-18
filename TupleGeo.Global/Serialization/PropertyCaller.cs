
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

#endregion

namespace TupleGeo.Global.Serialization {

  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public static class PropertyCaller<T> {
    
    public delegate void GenSetter(T target, System.Object value);
    public delegate System.Object GenGetter(T target);

    private static Dictionary<Type, Dictionary<Type, Dictionary<string, GenGetter>>> _getsDic = new Dictionary<Type, Dictionary<Type, Dictionary<string, GenGetter>>>();
    private static Dictionary<Type, Dictionary<Type, Dictionary<string, GenSetter>>> _setsDic = new Dictionary<Type, Dictionary<Type, Dictionary<string, GenSetter>>>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pi"></param>
    /// <returns></returns>
    public static GenGetter CreateGetMethod(PropertyInfo propertyInfo) {

      Type classType = typeof(T);
      Type propType = propertyInfo.PropertyType;
      string sPropName = propertyInfo.Name;

      Dictionary<Type, Dictionary<string, GenGetter>> i1 = null;
      if (_getsDic.TryGetValue(classType, out i1)) {
        Dictionary<string, GenGetter> i2 = null;
        if (i1.TryGetValue(propType, out i2)) {
          GenGetter i3 = null;
          if (i2.TryGetValue(sPropName, out i3)) {
            return i3;
          }
        }
      }

      //If there is no getter, return nothing
      MethodInfo getMethod = propertyInfo.GetGetMethod();
      if (getMethod == null) {
        return null;
      }

      //Create the dynamic method to wrap the internal get method
      Type[] arguments = new Type[1] { classType };

      DynamicMethod getter = new DynamicMethod(String.Concat("_Get", propertyInfo.Name, "_"), typeof(object), new Type[] { typeof(T) }, classType);
      ILGenerator generator = getter.GetILGenerator();
      generator.DeclareLocal(propType);
      generator.Emit(OpCodes.Ldarg_0);
      generator.Emit(OpCodes.Castclass, classType);
      generator.EmitCall(OpCodes.Callvirt, getMethod, null);
      if (!propType.IsClass)
        generator.Emit(OpCodes.Box, propType);
      generator.Emit(OpCodes.Ret);

      //Create the delegate and return it
      GenGetter genGetter = (GenGetter)getter.CreateDelegate(typeof(GenGetter));

      Dictionary<Type, Dictionary<string, GenGetter>> tempDict = null;
      Dictionary<string, GenGetter> tempPropDict = null;
      if (!_getsDic.ContainsKey(classType)) {
        tempPropDict = new Dictionary<string, GenGetter>();
        tempPropDict.Add(sPropName, genGetter);
        tempDict = new Dictionary<Type, Dictionary<string, GenGetter>>();
        tempDict.Add(propType, tempPropDict);
        _getsDic.Add(classType, tempDict);
      }
      else {
        if (!_getsDic[classType].ContainsKey(propType)) {
          tempPropDict = new Dictionary<string, GenGetter>();
          tempPropDict.Add(sPropName, genGetter);
          _getsDic[classType].Add(propType, tempPropDict);
        }
        else {
          if (!_getsDic[classType][propType].ContainsKey(sPropName)) {
            _getsDic[classType][propType].Add(sPropName, genGetter);
          }
        }
      }
      return genGetter;
    }

    public static GenSetter CreateSetMethod(PropertyInfo pi) {
      Type classType = typeof(T);
      Type propType = pi.PropertyType;
      string propName = pi.Name;

      Dictionary<Type, Dictionary<string, GenSetter>> i1 = null;
      if (_setsDic.TryGetValue(classType, out i1)) {
        Dictionary<string, GenSetter> i2 = null;
        if (i1.TryGetValue(propType, out i2)) {
          GenSetter i3 = null;
          if (i2.TryGetValue(propName, out i3)) {
            return i3;
          }
        }
      }

      //If there is no setter, return nothing
      MethodInfo setMethod = pi.GetSetMethod();
      if (setMethod == null) {
        return null;
      }

      //Create dynamic method
      Type[] arguments = new Type[2] { classType, typeof(object) };

      DynamicMethod setter = new DynamicMethod(String.Concat("_Set", pi.Name, "_"), typeof(void), arguments, classType);
      ILGenerator generator = setter.GetILGenerator();
      generator.Emit(OpCodes.Ldarg_0);
      generator.Emit(OpCodes.Castclass, classType);
      generator.Emit(OpCodes.Ldarg_1);

      if (propType.IsClass)
        generator.Emit(OpCodes.Castclass, propType);
      else
        generator.Emit(OpCodes.Unbox_Any, propType);

      generator.EmitCall(OpCodes.Callvirt, setMethod, null);
      generator.Emit(OpCodes.Ret);

      //Create the delegate and return it
      GenSetter genSetter = (GenSetter)setter.CreateDelegate(typeof(GenSetter));

      Dictionary<Type, Dictionary<string, GenSetter>> tempDict = null;
      Dictionary<string, GenSetter> tempPropDict = null;
      if (!_setsDic.ContainsKey(classType)) {
        tempPropDict = new Dictionary<string, GenSetter>();
        tempPropDict.Add(propName, genSetter);
        tempDict = new Dictionary<Type, Dictionary<string, GenSetter>>();
        tempDict.Add(propType, tempPropDict);
        _setsDic.Add(classType, tempDict);
      }
      else {
        if (!_setsDic[classType].ContainsKey(propType)) {
          tempPropDict = new Dictionary<string, GenSetter>();
          tempPropDict.Add(propName, genSetter);
          _setsDic[classType].Add(propType, tempPropDict);
        }
        else {
          if (!_setsDic[classType][propType].ContainsKey(propName)) {
            _setsDic[classType][propType].Add(propName, genSetter);
          }
        }
      }

      return genSetter;
    }
  }

}
