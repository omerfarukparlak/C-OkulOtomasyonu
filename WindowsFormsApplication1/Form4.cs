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
    public partial class Form4 : Form
    {
        public Form4()
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
        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable tablenobetci = new DataTable();
            MySqlDataAdapter adtrnobetci = new MySqlDataAdapter("select adsoyad from personel_ogretmen", bag.baglan());
            adtrnobetci.Fill(tablenobetci);
            adtrnobetci.Dispose();
            comboBox1.DataSource = tablenobetci;
            comboBox1.ValueMember = tablenobetci.Columns[0].ToString();
            comboBox2.DataSource = tablenobetci;
            comboBox2.ValueMember = tablenobetci.Columns[0].ToString();
            comboBox3.DataSource = tablenobetci;
            comboBox3.ValueMember = tablenobetci.Columns[0].ToString();
            comboBox4.DataSource = tablenobetci;
            comboBox4.ValueMember = tablenobetci.Columns[0].ToString();
            comboBox5.DataSource = tablenobetci;
            comboBox5.ValueMember = tablenobetci.Columns[0].ToString();
        }
    }
}
