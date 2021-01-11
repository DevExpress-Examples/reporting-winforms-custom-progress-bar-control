#Region "#Reference"
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraReports.Expressions
#End Region ' #Reference

#Region "#Code"
Namespace WindowsFormsApplication1
	<ToolboxItem(True), DefaultBindableProperty("Position")>
	Public Class ProgressBar
		Inherits XRControl

		' Implement a static constructor as shown below to add the
		' "Position" property to the property grid's "Expressions" tab.
		Shared Sub New()
			' Specify an array of events in which the property should be available.
			Dim eventNames() As String = { "BeforePrint" }

			' Specify the property position in the property grid's "Expressions" tab.
			' 0 - first, 1000 - last.
'INSTANT VB NOTE: The variable position was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim position_Renamed As Integer = 0

			' Specify an array of the property's inner properties.
			Dim nestedBindableProperties() As String = Nothing

			' Specify the property's category in the property grid's "Expressions" tab.
			' The empty string corresponds to the root category.
			Dim scopeName As String = ""

			' Create and set a description for the "Position" property.
			Dim description As New ExpressionBindingDescription(eventNames, position_Renamed, nestedBindableProperties, scopeName)

			ExpressionBindingDescriptor.SetPropertyDescription(GetType(ProgressBar), nameof(Position), description)
		End Sub

'INSTANT VB NOTE: The variable position was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private position_Renamed As Single = 0
'INSTANT VB NOTE: The variable maxValue was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private maxValue_Renamed As Single = 100

		Public Sub New()
			Me.ForeColor = SystemColors.Highlight
		End Sub

		<DefaultValue(100), Description("The maximum value of the bar position."), DisplayName("Max Value"), Category("Parameters"), XtraSerializableProperty>
		Public Property MaxValue() As Single
			Get
				Return Me.maxValue_Renamed
			End Get
			Set(ByVal value As Single)
				If value <= 0 Then
					Return
				End If
				Me.maxValue_Renamed = value
			End Set
		End Property

		<DefaultValue(0), Description("The current bar position."), DisplayName("Position"), Category("Parameters"), XtraSerializableProperty>
		Public Property Position() As Single
			Get
				Return Me.position_Renamed
			End Get
			Set(ByVal value As Single)
				If value < 0 OrElse value > maxValue_Renamed Then
					Return
				End If
				Me.position_Renamed = value
			End Set
		End Property

'        
'            You can use two bricks to construct a progress bar. The "VisualBrick"
'            corresponds to a rectangle bar, the "PanelBrick" serves as a container
'            for this bar.
'        

		Protected Overrides Function CreateBrick(ByVal childrenBricks() As VisualBrick) As VisualBrick
			' Create and return a panel brick.
			Return New PanelBrick(Me)
		End Function

		Protected Overrides Sub PutStateToBrick(ByVal brick As VisualBrick, ByVal ps As PrintingSystemBase)
			MyBase.PutStateToBrick(brick, ps)

			' Cast the "brick" variable to the "PanelBrick" type (the type of a brick
			' created in the "CreateBrick" method). 
			Dim panel As PanelBrick = CType(brick, PanelBrick)

			' Create a new visual brick to represent a bar.
			Dim progressBar As New VisualBrick(Me)

			' Hide the brick's borders.
			progressBar.Sides = BorderSide.None

			' Set the foreground color for the bar.
			progressBar.BackColor = panel.Style.ForeColor

			' Calculate the width of the progress bar's filled area.
			Dim filledAreaWidth As Single = panel.Rect.Width * (Position / MaxValue)

			' Create a rectangle to be filled by the foreground color.
			progressBar.Rect = New RectangleF(0, 0, filledAreaWidth, panel.Rect.Height)

			' Add the visual brick to the panel brick.
			panel.Bricks.Add(progressBar)
		End Sub
	End Class
End Namespace
#End Region ' #Code
