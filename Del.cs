using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanHangDT
{
    public partial class Del : Form
    {

        private bool perm;
        SqlConnection conn = null;
        string strcnn = "Data Source=DATLAPTOP\\SQLEXPRESS;Initial Catalog=QLDT;Integrated Security=True";
        public Del(bool permission)
        {
            InitializeComponent();
            perm = permission;
        }

        private int GetSelectedRow(string masach)
        {
            for (int i = 0; i < dtProduct.Rows.Count; i++)
            {
                if (dtProduct.Rows[i].Cells[0].Value.ToString() == masach)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dtProduct.SelectedRows.Count > 0)
            {
                int selectedRow = GetSelectedRow(txtMa.Text);
                if (selectedRow != -1)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "DELETE FROM product where ProductID = '" + txtMa.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        dtProduct.Rows.RemoveAt(this.dtProduct.SelectedRows[0].Index);
                    }
                }
                else
                {
                    MessageBox.Show("Sách cần xóa không tồn tại?", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                int selectedRow = GetSelectedRow(txtMa.Text);
                if (selectedRow != -1)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "DELETE FROM product where ProductID = '" + txtMa.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        for (int i = 0; i < this.dtProduct.Rows.Count; i++)
                        {
                            if (dtProduct.Rows[i].Cells[0].Value.ToString() == txtMa.Text)
                            {
                                dtProduct.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sách cần xóa không tồn tại?", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void Del_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strcnn);
            conn.Open();
            string sqlLoai = (" Select * from provider");
            SqlDataAdapter adapterProvider = new SqlDataAdapter(sqlLoai, conn);
            DataTable tableProvider = new DataTable();
            adapterProvider.Fill(tableProvider);
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            for (int i = 0; i < tableProvider.Rows.Count; i++)
            {
                DataRow dr = tableProvider.Rows[i];
                comboSource.Add(Convert.ToInt32(dr["providerID"].ToString()), dr["providerNAME"].ToString());
            }
            string sql = (" Select * from product");
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                int index = dtProduct.Rows.Add();
                dtProduct.Rows[index].Cells[0].Value = dr["productID"].ToString();
                dtProduct.Rows[index].Cells[1].Value = dr["productNAME"].ToString();
                dtProduct.Rows[index].Cells[2].Value = dr["productPrice"].ToString();
                for (int j = 0; j < tableProvider.Rows.Count; j++)
                {
                    DataRow drProvider = tableProvider.Rows[j];
                    if (drProvider["providerID"].ToString() == dr["providerID"].ToString())
                    {
                        dtProduct.Rows[index].Cells[3].Value = drProvider["providerNAME"].ToString();
                    }
                }
                dtProduct.Rows[index].Cells[4].Value = dr["productSTOCK"].ToString();
            }
        }

        private void dtProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtProduct.Rows[e.RowIndex];
                txtMa.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            var mainForm = new Form1(perm);
            mainForm.Show();
        }

        private void Del_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var mainForm = new Form1(perm);
            mainForm.Show();
        }
    }
}
