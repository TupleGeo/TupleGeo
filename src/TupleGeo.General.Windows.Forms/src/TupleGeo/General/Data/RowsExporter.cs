
#region Header
// Title Name       : RowsExporter
// Member of        : TupleGeo.General.Windows.Forms.dll
// Description      : Exports rows from a series of sources.
// Created by       : 27/05/2009, 01:45, Vasilis Vlastaras.
// Updated by       : 16/06/2009, 14:52, Vasilis Vlastaras.
//                    1.0.1 - Added ExportXml method.
//                  : 24/06/2009, 00:12.
//                    1.0.2 - Added ExportHtml method.
//                  : 23/02/2011, 20:41, Vasilis Vlastaras.
//                    1.0.3 - File moved in to a new project specific for supporting Windows Forms Applications,
//                    Removed System.Linq to make the source file compatible with .NET Framework 2.0. and
//                    added preprocessor directives for the same reason.
//                  : 02/05/2014, 12:03, Vasilis Vlastaras.
//                    1.0.4 - Changed private method names.
//                  : 18/05/2015, 04:49, Vasilis Vlastaras
//                    1.0.5 - Changed class to static, cleaned file, added resource strings.
// Version          : 1.0.5
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using TupleGeo.General.Windows.Forms.Properties;

#endregion

namespace TupleGeo.General.Data {

  /// <summary>
  /// Exports rows from a series of sources.
  /// </summary>
  public static class RowsExporter {

    #region Public Methods

    /// <summary>
    /// Exports the contents of a <see cref="DataGridView"/> in to a text file.
    /// </summary>
    /// <param name="dataGridView">The <see cref="DataGridView"/> containing the rows to be exported.</param>
    /// <param name="streamWriter">
    /// The <see cref="StreamWriter"/> that will be used to write the rows.</param>
    /// <param name="exportSelected">
    /// Indicates whether all rows or the selected rows will be exported.
    /// </param>
    /// <param name="separator">
    /// The separator <see cref="string"/> used to separate the field values.
    /// </param>
    public static void ExportText(DataGridView dataGridView, StreamWriter streamWriter, bool exportSelected, string separator) {

      if (dataGridView == null) {
        throw new ArgumentNullException("dataGridView");
      }

      if (streamWriter == null) {
        throw new ArgumentNullException("streamWriter");
      }

      try {
        // Loops through the columns of the DataGridView and writes them using the stream writer.
        foreach (DataGridViewColumn colN in dataGridView.Columns) {
          if (colN.Visible) {
            streamWriter.Write(colN.Name);
            if (colN.Index != dataGridView.Columns.Count - 1) {
              streamWriter.Write(separator);
            }
            else {
              streamWriter.WriteLine();
            }
          }
        }

        if (exportSelected) {
          // Writes the selected rows in a stream.
          foreach (DataGridViewRow rowN in dataGridView.SelectedRows) {
            WriteRowString(dataGridView, separator, streamWriter, rowN);
          }
        }
        else {
          // Writes all rows in a stream.
          foreach (DataGridViewRow rowN in dataGridView.Rows) {
            WriteRowString(dataGridView, separator, streamWriter, rowN);
          }
        }
      }
      catch (Exception) {
        throw;
      }
      finally {
        streamWriter.Close();
      }
    }

