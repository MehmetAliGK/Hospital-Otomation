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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktor",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //combobox'a brans çekme

            SqlCommand cmd2 = new SqlCommand("Select BransAd from Tbl_Brans", bgl.baglanti());
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                cmbbrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Doktor (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@a1,@a2,@a3,@a4,@a5)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", txtad.Text);
            cmd.Parameters.AddWithValue("@a2", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@a3", cmbbrans.Text);
            cmd.Parameters.AddWithValue("@a4", msktc.Text);
            cmd.Parameters.AddWithValue("@a5", txtsifre.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız yapıldı");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("delete from Tbl_Doktor where DoktorTC=@b1", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@b1", msktc.Text);
            cmd3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();                         
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("update Tbl_Doktor set DoktorAd=@c1,DoktorSoyad=@c2,DoktorBrans=@c3,DoktorSifre=@c5 where DoktorTC=@c4", bgl.baglanti());
            cmd4.Parameters.AddWithValue("@c1", txtad.Text);
            cmd4.Parameters.AddWithValue("@c2", txtsoyad.Text);
            cmd4.Parameters.AddWithValue("@c3", cmbbrans.Text);
            cmd4.Parameters.AddWithValue("@c4", msktc.Text);
            cmd4.Parameters.AddWithValue("@c5", txtsifre.Text);
            cmd4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız güncellendi");
        }
    }
}
