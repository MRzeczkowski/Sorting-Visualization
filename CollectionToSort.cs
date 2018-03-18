using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Sorting_visualization
{
    class CollectionToSort: CollectionOfElements
    {
        //private int[] SecondaryTab;
        private Element[] SecondaryTab;
        private Stopwatch Stopwatch;

        private int SwapCost;

        public int ModSwapCost
        {
            set
            {
                this.SwapCost = value;
            }
        }

        private int ComparisonCost;

        public int ModComparisonCost
        {
            set
            {
                this.ComparisonCost = value;
            }
        }

        private int AccessedCounter = 0;
        private int ComparisonCounter = 0;
        private int SwapCounter = 0;

        public CollectionToSort(CollectionOfElements coe, int SwapCost, int ComparisonCost): base(coe.modNumberOfElements, coe.modBuffer, coe.GetPictureBox)
        {
            //SecondaryTab = new int[this.NumberOfElements];
            SecondaryTab = new Element[this.NumberOfElements];

            Stopwatch = new Stopwatch();

            this.SwapCost = SwapCost;
            this.ComparisonCost = ComparisonCost;

            for (int i = 0; i < NumberOfElements; i++)
            {
                Elements[i] = new Element(coe.getElementValue(i), coe.modBuffer, coe.GetPictureBox, coe.getElementSepperation(i), coe.getElementWidth(i), coe.getElementColor(i));
                //SecondaryTab[i] = coe.getElementValue(i);
                SecondaryTab[i] = new Element(coe.getElementValue(i), coe.modBuffer, coe.GetPictureBox, coe.getElementSepperation(i), coe.getElementWidth(i), coe.getElementColor(i));
            }           
        }

        public void BubbleSort()
        {
            InitiateAndStartStopwatch();

            for (int i = 0; i < NumberOfElements; i++)
            {
                for (int j = 0; j < NumberOfElements - 1; j++)
                {
                    if (CompareElements(Elements[j], Elements[j + 1]))
                    {
                        SwapAndDrawElements(j, j + 1);
                    }
                }
            }
            ShowTimeElapsed();
        }

        public void InsertionSort()
        {
            InitiateAndStartStopwatch();

            int i = 1;
            while (i < NumberOfElements)
            {
                int j = i;
                while (j > 0 && CompareElements(Elements[j - 1], Elements[j]))
                {
                    SwapAndDrawElements(j, j - 1);
                    j--;                    
                }
                i++;
            }
            ShowTimeElapsed();
        }

        public void SelectionSort()
        {
            InitiateAndStartStopwatch();

            for (int i = 0; i < NumberOfElements - 1; i++)
            {
                int jMin = i;

                for(int j = i + 1; j < NumberOfElements; j++)
                {
                    if(CompareElements(Elements[jMin], Elements[j]))
                    {
                        jMin = j;
                    }
                }

                if(jMin != i)
                {
                    SwapAndDrawElements(i, jMin);
                }
            }
            ShowTimeElapsed();
        }

        private void Merge(int Start, int End)
        {
            for (int i = 0; i < NumberOfElements; i++)
            {
                SecondaryTab[i].modElement = Elements[i].modElement;
                SecondaryTab[i].modColor = Elements[i].modColor;
            }

            int start = Start;
            int middle = (Start+End)/2 + 1;
            int r = Start;

            while(start <= (Start + End) / 2 && middle <= End)
            {
                if(CompareValues(SecondaryTab[middle].modElement, SecondaryTab[start].modElement))
                {
                    SetValueFromSecondaryAndShowElement(r, start);

                    r++;
                    start++;
                }
                else
                {
                    SetValueFromSecondaryAndShowElement(r, middle);

                    r++;
                    middle++;
                }

            }
            while(start <= (Start + End) / 2)
            {
                SetValueFromSecondaryAndShowElement(r, start);

                r++;
                start++;
            }
        }
        
        public void MergeSort(int Start, int End)
        {            
            if (Start < End)
            {
                MergeSort(Start, (Start + End)/2);
                MergeSort((Start + End) / 2 + 1, End);

                Merge(Start, End);
            }            
        }

        public void ShellSort()
        {
            int[] gaps = new int[8] { 701, 301, 132, 57, 23, 10, 4, 1 };

            int j;

            Element temp = new Element(0, buffer, PictureBox, 1, 1);

            InitiateAndStartStopwatch();

            foreach (int gap in gaps)
            {
                for(int i = gap; i < NumberOfElements; i++)
                {

                    temp.modElement = Elements[i].modElement;
                    temp.modColor = Elements[i].modColor;

                    for (j = i; j >= gap && CompareElements(Elements[j - gap], temp); j -= gap)
                    {
                        Elements[j - gap].Highligth();
                        SetValueFromMainAndShowElement(j, j - gap);
                    }
                    Elements[j].Highligth();
                    EraseElement(j);
                    Elements[j].modElement = temp.modElement;
                    Elements[j].modColor = temp.modColor;
                    DrawElement(j);
                    SwapCounter++;
                }
            }
           ShowTimeElapsed();
        }

        public void CombSort()
        {
            int gap = NumberOfElements;
            double ShrinkFactor = 1.3;
            bool sorted = false;

            InitiateAndStartStopwatch();

            while (sorted == false)
            {
                gap = (int)Math.Floor(gap/ShrinkFactor);

                if (gap > 1)
                {
                    sorted = false;
                }

                else
                {
                    gap = 1;
                    sorted = true;
                }

                int i = 0;

                while(i + gap < NumberOfElements)
                {
                    if(CompareElements(Elements[i], Elements[i + gap]))
                    {
                        SwapAndDrawElements(i, i + gap);
                        sorted = false;
                    }

                    i++;
                }
            }
            ShowTimeElapsed();
        }

        public void QuickSort(int left, int right)
        {
            int i = left;
            int j = right;

            var pivot = Elements[(left + right) / 2].modElement;

            while(i < j)
            {
                while (CompareValues(pivot, Elements[i].modElement)) i++;
                while (CompareValues(Elements[j].modElement,pivot)) j--;

                if(i <= j)
                {
                    SwapAndDrawElements(i, j);

                    i++;
                    j--;
                }
            }
            if (left < j) QuickSort(left, j);
            if (i < right) QuickSort(i, right);
        }

        public void HeapSort()
        {
            InitiateAndStartStopwatch();

            int heapSize = NumberOfElements;

            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(heapSize, p);

            for(int i = NumberOfElements -1; i >=0; i--)
            {
                SwapAndDrawElements(i, 0);

                heapSize--;
                MaxHeapify(heapSize, 0);
            }

            ShowTimeElapsed();
        }

        private void MaxHeapify(int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && CompareElements(Elements[left], Elements[index]))
                largest = left;
            else
                largest = index;

            if (right < heapSize && CompareElements(Elements[right], Elements[largest]))
                largest = right;

            if(largest != index)
            {
                SwapAndDrawElements(index, largest);

                MaxHeapify(heapSize, largest);
            }
        }

        public void RadixSort()
        {
            InitiateAndStartStopwatch();

            int r = 4; //długość w bitach naszych grup

            int b = 32; // liczba bitów int'a w C#

            int[] count = new int[1 << r]; //ilość cyfr w liczbie
            int[] pref = new int[1 << r]; // prefiksy

            int groups = (int)Math.Ceiling(b/(double)r); // liczba grup

            int mask = (1 << r) - 1; // maska używana do identyfikacji grup

            for(int c = 0, shift = 0; c < groups; c++, shift += r)
            {
                for (int j = 0; j < count.Length; j++)
                    count[j] = 0; // resetuje liczność

                for (int i = 0; i < NumberOfElements; i++)
                    count[(Elements[i].modElement >> shift) & mask]++; // obliczam liczność grupy
                 
                //obliczam prefiksy
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];

                for (int i = 0; i < NumberOfElements; i++)
                {
                    //z oryginalnej tabeli do pomocniczej uporządkwane względem grupy
                    SecondaryTab[pref[(Elements[i].modElement >> shift) & mask]].modElement = Elements[i].modElement;
                    SecondaryTab[pref[(Elements[i].modElement >> shift) & mask]].modColor = Elements[i].modColor;
                    pref[(Elements[i].modElement >> shift) & mask]++;
                }


                for(int a = 0; a < NumberOfElements; a++)
                {
                    // z pomocniczej wrzucam do oryginalnej i powtarzam aż dojdę do ostatniej grupy
                    SetValueFromSecondaryAndShowElement(a, a);
                }
            }

            ShowTimeElapsed();
        }

        public  void BucketSort()
        {
            int minValue = Elements[0].modElement;
            int maxValue = Elements[0].modElement;

            InitiateAndStartStopwatch();

            for (int i = 1; i < NumberOfElements; i++)
            {
                AccessedCounter++;
                if (Elements[i].modElement > maxValue)
                    maxValue = Elements[i].modElement;
                if (Elements[i].modElement < minValue)
                    minValue = Elements[i].modElement;
            }

            List<Element>[] bucket = new List<Element>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<Element>();
            }

            for (int i = 0; i < NumberOfElements; i++)
            {
                System.Threading.Thread.Sleep(SwapCost);
                SwapCounter++;
                AccessedCounter++;
                bucket[Elements[i].modElement - minValue].Add(SecondaryTab[i]);
                Elements[i].Erase();
            }

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        System.Threading.Thread.Sleep(SwapCost);
                        Elements[k].Erase();
                        Elements[k].modElement = bucket[i][j].modElement;
                        Elements[k].modColor = bucket[i][j].modColor;
                        Elements[k].Draw();
                        k++;
                        SwapCounter++;
                        AccessedCounter++;
                    }
                }
            }

            ShowTimeElapsed();
        }

        public void InitiateAndStartStopwatch()
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
        }

        public void ShowTimeElapsed()
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0));
            Point point = new Point(0, 0);
            Font font = new Font("Arial", 8);

            double time = (double)(Stopwatch.ElapsedMilliseconds);
            time = time / 1000;

            graphics.DrawString(time.ToString() + " s", font, brush, point);

            point.Y = 10;
            graphics.DrawString("Array accessed " + AccessedCounter.ToString() + " times", font, brush, point);

            point.Y = 20;
            graphics.DrawString("Number of comparisons: " + ComparisonCounter.ToString(), font, brush, point);

            point.Y = 30;
            graphics.DrawString("Number of swaps: " + SwapCounter.ToString(), font, brush, point);

            PictureBox.Image = buffer;
        }

        private void SwapAndDrawElements(int i, int j)
        {
            Elements[i].Highligth();
            Elements[j].Highligth();

            System.Threading.Thread.Sleep(SwapCost);

            EraseElement(i);
            EraseElement(j);

            int tmp = Elements[i].modElement;
            Color color = Elements[i].modColor;

            Elements[i].modElement = Elements[j].modElement;
            Elements[i].modColor = Elements[j].modColor;

            Elements[j].modElement = tmp;
            Elements[j].modColor = color;


            DrawElement(i);
            DrawElement(j);

            AccessedCounter += 2;
            SwapCounter++;
        }

        private void SetValueFromSecondaryAndShowElement(int i, int j)
        {
            Elements[i].Highligth();

            System.Threading.Thread.Sleep(SwapCost);

            EraseElement(i);

            Elements[i].modElement =SecondaryTab[j].modElement;
            Elements[i].modColor = SecondaryTab[j].modColor;

            DrawElement(i);

            SwapCounter++;
            AccessedCounter += 1;
        }

        private void SetValueFromMainAndShowElement(int i, int j)
        {
            Elements[i].Highligth();

            System.Threading.Thread.Sleep(SwapCost);

            EraseElement(i);

            Elements[i].modElement = Elements[j].modElement;
            Elements[i].modColor = Elements[j].modColor;

            DrawElement(i);

            SwapCounter++;
            AccessedCounter += 1;
        }

        private bool CompareElements(Element i, Element j)
        {
            System.Threading.Thread.Sleep(ComparisonCost);

            ComparisonCounter++;
            AccessedCounter += 1;

            if (i.modElement > j.modElement) return true;
            else return false;
        }

        private bool CompareValues(int i, int j)
        {
            System.Threading.Thread.Sleep(ComparisonCost);

            AccessedCounter += 1;
            ComparisonCounter++;

            if (i > j) return true;
            else return false;
        }
    }
}
