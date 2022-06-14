namespace WindowsApplication53
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pivotGridControl1 = new WindowsApplication53.MyPivotGridControl();
            this.fieldName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldValue = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldValue1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldValue2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDate1 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTable1.TableName = "Data";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Name";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Date";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Value";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(596, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 292);
            this.panel1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(385, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 38);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Preview";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "smile.jpg");
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.FieldHeader.Options.UseTextOptions = true;
            this.pivotGridControl1.Appearance.FieldHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControl1.DataMember = "Data";
            this.pivotGridControl1.DataSource = this.dataSet1;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldName,
            this.fieldDate,
            this.fieldValue,
            this.fieldValue1,
            this.fieldValue2,
            this.fieldDate1});
            this.pivotGridControl1.HeaderImages = this.imageList1;
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsDataField.ColumnValueLineCount = 2;
            this.pivotGridControl1.Size = new System.Drawing.Size(596, 292);
            this.pivotGridControl1.TabIndex = 0;
            this.pivotGridControl1.CustomExportHeader += new System.EventHandler<DevExpress.XtraPivotGrid.CustomExportHeaderEventArgs>(this.pivotGridControl1_CustomExportHeader);
            // 
            // fieldName
            // 
            this.fieldName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldName.AreaIndex = 0;
            this.fieldName.Caption = "Name";
            this.fieldName.FieldName = "Name";
            this.fieldName.ImageIndex = 0;
            this.fieldName.Name = "fieldName";
            // 
            // fieldDate
            // 
            this.fieldDate.AreaIndex = 0;
            this.fieldDate.Caption = "Year";
            this.fieldDate.FieldName = "Date";
            this.fieldDate.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
            this.fieldDate.ImageIndex = 0;
            this.fieldDate.Name = "fieldDate";
            this.fieldDate.UnboundFieldName = "fieldDate";
            this.fieldDate.Width = 40;
            // 
            // fieldValue
            // 
            this.fieldValue.Appearance.Value.Options.UseTextOptions = true;
            this.fieldValue.Appearance.Value.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldValue.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldValue.AreaIndex = 0;
            this.fieldValue.Caption = "Sum";
            this.fieldValue.ColumnValueLineCount = 2;
            this.fieldValue.FieldName = "Value";
            this.fieldValue.ImageIndex = 0;
            this.fieldValue.Name = "fieldValue";
            // 
            // fieldValue1
            // 
            this.fieldValue1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldValue1.AreaIndex = 1;
            this.fieldValue1.Caption = "Count";
            this.fieldValue1.ColumnValueLineCount = 2;
            this.fieldValue1.FieldName = "Value";
            this.fieldValue1.Name = "fieldValue1";
            this.fieldValue1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.fieldValue1.Visible = false;
            // 
            // fieldValue2
            // 
            this.fieldValue2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldValue2.AreaIndex = 2;
            this.fieldValue2.Caption = "Average";
            this.fieldValue2.ColumnValueLineCount = 2;
            this.fieldValue2.FieldName = "Value";
            this.fieldValue2.Name = "fieldValue2";
            this.fieldValue2.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
            this.fieldValue2.Visible = false;
            // 
            // fieldDate1
            // 
            this.fieldDate1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldDate1.AreaIndex = 0;
            this.fieldDate1.Caption = "Date";
            this.fieldDate1.FieldName = "Date";
            this.fieldDate1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.Date;
            this.fieldDate1.ImageIndex = 0;
            this.fieldDate1.Name = "fieldDate1";
            this.fieldDate1.UnboundFieldName = "fieldDate1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 292);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyPivotGridControl pivotGridControl1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private DevExpress.XtraPivotGrid.PivotGridField fieldName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDate;
        private DevExpress.XtraPivotGrid.PivotGridField fieldValue;
        private DevExpress.XtraPivotGrid.PivotGridField fieldValue1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldValue2;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDate1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

