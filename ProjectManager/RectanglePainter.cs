using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ProjectManager
{
    class RectanglePainter
    {
        private static readonly Color FillColor = Color.FromArgb(128, 255, 215, 0);
        private static readonly Color BorderColor = Color.FromArgb(255, 255, 140, 0);

        public bool IsDrawing { get; private set; }

        public IList<Rectangle> Rectangles { get; private set; }

        private readonly IList<Rectangle> NativeRectangles;

        private Point StartPosition;
        private Point CurrentPosition;

        private readonly Brush Brush;
        private readonly Pen Pen;

        public RectanglePainter()
        {
            this.NativeRectangles = new List<Rectangle>();
            this.Rectangles = new List<Rectangle>();

            this.Brush = new SolidBrush(FillColor);
            this.Pen = new Pen(BorderColor) { DashStyle = DashStyle.Dash };
        }

        public void StartDrawing(Point position)
        {
            CurrentPosition = position;
            StartPosition = position;
            IsDrawing = true;
        }

        public void UpdatePosition(Point position)
        {
            CurrentPosition = position;
        }

        public Rectangle AssignNewNativeRectangle(float zoomFactor)
        {
            if (IsDrawing)
            {
                IsDrawing = false;
                var rectangle = CreateNativeRectangle(zoomFactor);
                if (rectangle.Width > 0 && rectangle.Height > 0)
                {
                    NativeRectangles.Add(rectangle);
                }
                ResizeRectangles(zoomFactor);
                return rectangle;
            }
            return default;
        }

        public void PaintRectangles(Graphics graphics)
        {
            if (Rectangles.Count > 0)
            {
                var rectanglesArray = Rectangles.ToArray();
                graphics.FillRectangles(Brush, rectanglesArray);
                graphics.DrawRectangles(Pen, rectanglesArray);
            }

            if (IsDrawing)
            {
                graphics.DrawRectangle(Pens.Red, CreateNativeRectangle(1));
            }
        }

        public void ResizeRectangles(float zoomFactor)
        {
            Rectangles.Clear();
            foreach (var rectangle in NativeRectangles)
            {
                var x = (int)(rectangle.X * zoomFactor);
                var y = (int)(rectangle.Y * zoomFactor);
                var w = (int)(rectangle.Width * zoomFactor);
                var h = (int)(rectangle.Height * zoomFactor);
                Rectangles.Add(new Rectangle(x, y, w, h));
            }
        }

        private Rectangle CreateNativeRectangle(float zoomFactor)
        {
            var x1 = (int)(StartPosition.X / zoomFactor);
            var x2 = (int)(CurrentPosition.X / zoomFactor);
            var y1 = (int)(StartPosition.Y / zoomFactor);
            var y2 = (int)(CurrentPosition.Y / zoomFactor);
            return new Rectangle(
                Math.Min(x1, x2),
                Math.Min(y1, y2),
                Math.Abs(x1 - x2),
                Math.Abs(y1 - y2));
        }
    }
}
