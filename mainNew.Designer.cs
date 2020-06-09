namespace Food_Planner_2
{
    partial class mainNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDB = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDBTest = new System.Windows.Forms.Button();
            this.dgvMealPlan = new System.Windows.Forms.DataGridView();
            this.btnCalcTotal = new System.Windows.Forms.Button();
            this.lblTotalFat = new System.Windows.Forms.Label();
            this.lblTotalCarbs = new System.Windows.Forms.Label();
            this.lblTotalProtein = new System.Windows.Forms.Label();
            this.lblTotalCalories = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtFat = new System.Windows.Forms.TextBox();
            this.txtCarbs = new System.Windows.Forms.TextBox();
            this.txtProtein = new System.Windows.Forms.TextBox();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.txtServing = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddToMealPlan = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvLookupSearch = new System.Windows.Forms.DataGridView();
            this.txtFoodSearchName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteFromMealPlan = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMealPlan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLookupSearch)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDB
            // 
            this.dgvDB.AllowUserToAddRows = false;
            this.dgvDB.AllowUserToDeleteRows = false;
            this.dgvDB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDB.Location = new System.Drawing.Point(829, 40);
            this.dgvDB.Name = "dgvDB";
            this.dgvDB.ReadOnly = true;
            this.dgvDB.RowHeadersWidth = 51;
            this.dgvDB.RowTemplate.Height = 24;
            this.dgvDB.Size = new System.Drawing.Size(868, 271);
            this.dgvDB.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(184, 576);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDBTest
            // 
            this.btnDBTest.Location = new System.Drawing.Point(27, 576);
            this.btnDBTest.Name = "btnDBTest";
            this.btnDBTest.Size = new System.Drawing.Size(151, 23);
            this.btnDBTest.TabIndex = 2;
            this.btnDBTest.Text = "Test DB Connection";
            this.btnDBTest.UseVisualStyleBackColor = true;
            this.btnDBTest.Click += new System.EventHandler(this.btnDBTest_Click);
            // 
            // dgvMealPlan
            // 
            this.dgvMealPlan.AllowUserToAddRows = false;
            this.dgvMealPlan.AllowUserToDeleteRows = false;
            this.dgvMealPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMealPlan.Location = new System.Drawing.Point(829, 355);
            this.dgvMealPlan.Name = "dgvMealPlan";
            this.dgvMealPlan.ReadOnly = true;
            this.dgvMealPlan.RowHeadersWidth = 51;
            this.dgvMealPlan.RowTemplate.Height = 24;
            this.dgvMealPlan.Size = new System.Drawing.Size(868, 244);
            this.dgvMealPlan.TabIndex = 3;
            // 
            // btnCalcTotal
            // 
            this.btnCalcTotal.Location = new System.Drawing.Point(16, 99);
            this.btnCalcTotal.Name = "btnCalcTotal";
            this.btnCalcTotal.Size = new System.Drawing.Size(195, 23);
            this.btnCalcTotal.TabIndex = 4;
            this.btnCalcTotal.Text = "Calculate Meal Plan Totals";
            this.btnCalcTotal.UseVisualStyleBackColor = true;
            this.btnCalcTotal.Click += new System.EventHandler(this.btnCalcTotal_Click);
            // 
            // lblTotalFat
            // 
            this.lblTotalFat.AutoSize = true;
            this.lblTotalFat.Location = new System.Drawing.Point(315, 52);
            this.lblTotalFat.Name = "lblTotalFat";
            this.lblTotalFat.Size = new System.Drawing.Size(0, 17);
            this.lblTotalFat.TabIndex = 19;
            // 
            // lblTotalCarbs
            // 
            this.lblTotalCarbs.AutoSize = true;
            this.lblTotalCarbs.Location = new System.Drawing.Point(315, 30);
            this.lblTotalCarbs.Name = "lblTotalCarbs";
            this.lblTotalCarbs.Size = new System.Drawing.Size(0, 17);
            this.lblTotalCarbs.TabIndex = 18;
            // 
            // lblTotalProtein
            // 
            this.lblTotalProtein.AutoSize = true;
            this.lblTotalProtein.Location = new System.Drawing.Point(109, 52);
            this.lblTotalProtein.Name = "lblTotalProtein";
            this.lblTotalProtein.Size = new System.Drawing.Size(0, 17);
            this.lblTotalProtein.TabIndex = 17;
            // 
            // lblTotalCalories
            // 
            this.lblTotalCalories.AutoSize = true;
            this.lblTotalCalories.Location = new System.Drawing.Point(118, 30);
            this.lblTotalCalories.Name = "lblTotalCalories";
            this.lblTotalCalories.Size = new System.Drawing.Size(0, 17);
            this.lblTotalCalories.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total Protein:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Total Carbs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Total Fat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Total Calories:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCalcTotal);
            this.groupBox1.Controls.Add(this.lblTotalFat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTotalCarbs);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTotalProtein);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblTotalCalories);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(428, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 315);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meal Plan Information";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(135, 260);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 39);
            this.btnSubmit.TabIndex = 34;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(24, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 39);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtFat
            // 
            this.txtFat.Location = new System.Drawing.Point(140, 218);
            this.txtFat.Name = "txtFat";
            this.txtFat.Size = new System.Drawing.Size(211, 22);
            this.txtFat.TabIndex = 32;
            // 
            // txtCarbs
            // 
            this.txtCarbs.Location = new System.Drawing.Point(140, 180);
            this.txtCarbs.Name = "txtCarbs";
            this.txtCarbs.Size = new System.Drawing.Size(211, 22);
            this.txtCarbs.TabIndex = 31;
            // 
            // txtProtein
            // 
            this.txtProtein.Location = new System.Drawing.Point(140, 142);
            this.txtProtein.Name = "txtProtein";
            this.txtProtein.Size = new System.Drawing.Size(211, 22);
            this.txtProtein.TabIndex = 30;
            // 
            // txtCalories
            // 
            this.txtCalories.Location = new System.Drawing.Point(140, 104);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(211, 22);
            this.txtCalories.TabIndex = 29;
            // 
            // txtServing
            // 
            this.txtServing.Location = new System.Drawing.Point(140, 66);
            this.txtServing.Name = "txtServing";
            this.txtServing.Size = new System.Drawing.Size(211, 22);
            this.txtServing.TabIndex = 28;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(140, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 22);
            this.txtName.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Fat:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Carbs:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Protein:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Calories:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Serving (g):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtFat);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCarbs);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtProtein);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCalories);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtServing);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Location = new System.Drawing.Point(27, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 320);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Food";
            // 
            // btnAddToMealPlan
            // 
            this.btnAddToMealPlan.Location = new System.Drawing.Point(173, 155);
            this.btnAddToMealPlan.Name = "btnAddToMealPlan";
            this.btnAddToMealPlan.Size = new System.Drawing.Size(152, 43);
            this.btnAddToMealPlan.TabIndex = 43;
            this.btnAddToMealPlan.Text = "Add To Meal Plan";
            this.btnAddToMealPlan.UseVisualStyleBackColor = true;
            this.btnAddToMealPlan.Click += new System.EventHandler(this.btnAddToMealPlan_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(489, 155);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 43);
            this.btnDelete.TabIndex = 42;
            this.btnDelete.Text = "Delete From Database";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvLookupSearch
            // 
            this.dgvLookupSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLookupSearch.Location = new System.Drawing.Point(13, 51);
            this.dgvLookupSearch.Name = "dgvLookupSearch";
            this.dgvLookupSearch.RowHeadersWidth = 51;
            this.dgvLookupSearch.RowTemplate.Height = 24;
            this.dgvLookupSearch.Size = new System.Drawing.Size(763, 98);
            this.dgvLookupSearch.TabIndex = 39;
            // 
            // txtFoodSearchName
            // 
            this.txtFoodSearchName.Location = new System.Drawing.Point(65, 23);
            this.txtFoodSearchName.Name = "txtFoodSearchName";
            this.txtFoodSearchName.Size = new System.Drawing.Size(306, 22);
            this.txtFoodSearchName.TabIndex = 38;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(15, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(152, 43);
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteFromMealPlan);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.dgvLookupSearch);
            this.groupBox3.Controls.Add(this.btnAddToMealPlan);
            this.groupBox3.Controls.Add(this.txtFoodSearchName);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Location = new System.Drawing.Point(27, 338);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(796, 223);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Food Search";
            // 
            // btnDeleteFromMealPlan
            // 
            this.btnDeleteFromMealPlan.Location = new System.Drawing.Point(331, 155);
            this.btnDeleteFromMealPlan.Name = "btnDeleteFromMealPlan";
            this.btnDeleteFromMealPlan.Size = new System.Drawing.Size(152, 43);
            this.btnDeleteFromMealPlan.TabIndex = 44;
            this.btnDeleteFromMealPlan.Text = "Delete From Meal Plan";
            this.btnDeleteFromMealPlan.UseVisualStyleBackColor = true;
            this.btnDeleteFromMealPlan.Click += new System.EventHandler(this.btnDeleteFromMealPlan_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(830, 335);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 45;
            this.label12.Text = "Meal Plan";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(830, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 46;
            this.label13.Text = "Database";
            // 
            // mainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 615);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMealPlan);
            this.Controls.Add(this.btnDBTest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDB);
            this.Name = "mainNew";
            this.Text = "mainNew";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMealPlan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLookupSearch)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDB;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDBTest;
        private System.Windows.Forms.DataGridView dgvMealPlan;
        private System.Windows.Forms.Button btnCalcTotal;
        private System.Windows.Forms.Label lblTotalFat;
        private System.Windows.Forms.Label lblTotalCarbs;
        private System.Windows.Forms.Label lblTotalProtein;
        private System.Windows.Forms.Label lblTotalCalories;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtFat;
        private System.Windows.Forms.TextBox txtCarbs;
        private System.Windows.Forms.TextBox txtProtein;
        private System.Windows.Forms.TextBox txtCalories;
        private System.Windows.Forms.TextBox txtServing;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddToMealPlan;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvLookupSearch;
        private System.Windows.Forms.TextBox txtFoodSearchName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnDeleteFromMealPlan;
    }
}