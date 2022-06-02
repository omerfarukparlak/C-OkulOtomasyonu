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
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
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
        void Ogrenciler()
        {
            MySqlCommand ogrencilistele = new MySqlCommand("select * from ogrencibilgi", bag.baglan());
            ogrencilistele.ExecuteNonQuery();
            MySqlDataReader oku = ogrencilistele.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ogrenci_no"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["soyadi"].ToString());
                ekle.SubItems.Add(oku["sinifi"].ToString());
                ekle.SubItems.Add(oku["ogrenci_iletisim"].ToString());
                listView2.Items.Add(ekle);
            }
        }
        void Personeller()
        {
            MySqlCommand cmdpers = new MySqlCommand("select * from personel_ogretmen", bag.baglan());
            MySqlDataReader dr = cmdpers.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["mevkii"].ToString();
                ekle.SubItems.Add(dr["adsoyad"].ToString());
                ekle.SubItems.Add(dr["brans"].ToString());
                ekle.SubItems.Add(dr["iletisim"].ToString());
                listView1.Items.Add(ekle);
            }
            dr.Close();
        }
        sqlbaglanti bag = new sqlbaglanti();
        MySqlCommand cmd = new MySqlCommand();
        private void button2_Click(object sender, EventArgs e)
        {
            ogrenciEkle ogrekle = new ogrenciEkle();
            ogrekle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notEkle nekle = new notEkle();
            nekle.ShowDialog();
        }

        private void frmAna_Load(object sender, EventArgs e)
        {
            Personeller();
            Ogrenciler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personelEkle pers = new personelEkle();
            pers.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 user = new Form2();
            user.ShowDialog();
        }

        private void frmAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 dersler = new Form3();
            dersler.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 nobetci = new Form4();
            nobetci.ShowDialog();
        }
    }
}
