using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class notEkle : Form
    {
        public notEkle()
        {
            InitializeComponent();
        }
        class sqlbaglanti
        {
            public MySqlConnection baglan()
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=okulyonetim;Uid=root;Pwd=omer252526;AllowUserVariables=True");
                baglanti.Open();
                MySqlConnection.ClearPool(baglanti);
                return (baglanti);
            }
        }
        sqlbaglanti bag = new sqlbaglanti();
        MySqlCommand cmd = new MySqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = bag.baglan();
                cmd.CommandText = "insert into ogrencinot(ogrenci_no,ders,yazili1,yazili2,sozlu1,sozlu2)values(@no,@ders,@yazili1,@yazili2,@sozlu1,@sozlu2)";
                cmd.Parameters.AddWithValue("@no", cmbNo.Text.ToString());
                cmd.Parameters.AddWithValue("@ders", cmbDers.Text.ToString());
                cmd.Parameters.AddWithValue("@yazili1",yazili1.Text);
                cmd.Parameters.AddWithValue("@yazili2", yazili2.Text);
                cmd.Parameters.AddWithValue("@sozlu1", sozlu1.Text);
                cmd.Parameters.AddWithValue("@sozlu2", sozlu2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Not Başarıyla Eklendi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void notEkle_Load(object sender, EventArgs e)
        {
            DataTable tableogrenci = new DataTable();
            MySqlDataAdapter adtrogrenci = new MySqlDataAdapter("select ogrenci_no from ogrencibilgi", bag.baglan());
            adtrogrenci.Fill(tableogrenci);
            cmbNo.DataSource = tableogrenci;
            adtrogrenci.Dispose();
            cmbNo.ValueMember = tableogrenci.Columns[0].ToString();
            DataTable tableders = new DataTable();
            MySqlDataAdapter adtrders = new MySqlDataAdapter("select ders_kodu from dersler",bag.baglan());
            adtrders.Fill(tableders);
            cmbDers.DataSource = tableders;
            cmbDers.ValueMember = tableders.Columns[0].ToString();

        }

        private void cmbNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd.Connection = bag.baglan();
            cmd.CommandText = "select * from ogrencibilgi where ogrenci_no='" + cmbNo.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            MySqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                label8.Text = oku["adi"].ToString() + " " + oku["soyadi"].ToString();
            }
            oku.Close();
        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd.Connection = bag.baglan();
            cmd.CommandText = "select * from dersler where ders_kodu='" + cmbDers.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            MySqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                label9.Text = oku["ders_adi"].ToString();
            }
            oku.Close();
        }
    }
}
