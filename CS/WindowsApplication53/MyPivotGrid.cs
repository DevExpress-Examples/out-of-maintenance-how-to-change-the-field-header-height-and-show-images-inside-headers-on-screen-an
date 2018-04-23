using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.XtraPivotGrid.Printing;
using DevExpress.XtraPrinting;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.PivotGrid.Printing;
using DevExpress.XtraPrinting.Native;

namespace WindowsApplication53
{
    
    public class MyPivotGridControl : PivotGridControl
    {
        public static string ImagePlaceHolder { get { return "*Image*"; } }
        public MyPivotGridControl() : base() { }
        public MyPivotGridControl(PivotGridViewInfoData viewInfoData) : base(viewInfoData) { }

        protected override PivotGridViewInfoData CreateData()
        {
            return new MyPivotGridViewInfoData(this);
        }
        protected override PivotGridPrinter CreatePrinter()
        {
            MyPivotGridPrinter printer = new MyPivotGridPrinter(this);
            printer.Owner = this;
            return printer;
        }
    }

    public class MyPivotGridViewInfoData : PivotGridViewInfoData
    {
        public MyPivotGridViewInfoData() : base() { }
        public MyPivotGridViewInfoData(IViewInfoControl control) : base(control) { }
        protected override PivotGridViewInfo CreateViewInfo()
        {
            return new MyPivotGridViewInfo(this);
        }
    }
    public class MyPivotGridViewInfo : PivotGridViewInfo
    {
        public MyPivotGridViewInfo(PivotGridViewInfoData data) : base(data) { }


    }    

    public class MyPivotGridPrinter : PivotGridPrinter
    {
        public MyPivotGridPrinter(PivotGridControl pivotGridControl) : base(pivotGridControl) { }


        protected override IVisualBrick DrawHeaderBrick(PivotFieldItemBase field, Rectangle bounds)
        {
            IPivotPrintAppearance appearance = GetFieldAppearance(field);
            SetDefaultBrickStyle(appearance, new Padding(CellSizeProvider.FieldValueTextOffset, 0, 0, 0));

            string text = field.Caption;
            IVisualBrick brick = CreateTextBrick();
            brick.Text = text.Substring(MyPivotGridControl.ImagePlaceHolder.Length);
            if (text != null)
                brick.TextValue = text;
            brick.TextValueFormatString = "";
            int imageIndex = ((PivotGridField)this.Data.GetField(field)).ImageIndex;
            if (imageIndex > -1)
            {

                ImageBrick ib = new ImageBrick(BorderSide.None, 0, Color.Red, Color.Transparent);
                ib.Image = ((ImageList)this.PivotGridControl.HeaderImages).Images[imageIndex];
                int imageWidth = ib.Image.Width;
                int imageHeight = ib.Image.Height;
                ib.BackColor = brick.BackColor;
                ib.BorderColor = brick.BorderColor;
                brick.Sides = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
                ib.BorderStyle = brick.BorderStyle;
                ib.BorderWidth = brick.BorderWidth;
                ib.Sides = BorderSide.Top | BorderSide.Left | BorderSide.Bottom;
                ib.SizeMode = ImageSizeMode.CenterImage;

                //Graph.DrawBrick(ib, new Rectangle(bounds.X, bounds.Y + (bounds.Height - imageHeight) / 2, imageWidth, imageHeight));
                Graph.DrawBrick(ib, new Rectangle(bounds.X, bounds.Y, imageWidth, bounds.Height));
                Graph.DrawBrick(brick, new Rectangle(bounds.X + imageWidth, bounds.Y, bounds.Width - imageWidth, bounds.Height));
            }
            else
                Graph.DrawBrick(brick, new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height));
            brick.Separable = false;
            if (Owner != null)
            {
                if (Owner.CustomExportHeader(ref brick, field, appearance, ref bounds))
                    ApplyAppearanceToBrickStyle(brick, appearance);
            }
            return brick;
        }

        void ApplyAppearanceToBrickStyle(IVisualBrick brick, IPivotPrintAppearance appearance)
        {
            IPanelBrick panelBrick = brick as IPanelBrick;
            if (panelBrick != null)
            {
                foreach (IVisualBrick item in panelBrick.Bricks)
                    ApplyAppearanceToBrickStyleCore(item, appearance);
            }
            ApplyAppearanceToBrickStyleCore(brick, appearance);
        }
        void ApplyAppearanceToBrickStyleCore(IVisualBrick brick, IPivotPrintAppearance appearance)
        {
            BrickStyle brickStyle = brick.Style != null ?
                (BrickStyle)brick.Style.Clone() :
                (BrickStyle)Graph.DefaultBrickStyle.Clone();
            if (appearance.Options.UseBackColor)
                brickStyle.BackColor = appearance.BackColor;
            if (appearance.Options.UseBorderColor)
                brickStyle.BorderColor = appearance.BorderColor;
            if (appearance.Options.UseBorderWidth)
                brickStyle.BorderWidth = appearance.BorderWidth;
            if (appearance.Options.UseBorderStyle)
                brickStyle.BorderStyle = appearance.BorderStyle;
            if (appearance.Options.UseFont)
                brickStyle.Font = appearance.Font;
            if (appearance.Options.UseForeColor)
                brickStyle.ForeColor = appearance.ForeColor;
            if (appearance.Options.UseTextOptions)
            {
                brickStyle.TextAlignment = TextAlignmentConverter.ToTextAlignment(appearance.TextHorizontalAlignment, appearance.TextVerticalAlignment);
                brickStyle.StringFormat = new BrickStringFormat(appearance.StringFormat);
            }
            brickStyle.StringFormat.PrototypeKind = BrickStringFormatPrototypeKind.GenericTypographic;
            brick.Style = brickStyle;
        }
        void SetDefaultBrickStyle(IPivotPrintAppearance appearance, Padding padding)
        {
            if (appearance == null)
                return;
            Graph.DefaultBrickStyle = CreateBrickStyle(appearance, padding);
        }
        protected override PivotPrintBestFitter CreatePivotPrintBestFitter()
        {
            return new MyPivotPrintBestFitter(Data, this);
        }
    }

    public class MyPivotPrintBestFitter : PivotPrintBestFitter
    {
        public MyPivotPrintBestFitter(PivotGridData data, PivotGridPrinterBase printer)
            : base(data, printer, new MyPrintCellSizeProvider(data, data.VisualItems, printer))
        {
        }
    }

    public class MyPrintCellSizeProvider : PrintCellSizeProvider
    {
        int imageHeight;
        public MyPrintCellSizeProvider(PivotGridData data, PivotVisualItemsBase visualItems, PivotGridPrinterBase printer)
            : base(data, visualItems, printer) { 
                imageHeight = ((ImageList)data.HeaderImages).ImageSize.Height;
        }     
        protected override int CalculateHeaderHeight(PivotFieldItemBase field)
        {
            int baseHeight = base.CalculateHeaderHeight(field);
            return Math.Max(baseHeight, imageHeight + 4);
        }
    }

}
