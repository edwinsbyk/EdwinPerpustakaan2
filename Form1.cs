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
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Perpus_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            txtNis.Focus();
        }

        void LoadPengunjung()
        {
            string Sql = "SELECT * FROM tabel_pengunjung;";
            Data.Dtg(Sql, "", dtgTampil);
        }

        void Clear()
        {
            txtNis.Text = "";
            txtNama.Text = "";
            txtKelas.Text = "";
            txtProdi.Text = "";
            txtJenkel.Text = "";
            txtAlamat.Text = "";
            txtKota.Text = "";
            txtKode.Text = "";
        }

        

        private void BtnLoad_Click_1(object sender, EventArgs e)
        {
            LoadPengunjung();
        }

        private void DtgTampil_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgTampil.CurrentRow.Index != -1)
            {
                txtNis.Text = dtgTampil.CurrentRow.Cells[0].Value.ToString();
                txtNama.Text = dtgTampil.CurrentRow.Cells[1].Value.ToString();
                txtKelas.Text = dtgTampil.CurrentRow.Cells[2].Value.ToString();
                txtProdi.Text = dtgTampil.CurrentRow.Cells[3].Value.ToString();
                txtJenkel.Text = dtgTampil.CurrentRow.Cells[4].Value.ToString();
                txtAlamat.Text = dtgTampil.CurrentRow.Cells[5].Value.ToString();
                txtKota.Text = dtgTampil.CurrentRow.Cells[6].Value.ToString();
                txtKode.Text = dtgTampil.CurrentRow.Cells[7].Value.ToString();
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnClose.Enabled = false;
            btnLoad.Enabled = true;
            txtNis.Focus();

            Clear();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
                string Sql = "UPDATE tabel_pengunjung SET nama='" + txtNama.Text + "',kelas='" + txtKelas.Text + "',prodi='" + txtProdi.Text + "',jenis_kelamin='" + txtJenkel.Text + "',alamat='" + txtAlamat.Text + "', kota='" + txtKota.Text + "', kode_buku='" + txtKode.Text + "' WHERE nis='" + txtNis.Text + "';";
                Data.Ubah(Sql);
                LoadPengunjung();
                Clear();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            Data.Hapus( "tabel_pengunjung", "nis", txtNis);
            LoadPengunjung();
            Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtNis.Text == "" || txtNama.Text == "" || txtKelas.Text == "" || txtProdi.Text == "" || txtJenkel.Text == "" || txtAlamat.Text == "" || txtKota.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Data Dengan Benar !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

            else
            {
                string Sql = "INSERT INTO tabel_pengunjung VALUES ('" + txtNis.Text + "','" + txtNama.Text + "','" + txtKelas.Text + "','" + txtProdi.Text + "','" + txtJenkel.Text + "','" + txtAlamat.Text + "','" + txtKota.Text + "','" + txtKode.Text + "')";
                Data.Simpan(Sql);
                LoadPengunjung();
                Clear();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult Exit = MessageBox.Show("Apakah Anda Ingin Keluar ???", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataBuku Buku = new DataBuku();
            Buku.Show();
        }
    }
}
