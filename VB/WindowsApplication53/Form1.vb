Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPivotGrid

Namespace WindowsApplication53
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            PopulateTable()
            pivotGridControl1.RefreshData()
            pivotGridControl1.BestFit()
            pivotGridControl1.FieldsCustomization(panel1)
        End Sub
        Private Sub PopulateTable()
            Dim myTable As DataTable = dataSet1.Tables("Data")
            myTable.Rows.Add(New Object() {"Aaa", Date.Today, 7})
            myTable.Rows.Add(New Object() { "Aaa", Date.Today.AddDays(1), 4 })
            myTable.Rows.Add(New Object() { "Bbb", Date.Today, 12 })
            myTable.Rows.Add(New Object() { "Bbb", Date.Today.AddDays(1), 14 })
            myTable.Rows.Add(New Object() { "Ccc", Date.Today, 11 })
            myTable.Rows.Add(New Object() { "Ccc", Date.Today.AddDays(1), 10 })

            myTable.Rows.Add(New Object() { "Aaa", Date.Today.AddYears(1), 4 })
            myTable.Rows.Add(New Object() { "Aaa", Date.Today.AddYears(1).AddDays(1), 2 })
            myTable.Rows.Add(New Object() { "Bbb", Date.Today.AddYears(1), 3 })
            myTable.Rows.Add(New Object() { "Bbb", Date.Today.AddDays(1).AddYears(1), 1 })
            myTable.Rows.Add(New Object() { "Ccc", Date.Today.AddYears(1), 8 })
            myTable.Rows.Add(New Object() { "Ccc", Date.Today.AddDays(1).AddYears(1), 22 })
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
            For Each field As PivotGridField In pivotGridControl1.Fields
                field.Caption = MyPivotGridControl.ImagePlaceHolder & field.Caption
            Next field
            pivotGridControl1.ShowPrintPreview()
            For Each field As PivotGridField In pivotGridControl1.Fields
                field.Caption = field.Caption.Substring(MyPivotGridControl.ImagePlaceHolder.Length)
            Next field

        End Sub

        Private Sub pivotGridControl1_CustomExportHeader(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportHeaderEventArgs) Handles pivotGridControl1.CustomExportHeader
        End Sub


    End Class
End Namespace