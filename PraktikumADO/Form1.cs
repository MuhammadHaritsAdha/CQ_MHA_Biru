using System;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace PraktikumADO
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=RITS;Initial Catalog=DBAkademikADO;Integrated Security=True"
            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                MessageBox.Show("Koneksi ke database Berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            Koneksi();
            conn.Open();

            string query = "SELECT COUNT(*) FROM Mahasiswa";

            cmd = new SqlCommand(query, conn);

            int jumlah = (int)cmd.ExecuteScalar();
            txtHasil.Text = jumlah.ToString();

            conn.Close();
        }

    }
}