    /// <summary>
    /// Exports the rows of a <see cref="DataGridView"/> as XML.
    /// </summary>
    /// <param name="dataGridView">The <see cref="DataGridView"/> containing the rows to be exported.</param>
    /// <param name="textWriter">
    /// The <see cref="TextWriter"/> that will be used to write the rows.</param>
    /// <param name="exportSelected">
    /// Indicates whether all rows or the selected rows will be exported.
    /// </param>
    public static void ExportXml(DataGridView dataGridView, TextWriter textWriter, bool exportSelected) {

      if (dataGridView == null) {
        throw new ArgumentNullException("dataGridView");
      }

      if (textWriter == null) {
        throw new ArgumentNullException("textWriter");
      }

      try {
        if (exportSelected) {
          if (dataGridView.SelectedRows.Count > 0) {
            XElement xElement = new XElement(XName.Get(dataGridView.SelectedRows[0].DataBoundItem.GetType().Name + "_Array")); // HARDCODE
            foreach (DataGridViewRow row in dataGridView.SelectedRows) {
              if (row.DataBoundItem != null) {
                xElement.Add(GetXElement(row.DataBoundItem));
              }
            }
            xElement.Save(textWriter);
          }
        }
        else {
          if (dataGridView.Rows.Count > 0) {
            XElement xElement = new XElement(XName.Get(dataGridView.Rows[0].DataBoundItem.GetType().Name + "_Array")); // HARDCODE
            foreach (DataGridViewRow row in dataGridView.Rows) {
              if (row.DataBoundItem != null) {
                xElement.Add(GetXElement(row.DataBoundItem));
              }
            }
            xElement.Save(textWriter);
          }
        }
      }
      catch (Exception) {
        throw;
      }
      finally {
        textWriter.Close();
      }

    }

    /// <summary>
    /// Exports the rows of a <see cref="DataGridView"/> as HTML.
    /// </summary>
    /// <param name="dataGridView">The <see cref="DataGridView"/> containing the rows to be exported.</param>
    /// <param name="textWriter">
    /// The <see cref="TextWriter"/> that will be used to write the rows.</param>
    /// <param name="exportSelected">
    /// Indicates whether all rows or the selected rows will be exported.
    /// </param>
    public static void ExportHtml(DataGridView dataGridView, TextWriter textWriter, bool exportSelected) {

      if (dataGridView == null) {
        throw new ArgumentNullException("dataGridView");
      }

      if (textWriter == null) {
        throw new ArgumentNullException("textWriter");
      }

      try {
        XNamespace xnsHtml = XNamespace.Get("http://www.w3.org/1999/xhtml");
        XElement xTableBody = new XElement(xnsHtml + "tbody");
        object sample = null;
        if (exportSelected) {
          if (dataGridView.SelectedRows.Count > 0) {
            sample = dataGridView.SelectedRows[0].DataBoundItem;
            foreach (DataGridViewRow row in dataGridView.SelectedRows) {
              if (row.DataBoundItem != null) {
                xTableBody.Add(GetRowElement(row.DataBoundItem));
              }
            }
          }
        }
        else {
          if (dataGridView.Rows.Count > 0) {
            sample = dataGridView.Rows[0].DataBoundItem;
            foreach (DataGridViewRow row in dataGridView.Rows) {
              if (row.DataBoundItem != null) {
                xTableBody.Add(GetRowElement(row.DataBoundItem));
              }
            }
          }
        }

        if (sample != null) {
          AttributeCollection atts = TypeDescriptor.GetAttributes(sample);
          string title = null;
          foreach (Attribute att in atts) {
            if (att.GetType() == typeof(DisplayNameAttribute)) {
              title = ((DisplayNameAttribute)att).DisplayName;
              break;
            }
          }
          if (title == null) {
            title = exportSelected ? Resources.Data_RowsExporter_SelectedRecords : Resources.Data_RowsExporter_AllRecords;
          }
          
          XElement xMeta = new XElement(xnsHtml + "meta", new XAttribute("http-equiv", "Content-Type"), new XAttribute("content", "text/html; charset=utf-8"));

          string styleContent = "body { font-family: Verdana; } table { font-size: 0.8em; border-collapse: collapse; }" +
              "thead tr:first-child { background: #BBB } tbody tr:nth-child(even) { background: #DDD } " +
              "tbody tr:nth-child(odd) { background: #FFF } th, td { border: thin solid black; padding: .2em; }";

          XElement xStyle = new XElement(xnsHtml + "style", new XAttribute("type", "text/css"), styleContent);
          XElement xHeader = new XElement(xnsHtml + "head", new XElement(xnsHtml + "title", title), xMeta, xStyle);

          XElement xTable = new XElement(xnsHtml + "table", GetHeaderElement(sample), xTableBody);
          XElement xBody = new XElement(xnsHtml + "body", new XElement(xnsHtml + "h1", title), xTable);

          XElement xHtml = new XElement(xnsHtml + "html", xHeader, xBody);

          XDocumentType doctype = new XDocumentType("html", "-//W3C//DTD XHTML 1.0 Transitional//EN", "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", null);
          XDocument doc = new XDocument(doctype, xHtml);

          doc.Save(textWriter);
        }
      }
      catch (Exception) {
        throw;
      }
      finally {
        textWriter.Close();
      }

    }

