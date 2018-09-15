#region #Reference
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils.Design;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
// ...
#endregion #Reference

#region #Code
namespace WindowsFormsApplication1 {
// The DefaultBindableProperty attribute is intended to make the Position 
// property bindable when an item is dropped from the Field List.
    [
    ToolboxItem(true),
    DefaultBindableProperty("Position"),
    ToolboxBitmap24("WindowsFormsApplication1.ProgressBar24x24.png, WindowsFormsApplication11")
    ]
    public class ProgressBar : XRControl {
        // The current position value.
        private float pos = 0;

        // The maximum value for the progress bar position.
        private float maxVal = 100;

        static ProgressBar() {
            DevExpress.XtraReports.Expressions.ExpressionBindingDescriptor.SetPropertyDescription(typeof(ProgressBar), "Position", new DevExpress.XtraReports.Expressions.ExpressionBindingDescription(new string[] { "BeforePrint" }, 1000, new string[0]));
        }

        public ProgressBar() {
            this.ForeColor = SystemColors.Highlight;
        }

        // Define the MaxValue property.
        [DefaultValue(100)]
        [XtraSerializableProperty]
        public float MaxValue {
            get { return this.maxVal; }
            set {
                if (value <= 0) return;
                this.maxVal = value;
            }
        }

        // Define the Position property. 
        [DefaultValue(0), Bindable(true)]
        [XtraSerializableProperty]
        public float Position {
            get { return this.pos; }
            set {
                if (value < 0 || value > maxVal)
                    return;
                this.pos = value;
            }
        }

        // Override the XRControl.CreateBrick method.
        protected override VisualBrick CreateBrick(VisualBrick[] childrenBricks) {
            // Use this code to make the progress bar control 
            // always represented as a Panel brick.
            return new PanelBrick(this);
        }

        // Override the XRControl.PutStateToBrick method.
        protected override void PutStateToBrick(VisualBrick brick, PrintingSystemBase ps) {
            // Call the PutStateToBrick method of the base class.
            base.PutStateToBrick(brick, ps);

            // Get the Panel brick which represents the current progress bar control.
            PanelBrick panel = (PanelBrick)brick;

            // Create a new VisualBrick to be inserted into the panel brick.
            VisualBrick progressBar = new VisualBrick(this);

            // Hide borders.
            progressBar.Sides = BorderSide.None;

            // Set the foreground color to fill the completed area of a progress bar.
            progressBar.BackColor = panel.Style.ForeColor;

            // Calculate the rectangle to be filled by the foreground color.
            progressBar.Rect = new RectangleF(0, 0, panel.Rect.Width * (Position / MaxValue),
                panel.Rect.Height);

            // Add the VisualBrick to the panel.
            panel.Bricks.Add(progressBar);
        }
    }
}
#endregion #Code