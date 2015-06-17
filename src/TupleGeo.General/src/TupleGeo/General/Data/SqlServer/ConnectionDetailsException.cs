
#region Header
// Title Name       : ConnectionDetailsException
// Member of        : TupleGeo.General.dll
// Description      : The exception used for problems with the ConnectionDetails.
// Created by       : 29/05/2015, 05:21, Vasilis Vlastaras.
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
using System.Runtime.Serialization;
using System.Text;

#endregion

namespace TupleGeo.General.Data.SqlServer {

  /// <summary>
  /// The exception used for problems with the <see cref="ConnectionDetails"/>.
  /// </summary>
  [SerializableAttribute()]
  public sealed class ConnectionDetailsException : Exception {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="ConnectionDetailsException"/>.
    /// </summary>
    public ConnectionDetailsException() {
      
    }

    /// <summary>
    /// Initializes the <see cref="ConnectionDetailsException"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public ConnectionDetailsException(string message)
      : base(message) {

    }

    /// <summary>
    /// Initializes the <see cref="ConnectionDetailsException"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception.</param>
    public ConnectionDetailsException(string message, Exception innerException)
      : base(message, innerException) {

    }

    /// <summary>
    /// Initializes the <see cref="ConnectionDetailsException"/>.
    /// </summary>
    /// <param name="info">The SerializationInfo.</param>
    /// <param name="context">The StreamingContext.</param>
    private ConnectionDetailsException(SerializationInfo info, StreamingContext context)
      : base(info, context) {

    }

    #endregion

  }

}
