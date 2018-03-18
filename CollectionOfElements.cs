using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting_visualization
{
    class CollectionOfElements
    {
        protected Element[] Elements;

        protected Graphics graphics;

        protected Bitmap buffer;

        protected PictureBox PictureBox;

        public PictureBox GetPictureBox
        {
            get
            {
                return this.PictureBox;
            }
        }

        public Bitmap modBuffer
        {
            get
            {
                return this.buffer;
            }
        }

        public int getElementValue(int i)
        {
            return Elements[i].modElement;
        }

        public int getElementSepperation(int i)
        {
            return Elements[i].GetSepperation;
        }

        public int getElementWidth(int i)
        {
            return Elements[i].GetElementWidth;
        }

        public Color getElementColor(int i)
        {
            return Elements[i].modColor;
        }

        private int[] Values;

        private double Sepperation;
        private double ValueLevel;
        private double ElementWidth;

        protected int Height;

        public int modHeight
        {
            get
            {
                return this.Height;
            }
        }

        protected int NumberOfElements;

        public int modNumberOfElements
        {
            get
            {
                return this.NumberOfElements;
            }
        }

        private Random randVal;

        public CollectionOfElements(int NumberOfElements, Bitmap buffer, PictureBox PictureBox)
        {
            this.Elements = new Element[NumberOfElements];
            this.Values = new int[NumberOfElements];
            this.NumberOfElements = NumberOfElements;
            this.buffer = buffer;
            this.PictureBox = PictureBox;
            this.Height = PictureBox.Height;
            this.graphics = Graphics.FromImage(buffer);
            this.Sepperation = (((double)PictureBox.Width / NumberOfElements));
            this.ValueLevel = (((double)PictureBox.Height / NumberOfElements));
            this.ElementWidth = ((double)PictureBox.Width / NumberOfElements) - 2;
        }

        public void DrawElements()
        {
            for(int i = 0; i < NumberOfElements; i++)
            {
                DrawElement(i);
            }
        }

        public void EraseElements()
        {
            for (int i = 0; i < NumberOfElements; i++)
            {
                EraseElement(i);
            }
        }

        public void ColoneCoe(CollectionOfElements coe)
        {
            for(int i = 0; i < NumberOfElements; i++)
            {
                this.Elements[i].modElement = coe.Elements[i].modElement;
                this.Elements[i].modColor = coe.Elements[i].modColor;
                this.Elements[i].GetSepperation = coe.Elements[i].GetSepperation;
            }
        }

        protected void DrawElement(int numOfElement)
        {
            Elements[numOfElement].Erase();
            Elements[numOfElement].Draw();
        }

        protected void EraseElement(int numOfElement)
        {
            Elements[numOfElement].Erase();
        }

        public void Initiate()
        {           
            for (int i = 0; i < NumberOfElements; i++)
            {              
                Elements[i] = new Element(0, buffer, PictureBox, (int)(Sepperation * i), (int)(ElementWidth));
            }
        }

        public void FillInDesc()
        {
            for (int i = 0; i < NumberOfElements; i++)
            {
                Elements[i] = new Element(Height-(int)(ValueLevel * i), buffer, PictureBox, (int)(Sepperation * i), (int)(ElementWidth));
               
            }

        }

        public void FillInRandom()
        {
            FillInDesc();
            Shuffle();
        }

        public void FillWithFewUnique()
        {
            int k = NumberOfElements/3;

            for (int i = 0; i < NumberOfElements; i++)
            { 
                if (k >= i + NumberOfElements/5)
                {
                    Elements[i] = new Element((int)(ValueLevel * k), buffer, PictureBox, (int)(Sepperation * i), (int)(ElementWidth));
                }
                else
                {
                    k += NumberOfElements / 5;
                    Elements[i] = new Element((int)(ValueLevel * k),  buffer, PictureBox, (int)(Sepperation * i), (int)(ElementWidth));
                }

                if (i == 0)
                {
                    Elements[i].modColor = Color.Green;
                }
                if (i == 1)
                {
                    Elements[i].modColor = Color.Red;
                }

            }
            Shuffle();
        }

        public void FillWithAlmostSorted()
        {
            for(int i = 0; i < NumberOfElements; i++)
            {
                Elements[i] = new Element((int)(ValueLevel * (i+1)), buffer, PictureBox, (int)(Sepperation * i), (int)(ElementWidth));
            }

            randVal = new Random();

            for(int j = 0; j < NumberOfElements/20; j++)
            {
                int r1 = randVal.Next(0, NumberOfElements);
                int r2 = randVal.Next(0, NumberOfElements);

                int tmp = Elements[r1].modElement;

                Elements[r1].modElement = Elements[r2].modElement;

                Elements[r2].modElement = tmp;
            }
        }

        public void FillWithRandomValues()
        {
            randVal = new Random();

            for (int i = 0; i < NumberOfElements; i++)
            {
                int tmp = randVal.Next(1, PictureBox.Height);

                Elements[i] = new Element(tmp, buffer, PictureBox, (int)(Sepperation * i), (int)(ElementWidth));
            }
        }

        private void Shuffle()
        {
            randVal = new Random();

            for (int i = 0; i < NumberOfElements; i++)
            {
                int tmp = Elements[i].modElement;
                Color color = Elements[i].modColor;

                int r = randVal.Next(i, NumberOfElements);

                Elements[i].modElement = Elements[r].modElement;
                Elements[i].modColor = Elements[r].modColor;

                Elements[r].modElement = tmp;
                Elements[r].modColor = color;
            }
        }

        public void ShowValues()
        {
            string messagetext = "";

            for(int i = 0; i < NumberOfElements; i++)
            {
                Values[i] = Elements[i].modElement/8;
                messagetext += Values[i].ToString() + " ";
            }
            MessageBox.Show(messagetext);
        }
    }
}
