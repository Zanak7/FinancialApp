namespace FinancialApp
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            descriptionTextBox = new TextBox();
            amountTextBox = new TextBox();
            transactionTypeComboBox = new ComboBox();
            addTransactionButton = new Button();
            label5 = new Label();
            label6 = new Label();
            deleteTransactionButton = new Button();
            showReportsButton = new Button();
            label7 = new Label();
            updateTransactionButton = new Button();
            logoutButton = new Button();
            reportTypeComboBox = new ComboBox();
            dataGridView2 = new DataGridView();
            label8 = new Label();
            transactionDatePicker = new DateTimePicker();
            label9 = new Label();
            updateAllButton = new Button();
            deleteAllButton = new Button();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 295);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(624, 225);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(91, -1);
            label1.Name = "label1";
            label1.Size = new Size(487, 54);
            label1.TabIndex = 1;
            label1.Text = "Personal Finance Manager";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(17, 87);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 2;
            label2.Text = "Description :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(17, 124);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 3;
            label3.Text = "Amount :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(17, 200);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 4;
            label4.Text = "Type :";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(174, 87);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(217, 23);
            descriptionTextBox.TabIndex = 5;
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(174, 124);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(217, 23);
            amountTextBox.TabIndex = 6;
            // 
            // transactionTypeComboBox
            // 
            transactionTypeComboBox.FormattingEnabled = true;
            transactionTypeComboBox.Location = new Point(173, 200);
            transactionTypeComboBox.Name = "transactionTypeComboBox";
            transactionTypeComboBox.Size = new Size(218, 23);
            transactionTypeComboBox.TabIndex = 7;
            // 
            // addTransactionButton
            // 
            addTransactionButton.BackColor = SystemColors.Control;
            addTransactionButton.Location = new Point(433, 87);
            addTransactionButton.Name = "addTransactionButton";
            addTransactionButton.Size = new Size(203, 54);
            addTransactionButton.TabIndex = 8;
            addTransactionButton.Text = "Add";
            addTransactionButton.UseVisualStyleBackColor = false;
            addTransactionButton.Click += addTransactionButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(17, 260);
            label5.Name = "label5";
            label5.Size = new Size(143, 20);
            label5.TabIndex = 10;
            label5.Text = "List Of Transactions :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-5, 233);
            label6.Name = "label6";
            label6.Size = new Size(667, 15);
            label6.TabIndex = 11;
            label6.Text = "____________________________________________________________________________________________________________________________________";
            // 
            // deleteTransactionButton
            // 
            deleteTransactionButton.BackColor = Color.Tomato;
            deleteTransactionButton.Location = new Point(493, 530);
            deleteTransactionButton.Name = "deleteTransactionButton";
            deleteTransactionButton.Size = new Size(148, 52);
            deleteTransactionButton.TabIndex = 12;
            deleteTransactionButton.Text = "Delete";
            deleteTransactionButton.UseVisualStyleBackColor = false;
            deleteTransactionButton.Click += deleteTransactionButton_Click;
            // 
            // showReportsButton
            // 
            showReportsButton.Location = new Point(17, 642);
            showReportsButton.Name = "showReportsButton";
            showReportsButton.Size = new Size(148, 23);
            showReportsButton.TabIndex = 13;
            showReportsButton.Text = "Show Reports";
            showReportsButton.UseVisualStyleBackColor = true;
            showReportsButton.Click += showReportsButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(433, 170);
            label7.Name = "label7";
            label7.Size = new Size(166, 21);
            label7.TabIndex = 14;
            label7.Text = "Current Balance: $0.00";
            // 
            // updateTransactionButton
            // 
            updateTransactionButton.BackColor = Color.DodgerBlue;
            updateTransactionButton.Location = new Point(339, 530);
            updateTransactionButton.Name = "updateTransactionButton";
            updateTransactionButton.Size = new Size(148, 52);
            updateTransactionButton.TabIndex = 15;
            updateTransactionButton.Text = "Update";
            updateTransactionButton.UseVisualStyleBackColor = false;
            updateTransactionButton.Click += updateTransactionButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.Firebrick;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.ForeColor = SystemColors.ControlLightLight;
            logoutButton.Location = new Point(12, 12);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(73, 41);
            logoutButton.TabIndex = 16;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // reportTypeComboBox
            // 
            reportTypeComboBox.FormattingEnabled = true;
            reportTypeComboBox.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });
            reportTypeComboBox.Location = new Point(17, 613);
            reportTypeComboBox.Name = "reportTypeComboBox";
            reportTypeComboBox.Size = new Size(148, 23);
            reportTypeComboBox.TabIndex = 17;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(19, 692);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(617, 174);
            dataGridView2.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F);
            label8.Location = new Point(19, 669);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 19;
            label8.Text = "Reports :";
            // 
            // transactionDatePicker
            // 
            transactionDatePicker.Format = DateTimePickerFormat.Short;
            transactionDatePicker.Location = new Point(174, 161);
            transactionDatePicker.Name = "transactionDatePicker";
            transactionDatePicker.Size = new Size(217, 23);
            transactionDatePicker.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F);
            label9.Location = new Point(19, 161);
            label9.Name = "label9";
            label9.Size = new Size(48, 20);
            label9.TabIndex = 21;
            label9.Text = "Date :";
            // 
            // updateAllButton
            // 
            updateAllButton.BackColor = Color.DodgerBlue;
            updateAllButton.Location = new Point(339, 257);
            updateAllButton.Name = "updateAllButton";
            updateAllButton.Size = new Size(148, 34);
            updateAllButton.TabIndex = 23;
            updateAllButton.Text = "Update All";
            updateAllButton.UseVisualStyleBackColor = false;
            updateAllButton.Click += updateAllButton_Click;
            // 
            // deleteAllButton
            // 
            deleteAllButton.BackColor = Color.Tomato;
            deleteAllButton.Location = new Point(493, 257);
            deleteAllButton.Name = "deleteAllButton";
            deleteAllButton.Size = new Size(148, 34);
            deleteAllButton.TabIndex = 22;
            deleteAllButton.Text = "Delete All";
            deleteAllButton.UseVisualStyleBackColor = false;
            deleteAllButton.Click += deleteAllButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(-3, 584);
            label10.Name = "label10";
            label10.Size = new Size(667, 15);
            label10.TabIndex = 24;
            label10.Text = "____________________________________________________________________________________________________________________________________";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(19, 538);
            label11.Name = "label11";
            label11.Size = new Size(258, 30);
            label11.TabIndex = 25;
            label11.Text = "To delete or update a transaction please select it\r\nfrom the datagridview above.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(660, 878);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(updateAllButton);
            Controls.Add(deleteAllButton);
            Controls.Add(label9);
            Controls.Add(transactionDatePicker);
            Controls.Add(label8);
            Controls.Add(dataGridView2);
            Controls.Add(reportTypeComboBox);
            Controls.Add(logoutButton);
            Controls.Add(updateTransactionButton);
            Controls.Add(label7);
            Controls.Add(showReportsButton);
            Controls.Add(deleteTransactionButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(addTransactionButton);
            Controls.Add(transactionTypeComboBox);
            Controls.Add(amountTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fianacial App";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox descriptionTextBox;
        private TextBox amountTextBox;
        private ComboBox transactionTypeComboBox;
        private Button addTransactionButton;
        private Label label5;
        private Label label6;
        private Button showReportsButton;
        private Label label7;
        private Button deleteTransactionButton;
        private Button updateTransactionButton;
        private Button logoutButton;
        private ComboBox reportTypeComboBox;
        private DataGridView dataGridView2;
        private Label label8;
        private DateTimePicker transactionDatePicker;
        private Label label9;
        private Button updateAllButton;
        private Button deleteAllButton;
        private Label label10;
        private Label label11;
    }
}
