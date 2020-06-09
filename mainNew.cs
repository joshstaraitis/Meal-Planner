using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Food_Planner_2
{
    public partial class mainNew : Form
    {
        string connectionString = @"Data Source=JOSHPC\SQLEXPRESS;Initial Catalog=FoodTEST;Integrated Security=True;
        Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private void UpdateMealPlanTotals()
        {
            try
            {
                // SqlConnection connection creates a connection to SQL DB using connectionString
                // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
                // Using statement provides simple syntax to ensure correct use of IDisposable objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Stores query in command
                    command.CommandText = @"SELECT SUM(calories) from mealplan";
                    // Opens DB Connection
                    connection.Open();
                    // Executes command against the connection object and returns the number of rows affected
                    command.ExecuteNonQuery();
                    // ExecuteScalar() executes query and returns the first column of the first row in the result
                    object result = command.ExecuteScalar();
                    lblTotalCalories.Text = Convert.ToString(result);

                    command.CommandText = @"SELECT SUM(protein) from mealplan";
                    command.ExecuteNonQuery();
                    object result2 = command.ExecuteScalar();
                    lblTotalProtein.Text = Convert.ToString(result2);

                    command.CommandText = @"SELECT SUM(carbs) from mealplan";
                    command.ExecuteNonQuery();
                    object result3 = command.ExecuteScalar();
                    lblTotalCarbs.Text = Convert.ToString(result3);

                    command.CommandText = @"SELECT SUM(fat) from mealplan";
                    command.ExecuteNonQuery();
                    object result4 = command.ExecuteScalar();
                    lblTotalFat.Text = Convert.ToString(result4);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error updating Meal Plan Totals.");
            }
        }
        private void UpdateDB()
        {
            try
            {
                // SqlConnection connection creates a connection to SQL DB using connectionString
                // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
                // Using statement provides simple syntax to ensure correct use of IDisposable objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Stores query in command
                    command.CommandText = @"SELECT * FROM FOOD";
                    // Creates new SqlCommand with (the text of the query, and connection string) and saves in variable cmd.
                    SqlCommand cmd = new SqlCommand(command.CommandText, connection);
                    // Creates new SqlDataAdapter with specified cmd data
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    // Creates new dataset
                    DataSet dataSet = new DataSet();
                    // Adds rows from dataAdapter into DataSet.
                    dataAdapter.Fill(dataSet);
                    // Sets dgv to read only
                    dgvDB.ReadOnly = true;
                    // sets dvg dataSource to dataSet Dataset
                    dgvDB.DataSource = dataSet.Tables[0];
                    // Closes DB Connection.
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error updating Food Database View");
            }
        }
        private void UpdateMealPlan()
        {
            try
            {
                // SqlConnection connection creates a connection to SQL DB using connectionString
                // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
                // Using statement provides simple syntax to ensure correct use of IDisposable objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Stores query in command
                    command.CommandText = @"SELECT * FROM MEALPLAN";
                    // Creates new SqlCommand with (the text of the query, and connection string) and saves in variable cmd.
                    SqlCommand cmd = new SqlCommand(command.CommandText, connection);
                    // Creates new SqlDataAdapter with specified cmd data
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    // Creates new dataset
                    DataSet dataSet = new DataSet();
                    // Adds rows from dataAdapter into DataSet.
                    dataAdapter.Fill(dataSet);
                    // Sets dgv to read only
                    dgvMealPlan.ReadOnly = true;
                    // sets dvg dataSource to dataSet Dataset
                    dgvMealPlan.DataSource = dataSet.Tables[0];
                    // Closes DB Connection.
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error updating Meal Plan View");
            }
        }
        private bool IsNameTwoValid()
        {
            // Checks to make sure txtFoodSearchName is not empty
            // Returns true if txtFoodSearchName is not empty.
            // Returns false if txtFoodSearchName is empty.
            if (txtFoodSearchName.Text == "")
            {
                MessageBox.Show("Please enter a food name to search.");
                return false;
            }
            return true;
        }
        private bool IsAddFoodDataValid()
        {
            // Checks to make sure txt boxes for adding food section have data entered.
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter food name.");
            }
            else if (txtServing.Text == "")
            {
                MessageBox.Show("Please enter serving size in grams.");
            }
            else if (txtCalories.Text == "")
            {
                MessageBox.Show("Please enter calories.");
            }
            else if (txtProtein.Text == "")
            {
                MessageBox.Show("Please enter protein.");
            }
            else if (txtCarbs.Text == "")
            {
                MessageBox.Show("Please enter carbs.");
            }
            else if (txtFat.Text == "")
            {
                MessageBox.Show("Please enter fat.");
            }
            return true;
        }
        private void DBConnectionTest()
        {
            // SqlConnection connection creates a connection to SQL DB using connectionString
            // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
            // Using statement provides simple syntax to ensure correct use of IDisposable objects.
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                // Opens DB Connection.
                connection.Open();
                // Checks to see if connectionState is open
                // If open, display message box telling user the DB Connection is Open.
                // If closed, display message box telling user the DB Connection is Closed.
                if (connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Database connection is OPEN.");
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    MessageBox.Show("Database connection is CLOSED.");

                }
                // Close DB Connection.
                connection.Close();
            }
        }
        private void ClearForm()
        {
            // Clears all txtBox data
            txtCalories.Clear();
            txtCarbs.Clear();
            txtFat.Clear();
            txtName.Clear();
            txtProtein.Clear();
            txtServing.Clear();
            txtFoodSearchName.Clear();
        }
        private void SubmitData()
        {
            try
            {
                // SqlConnection connection creates a connection to SQL DB using connectionString
                // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
                // Using statement provides simple syntax to ensure correct use of IDisposable objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Stores SQL Query in command
                    command.CommandText = "INSERT INTO Food(Name, Serving, Calories, Protein, Carbs, Fat)" +
                        "VALUES(@Name, @Serving, @Calories, @Protein, @Carbs, @Fat)";
                    // Use AddWithValue to assign txtBox.txt to @DBData
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Serving", txtServing.Text);
                    command.Parameters.AddWithValue("@Calories", txtCalories.Text);
                    command.Parameters.AddWithValue("@Protein", txtProtein.Text);
                    command.Parameters.AddWithValue("@Carbs", txtCarbs.Text);
                    command.Parameters.AddWithValue("@Fat", txtFat.Text);
                    // Opens DB Connection
                    connection.Open();
                    // Executes command against the connection object and returns the number of rows affected
                    command.ExecuteNonQuery();
                }
                MessageBox.Show(txtName.Text + " was added to the database");
                ClearForm();
            }
            catch (SqlException)
            {
                MessageBox.Show(txtName.Text + " was NOT added to the database.");
            }
        }
        private void DeleteFromDB()
        {
            try
            {
                // SqlConnection connection creates a connection to SQL DB using connectionString
                // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
                // Using statement provides simple syntax to ensure correct use of IDisposable objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Stores SQL Query in command
                    command.CommandText = @"DELETE from Food WHERE Name = '" + txtFoodSearchName.Text + "'";
                    // Opens DB Connection
                    connection.Open();
                    // Executes command against the connection object and returns the number of rows affected
                    command.ExecuteNonQuery();
                    // Displays messageBox to alert user that deletion was successful.
                    MessageBox.Show(txtFoodSearchName.Text + " was removed from database.");
                    // Calls ClearForm() Method to clear form data
                    ClearForm();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error deleting from food database.");
            }
        }
        private void AddToMealPlan()
        {
            try
            {
                // SqlConnection connection creates a connection to SQL DB using connectionString
                // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
                // Using statement provides simple syntax to ensure correct use of IDisposable objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Stores SQL Query in command
                    command.CommandText = @"INSERT INTO MEALPLAN(Name, Serving, Calories, Protein, Carbs, Fat)" +
                    "select Name, Serving, Calories, Protein, Carbs, Fat from food WHERE Name = '" + txtFoodSearchName.Text + "'";
                    // Open DB Connection
                    connection.Open();
                    // Executes command against the connection object and returns the number of rows affected
                    command.ExecuteNonQuery();
                    // Calls ClearForm() Method to clear form data
                    ClearForm();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error adding to meal plan.");
            }
        }
        private void DeleteFromMealPlan()
        {
            try
            {
                // SqlConnection connection creates a connection to SQL DB using connectionString
                // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
                // Using statement provides simple syntax to ensure correct use of IDisposable objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Stores SQL Query in command
                    command.CommandText = @"DELETE FROM MEALPLAN WHERE Name = '" + txtFoodSearchName.Text + "'";
                    // Opens DB Connection
                    connection.Open();
                    // Executes command against the connection object and returns the number of rows affected
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error deleting from meal plan.");
            }
        }
        private void SearchDB()
        {
            try
            {
                // SqlConnection connection creates a connection to SQL DB using connectionString
                // SqlCommand command stores a SQL statement/procedure to execute against SQL server DB
                // Using statement provides simple syntax to ensure correct use of IDisposable objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Stores SQL Query in command
                    command.CommandText = @"SELECT Name, Serving, Calories, Protein, Carbs, Fat FROM Food WHERE NAME = '" + txtFoodSearchName.Text + "'";
                    // Creates new SqlCommand with (the text of the query, and connection string) and saves in variable cmd.
                    SqlCommand cmd = new SqlCommand(command.CommandText, connection);
                    // Creates new SqlDataAdapter with specified cmd data
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    // Creates new dataset
                    DataSet dataSet = new DataSet();
                    // Adds rows from dataAdapter into DataSet.
                    dataAdapter.Fill(dataSet);
                    // Sets dgv to read only
                    dgvLookupSearch.ReadOnly = true;
                    // sets dvg dataSource to dataSet Dataset
                    dgvLookupSearch.DataSource = dataSet.Tables[0];
                    // Closes DB Connection.
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error searching food database.");
            }
        }
        public mainNew()
        {
            InitializeComponent();
            UpdateDB();
            UpdateMealPlan();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDBTest_Click(object sender, EventArgs e)
        {
            DBConnectionTest();
        }
        private void btnCalcTotal_Click(object sender, EventArgs e)
        {
            UpdateMealPlanTotals();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsAddFoodDataValid())
            {
                SubmitData();
                UpdateDB();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteFromDB();
            UpdateDB();
        }
        private void btnAddToMealPlan_Click(object sender, EventArgs e)
        {
            AddToMealPlan();
            UpdateMealPlan();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsNameTwoValid())
            {
                SearchDB();
            }
        }
        private void btnDeleteFromMealPlan_Click(object sender, EventArgs e)
        {
            DeleteFromMealPlan();
            UpdateMealPlan();
            ClearForm();
        }
    }
}