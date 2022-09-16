using System;
using System.Drawing;
using System.Windows.Forms;

namespace iNTrack
{
    public class TitleControl : Control
    {
        private const int BATTERY_WIDTH = 25;

        private const int MARGIN = 4;

        private static Timer m_timer;

        public static SizeF m_scaleFactor;

        static TitleControl()
        {
            TitleControl.m_scaleFactor = new SizeF(1f, 1f);
        }

        public TitleControl(string Title)
        {
            this.Text = Title;
            Graphics graphic = base.CreateGraphics();
            try
            {
                TitleControl.m_scaleFactor.Width = graphic.DpiX / 96f;
                TitleControl.m_scaleFactor.Height = graphic.DpiY / 96f;
            }
            finally
            {
                if (graphic != null)
                {
                    ((IDisposable)graphic).Dispose();
                }
            }
            if (TitleControl.m_timer == null)
            {
                TitleControl.m_timer = new Timer()
                {
                    Interval = 10000,
                    Enabled = true
                };
            }
            TitleControl.m_timer.Tick += new EventHandler(this.ControlTimer_Tick);
        }

        private void ControlTimer_Tick(object sender, EventArgs e)
        {
            base.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (TitleControl.m_timer != null)
                {
                    TitleControl.m_timer.Tick -= new EventHandler(this.ControlTimer_Tick);
                }
            }
            base.Dispose(disposing);
        }

        private void DrawBattery(Graphics graphics, Brush brush, RectangleF rect, int level)
        {
            if ((level < 0 ? true : level > 100))
            {
                level = 100;
            }
            int num = TitleControl.ScaleCoord(1);
            int num1 = num * 8;
            int num2 = num * 2;
            int num3 = num * 4;
            int width = (int)rect.Width - num * 8;
            int x = (int)rect.X;
            int y = (int)(rect.Y + (rect.Height - (float)num1) / 2f);
            graphics.FillRectangle(brush, x, y + num2, num2, num3);
            width -= num2;
            x += num2;
            graphics.FillRectangle(brush, x, y, width, num);
            graphics.FillRectangle(brush, x, y, num, num1);
            graphics.FillRectangle(brush, x, y + num1 - num, width, num);
            graphics.FillRectangle(brush, x + width - num, y, num, num1);
            width -= num3;
            x += num2;
            y += num2;
            num1 -= num3;
            int num4 = width * level / 100;
            graphics.FillRectangle(brush, x + width - num4, y, num4, num1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Brush solidBrush = new SolidBrush(this.BackColor);
            try
            {
                Font font = this.Font;
                Rectangle clientRectangle = base.ClientRectangle;
                graphics.FillRectangle(solidBrush, clientRectangle);
                string shortTimeString = DateTime.Now.ToShortTimeString();
                SizeF sizeF = graphics.MeasureString(shortTimeString, font);
                int num = (int)Math.Ceiling((double)sizeF.Width);
                int num1 = TitleControl.ScaleCoord(25);
                int num2 = TitleControl.ScaleCoord(4);
                int width = clientRectangle.Width - num - num1 - num2 * 2;
                SolidBrush solidBrush1 = new SolidBrush(this.ForeColor);
                try
                {
                    RectangleF rectangleF = new RectangleF((float)(clientRectangle.X + num2), (float)clientRectangle.Y, (float)width, (float)clientRectangle.Height);
                    StringFormat stringFormat = new StringFormat()
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    };
                    StringFormat stringFormat1 = stringFormat;
                    string upper = this.Text.ToUpper();
                    graphics.DrawString(upper, font, solidBrush1, rectangleF, stringFormat1);
                    rectangleF.X = (float)(clientRectangle.Right - num2 - num);
                    rectangleF.Width = (float)num;
                    graphics.DrawString(shortTimeString, font, solidBrush1, rectangleF, stringFormat1);
                    rectangleF.X = (float)(clientRectangle.X + num2 + width);
                    rectangleF.Width = (float)num1;
                    this.DrawBattery(graphics, solidBrush1, rectangleF, InteropLib.GetMainBatteryLifePercent());
                }
                finally
                {
                    if (solidBrush1 != null)
                    {
                        ((IDisposable)solidBrush1).Dispose();
                    }
                }
            }
            finally
            {
                if (solidBrush != null)
                {
                    ((IDisposable)solidBrush).Dispose();
                }
            }
            base.OnPaint(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.Invalidate();
            base.OnTextChanged(e);
        }

        public static int ScaleCoord(int x)
        {
            return (int)((float)x * TitleControl.m_scaleFactor.Width);
        }

        public static float ScaleCoord(float x)
        {
            return x * TitleControl.m_scaleFactor.Width;
        }
    }
}