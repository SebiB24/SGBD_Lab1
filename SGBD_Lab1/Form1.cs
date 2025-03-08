using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SGBD_Lab1
{
    public partial class Form1 : Form
    {
        String conectionString = @"Server=LEGIONAR\SQLEXPRESS;Database=Lab1_SGBD;
        Integrated Security=True;TrustServerCertificate=true;"; // crating connection string for SQL DB
        DataSet dataSet = new DataSet();
        SqlDataAdapter dataAdaptor = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayInView(SqlConnection con)
        {
            // citirea datelor
            dataAdaptor.SelectCommand = new SqlCommand("SELECT * FROM Lant;", con);
            dataSet.Clear();
            dataAdaptor.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];


        }

        private void button2_Click(object sender, EventArgs e)
        { 
            try
            {
                using (SqlConnection con = new SqlConnection(conectionString))
                {
                    con.Open();
                    MessageBox.Show("Starea conexiunii: " + con.State);
                    con.Close();
                    DisplayInView(con);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
