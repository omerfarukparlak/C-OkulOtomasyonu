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
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class sqlbaglantisi
        {
            public MySqlConnection baglan()
            {
                MySqlConnection baglanti = new MySqlConnection("Server=192.168.1.103;Database=okulyonetim;Uid=root;Pwd=omer252526;");
                baglanti.Open();
                MySqlConnection.ClearPool(baglanti);
                return (baglanti);
            }
        }
        void List()
        {
            Thread.Sleep(5000);
        }
        private void txtUserLogin_Click(object sender, EventArgs e)
        {
            txtUserLogin.Text = "";
        }

        private void txtPassLogin_Click(object sender, EventArgs e)
        {
            txtPassLogin.Text = "";
        }

        private void txtAd_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
        }

        private void txtSoyad_Click(object sender, EventArgs e)
        {
            txtSoyad.Text = "";
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }
        sqlbaglantisi bag = new sqlbaglantisi();
        MySqlCommand cmd = new MySqlCommand();
        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.Connection = bag.baglan();
            cmd.CommandText = "select * from kategori";
            MySqlDataReader oku;
            oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                cmbMevkii.Items.Add(oku["kategori_ad"]);
            }
        }

        private void txtKayit_Click(object sender, EventArgs e)
        {
          string sorgu = "insert into userdata(ad,soyad,mevkii,dogumtarihi,username,password)values(@ad,@soyad,@mevki,@dogum,@user,@pass)";
          cmd = new MySqlCommand(sorgu, bag.baglan());
          cmd.Parameters.AddWithValue("@ad", txtAd.Text);
          cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
          cmd.Parameters.AddWithValue("@mevki", cmbMevkii.Text.ToString());
          cmd.Parameters.AddWithValue("@dogum", datetimepicker.Value.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@user", txtUser.Text);
            cmd.Parameters.AddWithValue("@pass", txtPass.Text);
            cmd.Connection = bag.baglan();
          cmd.ExecuteNonQuery();
          cmd.Connection.Close();
          MessageBox.Show("Başarıyla Kaydoldunuz! Şimdi Giriş Yapabilirsiniz", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
           
        }
        MySqlDataReader datareader;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            // login
            string sorgu = "SELECT * FROM userdata where username=@user AND password=@pass";
            sqlbaglantisi bag = new sqlbaglantisi();
            cmd = new MySqlCommand(sorgu, bag.baglan());
            cmd.Parameters.AddWithValue("@user", txtUserLogin.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassLogin.Text);
            waitForm frm = new waitForm(List);
            frm.ShowDialog();
            datareader = cmd.ExecuteReader();
            if (datareader.Read())
            {
                frmAna anaform = new frmAna();
                anaform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
        }

        private void cmbMevkii_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