    #endregion

    #region Private Procedures

    /// <summary>
    /// Writes a string representing the contents of a <see cref="DataGridView"/>
    /// row in to the <see cref="StringBuilder"/>.
    /// </summary>
    /// <param name="dataGridView">
    /// The <see cref="DataGridView"/> containing the row.
    /// </param>
    /// <param name="separator">
    /// The separator <see cref="char"/> used to separate values in the string representing the row.
    /// </param>
    /// <param name="streamWriter">
    /// The <see cref="StreamWriter"/> used to write the row string.
    /// </param>
    /// <param name="row">
    /// The <see cref="DataGridViewRow"/> used to extract the field values from.
    /// </param>
    private static void WriteRowString(DataGridView dataGridView, string separator, StreamWriter streamWriter, DataGridViewRow row) {
      foreach (DataGridViewCell cellN in row.Cells) {
        if (cellN.OwningColumn.Name == Resources.Data_RowsExporter_ObjectId) {
          if (cellN.Value == null) {
            break;
          }
        }
        if (cellN.Value != null) {
          streamWriter.Write(cellN.Value.ToString().Replace("\r", "").Replace("\n", ""));
        }
        else {
          streamWriter.Write(Resources.Data_RowsExporter_NullValue);
        }
        if (cellN.ColumnIndex != dataGridView.Columns.Count - 1) {
          streamWriter.Write(separator);
        }
        else {
          streamWriter.WriteLine();
        }
      }
    }

    /// <summary>
    /// Gets an <see cref="XElement"/> representing the object.
    /// </summary>
    /// <param name="o">The object to be transformed in to an XML element.</param>
    /// <returns>An <see cref="XElement"/> representing the object.</returns>
    private static XElement GetXElement(object o) {
      XElement xElement = new XElement(XName.Get(o.GetType().Name));

      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(o);

      for (int i = 0; i < properties.Count; i++) {
        PropertyDescriptor pd = properties[i];
        xElement.Add(new XElement(XName.Get(pd.Name), pd.GetValue(o)));
      }

      return xElement;
    }

    /// <summary>
    /// Gets an <see cref="XElement"/> representing the object's table row.
    /// </summary>
    /// <param name="o">The object to be transformed in to an XML element.</param>
    /// <returns>An <see cref="XElement"/> representing the object.</returns>
    private static XElement GetRowElement(object o) {
      XNamespace xnsHtml = XNamespace.Get("http://www.w3.org/1999/xhtml");
      XElement xRow = new XElement(xnsHtml + "tr");

      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(o);

      for (int i = 0; i < properties.Count; i++) {
        PropertyDescriptor pd = properties[i];
        xRow.Add(new XElement(xnsHtml + "td", pd.GetValue(o)));
      }
      
      return xRow;
    }

    /// <summary>
    /// Gets an <see cref="XElement"/> representing the table header containing row like the object.
    /// </summary>
    /// <param name="o">The object to be transformed in to an XML element.</param>
    /// <returns>An <see cref="XElement"/> representing the object.</returns>
    private static XElement GetHeaderElement(object o) {
      XNamespace xnsHtml = XNamespace.Get("http://www.w3.org/1999/xhtml");
      XElement xTHead = new XElement(xnsHtml + "thead");
      XElement xRow = new XElement(xnsHtml + "tr");
      xTHead.Add(xRow);

      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(o);

      for (int i = 0; i < properties.Count; i++) {
        PropertyDescriptor pd = properties[i];
        xRow.Add(new XElement(xnsHtml + "th", pd.DisplayName));
      }

      return xTHead;
    }

    #endregion

  }

}
