Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraPivotGrid.ViewInfo
Imports DevExpress.XtraPivotGrid.Printing
Imports DevExpress.XtraPrinting
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils

Namespace WindowsApplication53

	Public Class MyPivotGridControl
		Inherits PivotGridControl
		Public Shared ReadOnly Property ImagePlaceHolder() As String
			Get
				Return "*Image*"
			End Get
		End Property
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal viewInfoData As PivotGridViewInfoData)
			MyBase.New(viewInfoData)
		End Sub

		Protected Overrides Function CreateData() As PivotGridViewInfoData
			Return New MyPivotGridViewInfoData(Me)
		End Function
		Protected Overrides Function CreatePrinter() As PivotGridPrinter
			Dim printer As New MyPivotGridPrinter(Me)
			printer.Owner = Me
			Return printer
		End Function
	End Class

	Public Class MyPivotGridViewInfoData
		Inherits PivotGridViewInfoData
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal control As IViewInfoControl)
			MyBase.New(control)
		End Sub
		Protected Overrides Function CreateViewInfo() As PivotGridViewInfo
			Return New MyPivotGridViewInfo(Me)
		End Function
	End Class
	Public Class MyPivotGridViewInfo
		Inherits PivotGridViewInfo
		Public Sub New(ByVal data As PivotGridViewInfoData)
			MyBase.New(data)
		End Sub


	End Class

	Public Class MyPivotGridPrintViewInfo
		Inherits PivotGridPrintViewInfo
		Public Sub New(ByVal data As PivotGridViewInfoData, ByVal isPSOwner As Boolean)
			MyBase.New(data, isPSOwner)
		End Sub

		Protected Overrides Function CalcFieldHeight(ByVal isHeader As Boolean, ByVal lineCount As Integer) As Integer
			Dim baseHeight As Integer = MyBase.CalcFieldHeight(isHeader, lineCount)
			If isHeader AndAlso Me.Data.HeaderImages IsNot Nothing Then
				Return Math.Max(baseHeight, (CType(Me.Data.HeaderImages, ImageList)).ImageSize.Height + 4)
			End If
			Return baseHeight
		End Function

	End Class

	Public Class MyPivotGridPrinter
		Inherits PivotGridPrinter
		Public Sub New(ByVal pivotGridControl As PivotGridControl)
			MyBase.New(pivotGridControl)
		End Sub
		Protected Overrides Function CreateViewInfo(ByVal data As PivotGridViewInfoData) As PivotGridPrintViewInfo
			Return New MyPivotGridPrintViewInfo(data, True)
		End Function

		Protected Overrides Function DrawHeaderBrick(ByVal headerViewInfo As PivotHeaderViewInfoBase) As ITextBrick
			Dim appearance As ExportAppearanceObject = CalculateAppearance(headerViewInfo)
			SetDefaultBrickStyle(appearance, headerViewInfo.GetPaddings())

			Dim text As String = headerViewInfo.Caption
			Dim bounds As Rectangle = headerViewInfo.ControlBounds
			Dim brick As ITextBrick = CreateTextBrick()
			brick.Text = text.Substring(MyPivotGridControl.ImagePlaceHolder.Length)

				If text IsNot Nothing Then
					brick.TextValue = text
				End If
				brick.TextValueFormatString = ""
				If headerViewInfo.Field.ImageIndex>-1 Then

					Dim ib As New ImageBrick(BorderSide.None, 0, Color.Red, Color.Transparent)
					ib.Image = (CType(Me.PivotGridControl.HeaderImages, ImageList)).Images(headerViewInfo.Field.ImageIndex)
					Dim imageWidth As Integer = ib.Image.Width
					Dim imageHeight As Integer = ib.Image.Height
					ib.BackColor = brick.BackColor
					ib.BorderColor = brick.BorderColor
					brick.Sides = BorderSide.Top Or BorderSide.Right Or BorderSide.Bottom
					ib.BorderStyle = brick.BorderStyle
					ib.BorderWidth = brick.BorderWidth
					ib.Sides = BorderSide.Top Or BorderSide.Left Or BorderSide.Bottom
					ib.SizeMode = ImageSizeMode.CenterImage

					'Graph.DrawBrick(ib, new Rectangle(bounds.X, bounds.Y + (bounds.Height - imageHeight) / 2, imageWidth, imageHeight));
					Graph.DrawBrick(ib, New Rectangle(bounds.X, bounds.Y, imageWidth, bounds.Height))
					Graph.DrawBrick(brick, New Rectangle(bounds.X + imageWidth, bounds.Y, bounds.Width - imageWidth, bounds.Height))
				Else
					Graph.DrawBrick(brick, New Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height))
				End If
			brick.Separable = False
			If Owner IsNot Nothing Then
				If Owner.CustomDrawHeader(brick, headerViewInfo, appearance) Then
					ApplyAppearanceToBrickStyle(brick, appearance)
				End If
			End If
			Return brick
		End Function

		Private Sub SetDefaultBrickStyle(ByVal appearance As AppearanceObject, ByVal padding As Padding)
			If appearance Is Nothing Then
				Return
			End If
			Graph.DefaultBrickStyle = CreateBrickStyle(appearance, padding)
		End Sub


	End Class

End Namespace
