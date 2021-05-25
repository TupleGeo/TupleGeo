
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TupleGeo.General.ComponentModel;
using TupleGeo.Apps;
using TupleGeo.Apps.Presentation;
using TupleGeo.TemplateApplication.Engine;

#endregion

namespace TupleGeo.TemplateApplication.Models {

  /// <summary>
  /// The model used by the shell.
  /// </summary>
  public sealed class ShellModel : Model {

    #region Member Variables

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="ShellModel"/>.
    /// </summary>
    public ShellModel() {

    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the caption of the shell.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    public string Caption {
      get {
        if (AppEngine.Instance.ApplicationModel != null) {
          return AppEngine.Instance.ApplicationModel.Caption;
        }
        else {
          return "";
        }
      }
    }

    #endregion

    #region Event Procedures

    #endregion

    #region Private Procedures

    #endregion

    #region Model Members

    /// <summary>
    /// Gets the name of the model.
    /// </summary>
    public override string ModelName => "ShellModel";

    #endregion

  }

}
