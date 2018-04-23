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

    public class MyPivotGridPrintViewInfo : PivotGridPrintViewInfo
    {
        public MyPivotGridPrintViewInfo(PivotGridViewInfoData data, bool isPSOwner) : base(data, isPSOwner) { }

        protected override int CalcFieldHeight(bool isHeader, int lineCount)
        {
            int baseHeight = base.CalcFieldHeight(isHeader, lineCount);
            if (isHeader && this.Data.HeaderImages != null)
            {
                return Math.Max(baseHeight, ((ImageList)this.Data.HeaderImages).ImageSize.Height + 4);
            }
            return baseHeight;
        }

    }

    public class MyPivotGridPrinter : PivotGridPrinter
    {
        public MyPivotGridPrinter(PivotGridControl pivotGridControl) : base(pivotGridControl) { }
        protected override PivotGridPrintViewInfo CreateViewInfo(PivotGridViewInfoData data)
        {
            return new MyPivotGridPrintViewInfo(data, true);
        }

        protected override ITextBrick DrawHeaderBrick(PivotHeaderViewInfoBase headerViewInfo)
        {
            ExportAppearanceObject appearance = CalculateAppearance(headerViewInfo);
            SetDefaultBrickStyle(appearance, headerViewInfo.GetPaddings());
            
            string text = headerViewInfo.Caption;
            Rectangle bounds = headerViewInfo.ControlBounds;
            ITextBrick brick = CreateTextBrick();
            brick.Text = text.Substring(MyPivotGridControl.ImagePlaceHolder.Length); ;
                if (text != null)
                    brick.TextValue = text;
                brick.TextValueFormatString = "";
                if (headerViewInfo.Field.ImageIndex>-1)
                {

                    ImageBrick ib = new ImageBrick(BorderSide.None, 0, Color.Red, Color.Transparent);
                    ib.Image = ((ImageList)this.PivotGridControl.HeaderImages).Images[headerViewInfo.Field.ImageIndex];
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
                    Graph.DrawBrick(ib, new Rectangle(bounds.X, bounds.Y , imageWidth, bounds.Height ));
                    Graph.DrawBrick(brick, new Rectangle(bounds.X + imageWidth, bounds.Y, bounds.Width - imageWidth, bounds.Height));
                }
                else
                    Graph.DrawBrick(brick, new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height));
            brick.Separable = false;
            if (Owner != null)
            {
                if (Owner.CustomDrawHeader(brick, headerViewInfo, ref appearance))
                    ApplyAppearanceToBrickStyle(brick, appearance);
            }
            return brick;
        }

        void SetDefaultBrickStyle(AppearanceObject appearance, Padding padding)
        {
            if (appearance == null)
                return;
            Graph.DefaultBrickStyle = CreateBrickStyle(appearance, padding);
        }

    
    }

}
