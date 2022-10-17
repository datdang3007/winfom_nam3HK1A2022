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
    public partial class Add : Form
    {

        private bool perm;
        SqlConnection conn = null;
        string strcnn = "Data Source=DATLAPTOP\\SQLEXPRESS;Initial Catalog=QLDT;Integrated Security=True";
        public Add(bool permission)
        {
            InitializeComponent();
            perm = permission;
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
            // Combobox Loại:
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

        private void Add_Load(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "" && txtTen.Text != "" && txtGia.Text != "" && cbxNSX.Text != "" && txtSL.Text != "")
            {
                int selectedRow = GetSelectedRow(txtMa.Text);
                if (selectedRow == -1)
                {
                    String query = "INSERT INTO product (productID,productNAME,productPRICE,providerID,productSTOCK) VALUES (@Ma,@Ten,@gia,@nsx,@sl)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Ma", txtMa.Text);
                        command.Parameters.AddWithValue("@Ten", txtTen.Text);
                        command.Parameters.AddWithValue("@gia", txtGia.Text);
                        command.Parameters.AddWithValue("@nsx", ((KeyValuePair<int, string>)cbxNSX.SelectedItem).Key);
                        command.Parameters.AddWithValue("@sl", txtSL.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                            int index = dtProduct.Rows.Add();
                            dtProduct.Rows[index].Cells[0].Value = txtMa.Text;
                            dtProduct.Rows[index].Cells[1].Value = txtTen.Text;
                            dtProduct.Rows[index].Cells[2].Value = txtGia.Text;
                            dtProduct.Rows[index].Cells[3].Value = ((KeyValuePair<int, string>)cbxNSX.SelectedItem).Value;
                            dtProduct.Rows[index].Cells[4].Value = txtSL.Text;
                            ResetInput();
                            MessageBox.Show("Thêm mới thành công!", "Thông Báo", MessageBoxButtons.OK);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu bị đã tồn tại!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var mainForm = new Form1(perm);
            mainForm.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
