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
    public partial class Form3 : Form
    {
        public Form3()
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
        private void Form3_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("select * from dersler", bag.baglan());
            cmd.ExecuteNonQuery();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["ders_kodu"].ToString();
                ekle.SubItems.Add(dr["ders_adi"].ToString());
                listView1.Items.Add(ekle);
            }
        }
    }
}
