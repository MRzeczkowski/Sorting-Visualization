using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sorting_visualization
{
    public partial class MainWindow : Form
    {        
        CollectionOfElements test;
        CollectionToSort cts;

        CollectionOfElements test2;
        CollectionToSort cts2;

        string tmp;
        string tmp2;

        Bitmap Bitmap;
        Bitmap Bitmap2;

        int NumberOfElements;
        int SwapCost;
        int SwapCost2;

        int ComparisonCost;
        int ComparisonCost2;

        int MaxAmountOfElements;

        int sem;
        
        public MainWindow()
        {            
            InitializeComponent();

            btnSort.Enabled = false;

            cmbChooseFill.Text = "Descending order";
            cmbChooseSort.Text = "Bubble Sort";                        
            cmbChooseSort2.Text = "Bubble Sort";

            txtbNumberOfElements.Text = "10";

            txtbSwapCost.Text = "10";
            txtbComparisonCost.Text = "10";

            txtbSwapCost2.Text = "10";
            txtbComparisonCost2.Text = "10";

            Bitmap = new Bitmap(pctbox_drawingArea.Width, pctbox_drawingArea.Height);
            Bitmap2 = new Bitmap(pctbox_drawingArea2.Width, pctbox_drawingArea2.Height);

            NumberOfElements = Int32.Parse(txtbNumberOfElements.Text);

            SwapCost = Int32.Parse(txtbSwapCost.Text);
            ComparisonCost = Int32.Parse(txtbComparisonCost.Text);

            SwapCost2 = Int32.Parse(txtbSwapCost.Text);
            ComparisonCost2 = Int32.Parse(txtbComparisonCost.Text);
        }

        private void Draw(object sender, MouseEventArgs e)
        {            
            try
            {
                NumberOfElements = Int32.Parse(txtbNumberOfElements.Text);
                test = new CollectionOfElements(NumberOfElements, Bitmap, pctbox_drawingArea);
                test2 = new CollectionOfElements(NumberOfElements,  Bitmap2, pctbox_drawingArea2);

            }
            catch
            {                
                MessageBox.Show("Please set parameters", "No parameters");
                return;
            }
            

            if (pctbox_drawingArea.Image != null)
            {
                pctbox_drawingArea.Image.Dispose();
                pctbox_drawingArea.Image = null;
            }

            if (pctbox_drawingArea2.Image != null)
            {
                pctbox_drawingArea2.Image.Dispose();
                pctbox_drawingArea2.Image = null;
            }
            
            Bitmap = new Bitmap(pctbox_drawingArea.Width, pctbox_drawingArea.Height);
            Bitmap2 = new Bitmap(pctbox_drawingArea2.Width, pctbox_drawingArea2.Height);

            ChooseFillType();            

            test2.Initiate();
            test2.ColoneCoe(test);

            test.DrawElements();
            test2.DrawElements();
            btnSort.Enabled = true;
        }
        
        private void ChooseFillType()
        {
            switch (cmbChooseFill.Text)
            {
                case "Descending order":
                    test.FillInDesc();                    
                    break;

                case "Random":
                    test.FillInRandom();
                    break;

                case "Few unique":
                    test.FillWithFewUnique();
                    break;

                case "Almost sorted":
                    test.FillWithAlmostSorted();
                    break;

                case "Random values":
                    test.FillWithRandomValues();
                    break;
            }
        }

        private void StartSorting(object sender, EventArgs e)       
        {
            sem = 0;

            cts = new CollectionToSort(test, SwapCost, ComparisonCost);
            cts2 = new CollectionToSort(test2, SwapCost, ComparisonCost);

            Graphics graphic = Graphics.FromImage(pctbox_drawingArea.Image);
            graphic.Clear(Color.White);

            Graphics graphic2 = Graphics.FromImage(pctbox_drawingArea2.Image);
            graphic2.Clear(Color.White);


            Bitmap = new Bitmap(pctbox_drawingArea.Width, pctbox_drawingArea.Height);
            Bitmap2 = new Bitmap(pctbox_drawingArea2.Width, pctbox_drawingArea2.Height);

            ChooseFillType();
            test2.ColoneCoe(test);

            cts.DrawElements();
            cts2.DrawElements();

            tmp = cmbChooseSort.Text;
            tmp2 = cmbChooseSort2.Text;
            DisableControls();

            BackgroundWorker sort = new BackgroundWorker();
            BackgroundWorker sort2 = new BackgroundWorker();

            sort.DoWork += new DoWorkEventHandler(Sorting);
            sort2.DoWork += new DoWorkEventHandler(Sorting2);

            sort.RunWorkerCompleted += new RunWorkerCompletedEventHandler(EnableControls);
            sort2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(EnableControls);

            sort.RunWorkerAsync();
            Thread.Sleep(10);
            sort2.RunWorkerAsync();
        }

        private void Sorting(object sender, DoWorkEventArgs e)
        {
            switch (tmp)
            {
                case "Bubble Sort":
                    cts.BubbleSort();
                    break;

                case "Insertion Sort":
                    cts.InsertionSort();
                    break;

                case "Selection Sort":
                    cts.SelectionSort();
                    break;

                case "Merge Sort":
                    cts.InitiateAndStartStopwatch();
                    cts.MergeSort(0, NumberOfElements - 1);
                    cts.ShowTimeElapsed();
                    break;

                case "Shell Sort":
                    cts.ShellSort();
                    break;

                case "Comb Sort":
                    cts.CombSort();
                    break;

                case "QuickSort":
                    cts.InitiateAndStartStopwatch();
                    cts.QuickSort(0, NumberOfElements - 1);
                    cts.ShowTimeElapsed();
                    break;

                case "Heap Sort":
                    cts.HeapSort();
                    break;

                case "Radix Sort":
                    cts.RadixSort();
                    break;
            }
        }

        private void Sorting2(object sender, DoWorkEventArgs e)
        {
            switch (tmp2)
            {
                case "Bubble Sort":
                        cts2.BubbleSort();
                        break;

                    case "Insertion Sort":
                        cts2.InsertionSort();
                        break;

                    case "Selection Sort":
                        cts2.SelectionSort();
                        break;

                    case "Merge Sort":
                        cts2.InitiateAndStartStopwatch();
                        cts2.MergeSort(0, NumberOfElements - 1);
                        cts2.ShowTimeElapsed();
                        break;

                    case "Shell Sort":
                        cts2.ShellSort();
                        break;

                    case "Comb Sort":
                        cts2.CombSort();
                        break;

                    case "QuickSort":
                        cts2.InitiateAndStartStopwatch();
                        cts2.QuickSort(0, NumberOfElements - 1);
                        cts2.ShowTimeElapsed();
                        break;

                    case "Heap Sort":
                        cts2.HeapSort();
                        break;

                case "Radix Sort":
                    cts2.RadixSort();
                    break;
            }
        }        
        
        private void DisableControls()
        {
            txtbNumberOfElements.Enabled = false;

            foreach (Control c in this.Controls)
            {
                if ((c is Button))
                    c.Enabled = false;                
            }
        }

        private void EnableControls(object sender, RunWorkerCompletedEventArgs e)
        {            
            if (sem == 1)
            {
                foreach (Control c in this.Controls)
                {
                    if (!(c is PictureBox))
                        c.Enabled = true;
                }
                this.Enabled = true;
                sem = 0;
            }
            sem++;
        }

        private void txtbSwapCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SwapCost = Int32.Parse(txtbSwapCost.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a number.", "Numbers only!");
                txtbSwapCost.Text = "10";                
            }

            if (cts != null && cts2 != null)
            {
                cts.ModSwapCost = SwapCost;
            }
        }

        private void txtbSwapCost2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SwapCost2 = Int32.Parse(txtbSwapCost2.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a number.", "Numbers only!");
                txtbSwapCost2.Text = "10";
            }

            if (cts != null && cts2 != null)
            {                
                cts2.ModSwapCost = SwapCost2;
            }
        }

        private void txtbComparisonCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ComparisonCost = Int32.Parse(txtbComparisonCost.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a number.", "Numbers only!");
                txtbComparisonCost.Text = "10";
            }

            if (cts != null && cts2 != null)
            {
                cts.ModComparisonCost = ComparisonCost;
            }
        }

        private void txtbComparisonCost2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ComparisonCost2 = Int32.Parse(txtbComparisonCost2.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a number.", "Numbers only!");
                txtbComparisonCost2.Text = "10";
            }

            if (cts != null && cts2 != null)
            {
                cts2.ModComparisonCost = ComparisonCost2;
            }
        }

        private void txtbNumberOfElements_TextChanged(object sender, EventArgs e)
        {
            MaxAmountOfElements = pctbox_drawingArea.Width / 3;

            try
            {
                if (Int32.Parse(txtbNumberOfElements.Text) <= MaxAmountOfElements)
                {
                    NumberOfElements = Int32.Parse(txtbNumberOfElements.Text);
                }
                else
                {
                    MessageBox.Show("Maximal amount of elements is " + MaxAmountOfElements, "To many elements");
                    txtbNumberOfElements.Text = MaxAmountOfElements.ToString();
                    NumberOfElements = MaxAmountOfElements;
                }
            }
            catch
            {                
                MessageBox.Show("Please enter a number.", "Numbers only!");
                txtbNumberOfElements.Text = "10";
                return;
            }
        }        
    }
}
