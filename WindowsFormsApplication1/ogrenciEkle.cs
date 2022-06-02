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
    public partial class ogrenciEkle : Form
    {
        public ogrenciEkle()
        {
            InitializeComponent();
        }
        void Ogrenciler()
        {
            MySqlCommand ogrencilistele = new MySqlCommand("select * from ogrencibilgi",bag.baglan());
            ogrencilistele.ExecuteNonQuery();
            MySqlDataReader oku = ogrencilistele.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ogrenci_no"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["soyadi"].ToString());
                ekle.SubItems.Add(oku["sinifi"].ToString());
                ekle.SubItems.Add(oku["veli_iletisim"].ToString());
                ekle.SubItems.Add(oku["ogrenci_iletisim"].ToString());
                listView1.Items.Add(ekle);
            }
        }
        class sqlbaglanti
        {
            public MySqlConnection baglan()
            {
                MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=okulyonetim;Uid=root;Pwd=omer252526");
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
                cmd.Connection = bag.baglan();
                cmd.CommandText = "insert into ogrencibilgi(ogrenci_no,adi,soyadi,sinifi,veli_iletisim,ogrenci_iletisim)values(@no,@ad,@soyad,@sinif,@veli,@ogrenci)";
                cmd.Parameters.AddWithValue("@no", txtNo.Text);
                cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("@sinif", txtSinif.Text);
                cmd.Parameters.AddWithValue("@veli", txtVeli.Text);
                cmd.Parameters.AddWithValue("@ogrenci", txtOgrenci.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Eklendi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Ogrenciler();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "HATA");
                throw;
            }
          

        }

        private void ogrenciEkle_Load(object sender, EventArgs e)
        {
            Ogrenciler();
        }
    }
}
