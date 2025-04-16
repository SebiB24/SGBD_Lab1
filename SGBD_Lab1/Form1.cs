using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace SGBD_Lab1
{
    public partial class Form1 : Form
    {
        static string server = ConfigurationManager.AppSettings.Get("server");
        static string dataBase = ConfigurationManager.AppSettings.Get("database");
        static string parentTable = ConfigurationManager.AppSettings.Get("parentTable");
        static string childTable = ConfigurationManager.AppSettings.Get("childTable");
        static string parentPrimaryKey = ConfigurationManager.AppSettings.Get("parentPrimaryKey");
        static string childForeignKey = ConfigurationManager.AppSettings.Get("childForeignKey");
        static string childPrimaryKey = ConfigurationManager.AppSettings.Get("childPrimaryKey");

        static string conString = @"Server=" + server + ";Database=" + dataBase + ";Integrated Security=True;TrustServerCertificate=true;";

        DataSet ds = new DataSet();
        SqlDataAdapter parentAdapter;
        SqlDataAdapter childAdapter;
        BindingSource bsParent = new BindingSource();
        BindingSource bsChild = new BindingSource();

        SqlConnection sqlConnection = new SqlConnection(conString);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Load Data  ===============================================================================
        private void LoadData()
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                parentAdapter = new SqlDataAdapter("SELECT * FROM " + parentTable, sqlConnection);
                parentAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                childAdapter = new SqlDataAdapter("SELECT * FROM " + childTable, sqlConnection);
                childAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                ds.Clear();
                parentAdapter.Fill(ds, parentTable);
                childAdapter.Fill(ds, childTable);

                // Configure AutoIncrement for ID generated in SQL
                DataTable parentDt = ds.Tables[parentTable];
                parentDt.Columns[parentPrimaryKey].AutoIncrement = true;
                parentDt.Columns[parentPrimaryKey].AutoIncrementSeed = -1;
                parentDt.Columns[parentPrimaryKey].AutoIncrementStep = -1;

                // Build commands
                SqlCommandBuilder parentBuilder = new SqlCommandBuilder(parentAdapter);
                SqlCommandBuilder childBuilder = new SqlCommandBuilder(childAdapter);

                // Explicitly set commands
                parentAdapter.InsertCommand = parentBuilder.GetInsertCommand(true);
                parentAdapter.UpdateCommand = parentBuilder.GetUpdateCommand(true);
                parentAdapter.DeleteCommand = parentBuilder.GetDeleteCommand(true);

                childAdapter.InsertCommand = childBuilder.GetInsertCommand(true);
                childAdapter.UpdateCommand = childBuilder.GetUpdateCommand(true);
                childAdapter.DeleteCommand = childBuilder.GetDeleteCommand(true);

                // Parent-child relationship
                if (ds.Relations.Contains("fk_parent_child"))
                    ds.Relations.Remove("fk_parent_child");

                DataColumn parentPK = ds.Tables[parentTable].Columns[parentPrimaryKey];
                DataColumn childFK = ds.Tables[childTable].Columns[childForeignKey];
                DataRelation relation = new DataRelation("fk_parent_child", parentPK, childFK, true);
                ds.Relations.Add(relation);

                // BindingSource
                bsParent.DataSource = ds;
                bsParent.DataMember = parentTable;

                bsChild.DataSource = bsParent;
                bsChild.DataMember = "fk_parent_child";

                dataGridViewParent.DataSource = bsParent;
                dataGridViewChild.DataSource = bsChild;

                dataGridViewChild.DataError += dataGridViewChild_DataError;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void dataGridViewChild_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Conversion error: " + e.Exception.Message);
            e.ThrowException = false;
        }

        // Update/Delete Buttons =========================================================================
        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                parentAdapter.Update(ds, parentTable);
                childAdapter.Update(ds, childTable);
                MessageBox.Show("Data updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewChild.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to delete.");
                    return;
                }

                int idChild = Convert.ToInt32(dataGridViewChild.SelectedRows[0].Cells[childPrimaryKey].Value);

                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM " + childTable + " WHERE " + childPrimaryKey + "=@childPrimaryKey",
                    sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@childPrimaryKey", idChild);
                    cmd.ExecuteNonQuery();
                }

                LoadData();
                MessageBox.Show("Delete successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
