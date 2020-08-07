using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ProjectManager.Drawing
{
    class RectanglePainter
    {
        private static readonly Color FillColor = Color.FromArgb(128, 255, 215, 0);
        private static readonly Color BorderColor = Color.FromArgb(255, 255, 140, 0);

        private bool isDrawing;

        private Point StartPosition;
        private Point CurrentPosition;

        private readonly Brush Brush;
        private readonly Pen Pen;

        public RectanglePainter()
        {
            this.Brush = new SolidBrush(FillColor);
            this.Pen = new Pen(BorderColor) { DashStyle = DashStyle.Dash };
        }

        public void BeginRectangleCreation(Point position)
        {
            CurrentPosition = position;
            StartPosition = position;
            isDrawing = true;
        }

        public bool UpdatePosition(Point position)
        {
            if (isDrawing)
            {
                CurrentPosition = position;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Rectangle FinishRectangleCreation()
        {
            if (isDrawing)
            {
                isDrawing = false;
                var rectangle = GetCreatedRectangle();
                if (rectangle.Width > 0 && rectangle.Height > 0)
                {
                    return rectangle;
                }
            }
            return default;
        }

        public void PaintRectangles(Graphics graphics, Rectangle[] rectangles)
        {
            if (rectangles.Length > 0)
            {
                graphics.FillRectangles(Brush, rectangles);
                graphics.DrawRectangles(Pen, rectangles);

            }

            if (isDrawing)
            {
                graphics.DrawRectangle(Pens.Red, GetCreatedRectangle());
            }
        }

        private Rectangle GetCreatedRectangle()
        {
            var x1 = StartPosition.X;
            var x2 = CurrentPosition.X;
            var y1 = StartPosition.Y;
            var y2 = CurrentPosition.Y;

            return new Rectangle(
                Math.Min(x1, x2),
                Math.Min(y1, y2),
                Math.Abs(x1 - x2),
                Math.Abs(y1 - y2));
        }
    }
}
