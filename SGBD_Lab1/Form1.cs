using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SGBD_Lab1
{
    public partial class Form1 : Form
    {
        String connectionString = @"Server=LEGIONAR\SQLEXPRESS;Database=Lab1_SGBD;
        Integrated Security=True;TrustServerCertificate=true;"; // crating connection string for SQL DB
        DataSet ds = new DataSet();
        SqlDataAdapter parentAdapter = new SqlDataAdapter();
        SqlDataAdapter childAdapter = new SqlDataAdapter();
        BindingSource bsParent = new BindingSource();
        BindingSource bsChild = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    parentAdapter.SelectCommand = new SqlCommand("SELECT * FROM Lant;", con);
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Locatie;", con);
                    parentAdapter.Fill(ds, "Lant");
                    childAdapter.Fill(ds, "Locatie");
                    DataColumn pkColumn = ds.Tables["Lant"].Columns["id_lant"];
                    DataColumn fkColumn = ds.Tables["Locatie"].Columns["id_lant"];
                    DataRelation relation = new DataRelation("FK_Lant_Locatii", pkColumn, fkColumn, true);
                    ds.Relations.Add(relation);
                    bsParent.DataSource = ds.Tables["Lant"];
                    dataGridViewParent.DataSource = bsParent;
                    textBox1.DataBindings.Add("Text", bsParent, "nume", true);
                    bsChild.DataSource = bsParent;
                    bsChild.DataMember = "FK_Lant_Locatii";
                    dataGridViewChild.DataSource = bsChild;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdaptor.InsertCommand = new SqlCommand("INSERT INTO Lant (nume, numar_locatii)" +
                    " VALUES (@nume, @numar_locatii);", con);
                dataAdaptor.InsertCommand.Parameters.AddWithValue("@nume", textBox1.Text);
                dataAdaptor.InsertCommand.Parameters.AddWithValue("@numar_locatii", Int32.Parse(textBox2.Text));
                dataAdaptor.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted Succesfully to  the Data Base");
                DisplayInView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        */
    }
}
