using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Custom
{
    public class RoundedPanel : Panel
    {
        public int Radius { get; set; } = 20;    // Bán kính bo góc
        public Color BorderColor { get; set; } = Color.Black;
        public int BorderSize { get; set; } = 1;

        public RoundedPanel()
        {
            DoubleBuffered = true;
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2f;
            RectangleF arc = new RectangleF(rect.Location, new SizeF(diameter, diameter));

            // Gần như giống với tham khảo: vẽ đường path bo quanh hình
            path.StartFigure();
            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = GetRoundPath(rect, Radius))
            {
                // Thiết lập vùng hiển thị bo góc
                Region = new Region(path);

                // Vẽ viền nếu cần
                if (BorderSize > 0)
                {
                    using (Pen pen = new Pen(BorderColor, BorderSize))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }

}
