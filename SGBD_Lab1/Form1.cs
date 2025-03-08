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
        SqlConnection con;

        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayInView()
        {
            dataSet.Clear();
            dataAdaptor.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(conectionString);
                con.Open();
                ///MessageBox.Show("Starea conexiunii: " + con.State);

                // select + display
                dataAdaptor.SelectCommand = new SqlCommand("SELECT * FROM Lant", con);
                DisplayInView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

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
    }
}
