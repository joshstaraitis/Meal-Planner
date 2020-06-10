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
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Database connection is OPEN.");
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    MessageBox.Show("Database connection is CLOSED.");

                }
                connection.Close();
            }
        }
        private void ClearForm()
        {
            txtCalories.Clear();
            txtCarbs.Clear();
            txtFat.Clear();
            txtName.Clear();
            txtProtein.Clear();
            txtServing.Clear();
            txtFoodSearchName.Clear();
        }
        private void SubmitDataFoodAdd()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Food(Name, Serving, Calories, Protein, Carbs, Fat)" +
                        "VALUES(@Name, @Serving, @Calories, @Protein, @Carbs, @Fat)";
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Serving", txtServing.Text);
                    command.Parameters.AddWithValue("@Calories", txtCalories.Text);
                    command.Parameters.AddWithValue("@Protein", txtProtein.Text);
                    command.Parameters.AddWithValue("@Carbs", txtCarbs.Text);
                    command.Parameters.AddWithValue("@Fat", txtFat.Text);
                    connection.Open();
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
        private void DeleteFoodFromDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE from Food WHERE Name = '" + txtFoodSearchName.Text + "'";
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show(txtFoodSearchName.Text + " was removed from database.");
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO MEALPLAN(Name, Serving, Calories, Protein, Carbs, Fat)" +
                    "select Name, Serving, Calories, Protein, Carbs, Fat from food WHERE Name = '" + txtFoodSearchName.Text + "'";
                    connection.Open();
                    command.ExecuteNonQuery();
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM MEALPLAN WHERE Name = '" + txtFoodSearchName.Text + "'";
                    connection.Open();
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Name, Serving, Calories, Protein, Carbs, Fat FROM Food WHERE NAME LIKE '%" + txtFoodSearchName.Text + "%'";
                    SqlCommand cmd = new SqlCommand(command.CommandText, connection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dgvFoodSearch.ReadOnly = true;
                    dgvFoodSearch.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error searching food database.");
            }
        }
        private void SearchDBWithConstraints()
        {
            try
            {             
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM food WHERE CALORIES <= '" +
                        txtFFCal.Text + "' AND PROTEIN <= '" + txtFFProtein.Text + "' " +
                            "AND CARBS <= '" + txtFFCarb.Text + "' AND FAT <= '" + txtFFFat.Text + "'";
                    SqlCommand cmd = new SqlCommand(command.CommandText, connection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dgvFoodSearch.ReadOnly = true;
                    dgvFoodSearch.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error searching food database.");
            }

        }
        private void SubmitMacroGoalData()
        {
            try
            {
               
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO MacroGoalsNEW(calories, protein, carbs, fat)" +
                        "VALUES(@calories, @protein, @carbs, @fat)";
                    command.Parameters.AddWithValue("@calories", tbGoalCal.Text);
                    command.Parameters.AddWithValue("@protein", tbGoalProtein.Text);
                    command.Parameters.AddWithValue("@carbs", tbGoalCarbs.Text);
                    command.Parameters.AddWithValue("@fat", tbGoalFat.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Macro goals have been submitted.");

                //MessageBox.Show("Your updated MACRO GOALS ARE:\n" +
                //    "Calories: " + tbGoalCal.Text + "\n" +
                //    "Protein: " + tbGoalProtein.Text + "\n" +
                //    "Carbs: " + tbGoalCarbs.Text + "\n" +
                //    "Fat: " + tbGoalFat.Text);
            }
            catch (SqlException)
            {
                MessageBox.Show(txtName.Text + "MACRO GOAL ERROR.");
            }

        }
        private void UpdateMacroGoals()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT (calories) from macrogoalsnew";
                    connection.Open();
                    command.ExecuteNonQuery();
                    object result = command.ExecuteScalar();
                    lblGoalCal.Text = Convert.ToString(result);

                    command.CommandText = @"SELECT (protein) from macrogoalsnew";
                    command.ExecuteNonQuery();
                    object result2 = command.ExecuteScalar();
                    lblGoalProtein.Text = Convert.ToString(result2);

                    command.CommandText = @"SELECT(carbs) from macrogoalsnew";
                    command.ExecuteNonQuery();
                    object result3 = command.ExecuteScalar();
                    lblGoalCarbs.Text = Convert.ToString(result3);

                    command.CommandText = @"SELECT (fat) from macrogoalsnew";
                    command.ExecuteNonQuery();
                    object result4 = command.ExecuteScalar();
                    lblGoalFat.Text = Convert.ToString(result4);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error updating Meal Plan Totals.");
            }
        }
        private void UpdateMacroDifference()
        {
            double GoalCal = Convert.ToDouble(lblGoalCal.Text);
            double TotalCal = Convert.ToDouble(lblTotalCalories.Text);
            double GoalProtein = Convert.ToDouble(lblGoalProtein.Text);
            double TotalProtein = Convert.ToDouble(lblTotalProtein.Text);
            double GoalCarbs = Convert.ToDouble(lblGoalCarbs.Text);
            double TotalCarbs = Convert.ToDouble(lblTotalCarbs.Text);
            double GoalFat = Convert.ToDouble(lblGoalFat.Text);
            double TotalFat = Convert.ToDouble(lblTotalFat.Text);

            lblMacroDiffCal.Text = (GoalCal - TotalCal).ToString();
            lblMacroDiffProtein.Text = (GoalProtein - TotalProtein).ToString();
            lblMacroDiffCarbs.Text = (GoalCarbs - TotalCarbs).ToString();
            lblMacroDiffFat.Text = (GoalFat - TotalFat).ToString();
        }
        private void DVGFoodSearchPullData()
        {
            // Retrieve the cell value for the cell at [columnName, row]
            String cellValueName = (String)dgvFoodSearch["Name", 0].Value;
            txtFoodSearchName.Text = cellValueName;

            String cellValueCalories = (String)dgvFoodSearch["Calories", 0].Value.ToString();
            txtFFCal.Text = cellValueCalories;

            String cellValueProtein = (String)dgvFoodSearch["Protein", 0].Value.ToString();
            txtFFProtein.Text = cellValueProtein;

            String cellValueCarbs = (String)dgvFoodSearch["Carbs", 0].Value.ToString();
            txtFFCarb.Text = cellValueCarbs;

            String cellValueFat = (String)dgvFoodSearch["Fat", 0].Value.ToString();
            txtFFFat.Text = cellValueFat;
        }
        
        public mainNew()
        {
            InitializeComponent();
            UpdateDB();
            UpdateMealPlan();
            UpdateMealPlanTotals();
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
                SubmitDataFoodAdd();
                UpdateDB();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteFoodFromDB();
            UpdateDB();
        }
        private void btnAddToMealPlan_Click(object sender, EventArgs e)
        {
            AddToMealPlan();
            UpdateMealPlan();
            UpdateMealPlanTotals();
            UpdateMacroDifference();
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
            UpdateMealPlanTotals();
            UpdateMacroDifference();
        }
        private void btnFoodLimitSearch_Click(object sender, EventArgs e)
        {
            SearchDBWithConstraints();
        }
        private void btnAddToMealPlanFromLimit_Click(object sender, EventArgs e)
        {
            UpdateMealPlan();
        }
        private void dgvFoodSearch_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DVGFoodSearchPullData();
        }
        private void btnSubmitGoal_Click(object sender, EventArgs e)
        {
            SubmitMacroGoalData();
            UpdateMacroGoals();
            UpdateMacroDifference();
        }
    }
}

  