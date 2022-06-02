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
    public partial class personelEkle : Form
    {
        public personelEkle()
        {
            InitializeComponent();
        }
        void Personeller()
        {
            MySqlCommand cmdpers = new MySqlCommand("select * from personel_ogretmen", bag.baglan());
            MySqlDataReader dr = cmdpers.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["mevkii"].ToString();
                ekle.SubItems.Add(dr["ad"].ToString());
                ekle.SubItems.Add(dr["soyad"].ToString());
                ekle.SubItems.Add(dr["brans"].ToString());
                ekle.SubItems.Add(dr["iletisim"].ToString());
                listView1.Items.Add(ekle);
            }
            dr.Close();
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
        private void personelEkle_Load(object sender, EventArgs e)
        {
            Personeller();
            DataTable table = new DataTable();
            MySqlDataAdapter adtrmevkii = new MySqlDataAdapter("select kategori_ad from kategori", bag.baglan());
            adtrmevkii.Fill(table);
            cmbMevkii.DataSource = table;
            adtrmevkii.Dispose();
            cmbMevkii.ValueMember = table.Columns[0].ToString();
            DataTable tablebrans = new DataTable();
            MySqlDataAdapter adtrbrans = new MySqlDataAdapter("select brans from ogrt_brans", bag.baglan());
            adtrbrans.Fill(tablebrans);
            cmbBrans.DataSource = tablebrans;
            cmbBrans.ValueMember = tablebrans.Columns[0].ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = bag.baglan();
                cmd.CommandText = "insert into personel_ogretmen(ad,soyad,iletisim,brans,mevkii)values(@ad,@soyad,@iletisim,@brans,@mevkii)";
                cmd.Parameters.AddWithValue("@mevkii", cmbMevkii.Text.ToString());
                cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("@iletisim", txtİletisim.Text);
                cmd.Parameters.AddWithValue("@brans", cmbBrans.Text.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Eklendi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Personeller();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "HATA");
                throw;
            }
        }
    }
}
