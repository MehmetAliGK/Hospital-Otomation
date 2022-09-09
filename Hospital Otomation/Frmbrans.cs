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
    public partial class Frmbrans : Form
    {
        public Frmbrans()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();    
        private void Frmbrans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Brans",bgl.baglanti());
            da.Fill(dt);   
            dataGridView1.DataSource = dt;  
        
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Brans (BransAd) values(@a1)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", txtbransad.Text);
           
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans eklendi.");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("delete from Tbl_Brans where BransAd=@b1",bgl.baglanti());
            cmd2.Parameters.AddWithValue("@b1",txtbransad.Text);
            cmd2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans silindi.");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("update Tbl_Brans set BransAd=@b1 where BransAd=@b1", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@b1", txtbransad.Text);
            cmd3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans güncellendi.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;

            txtbransad.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();

        }
    }
}
