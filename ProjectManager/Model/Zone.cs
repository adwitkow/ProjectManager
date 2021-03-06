﻿using ProjectManager.Zones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{
    public abstract class Zone : INotifyPropertyChanged
    {
        // TODO: Clean up this object, decouple the DB model
        public abstract ZoneType Type { get; }

        public int Id { get; set; }
        public int X
        {
            get => _x;
            set
            {
                _x = value;
                ForceUpdateRectangle();
                OnPropertyChanged();
            }
        }
        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                ForceUpdateRectangle();
                OnPropertyChanged();
            }
        }
        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                ForceUpdateRectangle();
                OnPropertyChanged();
            }
        }
        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                ForceUpdateRectangle();
                OnPropertyChanged();
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                if (_rectangle == default)
                {
                    _rectangle = new Rectangle(X, Y, Width, Height);
                }
                return _rectangle;
            }
            set
            {
                _x = value.X;
                _y = value.Y;
                _width = value.Width;
                _height = value.Height;

                _rectangle = value;
                OnPropertyChanged();
            }
        }

        public int FillColorR { get; set; }
        public int FillColorG { get; set; }
        public int FillColorB { get; set; }
        public int FillColorA { get; set; }

        public int BorderColorR { get; set; }
        public int BorderColorG { get; set; }
        public int BorderColorB { get; set; }
        public int BorderColorA { get; set; }

        public Color FillColor
        {
            get
            {
                if (_fillColor == default)
                {
                    _fillColor = Color.FromArgb(FillColorA, FillColorR, FillColorG, FillColorB);
                }
                return _fillColor;
            }
            set
            {
                FillColorR = value.R;
                FillColorG = value.G;
                FillColorB = value.B;
                FillColorA = value.A;

                _fillColor = value;
                OnPropertyChanged();
            }
        }
        public Color BorderColor
        {
            get
            {
                if (_borderColor == default)
                {
                    _borderColor = Color.FromArgb(BorderColorA, BorderColorR, BorderColorG, BorderColorB);
                }
                return _borderColor;
            }
            set
            {
                BorderColorR = value.R;
                BorderColorG = value.G;
                BorderColorB = value.B;
                BorderColorA = value.A;

                _borderColor = value;
                OnPropertyChanged();
            }
        }

        private int _x;
        private int _y;
        private int _width;
        private int _height;

        private Rectangle _rectangle;
        private Color _fillColor;
        private Color _borderColor;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Zone(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public Zone(Rectangle rectangle, Color fillColor, Color borderColor) : this(rectangle)
        {
            this.FillColor = fillColor;
            this.BorderColor = borderColor;
        }

        public Zone() { }

        public abstract Zone Clone();

        private void ForceUpdateRectangle()
        {
            Rectangle = new Rectangle(X, Y, Width, Height);
        }
    }
}
