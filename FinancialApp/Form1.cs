using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace FinancialApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            PopulateTransactionTypeComboBox();
            LoadData(Session.LoggedInUserId);
            UpdateCurrentBalance();
        }







        private void LoadData(int currentUserId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT id, description, amount, date, type
                FROM transactions
                WHERE user_id = @user_id
                ORDER BY date DESC;";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", currentUserId);

                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            var dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Set the data source for the DataGridView
                            dataGridView1.DataSource = dataTable;

                            // Replace the type column with a ComboBox column
                            if (!dataGridView1.Columns.Contains("typeComboBox"))
                            {
                                var comboBoxColumn = new DataGridViewComboBoxColumn
                                {
                                    Name = "typeComboBox",
                                    HeaderText = "Type",
                                    DataPropertyName = "type", // Bind to the "type" field
                                    DataSource = new string[] { "Income", "Expense" }, // Set options
                                    DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton // Optional, for cleaner UI
                                };

                                // Remove existing type column and add the ComboBox column
                                dataGridView1.Columns.Remove("type");
                                dataGridView1.Columns.Add(comboBoxColumn);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateCurrentBalance()
        {
            try
            {
                // Ensure a user is logged in
                if (Session.LoggedInUserId == -1)
                {
                    MessageBox.Show("No user is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    COALESCE(SUM(CASE WHEN type = 'Income' THEN amount ELSE 0 END), 0) - 
                    COALESCE(SUM(CASE WHEN type = 'Expense' THEN amount ELSE 0 END), 0) 
                AS total_balance
                FROM transactions
                WHERE user_id = @user_id";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", Session.LoggedInUserId); // Filter by logged-in user

                        var totalBalance = Convert.ToDecimal(command.ExecuteScalar());
                        label7.Text = $"Current Balance: ${totalBalance:F2}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while calculating the balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void PopulateTransactionTypeComboBox()
        {
            // Add types to the ComboBox
            transactionTypeComboBox.Items.Add("Income");
            transactionTypeComboBox.Items.Add("Expense");

            // Optionally, set a default selection
            transactionTypeComboBox.SelectedIndex = 0; // Select "Income" by default
        }

        private void addTransactionButton_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(amountTextBox.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (transactionTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a transaction type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a user is logged in
            if (Session.LoggedInUserId == -1)
            {
                MessageBox.Show("No user is logged in. Please log in to add a transaction.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Insert transaction into the database
                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO transactions (description, amount, date, type, user_id) VALUES (@description, @amount, @date, @type, @user_id)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@date", DateTime.Now); // Current timestamp
                        command.Parameters.AddWithValue("@type", transactionTypeComboBox.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@user_id", Session.LoggedInUserId); // Use the logged-in user's ID

                        command.ExecuteNonQuery();
                    }
                }

                // Clear input fields
                descriptionTextBox.Text = string.Empty;
                amountTextBox.Text = string.Empty;
                transactionTypeComboBox.SelectedIndex = 0;

                // Refresh the DataGridView
                LoadData(Session.LoggedInUserId);
                UpdateCurrentBalance();

                MessageBox.Show("Transaction added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void deleteTransactionButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            int transactionId = (int)selectedRow.Cells["id"].Value;

            var result = MessageBox.Show(
                "Are you sure you want to delete this transaction?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new NpgsqlConnection(Session.ConnectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM transactions WHERE id = @id AND user_id = @user_id";

                        using (var command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", transactionId);
                            command.Parameters.AddWithValue("@user_id", Session.LoggedInUserId); // Ensure user-specific deletion

                            command.ExecuteNonQuery();
                        }
                    }

                    LoadData(Session.LoggedInUserId);
                    UpdateCurrentBalance();

                    MessageBox.Show("Transaction deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void updateTransactionButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            int transactionId = (int)selectedRow.Cells["id"].Value;

            string updatedDescription = selectedRow.Cells["description"].Value.ToString();
            decimal updatedAmount;
            if (!decimal.TryParse(selectedRow.Cells["amount"].Value.ToString(), out updatedAmount))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string updatedType = selectedRow.Cells[4].Value.ToString();

            var result = MessageBox.Show(
                "Are you sure you want to update this transaction?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new NpgsqlConnection(Session.ConnectionString))
                    {
                        connection.Open();
                        string query = @"
                    UPDATE transactions
                    SET description = @description, 
                        amount = @amount, 
                        type = @type
                    WHERE id = @id AND user_id = @user_id";

                        using (var command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@description", updatedDescription);
                            command.Parameters.AddWithValue("@amount", updatedAmount);
                            command.Parameters.AddWithValue("@type", updatedType);
                            command.Parameters.AddWithValue("@id", transactionId);
                            command.Parameters.AddWithValue("@user_id", Session.LoggedInUserId); // Ensure user-specific update

                            command.ExecuteNonQuery();
                        }
                    }

                    LoadData(Session.LoggedInUserId);
                    UpdateCurrentBalance();

                    MessageBox.Show("Transaction updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void showReportsButton_Click(object sender, EventArgs e)
        {
            if (reportTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = reportTypeComboBox.SelectedItem.ToString();
            string query = string.Empty;

            // Choose the query based on the selected report type
            switch (reportType)
            {
                case "Daily":
                    query = @"
                SELECT 
                    TO_CHAR(date, 'YYYY-MM-DD') AS day, 
                    COALESCE(SUM(CASE WHEN type = 'Income' THEN amount ELSE 0 END), 0) AS total_income,
                    COALESCE(SUM(CASE WHEN type = 'Expense' THEN amount ELSE 0 END), 0) AS total_expense,
                    COALESCE(SUM(CASE WHEN type = 'Income' THEN amount ELSE -amount END), 0) AS balance
                FROM 
                    transactions
                WHERE 
                    user_id = @user_id
                GROUP BY 
                    TO_CHAR(date, 'YYYY-MM-DD')
                ORDER BY 
                    day DESC;";
                    break;

                case "Monthly":
                    query = @"
                SELECT 
                    TO_CHAR(date, 'YYYY-MM') AS month, 
                    COALESCE(SUM(CASE WHEN type = 'Income' THEN amount ELSE 0 END), 0) AS total_income,
                    COALESCE(SUM(CASE WHEN type = 'Expense' THEN amount ELSE 0 END), 0) AS total_expense,
                    COALESCE(SUM(CASE WHEN type = 'Income' THEN amount ELSE -amount END), 0) AS balance
                FROM 
                    transactions
                WHERE 
                    user_id = @user_id
                GROUP BY 
                    TO_CHAR(date, 'YYYY-MM')
                ORDER BY 
                    month DESC;";
                    break;

                case "Yearly":
                    query = @"
                SELECT 
                    TO_CHAR(date, 'YYYY') AS year, 
                    COALESCE(SUM(CASE WHEN type = 'Income' THEN amount ELSE 0 END), 0) AS total_income,
                    COALESCE(SUM(CASE WHEN type = 'Expense' THEN amount ELSE 0 END), 0) AS total_expense,
                    COALESCE(SUM(CASE WHEN type = 'Income' THEN amount ELSE -amount END), 0) AS balance
                FROM 
                    transactions
                WHERE 
                    user_id = @user_id
                GROUP BY 
                    TO_CHAR(date, 'YYYY')
                ORDER BY 
                    year DESC;";
                    break;

                default:
                    MessageBox.Show("Invalid report type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Fetch and display the report
            try
            {
                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", Session.LoggedInUserId);

                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            var dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView2.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void Logout()
        {
            // Confirm logout
            var result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Clear session
                Session.LoggedInUserId = -1;

                // Redirect to LoginForm
                this.Hide(); // Hide the current form
                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        this.Show(); // If login is successful, show Form1 again
                        LoadData(Session.LoggedInUserId); // Reload user-specific data
                        UpdateCurrentBalance();
                    }
                    else
                    {
                        this.Close(); // If login is canceled, close the application
                    }
                }
            }
        }


        private void logoutButton_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
