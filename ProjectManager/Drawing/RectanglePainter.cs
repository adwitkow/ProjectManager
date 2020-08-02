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

        public void StartDrawing(Point position)
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

        public Rectangle GetCurrentNativeRectangle(float zoomFactor, Point offset)
        {
            if (isDrawing)
            {
                isDrawing = false;
                var rectangle = CreateNativeRectangle(zoomFactor, offset);
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
                graphics.DrawRectangle(Pens.Red, CreateNativeRectangle(1, Point.Empty));
            }
        }

        private Rectangle CreateNativeRectangle(float zoomFactor, Point offset)
        {
            var x1 = (int)(StartPosition.X / zoomFactor + offset.X);
            var x2 = (int)(CurrentPosition.X / zoomFactor + offset.X);
            var y1 = (int)(StartPosition.Y / zoomFactor + offset.Y);
            var y2 = (int)(CurrentPosition.Y / zoomFactor + offset.Y);
            return new Rectangle(
                Math.Min(x1, x2),
                Math.Min(y1, y2),
                Math.Abs(x1 - x2),
                Math.Abs(y1 - y2));
        }
    }
}
