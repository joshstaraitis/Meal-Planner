using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Food_Planner_2
{
    public partial class MainNew : Form
    {
        private const string ConnectionString = @"Data Source=JOSHPC\SQLEXPRESS;Initial Catalog=FoodTEST;Integrated Security=True;
        Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private void UpdateMealPlanTotals()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT SUM(calories) from mealplan";
                    connection.Open();
                    command.ExecuteNonQuery();
                    var result = command.ExecuteScalar();
                    lblTotalCalories.Text = Convert.ToString(result);

                    command.CommandText = @"SELECT SUM(protein) from mealplan";
                    command.ExecuteNonQuery();
                    var result2 = command.ExecuteScalar();
                    lblTotalProtein.Text = Convert.ToString(result2);

                    command.CommandText = @"SELECT SUM(carbs) from mealplan";
                    command.ExecuteNonQuery();
                    var result3 = command.ExecuteScalar();
                    lblTotalCarbs.Text = Convert.ToString(result3);

                    command.CommandText = @"SELECT SUM(fat) from mealplan";
                    command.ExecuteNonQuery();
                    var result4 = command.ExecuteScalar();
                    lblTotalFat.Text = Convert.ToString(result4);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error updating Meal Plan Totals.");
            }
        }
        private void UpdateDb()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM FOOD";
                    var cmd = new SqlCommand(command.CommandText, connection);
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dgvDB.ReadOnly = true;
                    dgvDB.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error updating Food Database View");
            }
        }
        private void UpdateMealPlan()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM MEALPLAN";
                    var cmd = new SqlCommand(command.CommandText, connection);
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dgvMealPlan.ReadOnly = true;
                    dgvMealPlan.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error updating Meal Plan View");
            }
        }
        private void UpdateMacroGoals()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT (calories) from macrogoals mgn1 WHERE mgn1.date = (select max(mgn2.date) " +
                        " from macrogoals mgn2 where mgn2.date >= mgn1.date)";
                    connection.Open();
                    command.ExecuteNonQuery();
                    var result = command.ExecuteScalar();
                    lblGoalCal.Text = Convert.ToString(result);

                    command.CommandText = @"SELECT (protein) from macrogoals mgn1 WHERE mgn1.date = (select max(mgn2.date) " +
                        " from macrogoals mgn2 where mgn2.date >= mgn1.date)";
                    command.ExecuteNonQuery();
                    var result2 = command.ExecuteScalar();
                    lblGoalProtein.Text = Convert.ToString(result2);

                    command.CommandText = @"SELECT (carbs) from macrogoals mgn1 WHERE mgn1.date = (select max(mgn2.date) " +
                        " from macrogoals mgn2 where mgn2.date >= mgn1.date)";
                    command.ExecuteNonQuery();
                    var result3 = command.ExecuteScalar();
                    lblGoalCarbs.Text = Convert.ToString(result3);

                    command.CommandText = @"SELECT (fat) from macrogoals mgn1 WHERE mgn1.date = (select max(mgn2.date) " +
                        " from macrogoals mgn2 where mgn2.date >= mgn1.date)";
                    command.ExecuteNonQuery();
                    var result4 = command.ExecuteScalar();
                    lblGoalFat.Text = Convert.ToString(result4);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error updating Meal Plan Totals.");
            }
        }
        private bool IsFoodSearchNameValid()
        {
            if (txtFoodSearchName.Text != "") return true;
            MessageBox.Show(@"Please enter a food name to search.");
            return false;
        }
        private bool IsAddFoodDataValid()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show(@"Please enter food name.");
                return false;
            }
            if (txtServing.Text == "")
            {
                MessageBox.Show(@"Please enter serving size in grams.");
                return false;
            }
            if (txtCalories.Text == "")
            {
                MessageBox.Show(@"Please enter calories.");
                return false;
            }
            if (txtProtein.Text == "")
            {
                MessageBox.Show(@"Please enter protein.");
                return false;
            }
            if (txtCarbs.Text == "")
            {
                MessageBox.Show(@"Please enter carbs.");
                return false;
            }
            if (txtFat.Text != "") return true;
            MessageBox.Show(@"Please enter fat.");
            return false;
        }
        private static void DbConnectionTest()
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (connection.CreateCommand())
            {
                connection.Open();
                switch (connection.State)
                {
                    case ConnectionState.Open:
                        MessageBox.Show(@"Database connection is OPEN.");
                        break;
                    case ConnectionState.Closed:
                        MessageBox.Show(@"Database connection is CLOSED.");
                        break;
                    case ConnectionState.Connecting:
                        MessageBox.Show(@"Database connection is CONNECTING.");
                        break;
                    case ConnectionState.Executing:
                        MessageBox.Show(@"Database connection is EXECUTING.");
                        break;
                    case ConnectionState.Fetching:
                        MessageBox.Show(@"Database connection is FETCHING.");
                        break;
                    case ConnectionState.Broken:
                        MessageBox.Show(@"Database connection is BROKEN.");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                connection.Close();
            }
        }
        private void SubmitDataFoodAdd()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
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
                MessageBox.Show(txtName.Text + @" was added to the database");
                ClearForm();
            }
            catch (SqlException)
            {
                MessageBox.Show(txtName.Text + @" was NOT added to the database.");
            }
        }
        private void DeleteFoodFromDb()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE from Food WHERE Name = '" + txtFoodSearchName.Text + "'";
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show(txtFoodSearchName.Text + @" was removed from database.");
                    ClearForm();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error deleting from food database.");
            }
        }
        private void AddToMealPlan()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO MEALPLAN(Name, Serving, Calories, Protein, Carbs, Fat)" +
                    "select Name, Serving, Calories, Protein, Carbs, Fat from food WHERE Name = '" + txtFoodSearchName.Text + "'";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error adding to meal plan.");
            }
        }
        private void DeleteFromMealPlan()
        {
            try
            {           
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM MEALPLAN WHERE Name = '" + txtFoodSearchName.Text + "'";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error deleting from meal plan.");
            }
        }
        private void SearchDb()
        {
            try
            {             
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Name, Serving, Calories, Protein, Carbs, Fat FROM Food WHERE NAME LIKE '%" + txtFoodSearchName.Text + "%'";
                    var cmd = new SqlCommand(command.CommandText, connection);
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dgvFoodSearch.ReadOnly = true;
                    dgvFoodSearch.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error searching food database.");
            }
        }
        private void SearchDbWithConstraints()
        {
            try
            {             
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM food WHERE CALORIES <= '" +
                        txtFFCal.Text + "' AND PROTEIN <= '" + txtFFProtein.Text + "' " +
                            "AND CARBS <= '" + txtFFCarb.Text + "' AND FAT <= '" + txtFFFat.Text + "'";
                    var cmd = new SqlCommand(command.CommandText, connection);
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dgvFoodSearch.ReadOnly = true;
                    dgvFoodSearch.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error searching food database.");
            }

        }
        private void SubmitMacroGoalData()
        {
            var date = DateTime.Now;
            try
            {
               
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())

                {
                    command.CommandText = "INSERT INTO macrogoals(calories, protein, carbs, fat, date)" +
                        "VALUES(@calories, @protein, @carbs, @fat, @Date)";
                    command.Parameters.AddWithValue("@calories", tbGoalCal.Text);
                    command.Parameters.AddWithValue("@protein", tbGoalProtein.Text);
                    command.Parameters.AddWithValue("@carbs", tbGoalCarbs.Text);
                    command.Parameters.AddWithValue("@fat", tbGoalFat.Text);
                    command.Parameters.AddWithValue("@Date", date);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                MessageBox.Show(@"Macro goals have been submitted.");
            }
            catch (SqlException)
            {
                MessageBox.Show(txtName.Text + @"MACRO GOAL ERROR.");
            }

        }
        private void UpdateMacroDifference()
        {
            var goalCal = Convert.ToDouble(lblGoalCal.Text);
            var totalCal = Convert.ToDouble(lblTotalCalories.Text);
            var goalProtein = Convert.ToDouble(lblGoalProtein.Text);
            var totalProtein = Convert.ToDouble(lblTotalProtein.Text);
            var goalCarbs = Convert.ToDouble(lblGoalCarbs.Text);
            var totalCarbs = Convert.ToDouble(lblTotalCarbs.Text);
            var goalFat = Convert.ToDouble(lblGoalFat.Text);
            var totalFat = Convert.ToDouble(lblTotalFat.Text);

            lblMacroDiffCal.Text = (goalCal - totalCal).ToString(CultureInfo.InvariantCulture);
            lblMacroDiffProtein.Text = (goalProtein - totalProtein).ToString(CultureInfo.InvariantCulture);
            lblMacroDiffCarbs.Text = (goalCarbs - totalCarbs).ToString(CultureInfo.InvariantCulture);
            lblMacroDiffFat.Text = (goalFat - totalFat).ToString(CultureInfo.InvariantCulture);
        }
         private void DvgFoodSearchPullData()
        {
            var rowIndex = dgvFoodSearch.CurrentCell.RowIndex;

            var cellValueName = (string)dgvFoodSearch["Name", rowIndex].Value;
            txtFoodSearchName.Text = cellValueName;

            var cellValueCalories = dgvFoodSearch["Calories", rowIndex].Value.ToString();
            txtFFCal.Text = cellValueCalories;

            var cellValueProtein = dgvFoodSearch["Protein", rowIndex].Value.ToString();
            txtFFProtein.Text = cellValueProtein;

            var cellValueCarbs = dgvFoodSearch["Carbs", rowIndex].Value.ToString();
            txtFFCarb.Text = cellValueCarbs;

            var cellValueFat = dgvFoodSearch["Fat", rowIndex].Value.ToString();
            txtFFFat.Text = cellValueFat;  
        }
        private void DgvdbPullData()
        {
            var rowIndex = dgvDB.CurrentCell.RowIndex;

            var cellValueName = (string)dgvDB["Name", rowIndex].Value;
            txtFoodSearchName.Text = cellValueName;

            var cellValueCalories = dgvDB["Calories", rowIndex].Value.ToString();
            txtFFCal.Text = cellValueCalories;

            var cellValueProtein = dgvDB["Protein", rowIndex].Value.ToString();
            txtFFProtein.Text = cellValueProtein;

            var cellValueCarbs = dgvDB["Carbs", rowIndex].Value.ToString();
            txtFFCarb.Text = cellValueCarbs;

            var cellValueFat = dgvDB["Fat", rowIndex].Value.ToString();
            txtFFFat.Text = cellValueFat;
        }
        private void DgvMealPlanPullData()
        {
            var rowIndex = dgvMealPlan.CurrentCell.RowIndex;

            var cellValueName = (string)dgvMealPlan["Name", rowIndex].Value;
            txtFoodSearchName.Text = cellValueName;

            var cellValueCalories = dgvMealPlan["Calories", rowIndex].Value.ToString();
            txtFFCal.Text = cellValueCalories;

            var cellValueProtein = dgvMealPlan["Protein", rowIndex].Value.ToString();
            txtFFProtein.Text = cellValueProtein;

            var cellValueCarbs = dgvMealPlan["Carbs", rowIndex].Value.ToString();
            txtFFCarb.Text = cellValueCarbs;

            var cellValueFat = dgvMealPlan["Fat", rowIndex].Value.ToString();
            txtFFFat.Text = cellValueFat;
        }
        private static void DeleteMealPlan()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM MEALPLAN";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error deleting from meal plan.");
            }
        }
        private void ClearForm()
        {
            txtName.Clear();
            txtServing.Clear();
            txtCalories.Clear();
            txtProtein.Clear();
            txtCarbs.Clear();
            txtFat.Clear();
            txtFoodSearchName.Clear();
            txtFFCal.Clear();
            txtFFCarb.Clear();
            txtFFFat.Clear();
            txtFFProtein.Clear();

        }
        private static bool Useraccept()
        {
            const string message = "Are you sure you want to do this?";
            const string title = "";
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show(message, title, buttons);
            return result == DialogResult.Yes;
        }
        private static void CreateMeal()
        {
        }
        private void GenerateMealPlan()
        {
            // Select food that meets criteria from user
            // add that food to mealplanGenerateTable
            // calculates mealplantotals from mealplanGenerateTable
            // checks values against user entered macro goals
            // continues to add food and loops through all checks until it is close to maxing out?
        }
        private void ExportMealPlanToTextFile()
        {
            // Add functionality to export MealPlan table to txt file/pdf?
        }
        public MainNew()
        {
            InitializeComponent();
            UpdateDb();
            UpdateMealPlan();
            UpdateMacroGoals();
            UpdateMealPlanTotals();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnDBTest_Click(object sender, EventArgs e)
        {
            DbConnectionTest();
        }
        private void btnCalcTotal_Click(object sender, EventArgs e)
        {
            if (!Useraccept()) return;
            DeleteMealPlan();
            UpdateMealPlan();
            UpdateMealPlanTotals();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsAddFoodDataValid() || !Useraccept()) return;
            SubmitDataFoodAdd();
            UpdateDb();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Useraccept()) return;
            DeleteFoodFromDb();
            UpdateDb();
            ClearForm();

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
            if (IsFoodSearchNameValid())
            {
                SearchDb();
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
            SearchDbWithConstraints();
        }
        private void dgvFoodSearch_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DvgFoodSearchPullData();
        }
        private void btnSubmitGoal_Click(object sender, EventArgs e)
        {
            SubmitMacroGoalData();
            UpdateMacroGoals();
            UpdateMealPlanTotals();
        }
        private void dgvDB_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DgvdbPullData();
        }
        private void btnSubmitMeal_Click(object sender, EventArgs e)
        {
            CreateMeal();
        }
        private void dgvMealPlan_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DgvMealPlanPullData();
        }
    }
}
