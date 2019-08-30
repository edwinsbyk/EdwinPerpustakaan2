using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace EdwinPerpustakaan2
{
    class Koneksi
    {
        static string Connection;

        public static MySqlConnection Connect
        {
            get
            {
                return new MySqlConnection(Connection);
            }
        }

        static Koneksi()
        {
            string Connect = "SERVER=localhost;" +
                             "PORT=3306;" +
                             "DATABASE=edwinperpudb;" +
                             "UID=root;" +
                             "PASSWORD=;";

            try
            {
                Connection = Connect;
                MessageBox.Show("Koneksi Ke Database Sukses !!!");
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Koneksi Ke Database Gagal " + Ex.Message);
            }
        }
    }

    public static class Data
    {
        static MySqlConnection Connection;
        static MySqlDataAdapter DataAdapter;
        static MySqlCommand Command;

        public static void Dtg(string Query, string Table, DataGridView Dtg)
        {
            System.Data.DataTable DataTable = new System.Data.DataTable();
            Connection = Koneksi.Connect;

            DataAdapter = new MySqlDataAdapter(Query, Connection);

            try
            {
                Connection.Open();
                DataAdapter.Fill(DataTable);
                Dtg.DataSource = DataTable;
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error : ", Ex.Message);
            }

            finally
            {
                Connection.Close();
            }
        }

        public static void Cbo(string Query, string Table, ComboBox Cbo)
        {
            System.Data.DataTable DataTable = new System.Data.DataTable();
            Connection = Koneksi.Connect;

            DataAdapter = new MySqlDataAdapter(Query, Connection);

            try
            {
                Connection.Open();
                DataAdapter.Fill(DataTable);
                Cbo.DataSource = DataTable;
                MySqlCommand command = new MySqlCommand(Query, Connection);
                MySqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Cbo.Items.Add(reader.GetString("kode_buku"));
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error : ", Ex.Message);
            }

            finally
            {
                Connection.Close();
            }
        }

        public static int Simpan(string Query)
        {
            Connection = Koneksi.Connect;
            Command = new MySqlCommand();

            try
            {
                Connection.Open();
                Command.Connection = Connection;
                Command.CommandText = Query;

                int i = Command.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan !!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return i;
            }

            catch (MySqlException i)
            {
                MessageBox.Show("Gagal Menyimpan Data !!!", i.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            finally
            {
                Connection.Close();
            }
        }

        public static void Ubah(string Query)
        {
            try
            {
                Connection = Koneksi.Connect;
                Connection.Open();

                Command = new MySqlCommand(Query, Connection);
                Command.ExecuteNonQuery();

                MessageBox.Show("Data Berhasil Di Update !!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Connection.Close();
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void Hapus(string Table, string Field, TextBox Box)
        {
            if (Box.Text == "")
            {
                MessageBox.Show("Pilih Data Yang Akan Dihapus !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                try
                {
                    string Sql = "DELETE FROM " + Table + " WHERE " + Field + " = '" + Box.Text + "'";

                    Connection = Koneksi.Connect;
                    Connection.Open();

                    Command = new MySqlCommand(Sql, Connection);
                    Command.ExecuteNonQuery();

                    MessageBox.Show("Data Berhasil Dihapus !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                    Connection.Close();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal static void HapusPengunjung(string v1, string v2, string v3, string text)
        {
            throw new NotImplementedException();
        }

        
    }
}
