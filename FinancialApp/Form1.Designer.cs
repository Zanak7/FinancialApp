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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(19, 352);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(713, 309);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F);
            label1.Location = new Point(103, 9);
            label1.Name = "label1";
            label1.Size = new Size(573, 62);
            label1.TabIndex = 1;
            label1.Text = "Personal Finance Manager";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 155);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 2;
            label2.Text = "Description :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 201);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 3;
            label3.Text = "Amount :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 263);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 4;
            label4.Text = "Type :";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(199, 152);
            descriptionTextBox.Margin = new Padding(3, 4, 3, 4);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(247, 27);
            descriptionTextBox.TabIndex = 5;
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(199, 201);
            amountTextBox.Margin = new Padding(3, 4, 3, 4);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(247, 27);
            amountTextBox.TabIndex = 6;
            // 
            // transactionTypeComboBox
            // 
            transactionTypeComboBox.FormattingEnabled = true;
            transactionTypeComboBox.Location = new Point(198, 265);
            transactionTypeComboBox.Margin = new Padding(3, 4, 3, 4);
            transactionTypeComboBox.Name = "transactionTypeComboBox";
            transactionTypeComboBox.Size = new Size(249, 28);
            transactionTypeComboBox.TabIndex = 7;
            // 
            // addTransactionButton
            // 
            addTransactionButton.BackColor = Color.SteelBlue;
            addTransactionButton.Location = new Point(495, 152);
            addTransactionButton.Margin = new Padding(3, 4, 3, 4);
            addTransactionButton.Name = "addTransactionButton";
            addTransactionButton.Size = new Size(232, 72);
            addTransactionButton.TabIndex = 8;
            addTransactionButton.Text = "Add";
            addTransactionButton.UseVisualStyleBackColor = false;
            addTransactionButton.Click += addTransactionButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 328);
            label5.Name = "label5";
            label5.Size = new Size(143, 20);
            label5.TabIndex = 10;
            label5.Text = "List Of Transactions :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-6, 305);
            label6.Name = "label6";
            label6.Size = new Size(801, 20);
            label6.TabIndex = 11;
            label6.Text = "____________________________________________________________________________________________________________________________________";
            // 
            // deleteTransactionButton
            // 
            deleteTransactionButton.BackColor = Color.Tomato;
            deleteTransactionButton.Location = new Point(563, 665);
            deleteTransactionButton.Margin = new Padding(3, 4, 3, 4);
            deleteTransactionButton.Name = "deleteTransactionButton";
            deleteTransactionButton.Size = new Size(169, 69);
            deleteTransactionButton.TabIndex = 12;
            deleteTransactionButton.Text = "Delete";
            deleteTransactionButton.UseVisualStyleBackColor = false;
            deleteTransactionButton.Click += deleteTransactionButton_Click;
            // 
            // showReportsButton
            // 
            showReportsButton.Location = new Point(19, 704);
            showReportsButton.Margin = new Padding(3, 4, 3, 4);
            showReportsButton.Name = "showReportsButton";
            showReportsButton.Size = new Size(169, 31);
            showReportsButton.TabIndex = 13;
            showReportsButton.Text = "Show Reports";
            showReportsButton.UseVisualStyleBackColor = true;
            showReportsButton.Click += showReportsButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F);
            label7.Location = new Point(495, 241);
            label7.Name = "label7";
            label7.Size = new Size(230, 30);
            label7.TabIndex = 14;
            label7.Text = "Current Balance: $0.00";
            // 
            // updateTransactionButton
            // 
            updateTransactionButton.BackColor = SystemColors.Control;
            updateTransactionButton.Location = new Point(387, 665);
            updateTransactionButton.Margin = new Padding(3, 4, 3, 4);
            updateTransactionButton.Name = "updateTransactionButton";
            updateTransactionButton.Size = new Size(169, 69);
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
            logoutButton.Location = new Point(14, 16);
            logoutButton.Margin = new Padding(3, 4, 3, 4);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(83, 55);
            logoutButton.TabIndex = 16;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // reportTypeComboBox
            // 
            reportTypeComboBox.FormattingEnabled = true;
            reportTypeComboBox.Items.AddRange(new object[] { "Daily", "Monthly", "Yearly" });
            reportTypeComboBox.Location = new Point(19, 665);
            reportTypeComboBox.Margin = new Padding(3, 4, 3, 4);
            reportTypeComboBox.Name = "reportTypeComboBox";
            reportTypeComboBox.Size = new Size(169, 28);
            reportTypeComboBox.TabIndex = 17;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(22, 773);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(705, 213);
            dataGridView2.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(22, 749);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 19;
            label8.Text = "Reports :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(754, 1003);
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
            Margin = new Padding(3, 4, 3, 4);
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
    }
}
