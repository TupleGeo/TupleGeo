
#region Header
// Title Name       : CollapsibleGroupBox
// Member of        : TupleGeo.Presentation.dll
// Description      : A GroupBox control that provides functionality to allow it to be collapsed.
// Created by       : 14/07/2009, 19:57, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#endregion

namespace TupleGeo.Presentation.Controls {

  /// <summary>
  /// A GroupBox control that provides functionality to allow it to be collapsed.
  /// </summary>
  [ToolboxBitmap(typeof(CollapsibleGroupBox))]
  public partial class CollapsibleGroupBox : GroupBox {

    #region Member Variables

    private Rectangle _toggleRect = new Rectangle(8, 2, 11, 11);
    private bool _collapsed = false;
    private bool _resizingFromCollapse = false;

    private readonly int _collapsedHeight = 20;
    private Size _fullSize = Size.Empty;

    /// <summary>
    /// The event fired when the collapse box is clicked.
    /// </summary>
    public event CollapseBoxClickedEventHandler CollapseBoxClickedEvent;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CollapsibleGroupBox"/>.
    /// </summary>
    public CollapsibleGroupBox() {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes the <see cref="CollapsibleGroupBox"/>.
    /// </summary>
    /// <param name="container">
    /// The <see cref="IContainer"/> used for initialization.
    /// </param>
    public CollapsibleGroupBox(IContainer container) {
      if (container == null) {
        throw new ArgumentNullException("container");
      }
      container.Add(this);
      InitializeComponent();
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the full height of the <see cref="CollapsibleGroupBox"/> control.
    /// </summary>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int FullHeight {
      get {
        return _fullSize.Height;
      }
    }

    /// <summary>
    /// Gets / Sets whether the <see cref="CollapsibleGroupBox"/> is collapsed or not.
    /// </summary>
    [DefaultValue(false), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsCollapsed {
      get {
        return _collapsed;
      }
      set {
        if (value != _collapsed) {
          _collapsed = value;

          if (!value)
            // Expand
            this.Size = _fullSize;
          else {
            // Collapse
            _resizingFromCollapse = true;
            this.Height = _collapsedHeight;
            _resizingFromCollapse = false;
          }

          foreach (Control c in Controls)
            c.Visible = !value;

          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets the height in collapsed mode.
    /// </summary>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CollapsedHeight {
      get {
        return _collapsedHeight;
      }
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Called on mouse up.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs"/>.</param>
    protected override void OnMouseUp(MouseEventArgs e) {
      if (e != null) {
        if (e.Location != null) {
          if (_toggleRect.Contains(e.Location)) {
            ToggleCollapsed();
          }
          else {
            base.OnMouseUp(e);
          }
        }
        else {
          base.OnMouseUp(e);
        }
      }
    }

    /// <summary>
    /// Called on paint.
    /// </summary>
    /// <param name="e">The <see cref="PaintEventArgs"/>.</param>
    protected override void OnPaint(PaintEventArgs e) {
      if (e != null) {
        if (e.Graphics != null) {
          HandleResize();
          DrawGroupBox(e.Graphics);
          DrawToggleButton(e.Graphics);
        }
      }
    }

    #endregion
    
    #region Private Procedures

    /// <summary>
    /// Draws the group box.
    /// </summary>
    /// <param name="g">The <see cref="Graphics"/> used to draw the group box.</param>
    private void DrawGroupBox(Graphics g) {
      // Get windows to draw the GroupBox.
      Rectangle bounds = new Rectangle(
        ClientRectangle.X,
        ClientRectangle.Y + 6,
        ClientRectangle.Width,
        ClientRectangle.Height - 6
      );
      GroupBoxRenderer.DrawGroupBox(g, bounds, Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled);

      // Text Formating positioning & Size.
      int textPos = (bounds.X + 8) + _toggleRect.Width + 2;
      int textSize = (int)g.MeasureString(Text, this.Font).Width;
      textSize = textSize < 1 ? 1 : textSize;
      int endPos = textPos + textSize + 1;

      // Draw a line to cover the GroupBox border where the text will sit.
      g.DrawLine(SystemPens.Control, textPos, bounds.Y, endPos, bounds.Y);

      // Draw the GroupBox text.
      using (SolidBrush drawBrush = new SolidBrush(Color.FromArgb(0, 70, 213))) {
        g.DrawString(Text, this.Font, drawBrush, textPos, 0);
      }
    }

    /// <summary>
    /// Draws the toggle button.
    /// </summary>
    /// <param name="g">The <see cref="Graphics"/> used to draw the toggle button.</param>
    private void DrawToggleButton(Graphics g) {
      if (IsCollapsed) {
        g.DrawImage(TupleGeo.Resources.Icons.Signs.Misc.Resources.Plus, _toggleRect);
      }
      else {
        g.DrawImage(TupleGeo.Resources.Icons.Signs.Misc.Resources.Minus, _toggleRect);
      }
    }

    /// <summary>
    /// Toggles the group box.
    /// </summary>
    private void ToggleCollapsed() {
      IsCollapsed = !IsCollapsed;

      if (CollapseBoxClickedEvent != null) {
        CollapseBoxClickedEvent(this, new EventArgs());
      }
    }

    /// <summary>
    /// Handles the resize of the <see cref="CollapsibleGroupBox"/> control.
    /// </summary>
    private void HandleResize() {
      if (!_resizingFromCollapse && !_collapsed) {
        _fullSize = this.Size;
      }
    }

    #endregion

  }

}
