Namespace WindowsApplication53

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WindowsApplication53.Form1))
            Dim dataSourceColumnBinding1 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
            Dim dataSourceColumnBinding2 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
            Dim dataSourceColumnBinding3 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
            Dim dataSourceColumnBinding4 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
            Dim dataSourceColumnBinding5 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
            Dim dataSourceColumnBinding6 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
            Me.dataSet1 = New System.Data.DataSet()
            Me.dataTable1 = New System.Data.DataTable()
            Me.dataColumn1 = New System.Data.DataColumn()
            Me.dataColumn2 = New System.Data.DataColumn()
            Me.dataColumn3 = New System.Data.DataColumn()
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
            Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.pivotGridControl1 = New WindowsApplication53.MyPivotGridControl()
            Me.fieldName1 = New DevExpress.XtraPivotGrid.PivotGridField()
            Me.fieldDate2 = New DevExpress.XtraPivotGrid.PivotGridField()
            Me.fieldValue3 = New DevExpress.XtraPivotGrid.PivotGridField()
            Me.fieldValue = New DevExpress.XtraPivotGrid.PivotGridField()
            Me.fieldValue1 = New DevExpress.XtraPivotGrid.PivotGridField()
            Me.fieldDate = New DevExpress.XtraPivotGrid.PivotGridField()
            CType((Me.dataSet1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.dataTable1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.pivotGridControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' dataSet1
            ' 
            Me.dataSet1.DataSetName = "NewDataSet"
            Me.dataSet1.Tables.AddRange(New System.Data.DataTable() {Me.dataTable1})
            ' 
            ' dataTable1
            ' 
            Me.dataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.dataColumn1, Me.dataColumn2, Me.dataColumn3})
            Me.dataTable1.TableName = "Data"
            ' 
            ' dataColumn1
            ' 
            Me.dataColumn1.ColumnName = "Name"
            ' 
            ' dataColumn2
            ' 
            Me.dataColumn2.ColumnName = "Date"
            Me.dataColumn2.DataType = GetType(System.DateTime)
            ' 
            ' dataColumn3
            ' 
            Me.dataColumn3.ColumnName = "Value"
            Me.dataColumn3.DataType = GetType(Decimal)
            ' 
            ' panel1
            ' 
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
            Me.panel1.Location = New System.Drawing.Point(596, 0)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(200, 292)
            Me.panel1.TabIndex = 1
            ' 
            ' simpleButton1
            ' 
            Me.simpleButton1.Location = New System.Drawing.Point(385, 0)
            Me.simpleButton1.Name = "simpleButton1"
            Me.simpleButton1.Size = New System.Drawing.Size(99, 38)
            Me.simpleButton1.TabIndex = 2
            Me.simpleButton1.Text = "Preview"
            AddHandler Me.simpleButton1.Click, New System.EventHandler(AddressOf Me.simpleButton1_Click)
            ' 
            ' imageList1
            ' 
            Me.imageList1.ImageStream = CType((resources.GetObject("imageList1.ImageStream")), System.Windows.Forms.ImageListStreamer)
            Me.imageList1.TransparentColor = System.Drawing.Color.White
            Me.imageList1.Images.SetKeyName(0, "smile.jpg")
            ' 
            ' pivotGridControl1
            ' 
            Me.pivotGridControl1.Appearance.FieldHeader.Options.UseTextOptions = True
            Me.pivotGridControl1.Appearance.FieldHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.[Default]
            Me.pivotGridControl1.DataMember = "Data"
            Me.pivotGridControl1.DataSource = Me.dataSet1
            Me.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.fieldName1, Me.fieldDate2, Me.fieldValue3, Me.fieldValue, Me.fieldValue1, Me.fieldDate})
            Me.pivotGridControl1.HeaderImages = Me.imageList1
            Me.pivotGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.pivotGridControl1.Name = "pivotGridControl1"
            Me.pivotGridControl1.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized
            Me.pivotGridControl1.OptionsDataField.ColumnValueLineCount = 2
            Me.pivotGridControl1.Size = New System.Drawing.Size(596, 292)
            Me.pivotGridControl1.TabIndex = 0
            AddHandler Me.pivotGridControl1.CustomExportHeader, New System.EventHandler(Of DevExpress.XtraPivotGrid.CustomExportHeaderEventArgs)(AddressOf Me.pivotGridControl1_CustomExportHeader)
            ' 
            ' fieldName1
            ' 
            Me.fieldName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
            Me.fieldName1.AreaIndex = 0
            Me.fieldName1.Caption = "Name"
            dataSourceColumnBinding1.ColumnName = "Name"
            Me.fieldName1.DataBinding = dataSourceColumnBinding1
            Me.fieldName1.ImageOptions.ImageIndex = 0
            Me.fieldName1.Name = "fieldName1"
            ' 
            ' fieldDate2
            ' 
            Me.fieldDate2.AreaIndex = 0
            Me.fieldDate2.Caption = "Year"
            dataSourceColumnBinding2.ColumnName = "Date"
            dataSourceColumnBinding2.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear
            Me.fieldDate2.DataBinding = dataSourceColumnBinding2
            Me.fieldDate2.ImageOptions.ImageIndex = 0
            Me.fieldDate2.Name = "fieldDate2"
            Me.fieldDate2.Width = 40
            ' 
            ' fieldValue3
            ' 
            Me.fieldValue3.Appearance.Value.Options.UseTextOptions = True
            Me.fieldValue3.Appearance.Value.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.fieldValue3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            Me.fieldValue3.AreaIndex = 0
            Me.fieldValue3.Caption = "Sum"
            Me.fieldValue3.ColumnValueLineCount = 2
            dataSourceColumnBinding3.ColumnName = "Value"
            Me.fieldValue3.DataBinding = dataSourceColumnBinding3
            Me.fieldValue3.ImageOptions.ImageIndex = 0
            Me.fieldValue3.Name = "fieldValue3"
            ' 
            ' fieldValue
            ' 
            Me.fieldValue.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            Me.fieldValue.AreaIndex = 1
            Me.fieldValue.Caption = "Count"
            Me.fieldValue.ColumnValueLineCount = 2
            dataSourceColumnBinding4.ColumnName = "Value"
            Me.fieldValue.DataBinding = dataSourceColumnBinding4
            Me.fieldValue.Name = "fieldValue"
            Me.fieldValue.Visible = False
            ' 
            ' fieldValue1
            ' 
            Me.fieldValue1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            Me.fieldValue1.AreaIndex = 2
            Me.fieldValue1.Caption = "Average"
            Me.fieldValue1.ColumnValueLineCount = 2
            dataSourceColumnBinding5.ColumnName = "Value"
            Me.fieldValue1.DataBinding = dataSourceColumnBinding5
            Me.fieldValue1.Name = "fieldValue1"
            Me.fieldValue1.Visible = False
            ' 
            ' fieldDate
            ' 
            Me.fieldDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
            Me.fieldDate.AreaIndex = 0
            Me.fieldDate.Caption = "Date"
            dataSourceColumnBinding6.ColumnName = "Date"
            dataSourceColumnBinding6.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.[Date]
            Me.fieldDate.DataBinding = dataSourceColumnBinding6
            Me.fieldDate.ImageOptions.ImageIndex = 0
            Me.fieldDate.Name = "fieldDate"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(796, 292)
            Me.Controls.Add(Me.simpleButton1)
            Me.Controls.Add(Me.pivotGridControl1)
            Me.Controls.Add(Me.panel1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.dataSet1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.dataTable1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.pivotGridControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private pivotGridControl1 As WindowsApplication53.MyPivotGridControl

        Private dataSet1 As System.Data.DataSet

        Private dataTable1 As System.Data.DataTable

        Private dataColumn1 As System.Data.DataColumn

        Private dataColumn2 As System.Data.DataColumn

        Private dataColumn3 As System.Data.DataColumn

        Private fieldName1 As DevExpress.XtraPivotGrid.PivotGridField

        Private fieldDate2 As DevExpress.XtraPivotGrid.PivotGridField

        Private fieldValue3 As DevExpress.XtraPivotGrid.PivotGridField

        Private fieldValue As DevExpress.XtraPivotGrid.PivotGridField

        Private fieldValue1 As DevExpress.XtraPivotGrid.PivotGridField

        Private fieldDate As DevExpress.XtraPivotGrid.PivotGridField

        Private panel1 As System.Windows.Forms.Panel

        Private simpleButton1 As DevExpress.XtraEditors.SimpleButton

        Private imageList1 As System.Windows.Forms.ImageList
    End Class
End Namespace
