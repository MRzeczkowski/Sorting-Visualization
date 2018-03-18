using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting_visualization
{
    class Element
    {
        private int Value;

        private Graphics graphics;

        private int Bottom;

        private Bitmap buffer;

        private PictureBox PictureBox;
        
        public int modElement
        {
            get
            {
                return this.Value;
            }

            set
            {
                this.Value = value;
                this.Bottom = PictureBox.Height - this.Value;
            }
        }        
        
        private int Sepperation = 1;

        public int GetSepperation
        {
            get
            {
                return this.Sepperation;
            }

            set
            {
                this.Sepperation = value;
            }
        }

        private int ElementWidth;

        public int GetElementWidth
        {
            get
            {
                return this.ElementWidth;
            }

            set
            {
                this.ElementWidth = value;
            }
        }

        private Pen pen = new Pen(Color.Black, 1);
        private Pen eraser = new Pen(Color.White, 1);

        private Rectangle rect;
        private SolidBrush brush;

        private Color Color;

        public Color modColor
        {
            get
            {
                return this.Color;
            }

            set
            {
                this.Color = value;
            }
        }

        
        
        public Element(int Value, Bitmap buffer, PictureBox PictureBox, int Sepperation, int ElementWidth)
        {
            this.Value = Value;
            Bottom = PictureBox.Height - Value;
            this.buffer = buffer;
            this.PictureBox = PictureBox;
            graphics =  Graphics.FromImage(buffer);
            this.Sepperation = Sepperation;
            this.ElementWidth = ElementWidth;
            Color = Color.FromArgb(0, 0, 0);
        }

        public Element(int Value, Bitmap buffer, PictureBox PictureBox, int Sepperation, int ElementWidth, Color color)
        {
            this.Value = Value;
            Bottom = PictureBox.Height - Value;
            this.buffer = buffer;
            this.PictureBox = PictureBox;
            graphics = Graphics.FromImage(buffer);
            this.Sepperation = Sepperation;
            this.ElementWidth = ElementWidth;
            this.Color = color;

        }

        public void Draw()
        {
            rect = new Rectangle(Sepperation, Bottom, ElementWidth, Value);
            brush = new SolidBrush(Color);
           
            graphics.DrawRectangle(pen, rect);
            graphics.FillRectangle(brush, rect);

            PictureBox.Image = buffer;
        }

        public void Erase()
        {
            rect = new Rectangle(Sepperation, Bottom, ElementWidth, Value);
            brush = new SolidBrush(Color.FromArgb(255, 255, 255));           
             
            graphics.DrawRectangle(eraser, rect);
            graphics.FillRectangle(brush, rect);

            PictureBox.Image = buffer;
        }

        public void Highligth()
        {
            Color Color = new Color();
            Color = Color.Blue;

            rect = new Rectangle(Sepperation, Bottom, ElementWidth, Value);
            brush = new SolidBrush(Color);

            graphics.DrawRectangle(pen, rect);
            graphics.FillRectangle(brush, rect);

            PictureBox.Image = buffer;
        }
    }
}