namespace ASM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtCustomerName = new TextBox();
            txtNumberOfPeople = new TextBox();
            txtThisMonthWater = new TextBox();
            txtLastMonthWater = new TextBox();
            label1 = new Label();
            btnCalculate = new Button();
            cbTypeOfCustomer = new ComboBox();
            lvWaterBill = new ListView();
            txtSearch = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cboSort = new ComboBox();
            SuspendLayout();
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(65, 47);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "Enter your Customer name";
            txtCustomerName.Size = new Size(217, 27);
            txtCustomerName.TabIndex = 0;
            // 
            // txtNumberOfPeople
            // 
            txtNumberOfPeople.Enabled = false;
            txtNumberOfPeople.Location = new Point(68, 134);
            txtNumberOfPeople.Name = "txtNumberOfPeople";
            txtNumberOfPeople.PlaceholderText = "Enter your Number People";
            txtNumberOfPeople.Size = new Size(214, 27);
            txtNumberOfPeople.TabIndex = 2;
            // 
            // txtThisMonthWater
            // 
            txtThisMonthWater.Location = new Point(65, 251);
            txtThisMonthWater.Name = "txtThisMonthWater";
            txtThisMonthWater.PlaceholderText = "Enter this month's water meter";
            txtThisMonthWater.Size = new Size(214, 27);
            txtThisMonthWater.TabIndex = 3;
            // 
            // txtLastMonthWater
            // 
            txtLastMonthWater.Location = new Point(65, 180);
            txtLastMonthWater.Name = "txtLastMonthWater";
            txtLastMonthWater.PlaceholderText = "Enter last month's water meter";
            txtLastMonthWater.Size = new Size(214, 27);
            txtLastMonthWater.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 228);
            label1.Name = "label1";
            label1.Size = new Size(175, 20);
            label1.TabIndex = 5;
            label1.Text = "This month's water meter";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(188, 302);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(94, 29);
            btnCalculate.TabIndex = 6;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // cbTypeOfCustomer
            // 
            cbTypeOfCustomer.FormattingEnabled = true;
            cbTypeOfCustomer.Items.AddRange(new object[] { "Household customer", "Administrative agency, public services", "Production units", "Business services" });
            cbTypeOfCustomer.Location = new Point(68, 90);
            cbTypeOfCustomer.Name = "cbTypeOfCustomer";
            cbTypeOfCustomer.Size = new Size(214, 28);
            cbTypeOfCustomer.TabIndex = 7;
            cbTypeOfCustomer.SelectedIndexChanged += cbTypeOfCustomer_SelectedIndexChanged_1;
            // 
            // lvWaterBill
            // 
            lvWaterBill.Location = new Point(343, 45);
            lvWaterBill.Name = "lvWaterBill";
            lvWaterBill.Size = new Size(943, 386);
            lvWaterBill.TabIndex = 8;
            lvWaterBill.UseCompatibleStateImageBehavior = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(343, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(362, 27);
            txtSearch.TabIndex = 9;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // cboSort
            // 
            cboSort.FormattingEnabled = true;
            cboSort.Items.AddRange(new object[] { "Total Bill (Small To Large)", "Total Bill (Large To Small)" });
            cboSort.Location = new Point(748, 14);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(151, 28);
            cboSort.TabIndex = 10;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 450);
            Controls.Add(cboSort);
            Controls.Add(txtSearch);
            Controls.Add(lvWaterBill);
            Controls.Add(cbTypeOfCustomer);
            Controls.Add(btnCalculate);
            Controls.Add(label1);
            Controls.Add(txtLastMonthWater);
            Controls.Add(txtThisMonthWater);
            Controls.Add(txtNumberOfPeople);
            Controls.Add(txtCustomerName);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCustomerName;
        private TextBox txtNumberOfPeople;
        private TextBox txtThisMonthWater;
        private TextBox txtLastMonthWater;
        private Label label1;
        private Button btnCalculate;
        private ComboBox cbTypeOfCustomer;
        private ListView lvWaterBill;
        private TextBox txtSearch;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cboSort;
    }
}
