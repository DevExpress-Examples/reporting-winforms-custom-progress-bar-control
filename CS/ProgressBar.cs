using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils.Serializing;
using DevExpress.XtraReports.Expressions;

namespace WindowsFormsApplication1 {
    [ToolboxItem(true)]
    [DefaultBindableProperty("Position")]
    public class ProgressBar : XRControl {
        // Implement a static constructor as shown below to add the
        // "Position" property to the property grid's "Expressions" tab.
        static ProgressBar() {
            // Specify an array of events in which the property should be available.
            string[] eventNames = new string[] { "BeforePrint" };

            // Specify the property position in the property grid's "Expressions" tab.
            // 0 - first, 1000 - last.
            int position = 0;

            // Specify an array of the property's inner properties.
            string[] nestedBindableProperties = null;

            // Specify the property's category in the property grid's "Expressions" tab.
            // The empty string corresponds to the root category.
            string scopeName = "";

            // Create and set a description for the "Position" property.
            ExpressionBindingDescription description = new ExpressionBindingDescription(
                eventNames, position, nestedBindableProperties, scopeName
            );

            ExpressionBindingDescriptor.SetPropertyDescription(
                typeof(ProgressBar),
                nameof(Position),
                new ExpressionBindingDescription(
                    eventNames, position,
                    nestedBindableProperties,
                    scopeName
                )
            );
        }

        private float position = 0;
        private float maxValue = 100;

        public ProgressBar() {
            this.ForeColor = SystemColors.Highlight;
        }

        [DefaultValue(100)]
        [Description("The maximum value of the bar position.")]
        [DisplayName("Max Value")]
        [Category("Parameters")]
        [XtraSerializableProperty]
        public float MaxValue {
            get { return this.maxValue; }
            set {
                if (value <= 0) return;
                this.maxValue = value;
            }
        }

        [DefaultValue(0)]
        [Description("The current bar position.")]
        [DisplayName("Position")]
        [Category("Parameters")]
        [XtraSerializableProperty]
        public float Position {
            get { return this.position; }
            set {
                if (value < 0 || value > maxValue)
                    return;
                this.position = value;
            }
        }

        /*
            You can use two bricks to construct a progress bar. The "VisualBrick"
            corresponds to a rectangle bar, the "PanelBrick" serves as a container
            for this bar.
        */

        protected override VisualBrick CreateBrick(VisualBrick[] childrenBricks) {
            // Create and return a panel brick.
            return new PanelBrick(this);
        }

        protected override void PutStateToBrick(VisualBrick brick, PrintingSystemBase ps) {
            base.PutStateToBrick(brick, ps);

            // Cast the "brick" variable to the "PanelBrick" type (the type of a brick
            // created in the "CreateBrick" method). 
            PanelBrick panel = (PanelBrick)brick;

            // Create a new visual brick to represent a bar.
            VisualBrick progressBar = new VisualBrick(this);

            // Hide the brick's borders.
            progressBar.Sides = BorderSide.None;

            // Set the foreground color for the bar.
            progressBar.BackColor = panel.Style.ForeColor;

            // Calculate the width of the progress bar's filled area.
            float filledAreaWidth = panel.Rect.Width * (Position / MaxValue);

            // Create a rectangle to be filled by the foreground color.
            progressBar.Rect = new RectangleF(0, 0, filledAreaWidth, panel.Rect.Height);

            // Add the visual brick to the panel brick.
            panel.Bricks.Add(progressBar);
        }
    }
}
