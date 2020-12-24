Namespace WindowsFormsApplication1
	Partial Public Class XtraReport1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim customJsonSource1 As New DevExpress.DataAccess.Json.CustomJsonSource()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(XtraReport1))
			Dim jsonSchemaNode1 As New DevExpress.DataAccess.Json.JsonSchemaNode("root", True, DevExpress.DataAccess.Json.JsonNodeType.Array)
			Dim jsonSchemaNode2 As New DevExpress.DataAccess.Json.JsonSchemaNode("Country", True, DevExpress.DataAccess.Json.JsonNodeType.Property, GetType(String))
			Dim jsonSchemaNode3 As New DevExpress.DataAccess.Json.JsonSchemaNode("Area", True, DevExpress.DataAccess.Json.JsonNodeType.Property, GetType(Double?))
			Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
			Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
			Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
			Me.jsonDataSource1 = New DevExpress.DataAccess.Json.JsonDataSource(Me.components)
			Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
			Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
			Me.progressBar1 = New WindowsFormsApplication1.ProgressBar()
			Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
			Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
			DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' Detail
			' 
			Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() { Me.progressBar1, Me.xrLabel1, Me.xrLabel2})
			Me.Detail.HeightF = 48.95833F
			Me.Detail.Name = "Detail"
			Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F)
			Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			' 
			' TopMargin
			' 
			Me.TopMargin.Name = "TopMargin"
			Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F)
			Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			' 
			' BottomMargin
			' 
			Me.BottomMargin.Name = "BottomMargin"
			Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F)
			Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			' 
			' jsonDataSource1
			' 
			Me.jsonDataSource1.ConnectionName = Nothing
			customJsonSource1.Json = resources.GetString("customJsonSource1.Json")
			Me.jsonDataSource1.JsonSource = customJsonSource1
			Me.jsonDataSource1.Name = "jsonDataSource1"
			jsonSchemaNode1.Nodes.Add(jsonSchemaNode2)
			jsonSchemaNode1.Nodes.Add(jsonSchemaNode3)
			Me.jsonDataSource1.Schema = jsonSchemaNode1
			' 
			' xrLabel1
			' 
			Me.xrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() { New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Country]")})
			Me.xrLabel1.Font = New System.Drawing.Font("Arial", 11F)
			Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(10.00001F, 3.999996F)
			Me.xrLabel1.Multiline = True
			Me.xrLabel1.Name = "xrLabel1"
			Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrLabel1.SizeF = New System.Drawing.SizeF(156.6667F, 33.41665F)
			Me.xrLabel1.StylePriority.UseFont = False
			Me.xrLabel1.StylePriority.UseTextAlignment = False
			Me.xrLabel1.Text = "xrLabel1"
			Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			' 
			' xrLabel2
			' 
			Me.xrLabel2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() { New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Area]")})
			Me.xrLabel2.Font = New System.Drawing.Font("Arial", 11F)
			Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(553.5417F, 3.999996F)
			Me.xrLabel2.Multiline = True
			Me.xrLabel2.Name = "xrLabel2"
			Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrLabel2.SizeF = New System.Drawing.SizeF(86.45831F, 33.41665F)
			Me.xrLabel2.StylePriority.UseFont = False
			Me.xrLabel2.StylePriority.UseTextAlignment = False
			Me.xrLabel2.Text = "xrLabel2"
			Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
			' 
			' progressBar1
			' 
			Me.progressBar1.BackColor = System.Drawing.Color.LightBlue
			Me.progressBar1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() { New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Position", "[Area]")})
			Me.progressBar1.ForeColor = System.Drawing.SystemColors.Highlight
			Me.progressBar1.LocationFloat = New DevExpress.Utils.PointFloat(177.0834F, 3.999996F)
			Me.progressBar1.MaxValue = 17100F
			Me.progressBar1.Name = "progressBar1"
			Me.progressBar1.Position = 0F
			Me.progressBar1.SizeF = New System.Drawing.SizeF(362.5F, 33.41665F)
			Me.progressBar1.StylePriority.UseBackColor = False
			' 
			' PageHeader
			' 
			Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() { Me.xrLabel3})
			Me.PageHeader.HeightF = 36.45833F
			Me.PageHeader.Name = "PageHeader"
			' 
			' xrLabel3
			' 
			Me.xrLabel3.Font = New System.Drawing.Font("Arial", 16F)
			Me.xrLabel3.ForeColor = System.Drawing.Color.SteelBlue
			Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(111.4583F, 0F)
			Me.xrLabel3.Multiline = True
			Me.xrLabel3.Name = "xrLabel3"
			Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrLabel3.SizeF = New System.Drawing.SizeF(430.2083F, 31.33332F)
			Me.xrLabel3.StylePriority.UseFont = False
			Me.xrLabel3.StylePriority.UseForeColor = False
			Me.xrLabel3.StylePriority.UseTextAlignment = False
			Me.xrLabel3.Text = "Top 10 Countries by Area"
			Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
			' 
			' XtraReport1
			' 
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() { Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader})
			Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() { Me.jsonDataSource1})
			Me.DataSource = Me.jsonDataSource1
			Me.Version = "20.2"
			DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private Detail As DevExpress.XtraReports.UI.DetailBand
		Private TopMargin As DevExpress.XtraReports.UI.TopMarginBand
		Private BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
		Private progressBar1 As ProgressBar
		Private xrLabel1 As DevExpress.XtraReports.UI.XRLabel
		Private xrLabel2 As DevExpress.XtraReports.UI.XRLabel
		Private jsonDataSource1 As DevExpress.DataAccess.Json.JsonDataSource
		Private PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
		Private xrLabel3 As DevExpress.XtraReports.UI.XRLabel
	End Class
End Namespace
