using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialApp;
using Npgsql;

namespace FinancialApp
{

    


    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {

            //CREATE USERS TABLE IN DATABASE
            try
            {
                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();

                    // Check if the table exists
                    string checkTableQuery = @"
                            SELECT EXISTS (
                                SELECT FROM information_schema.tables 
                                WHERE table_schema = 'public' 
                                AND table_name = 'users'
                            );";

                    bool tableExists;
                    using (var checkCommand = new NpgsqlCommand(checkTableQuery, connection))
                    {
                        tableExists = (bool)checkCommand.ExecuteScalar();
                    }

                    // Create the table if it doesn't exist
                    if (!tableExists)
                    {
                        string createTableQuery = @"
                                CREATE TABLE users (
                                    id SERIAL PRIMARY KEY,
                                    name TEXT NOT NULL UNIQUE,
                                    password TEXT NOT NULL,
                                    salt TEXT NOT NULL
                                );
        ";
                        using (var createCommand = new NpgsqlCommand(createTableQuery, connection))
                        {
                            createCommand.ExecuteNonQuery();
                        }

                        //MessageBox.Show("Table 'users' was created successfully.", "Database Initialized", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //else
                    //{
                    //    MessageBox.Show("Table 'users' already exists.", "Database Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while initializing the users table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            //CREATE TRANSACTIONS TABLE IN DATABASE 
            try
            {
                // Connect to the database
                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();

                    // Check if the table exists
                    string checkTableQuery = @"
                            SELECT EXISTS (
                                SELECT FROM information_schema.tables 
                                WHERE table_schema = 'public' 
                                AND table_name = 'transactions'
                            );";

                    bool tableExists;
                    using (var checkCommand = new NpgsqlCommand(checkTableQuery, connection))
                    {
                        tableExists = (bool)checkCommand.ExecuteScalar();
                    }

                    // Create the table if it doesn't exist
                    if (!tableExists)
                    {
                        string createTableQuery = @"
                                CREATE TABLE IF NOT EXISTS transactions (
                                id SERIAL PRIMARY KEY,
                                description TEXT NOT NULL,
                                amount NUMERIC NOT NULL,
                                date TIMESTAMP NOT NULL,
                                type VARCHAR(10) NOT NULL CHECK (type IN ('Income', 'Expense')),
                                user_id INT NOT NULL,
                                CONSTRAINT fk_user FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE
                            );

        ";
                        using (var createCommand = new NpgsqlCommand(createTableQuery, connection))
                        {
                            createCommand.ExecuteNonQuery();
                        }

                        // Insert default transactions
        //                string insertDefaultTransactions = @"
        //                        INSERT INTO transactions (description, amount, date, type, user_id) VALUES
        //                            ('Salary', 5000.00, NOW(), 'Income', 1),
        //                            ('Groceries', -150.00, NOW(), 'Expense', 1),
        //                            ('Utilities', -200.00, NOW(), 'Expense', 1),
        //                            ('Freelance Project', 1500.00, NOW(), 'Income', 2),
        //                            ('Gym Membership', -50.00, NOW(), 'Expense', 2),
        //                            ('Dining Out', -75.00, NOW(), 'Expense', 2);

        //";
        //                using (var insertCommand = new NpgsqlCommand(insertDefaultTransactions, connection))
        //                {
        //                    insertCommand.ExecuteNonQuery();
        //                }

                        //MessageBox.Show("Table 'transactions' was created.", "Database Initialized", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //else
                    //{
                    //    MessageBox.Show("Table 'transactions' already exists.", "Database Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while initializing the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private string GenerateSalt()
        {
            // Generate a 16-byte cryptographically secure random salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            // Combine password and salt
            string saltedPassword = password + salt;

            // Hash the salted password
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashBytes);
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash, string salt)
        {
            // Hash the input password with the same salt and compare with the stored hash
            string inputHash = HashPassword(inputPassword, salt);
            return inputHash == storedHash;
        }


        private void loginButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both name and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();

                    // Query to retrieve user ID, hashed password, and salt
                    string query = "SELECT id, password, salt FROM users WHERE name = @name";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0); // Retrieve the user ID
                                string storedHash = reader.GetString(1); // Retrieve the hashed password
                                string salt = reader.GetString(2); // Retrieve the salt

                                // Verify the entered password
                                if (VerifyPassword(password, storedHash, salt))
                                {
                                    Session.LoggedInUserId = userId; // Store the logged-in user's ID
                                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid name or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid name or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void signupButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both name and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();

                    // Generate salt and hash the password
                    string salt = GenerateSalt();
                    string hashedPassword = HashPassword(password, salt);

                    // Insert user into the database
                    string query = "INSERT INTO users (name, password, salt) VALUES (@name, @password, @salt)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@password", hashedPassword);
                        command.Parameters.AddWithValue("@salt", salt);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Signup successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (PostgresException ex) when (ex.SqlState == "23505") // Unique violation
            {
                MessageBox.Show("The name is already taken. Please choose a different one.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during signup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
