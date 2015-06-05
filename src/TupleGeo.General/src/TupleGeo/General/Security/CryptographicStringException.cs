
#region Header
// Title Name       : CryptographicStringException
// Member of        : TupleGeo.General.dll
// Description      : The exception used for problems with the CryptographicString.
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
using System.Runtime.Serialization;
using System.Text;

#endregion

namespace TupleGeo.General.Security {

  /// <summary>
  /// The exception used for problems with the <see cref="CryptographicString"/>.
  /// </summary>
  [SerializableAttribute()]
  public sealed class CryptographicStringException : Exception {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CryptographicStringException"/>.
    /// </summary>
    public CryptographicStringException() {

    }

    /// <summary>
    /// Initializes the <see cref="CryptographicStringException"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public CryptographicStringException(string message)
      : base(message) {

    }

    /// <summary>
    /// Initializes the <see cref="CryptographicStringException"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception.</param>
    public CryptographicStringException(string message, Exception innerException)
      : base(message, innerException) {

    }

    /// <summary>
    /// Initializes the <see cref="CryptographicStringException"/>.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/>.</param>
    /// <param name="context">The <see cref="StreamingContext"/>.</param>
    private CryptographicStringException(SerializationInfo info, StreamingContext context)
      : base(info, context) {

    }

    #endregion

  }

}
