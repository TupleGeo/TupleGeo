using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace XDocParser {

  public class ClassFactory<K> where K : class {

    private delegate K CtorDelegate();
    private static Dictionary<Type, CtorDelegate> ctorDels = new Dictionary<Type, CtorDelegate>();
    private Type m_GenType;

    public ClassFactory() {
      m_GenType = typeof(K);
      InitDelegate();
    }

    private void InitDelegate() {
      if (!ctorDels.ContainsKey(m_GenType)) {
        DynamicMethod dm = new DynamicMethod("", m_GenType, null, m_GenType);
        ILGenerator il = dm.GetILGenerator();
        il.Emit(OpCodes.Newobj, m_GenType.GetConstructor(new Type[] { }));
        il.Emit(OpCodes.Ret);

        ctorDels.Add(m_GenType, (CtorDelegate)dm.CreateDelegate(typeof(CtorDelegate)));
      }
    }

    public K CreateClass() {
      CtorDelegate ctor = null;
      ctorDels.TryGetValue(m_GenType, out ctor);
      if (ctor != null)
        return ctor();
      return null;
    }
    
  }

}
