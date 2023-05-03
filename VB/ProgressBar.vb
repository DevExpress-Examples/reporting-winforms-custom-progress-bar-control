'#Region "#Reference"
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils.Design
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI

' ...
'#End Region  ' #Reference
'#Region "#Code"
Namespace WindowsFormsApplication1

    ' The DefaultBindableProperty attribute is intended to make the Position 
    ' property bindable when an item is dropped from the Field List.
    <ToolboxItem(True), DefaultBindableProperty("Position"), ToolboxBitmap24("WindowsFormsApplication1.ProgressBar24x24.png, WindowsFormsApplication11")>
    Public Class ProgressBar
        Inherits XRControl

        ' The current position value.
        Private pos As Single = 0

        ' The maximum value for the progress bar position.
        Private maxVal As Single = 100

        Shared Sub New()
            Expressions.ExpressionBindingDescriptor.SetPropertyDescription(GetType(ProgressBar), "Position", New Expressions.ExpressionBindingDescription(New String() {"BeforePrint"}, 1000, New String(-1) {}))
        End Sub

        Public Sub New()
            ForeColor = SystemColors.Highlight
        End Sub

        ' Define the MaxValue property.
        <DefaultValue(100)>
        <XtraSerializableProperty>
        Public Property MaxValue As Single
            Get
                Return maxVal
            End Get

            Set(ByVal value As Single)
                If value <= 0 Then Return
                maxVal = value
            End Set
        End Property

        ' Define the Position property. 
        <DefaultValue(0), Bindable(True)>
        <XtraSerializableProperty>
        Public Property Position As Single
            Get
                Return pos
            End Get

            Set(ByVal value As Single)
                If value < 0 OrElse value > maxVal Then Return
                pos = value
            End Set
        End Property

        ' Override the XRControl.CreateBrick method.
        Protected Overrides Function CreateBrick(ByVal childrenBricks As VisualBrick()) As VisualBrick
            ' Use this code to make the progress bar control 
            ' always represented as a Panel brick.
            Return New PanelBrick(Me)
        End Function

        ' Override the XRControl.PutStateToBrick method.
        Protected Overrides Sub PutStateToBrick(ByVal brick As VisualBrick, ByVal ps As PrintingSystemBase)
            ' Call the PutStateToBrick method of the base class.
            MyBase.PutStateToBrick(brick, ps)
            ' Get the Panel brick which represents the current progress bar control.
            Dim panel As PanelBrick = CType(brick, PanelBrick)
            ' Create a new VisualBrick to be inserted into the panel brick.
            Dim progressBar As VisualBrick = New VisualBrick(Me)
            ' Hide borders.
            progressBar.Sides = BorderSide.None
            ' Set the foreground color to fill the completed area of a progress bar.
            progressBar.BackColor = panel.Style.ForeColor
            ' Calculate the rectangle to be filled by the foreground color.
            progressBar.Rect = New RectangleF(0, 0, panel.Rect.Width * (Position / MaxValue), panel.Rect.Height)
            ' Add the VisualBrick to the panel.
            panel.Bricks.Add(progressBar)
        End Sub
    End Class
End Namespace
'#End Region  ' #Code
