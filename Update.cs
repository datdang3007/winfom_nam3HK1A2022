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
    public partial class Update : Form
    {
        private bool perm;
        SqlConnection conn = null;
        string strcnn = "Data Source=DATLAPTOP\\SQLEXPRESS;Initial Catalog=QLDT;Integrated Security=True";
        public Update(bool permission)
        {
            InitializeComponent();
            perm = permission;
        }

        private void Update_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strcnn);
            conn.Open();
            string sqlLoai = (" Select * from provider");
            SqlDataAdapter adapterProvider = new SqlDataAdapter(sqlLoai, conn);
            DataTable tableProvider = new DataTable();
            adapterProvider.Fill(tableProvider);
            cbxNSX.Text = tableProvider.Rows[0]["providerNAME"].ToString();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            for (int i = 0; i < tableProvider.Rows.Count; i++)
            {
                DataRow dr = tableProvider.Rows[i];
                comboSource.Add(Convert.ToInt32(dr["providerID"].ToString()), dr["providerNAME"].ToString());
            }
            cbxNSX.DataSource = new BindingSource(comboSource, null);
            cbxNSX.DisplayMember = "Value";
            cbxNSX.ValueMember = "Key";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            var mainForm = new Form1(perm);
            mainForm.Show();
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

        private void ResetInput()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtGia.Text = "";
            string sqlLoai = (" Select * from provider");
            SqlDataAdapter adapterProvider = new SqlDataAdapter(sqlLoai, conn);
            DataTable tableProvider = new DataTable();
            adapterProvider.Fill(tableProvider);
            cbxNSX.Text = tableProvider.Rows[0]["providerNAME"].ToString();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            for (int i = 0; i < tableProvider.Rows.Count; i++)
            {
                DataRow dr = tableProvider.Rows[i];
                comboSource.Add(Convert.ToInt32(dr["providerID"].ToString()), dr["providerNAME"].ToString());
            }
            cbxNSX.DataSource = new BindingSource(comboSource, null);
            cbxNSX.DisplayMember = "Value";
            cbxNSX.ValueMember = "Key";
            txtSL.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "" && txtTen.Text != "" && txtGia.Text != "" && cbxNSX.Text != "" && txtSL.Text != "")
            {
                int selectedRow = GetSelectedRow(txtMa.Text);
                if (selectedRow != -1)
                {
                    String query = "UPDATE product SET productNAME  = '" + txtTen.Text + "', productPRICE = '" + txtGia.Text + "', providerID = '" + ((KeyValuePair<int, string>)cbxNSX.SelectedItem).Key + "', productSTOCK = '" + txtSL.Text + "' WHERE productID = '" + txtMa.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            for (int i = 0; i < this.dtProduct.Rows.Count; i++)
                            {
                                if (dtProduct.Rows[i].Cells[0].Value.ToString() == txtMa.Text)
                                {
                                    dtProduct.Rows[i].Cells[1].Value = txtTen.Text;
                                    dtProduct.Rows[i].Cells[2].Value = txtGia.Text;
                                    dtProduct.Rows[i].Cells[3].Value = ((KeyValuePair<int, string>)cbxNSX.SelectedItem).Value;
                                    dtProduct.Rows[i].Cells[4].Value = txtSL.Text;
                                }
                            }
                            ResetInput();
                            MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại!", "Thông Báo", MessageBoxButtons.OK);
                }
            }    
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void dtProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtProduct.Rows[e.RowIndex];
                txtMa.Text = row.Cells[0].Value.ToString();
                txtTen.Text = row.Cells[1].Value.ToString();
                txtGia.Text = row.Cells[2].Value.ToString();
                cbxNSX.Text = row.Cells[3].Value.ToString();
                txtSL.Text = row.Cells[4].Value.ToString();
            }
        }

        private void Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var mainForm = new Form1(perm);
            mainForm.Show();
        }
    }
}
