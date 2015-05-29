
#region Header
// Title Name       : GeneralException
// Member of        : TupleGeo.General.dll
// Description      : The exception used for any kind of error thrown by TupleGeo libraries.
// Created by       : 29/05/2015, 05:20, Vasilis Vlastaras.
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace TupleGeo.General {

  /// <summary>
  /// The exception used for any kind of error thrown by TupleGeo libraries.
  /// </summary>
  [SerializableAttribute()]
  public sealed class GeneralException : Exception {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="GeneralException"/>.
    /// </summary>
    public GeneralException() {

    }

    /// <summary>
    /// Initializes the <see cref="GeneralException"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public GeneralException(string message)
      : base(message) {

    }

    /// <summary>
    /// Initializes the <see cref="GeneralException"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception.</param>
    public GeneralException(string message, Exception innerException)
      : base(message, innerException) {

    }

    #endregion

  }

}
