
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using TupleGeo.TemplateApplication.Engine;

#endregion

namespace TupleGeo.TemplateApplication {

  /// <summary>
  /// Performs application bootstrapping.
  /// </summary>
  public partial class Bootstrapper : Application {

    #region Event Procedures

    /// <summary>
    /// Occurs upon application exit.
    /// </summary>
    /// <param name="e">The <see cref="ExitEventArgs"/>.</param>
    protected override void OnExit(ExitEventArgs e) {
      base.OnExit(e);

      // TODO: Uncomment if saving the configuration is needed.
      //AppEngine.Instance.SaveConfiguration();

    }

    /// <summary>
    /// Occurs upon application startup.
    /// </summary>
    /// <param name="e">The <see cref="StartupEventArgs"/>.</param>
    protected override void OnStartup(StartupEventArgs e) {
      base.OnStartup(e);

      Initialize();

    }

    /// <summary>
    /// Logs an application unhandled exception.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The UnhandledExceptionEventArgs.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      AppEngine.LogError((Exception)e.ExceptionObject);
    }

    /// <summary>
    /// Logs a dispatcher unhandled exception.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The DispatcherUnhandledExceptionEventArgs.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
      AppEngine.LogError(e.Exception);
    }

    #endregion

    #region Private Procedures

    /// <summary>
    /// Initializes the application.
    /// </summary>
    private void Initialize() {

      // Catch unhandled exceptions.
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException); // Let's hope Dichpatcher unhandled exception is sufficient enough.

      // Read the configuration file.
      AppEngine.ReadConfiguration();

    }

    #endregion

  }

}
