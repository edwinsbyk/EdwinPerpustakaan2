using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwinPerpustakaan2
{
    public partial class DataBuku : Form
    {
        public DataBuku()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        void LoadBuku()
        {
            string Sql = "SELECT * FROM tabel_buku;";
            Data.Dtg(Sql, "", dtgTampil);
        }

        /*void getKodeBuku()
        {
            
            try
            {
                string Sql = "SELECT * FROM tabel_buku;";
                Data.Cbo(Sql, "", cboKode);

                cboKode.Items.Add("kode_buku");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
        /*private void btnLoad_Click(object sender, EventArgs e)
        {

            
            LoadBuku();
            
        }*/

        

        private void Perpus2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            txtKode.Focus();
        }
        void Clear()
        {
            txtKode.Text = "";
            txtJudul.Text = "";
            txtPengarang.Text = "";
            txtPenerbit.Text = "";
            txtTahunTerbit.Text = "";
            txtHalaman.Text = "";
            
        }
        
        private void BtnNew_Click_1(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnClose.Enabled = true;
            btnCancel.Enabled = true;
            Clear();
        }
        private void BtnLoad_Click_1(object sender, EventArgs e)
        {
            LoadBuku();
            
            
        }

        private void DtgTampil_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
                
        }

        private void DtgTampil_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgTampil.CurrentRow.Index != -1)
            {
                txtKode.Text = dtgTampil.CurrentRow.Cells[0].Value.ToString();
                txtJudul.Text = dtgTampil.CurrentRow.Cells[1].Value.ToString();
                txtPengarang.Text = dtgTampil.CurrentRow.Cells[2].Value.ToString();
                txtPenerbit.Text = dtgTampil.CurrentRow.Cells[3].Value.ToString();
                txtTahunTerbit.Text = dtgTampil.CurrentRow.Cells[4].Value.ToString();
                txtHalaman.Text = dtgTampil.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string Sql = "UPDATE tabel_buku SET kode_buku='" + txtKode.Text + "',judul_buku='" + txtJudul.Text + "',pengarang='" + txtPengarang.Text + "',penerbit='" + txtPenerbit.Text + "',tahun_terbit='" + txtTahunTerbit.Text + "',jumlah_halaman='" + txtHalaman.Text + "' WHERE kode_buku='" + txtKode.Text + "';";
            Data.Ubah(Sql);
            LoadBuku();
            Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtKode.Text == "" || txtJudul.Text == "" || txtPengarang.Text == "" || txtPenerbit.Text == "" || txtTahunTerbit.Text == "" || txtHalaman.Text == "" )
            {
                MessageBox.Show("Silahkan Masukkan Data Dengan Benar !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

            else
            {
                string Sql = "INSERT INTO tabel_buku VALUES ('" + txtKode.Text + "','" + txtJudul.Text + "','" + txtPengarang.Text + "','" + txtPenerbit.Text + "','" + txtTahunTerbit.Text + "','" + txtHalaman.Text + "')";
                Data.Simpan(Sql);
                LoadBuku();
                Clear();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Data.Hapus("tabel_buku", "kode_buku", txtKode);
            LoadBuku();
            Clear();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult Exit = MessageBox.Show("Apakah Anda Ingin Keluar ???", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnClose.Enabled = true;
            btnCancel.Enabled = true;

            Clear();
        }

        private void TxtKode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
