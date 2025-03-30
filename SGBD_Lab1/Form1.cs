using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SGBD_Lab1
{
    public partial class Form1 : Form
    {
        String connectionString = @"Server=LEGIONAR\SQLEXPRESS;Database=Lab1_SGBD;Integrated Security=True;TrustServerCertificate=true;";
        DataSet ds = new DataSet();
        SqlDataAdapter parentAdapter = new SqlDataAdapter();
        SqlDataAdapter childAdapter = new SqlDataAdapter();
        BindingSource bsParent = new BindingSource();
        BindingSource bsChild = new BindingSource();

        SqlConnection con;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// Load Data =======================================================================================================================
        private void LoadData()
        {
            try
            {
                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    parentAdapter.SelectCommand = new SqlCommand("SELECT * FROM Lant;", con);
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Locatie;", con);

                    ds.Clear();
                    parentAdapter.Fill(ds, "Lant");
                    childAdapter.Fill(ds, "Locatie");

                    if (ds.Relations.Contains("FK_Lant_Locatii"))
                    {
                        ds.Relations.Remove("FK_Lant_Locatii");
                    }

                    DataColumn pkColumn = ds.Tables["Lant"].Columns["id_lant"];
                    DataColumn fkColumn = ds.Tables["Locatie"].Columns["id_lant"];
                    DataRelation relation = new DataRelation("FK_Lant_Locatii", pkColumn, fkColumn, true);
                    ds.Relations.Add(relation);

                    bsParent.DataSource = ds.Tables["Lant"];
                    dataGridViewParent.DataSource = bsParent;

                    bsChild.DataSource = bsParent;
                    bsChild.DataMember = "FK_Lant_Locatii";
                    dataGridViewChild.DataSource = bsChild;

                    textBoxAdr.DataBindings.Clear();
                    textBoxSup.DataBindings.Clear();
                    dateTimePicker1.DataBindings.Clear();

                    textBoxAdr.DataBindings.Add("Text", bsChild, "adresa", true);
                    textBoxSup.DataBindings.Add("Text", bsChild, "suprafata", true);
                    dateTimePicker1.DataBindings.Add("Value", bsChild, "data_deschidere", true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// Validari =========================================================================================================================
        
        private bool validateInput()
        {
            if (dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("Data deschiderii nu poate fi in viitor!");
                return false;
            }
            if (!int.TryParse(textBoxSup.Text, out int suprafata) || suprafata < 0)
            {
                MessageBox.Show("Suprafata trebuie sa fie un NUMAR POZITIV!");
                return false;
            }
            if (textBoxAdr.Text.Length < 4)
            {
                MessageBox.Show("Va rog introduceti o adresa completa!");
                return false;
            }
            return true;
        }

        /// Add Button =======================================================================================================================
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                   
                if (bsParent.Current == null) return;
                if(!validateInput()) return;
                int idLant = (int)((DataRowView)bsParent.Current)["id_lant"];

                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Locatie (adresa, suprafata, data_deschidere, id_lant) VALUES (@adresa, @suprafata, @data_deschidere, @id_lant);", con);
                    cmd.Parameters.AddWithValue("@adresa", textBoxAdr.Text);
                    cmd.Parameters.AddWithValue("@suprafata", int.Parse(textBoxSup.Text));
                    cmd.Parameters.AddWithValue("@data_deschidere", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@id_lant", idLant);

                    cmd.ExecuteNonQuery();
                }
                LoadData();
                MessageBox.Show("Adaugare reusita!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// Update Button =======================================================================================================================
        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsChild.Current == null) return;
                if (!validateInput()) return;
                int idLocatie = (int)((DataRowView)bsChild.Current)["id_locatie"];

                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Locatie SET adresa=@adresa, suprafata=@suprafata, data_deschidere=@data_deschidere WHERE id_locatie=@id_locatie", con);
                    cmd.Parameters.AddWithValue("@adresa", textBoxAdr.Text);
                    cmd.Parameters.AddWithValue("@suprafata", int.Parse(textBoxSup.Text));
                    cmd.Parameters.AddWithValue("@data_deschidere", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@id_locatie", idLocatie);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                MessageBox.Show("Actualizare reusita!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// Delete Button =======================================================================================================================
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewChild.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selectati un element pentru stergere.");
                    return;
                }
                int idChild = Convert.ToInt32(dataGridViewChild.SelectedRows[0].Cells["id_locatie"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Locatie WHERE id_locatie=@id_locatie", con);
                    cmd.Parameters.AddWithValue("@id_locatie", idChild);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                MessageBox.Show("Stergere reusita!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
