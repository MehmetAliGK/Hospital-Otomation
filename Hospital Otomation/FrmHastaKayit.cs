using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Proje_Hastane
{
    public partial class HastaKayit : Form
    {
        public HastaKayit()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnkayitol_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Hasta (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@a1,@a2,@a3,@a4,@a5,@a6)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", txtad.Text);
            cmd.Parameters.AddWithValue("@a2", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@a3", msktc.Text);
            cmd.Parameters.AddWithValue("@a4", msktel.Text);
            cmd.Parameters.AddWithValue("@a5", txtsifre.Text);
            cmd.Parameters.AddWithValue("@a6", cmbcinsiyet.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();

                MessageBox.Show("Kaydınız gerçekleştirildi  Şifreniz: " + txtsifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }
    }
}
