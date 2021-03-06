﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Food_Planner_2
{
    public partial class MainNew : Form
    {
        // const string to hold connection string
        // @ is used to interpret the string literally and to enhance readability 
        public const string ConnectionString = @"Data Source=JOSHPC\SQLEXPRESS;Initial Catalog=FoodTEST;Integrated Security=True;
        Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void UpdateMealPlanTotals()
        {
            try
            {
                // implemented using to help with resource management
                // creates connection variable set to ConnectionString
                // creates command variable that creates/returns a SqlCommand object associated with SqlConnection
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    // sets sql statement to command variable
                    command.CommandText = @"SELECT SUM(calories) from mealplan";
                    // opens database connection
                    connection.Open();
                    // executes sql command 
                    command.ExecuteNonQuery();
                    // sets result variable to sql single value from query
                    var result = command.ExecuteScalar();
                    // sets lbl.Text to query result, converted to string
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
                    // closes database connection
                    connection.Close();

                    /*
                     ExecuteNonQuery() method:
                     Is used to return number of rows affected by sql query. Can be used to perform catalog operations,
                     or to change the data in database without using a DataSet by executing UPDATE, INSERT, or DELETE statements.
                     Returns no rows. For UPDATE/INSET/DELETE statements, the return value is the number of rows affected by command. 
                     For all other statements, the return value is -1

                     ExecuteScalar() method:
                     Executed the query, and returns the first column of the first row in the result set returned by query. 
                     Additional columns and rows are ignored. Is used to retrieve a single value (ex: aggregate function) from
                     a database. Requires less code than ExecuteReader method.
                */
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error updating Meal Plan Totals.");
            }
        }
        public void UpdateDb()
        {
            try
            {
                // creates connection variable set to ConnectionString
                // creates command variable that creates/returns a SqlCommand object associated with SqlConnection
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    // sets sql statement to command variable
                    command.CommandText = @"SELECT * FROM FOOD";
                    // sets cmd variable to SqlCommand(commandText, ConnectionString)
                    var cmd = new SqlCommand(command.CommandText, connection);
                    // sets dataAdapter variable to new SqlDataAdapter instance passing cmd 
                    var dataAdapter = new SqlDataAdapter(cmd);
                    // sets dataSet variable to new DataSet instance
                    var dataSet = new DataSet();
                    // fills dataSet with dataAdapter rows
                    dataAdapter.Fill(dataSet);
                    // sets dvgDB to read only
                    dgvDB.ReadOnly = true;
                    // sets collection of tables in dataSet to dgvDB dataSource
                    dgvDB.DataSource = dataSet.Tables[0];
                    // closes database connection
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error updating Food Database View");
            }
        }
        public void UpdateMealPlan()
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
        public void UpdateMacroGoals()
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
        public bool IsFoodSearchNameValid()
        {
            if (txtFoodSearchName.Text != "") return true;
            MessageBox.Show(@"Please enter a food name to search.");
            return false;
        }
        public bool IsAddFoodDataValid()
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
            if (txtFat.Text != "")
            {
                return true;
            }
            MessageBox.Show(@"Please enter fat.");
            return false;
        }
        public static void DbConnectionTest()
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
        public void SubmitDataFoodAdd()
        {
            try
            {
                // creates connection variable set to ConnectionString
                // creates command variable that creates/returns a SqlCommand object associated with SqlConnection
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    // sets sql statement to command variable
                    command.CommandText = "INSERT INTO Food(Name, Serving, Calories, Protein, Carbs, Fat)" +
                        "VALUES(@Name, @Serving, @Calories, @Protein, @Carbs, @Fat)";
                    // adds the value from txtBox to corresponding column in sql table.
                    // using AddWithValue because the user specified its value
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
        public void UpdateMealPlanTotalsAfterGenerate()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT SUM(calories) from generatemealplan";
                    connection.Open();
                    command.ExecuteNonQuery();
                    var result = command.ExecuteScalar();
                    lblTotalCalories.Text = Convert.ToString(result);

                    command.CommandText = @"SELECT SUM(protein) from generatemealplan";
                    command.ExecuteNonQuery();
                    var result2 = command.ExecuteScalar();
                    lblTotalProtein.Text = Convert.ToString(result2);

                    command.CommandText = @"SELECT SUM(carbs) from generatemealplan";
                    command.ExecuteNonQuery();
                    var result3 = command.ExecuteScalar();
                    lblTotalCarbs.Text = Convert.ToString(result3);

                    command.CommandText = @"SELECT SUM(fat) from generatemealplan";
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
        public void DeleteFoodFromDb()
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
        public void AddToMealPlan()
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
        public void DeleteFromMealPlan()
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
        public void SearchDb()
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
        public void SearchDbWithConstraints()
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
        public void SubmitMacroGoalData()
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
        public void UpdateMacroDifference()
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
        public void DvgFoodSearchPullData()
        {
            // set rowIndex variable to the index of the clicked datagridview row
            var rowIndex = dgvFoodSearch.CurrentCell.RowIndex;
            // get value from column "Name" in row rowIndex
            var cellValueName = (string)dgvFoodSearch["Name", rowIndex].Value;
            // set txt to cellValueName.value
            txtFoodSearchName.Text = cellValueName;
            // get value from column "Name" in row rowIndex and running .ToString()
            var cellValueCalories = dgvFoodSearch["Calories", rowIndex].Value.ToString();
            txtFFCal.Text = cellValueCalories;
            var cellValueProtein = dgvFoodSearch["Protein", rowIndex].Value.ToString();
            txtFFProtein.Text = cellValueProtein;
            var cellValueCarbs = dgvFoodSearch["Carbs", rowIndex].Value.ToString();
            txtFFCarb.Text = cellValueCarbs;
            var cellValueFat = dgvFoodSearch["Fat", rowIndex].Value.ToString();
            txtFFFat.Text = cellValueFat;
        }
        public void DgvdbPullData()
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
        public void DgvMealPlanPullData()
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
        public static void DeleteMealPlan()
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
        public void ClearForm()
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
        public static bool Useraccept()
        {
            // sets constant string to message variable
            const string message = "Are you sure you want to do this?";
            // sets constant string to title variable
            const string title = "";
            // sets constant MessageBoxButtons variable buttons to MessageBoxButtons.YesNo
            // used to create messagebox with yes or no buttons
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            // displays messagebox passing message, title, and yesno buttons
            var result = MessageBox.Show(message, title, buttons);
            // submits if yes button is clicked, does NOT submit if no button is clicked
            return result == DialogResult.Yes;
        }
        public void CreateMealPlanProtein()
        {
            // select highest protein from food table where protein is <= lblGoalProtein.Text and insert into mealplangoals, update dvgGenerateMealPlan
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"insert into generatemealplan " +
                        "select * from food " +
                        "where protein = (select max(protein) from food where protein <= " + lblMacroDiffProtein.Text + ")";
                    connection.Open();
                    command.ExecuteNonQuery();

                    command.CommandText =
                        @"select * from generatemealplan";
                    command.ExecuteNonQuery();


                    var cmd = new SqlCommand(command.CommandText, connection);
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dvgGenerateMealPlan.ReadOnly = true;
                    dvgGenerateMealPlan.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error CREATING MEAL PLAN.");
            }
        }
        public void DeleteGeneratedMealPlan()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"select * from generatemealplan delete from generatemealplan where protein >= 0";
                    var cmd = new SqlCommand(command.CommandText, connection);
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dvgGenerateMealPlan.ReadOnly = true;
                    dvgGenerateMealPlan.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error CREATING MEAL PLAN.");
            }
        }
        public void ExportMealPlan()
        {
            try
            {
                // create constant strings for file name, folder, delimiter and extension
                var mealPlanName = tbMealPlanName.Text;
                const string folder = @"C:\Users\stara\Desktop\LogFiles";
                const string delimiter = ",";
                const string fileExtension = ".txt";

                // creates connection variable set to ConnectionString
                // creates command variable that creates/returns a SqlCommand object associated with SqlConnection
                using (var connection = new SqlConnection(ConnectionString))
                using (var command = connection.CreateCommand())
                {
                    // sets sql statement to command variable
                    command.CommandText = @"SELECT Name, count(*) as Servings FROM MEALPLAN group by name";
                    // sets cmd variable to SqlCommand(commandText, ConnectionString)
                    var cmd = new SqlCommand(command.CommandText, connection);
                    // open database connection
                    connection.Open();
                    // create new DataTable object
                    var dataTable = new DataTable();

                    // load dataTable with sql command data
                    //ExecuteReader() method: Sends the CommandText to the Connection and builds a SqlDataReader.
                    dataTable.Load(cmd.ExecuteReader());
                    // close database connection
                    connection.Close();
                    // creates file path
                    var filePath = folder + "\\" + mealPlanName  + fileExtension;
                    // creates textWriter for writing characters to file
                    StreamWriter streamWriter = null;
                    // creates StreamWriter(filePath, boolean) false boolean is used to prevent appending
                    streamWriter = new StreamWriter(filePath, false);
                    // counts columns in dataTable
                    var columnCount = dataTable.Columns.Count;
                    // sets icolumn count to 0; if icolumn is less than columnCount; icloumn++
                    for (var iColumn = 0; iColumn < columnCount; iColumn++)
                    {
                        // streamWriter writes columns from datatable to file
                        streamWriter.Write(dataTable.Columns[iColumn]);
                        // if icolumn is less than columnCount - 1
                        if (iColumn < columnCount - 1)
                        {
                            // streamWriter writes delimiter to file
                            streamWriter.Write(delimiter);
                        }
                    }
                    // stream writer writes newline to file
                    streamWriter.Write(streamWriter.NewLine);
                    // foreach row in dataTable
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        // sets iRow to 0; if iRow is less than columnCount; iRow++
                        for (var iRow = 0; iRow < columnCount; iRow++)
                        {
                            // if dataTow is not empty
                            if (!Convert.IsDBNull(dataRow[iRow]))
                            {
                                // print row to file and convert to string
                                streamWriter.Write(dataRow[iRow].ToString());
                            }
                            // if iRow is less than columnCount - 1
                            if (iRow < columnCount - 1)
                            {
                                // streamwriter writes delimiter to file
                                streamWriter.Write(delimiter);
                            }
                        }
                        //// streamwriter writes newline to file
                        streamWriter.Write(streamWriter.NewLine);
                    }
                    // close streamWriter
                    streamWriter.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Error Exporting Meal Plan");
            }
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
            if (!Useraccept())
            {
                return;
            }
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
            if (!IsAddFoodDataValid() || !Useraccept())
            {
                return;
            }
            SubmitDataFoodAdd();
            UpdateDb();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Useraccept())
            {
                return;
            }
            DeleteFoodFromDb();
            UpdateDb();
            ClearForm();
        }
        private void btnAddToMealPlan_Click(object sender, EventArgs e)
        {
            AddToMealPlan();
            UpdateMealPlan();
            UpdateMealPlanTotals();
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
            CreateMealPlanProtein();
            UpdateMealPlanTotalsAfterGenerate();
        }
        private void dgvMealPlan_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DgvMealPlanPullData();
        }
        private void btnDeleteGenMealPlan_Click(object sender, EventArgs e)
        {
            DeleteGeneratedMealPlan();
            UpdateMealPlanTotalsAfterGenerate();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportMealPlan();
        }
        private void btnMacroDiffCalc_Click(object sender, EventArgs e)
        {
            UpdateMacroDifference();
        }
    }
}