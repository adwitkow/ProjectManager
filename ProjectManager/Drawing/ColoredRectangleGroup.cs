using System.Drawing;

namespace ProjectManager.Drawing
{
    class ColoredRectangleGroup
    {
        public readonly Color FillColor;
        public readonly Color BorderColor;
        public readonly Rectangle[] Rectangles;

        public ColoredRectangleGroup(Color fillColor, Color borderColor, Rectangle[] rectangles)
        {
            this.FillColor = fillColor;
            this.BorderColor = borderColor;
            this.Rectangles = rectangles;
        }
    }
}
