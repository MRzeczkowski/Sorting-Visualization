namespace Sorting_visualization
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pctbox_drawingArea = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.cmbChooseFill = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.cmbChooseSort = new System.Windows.Forms.ComboBox();
            this.pctbox_drawingArea2 = new System.Windows.Forms.PictureBox();
            this.cmbChooseSort2 = new System.Windows.Forms.ComboBox();
            this.txtbNumberOfElements = new System.Windows.Forms.TextBox();
            this.lbNumberOfElements = new System.Windows.Forms.Label();
            this.txtbSwapCost = new System.Windows.Forms.TextBox();
            this.lbSwapCost = new System.Windows.Forms.Label();
            this.lbComparisonCost = new System.Windows.Forms.Label();
            this.txtbComparisonCost = new System.Windows.Forms.TextBox();
            this.lbChoseFillType = new System.Windows.Forms.Label();
            this.lbSwapCost2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbSwapCost2 = new System.Windows.Forms.TextBox();
            this.txtbComparisonCost2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_drawingArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_drawingArea2)).BeginInit();
            this.SuspendLayout();
            // 
            // pctbox_drawingArea
            // 
            this.pctbox_drawingArea.BackColor = System.Drawing.Color.White;
            this.pctbox_drawingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbox_drawingArea.Enabled = false;
            this.pctbox_drawingArea.Location = new System.Drawing.Point(101, 10);
            this.pctbox_drawingArea.Margin = new System.Windows.Forms.Padding(2);
            this.pctbox_drawingArea.Name = "pctbox_drawingArea";
            this.pctbox_drawingArea.Size = new System.Drawing.Size(657, 514);
            this.pctbox_drawingArea.TabIndex = 0;
            this.pctbox_drawingArea.TabStop = false;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(9, 136);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(2);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(74, 20);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Draw);
            // 
            // cmbChooseFill
            // 
            this.cmbChooseFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChooseFill.Items.AddRange(new object[] {
            "Descending order",
            "Random",
            "Few unique",
            "Almost sorted",
            "Random values"});
            this.cmbChooseFill.Location = new System.Drawing.Point(8, 38);
            this.cmbChooseFill.Margin = new System.Windows.Forms.Padding(2);
            this.cmbChooseFill.Name = "cmbChooseFill";
            this.cmbChooseFill.Size = new System.Drawing.Size(75, 21);
            this.cmbChooseFill.TabIndex = 2;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(720, 530);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(74, 20);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.StartSorting);
            // 
            // cmbChooseSort
            // 
            this.cmbChooseSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChooseSort.Items.AddRange(new object[] {
            "Bubble Sort",
            "Insertion Sort",
            "Selection Sort",
            "Merge Sort",
            "Shell Sort",
            "Comb Sort",
            "QuickSort",
            "Heap Sort",
            "Radix Sort"});
            this.cmbChooseSort.Location = new System.Drawing.Point(641, 528);
            this.cmbChooseSort.Margin = new System.Windows.Forms.Padding(2);
            this.cmbChooseSort.Name = "cmbChooseSort";
            this.cmbChooseSort.Size = new System.Drawing.Size(75, 21);
            this.cmbChooseSort.TabIndex = 4;
            // 
            // pctbox_drawingArea2
            // 
            this.pctbox_drawingArea2.BackColor = System.Drawing.Color.White;
            this.pctbox_drawingArea2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbox_drawingArea2.Enabled = false;
            this.pctbox_drawingArea2.Location = new System.Drawing.Point(762, 10);
            this.pctbox_drawingArea2.Margin = new System.Windows.Forms.Padding(2);
            this.pctbox_drawingArea2.Name = "pctbox_drawingArea2";
            this.pctbox_drawingArea2.Size = new System.Drawing.Size(657, 514);
            this.pctbox_drawingArea2.TabIndex = 5;
            this.pctbox_drawingArea2.TabStop = false;
            // 
            // cmbChooseSort2
            // 
            this.cmbChooseSort2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChooseSort2.FormattingEnabled = true;
            this.cmbChooseSort2.Items.AddRange(new object[] {
            "Bubble Sort",
            "Insertion Sort",
            "Selection Sort",
            "Merge Sort",
            "Shell Sort",
            "Comb Sort",
            "QuickSort",
            "Heap Sort",
            "Radix Sort"});
            this.cmbChooseSort2.Location = new System.Drawing.Point(798, 529);
            this.cmbChooseSort2.Margin = new System.Windows.Forms.Padding(2);
            this.cmbChooseSort2.Name = "cmbChooseSort2";
            this.cmbChooseSort2.Size = new System.Drawing.Size(75, 21);
            this.cmbChooseSort2.TabIndex = 6;
            // 
            // txtbNumberOfElements
            // 
            this.txtbNumberOfElements.Location = new System.Drawing.Point(10, 101);
            this.txtbNumberOfElements.Name = "txtbNumberOfElements";
            this.txtbNumberOfElements.Size = new System.Drawing.Size(73, 20);
            this.txtbNumberOfElements.TabIndex = 7;
            this.txtbNumberOfElements.TextChanged += new System.EventHandler(this.txtbNumberOfElements_TextChanged);
            // 
            // lbNumberOfElements
            // 
            this.lbNumberOfElements.AutoSize = true;
            this.lbNumberOfElements.Location = new System.Drawing.Point(12, 72);
            this.lbNumberOfElements.Name = "lbNumberOfElements";
            this.lbNumberOfElements.Size = new System.Drawing.Size(56, 26);
            this.lbNumberOfElements.TabIndex = 8;
            this.lbNumberOfElements.Text = "Number of\r\n elements";
            // 
            // txtbSwapCost
            // 
            this.txtbSwapCost.Location = new System.Drawing.Point(160, 544);
            this.txtbSwapCost.Name = "txtbSwapCost";
            this.txtbSwapCost.Size = new System.Drawing.Size(69, 20);
            this.txtbSwapCost.TabIndex = 9;
            this.txtbSwapCost.TextChanged += new System.EventHandler(this.txtbSwapCost_TextChanged);
            // 
            // lbSwapCost
            // 
            this.lbSwapCost.AutoSize = true;
            this.lbSwapCost.Location = new System.Drawing.Point(157, 528);
            this.lbSwapCost.Name = "lbSwapCost";
            this.lbSwapCost.Size = new System.Drawing.Size(79, 13);
            this.lbSwapCost.TabIndex = 10;
            this.lbSwapCost.Text = "Swap cost [ms]";
            // 
            // lbComparisonCost
            // 
            this.lbComparisonCost.AutoSize = true;
            this.lbComparisonCost.Location = new System.Drawing.Point(403, 529);
            this.lbComparisonCost.Name = "lbComparisonCost";
            this.lbComparisonCost.Size = new System.Drawing.Size(107, 13);
            this.lbComparisonCost.TabIndex = 11;
            this.lbComparisonCost.Text = "Comparison cost [ms]";
            // 
            // txtbComparisonCost
            // 
            this.txtbComparisonCost.Location = new System.Drawing.Point(406, 545);
            this.txtbComparisonCost.Name = "txtbComparisonCost";
            this.txtbComparisonCost.Size = new System.Drawing.Size(69, 20);
            this.txtbComparisonCost.TabIndex = 12;
            this.txtbComparisonCost.TextChanged += new System.EventHandler(this.txtbComparisonCost_TextChanged);
            // 
            // lbChoseFillType
            // 
            this.lbChoseFillType.AutoSize = true;
            this.lbChoseFillType.Location = new System.Drawing.Point(7, 9);
            this.lbChoseFillType.Name = "lbChoseFillType";
            this.lbChoseFillType.Size = new System.Drawing.Size(77, 26);
            this.lbChoseFillType.TabIndex = 13;
            this.lbChoseFillType.Text = "Chose starting \r\ndata order";
            // 
            // lbSwapCost2
            // 
            this.lbSwapCost2.AutoSize = true;
            this.lbSwapCost2.Location = new System.Drawing.Point(986, 528);
            this.lbSwapCost2.Name = "lbSwapCost2";
            this.lbSwapCost2.Size = new System.Drawing.Size(79, 13);
            this.lbSwapCost2.TabIndex = 14;
            this.lbSwapCost2.Text = "Swap cost [ms]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1266, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Comparison cost [ms]";
            // 
            // txtbSwapCost2
            // 
            this.txtbSwapCost2.Location = new System.Drawing.Point(989, 544);
            this.txtbSwapCost2.Name = "txtbSwapCost2";
            this.txtbSwapCost2.Size = new System.Drawing.Size(69, 20);
            this.txtbSwapCost2.TabIndex = 16;
            this.txtbSwapCost2.TextChanged += new System.EventHandler(this.txtbSwapCost2_TextChanged);
            // 
            // txtbComparisonCost2
            // 
            this.txtbComparisonCost2.Location = new System.Drawing.Point(1269, 545);
            this.txtbComparisonCost2.Name = "txtbComparisonCost2";
            this.txtbComparisonCost2.Size = new System.Drawing.Size(69, 20);
            this.txtbComparisonCost2.TabIndex = 17;
            this.txtbComparisonCost2.TextChanged += new System.EventHandler(this.txtbComparisonCost2_TextChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 580);
            this.Controls.Add(this.txtbComparisonCost2);
            this.Controls.Add(this.txtbSwapCost2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSwapCost2);
            this.Controls.Add(this.lbChoseFillType);
            this.Controls.Add(this.txtbComparisonCost);
            this.Controls.Add(this.lbComparisonCost);
            this.Controls.Add(this.lbSwapCost);
            this.Controls.Add(this.txtbSwapCost);
            this.Controls.Add(this.lbNumberOfElements);
            this.Controls.Add(this.txtbNumberOfElements);
            this.Controls.Add(this.cmbChooseSort2);
            this.Controls.Add(this.pctbox_drawingArea2);
            this.Controls.Add(this.cmbChooseSort);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.cmbChooseFill);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.pctbox_drawingArea);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "Sorting visualization";
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_drawingArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_drawingArea2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctbox_drawingArea;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.ComboBox cmbChooseFill;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ComboBox cmbChooseSort;
        private System.Windows.Forms.PictureBox pctbox_drawingArea2;
        private System.Windows.Forms.ComboBox cmbChooseSort2;
        private System.Windows.Forms.TextBox txtbNumberOfElements;
        private System.Windows.Forms.Label lbNumberOfElements;
        private System.Windows.Forms.TextBox txtbSwapCost;
        private System.Windows.Forms.Label lbSwapCost;
        private System.Windows.Forms.Label lbComparisonCost;
        private System.Windows.Forms.TextBox txtbComparisonCost;
        private System.Windows.Forms.Label lbChoseFillType;
        private System.Windows.Forms.Label lbSwapCost2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbSwapCost2;
        private System.Windows.Forms.TextBox txtbComparisonCost2;
    }
}

