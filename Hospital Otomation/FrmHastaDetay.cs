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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc;

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {

            // Ad soyad çekme
            lbltc.Text = tc;
            SqlCommand cmd = new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hasta where HastaTC=@a1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", lbltc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevu geçmişi 

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular Where HastaTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //brans çekme

            SqlCommand cmd2 = new SqlCommand("Select BransAd from Tbl_Brans", bgl.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand cmd3 = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktor where DoktorBrans= @b1", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@b1", cmbbrans.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where randevubrans='" + cmbbrans.Text + "'and randevudurum=0",bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle fr = new FrmBilgiDüzenle();
            fr.Tcno = lbltc.Text;
            fr.Show(); 
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView2.Rows[sec].Cells[0].Value.ToString();
        }

        private void btnrandevual_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("update Tbl_Randevular set hastaTC=@c1, hastasikayet=@c2, randevudurum=1 where randevuid=@c3", bgl.baglanti());
            cmd4.Parameters.AddWithValue("@c1", lbltc.Text);
            cmd4.Parameters.AddWithValue("@c2",rchsikayet.Text);
            cmd4.Parameters.AddWithValue("@c3", txtid.Text);
            cmd4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu alındı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}