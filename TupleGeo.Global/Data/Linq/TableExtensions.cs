using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.ComponentModel;

namespace TupleGeo.Global.Data.Linq {


  public static class TableExtensions {

    
    public static Table<TEntity> GetTable<TEntity>(this DataContext context, string sEntityPropertyName) where TEntity : class {

      #region Dynamic Table Invocation

      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(context);
      PropertyDescriptor pDescriptor = properties[sEntityPropertyName];
      object table = pDescriptor.GetValue(context);
      Type genericType = pDescriptor.PropertyType.GetGenericTypeDefinition();
      
      //System.Data.Linq.Table<View_FC_POI> linqTable = new Table<View_FC_POI>();

      //System.Converter<object, System.Data.Linq.Table<View_FC_POI>> converter = new Converter<object, Table<View_FC_POI>>(;
      
      //= (System.Data.Linq.Table<View_FC_POI>)table;

      ////var table = _context.View_FC_POIs;

      //var query =
      //  from   r in linqTable
      //  select r;
      #endregion

      return null;

    }

  }

}
