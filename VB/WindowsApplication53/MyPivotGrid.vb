Imports System
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraPivotGrid.ViewInfo
Imports DevExpress.XtraPivotGrid.Printing
Imports DevExpress.XtraPrinting
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.PivotGrid.Printing
Imports DevExpress.XtraPrinting.Native

Namespace WindowsApplication53

    Public Class MyPivotGridControl
        Inherits PivotGridControl

        Public Shared ReadOnly Property ImagePlaceHolder As String
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
            Dim printer As MyPivotGridPrinter = New MyPivotGridPrinter(Me)
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

    Public Class MyPivotGridPrinter
        Inherits PivotGridPrinter

        Public Sub New(ByVal pivotGridControl As PivotGridControl)
            MyBase.New(pivotGridControl)
        End Sub

        Protected Overrides Function DrawHeaderBrick(ByVal field As PivotFieldItemBase, ByVal bounds As Rectangle) As IVisualBrick
            Dim appearance As IPivotPrintAppearance = GetFieldAppearance(field)
            SetDefaultBrickStyle(appearance, CellSizeProvider.FieldValueTextOffset, 0, 0, 0)
            Dim text As String = field.Caption
            Dim brick As IVisualBrick = CreateTextBrick()
            brick.Text = text.Substring(MyPivotGridControl.ImagePlaceHolder.Length)
            If Not Equals(text, Nothing) Then brick.TextValue = text
            brick.TextValueFormatString = ""
            Dim imageIndex As Integer = CType(Data.GetField(field), PivotGridField).ImageIndex
            If imageIndex > -1 Then
                Dim ib As ImageBrick = New ImageBrick(BorderSide.None, 0, Color.Red, Color.Transparent)
                ib.Image = CType(PivotGridControl.HeaderImages, ImageList).Images(imageIndex)
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
                If Owner.CustomExportHeader(brick, field, appearance, bounds) Then ApplyAppearanceToBrickStyle(brick, appearance)
            End If

            Return brick
        End Function

        Private Overloads Sub ApplyAppearanceToBrickStyle(ByVal brick As IVisualBrick, ByVal appearance As IPivotPrintAppearance)
            Dim panelBrick As IPanelBrick = TryCast(brick, IPanelBrick)
            If panelBrick IsNot Nothing Then
                For Each item As IVisualBrick In panelBrick.Bricks
                    ApplyAppearanceToBrickStyleCore(item, appearance)
                Next
            End If

            ApplyAppearanceToBrickStyleCore(brick, appearance)
        End Sub

        Private Sub ApplyAppearanceToBrickStyleCore(ByVal brick As IVisualBrick, ByVal appearance As IPivotPrintAppearance)
            Dim brickStyle As BrickStyle = If(brick.Style IsNot Nothing, CType(brick.Style.Clone(), BrickStyle), CType(Graph.DefaultBrickStyle.Clone(), BrickStyle))
            If appearance.Options.UseBackColor Then brickStyle.BackColor = appearance.BackColor
            If appearance.Options.UseBorderColor Then brickStyle.BorderColor = appearance.BorderColor
            If appearance.Options.UseBorderWidth Then brickStyle.BorderWidth = appearance.BorderWidth
            If appearance.Options.UseBorderStyle Then brickStyle.BorderStyle = appearance.BorderStyle
            If appearance.Options.UseFont Then brickStyle.Font = appearance.Font
            If appearance.Options.UseForeColor Then brickStyle.ForeColor = appearance.ForeColor
            If appearance.Options.UseTextOptions Then
                brickStyle.TextAlignment = TextAlignmentConverter.ToTextAlignment(appearance.TextHorizontalAlignment, appearance.TextVerticalAlignment)
                brickStyle.StringFormat = New BrickStringFormat(brickStyle.StringFormat, brickStyle.StringFormat.FormatFlags, BrickStringFormatPrototypeKind.GenericTypographic)
            End If

            brick.Style = brickStyle
        End Sub

        Private Sub SetDefaultBrickStyle(ByVal appearance As IPivotPrintAppearance, ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
            If appearance Is Nothing Then Return
            Graph.DefaultBrickStyle = CreateBrickStyle(appearance, left, top, right, bottom)
        End Sub

        Protected Overrides Function CreatePivotPrintBestFitter() As PivotPrintBestFitter
            Return New MyPivotPrintBestFitter(Data, Me)
        End Function
    End Class

    Public Class MyPivotPrintBestFitter
        Inherits PivotPrintBestFitter

        Public Sub New(ByVal data As PivotGridData, ByVal printer As PivotGridPrinterBase)
            MyBase.New(data, printer, New MyPrintCellSizeProvider(data, data.VisualItems, printer))
        End Sub
    End Class

    Public Class MyPrintCellSizeProvider
        Inherits PrintCellSizeProvider

        Private imageHeight As Integer

        Public Sub New(ByVal data As PivotGridData, ByVal visualItems As PivotVisualItemsBase, ByVal printer As PivotGridPrinterBase)
            MyBase.New(data, visualItems, printer)
            imageHeight = CType(data.HeaderImages, ImageList).ImageSize.Height
        End Sub

        Protected Overrides Function CalculateHeaderHeight(ByVal field As PivotFieldItemBase) As Integer
            Dim baseHeight As Integer = MyBase.CalculateHeaderHeight(field)
            Return Math.Max(baseHeight, imageHeight + 4)
        End Function
    End Class
End Namespace
