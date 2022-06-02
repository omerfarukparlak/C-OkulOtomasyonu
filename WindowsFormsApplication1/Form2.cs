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
    public partial class Form2 : Form
    {
        public Form2()
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
        sqlbaglanti bag = new sqlbaglanti();
        MySqlCommand cmd = new MySqlCommand();
        private void Form2_Load(object sender, EventArgs e)
        {
            MySqlCommand adtruser = new MySqlCommand("select * from userdata", bag.baglan());
            adtruser.ExecuteNonQuery();
            MySqlDataReader dr = adtruser.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["ad"].ToString();
                ekle.SubItems.Add(dr["soyad"].ToString());
                ekle.SubItems.Add(dr["mevkii"].ToString());
                ekle.SubItems.Add(dr["dogumtarihi"].ToString());
                listView1.Items.Add(ekle);
            }
        }
    }
}
