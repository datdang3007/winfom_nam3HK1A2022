using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        //private bool init;
        private bool perm;
        private int userCARTID;
        private int selectedRow;
        SqlConnection conn = null;
        string strcnn = "Data Source=DATLAPTOP\\SQLEXPRESS;Initial Catalog=QLDT;Integrated Security=True";
        public Form1(bool permission)
        {
            InitializeComponent();
            perm = permission;
            //init = false;
        }
        public Form1(bool permission, int cartID)
        {
            InitializeComponent();
            perm = permission;
            userCARTID = cartID;
            //init = false;
        }

        //public Form1()
        //{
        //    InitializeComponent();
        //    //init = true;
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new Add(perm);
            addForm.Show();
            this.Hide();
        }

        private void loadingForm(bool perm)
        {
            if (perm)
            {
                btnCart.Visible = false;
                btnAddCart.Visible = false;
                txtSoluong.Visible = false;
                lbSoluong.Visible = false;
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
                    int index = mainProduct.Rows.Add();
                    mainProduct.Rows[index].Cells[0].Value = dr["productID"].ToString();
                    mainProduct.Rows[index].Cells[1].Value = dr["productNAME"].ToString();
                    mainProduct.Rows[index].Cells[2].Value = dr["productPrice"].ToString();
                    for (int j = 0; j < tableProvider.Rows.Count; j++)
                    {
                        DataRow drProvider = tableProvider.Rows[j];
                        if (drProvider["providerID"].ToString() == dr["providerID"].ToString())
                        {
                            mainProduct.Rows[index].Cells[3].Value = drProvider["providerNAME"].ToString();
                        }
                    }
                    mainProduct.Rows[index].Cells[4].Value = dr["productSTOCK"].ToString();
                }
            }
            else
            {
                btnAdd.Visible = false;
                btnChange.Visible = false;
                btnDel.Visible = false;
                btnAddCart.Enabled = false;
                txtSoluong.Enabled = false;
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
                    int index = mainProduct.Rows.Add();
                    mainProduct.Rows[index].Cells[0].Value = dr["productID"].ToString();
                    mainProduct.Rows[index].Cells[1].Value = dr["productNAME"].ToString();
                    mainProduct.Rows[index].Cells[2].Value = dr["productPrice"].ToString();
                    for (int j = 0; j < tableProvider.Rows.Count; j++)
                    {
                        DataRow drProvider = tableProvider.Rows[j];
                        if (drProvider["providerID"].ToString() == dr["providerID"].ToString())
                        {
                            mainProduct.Rows[index].Cells[3].Value = drProvider["providerNAME"].ToString();
                        }
                    }
                    mainProduct.Rows[index].Cells[4].Value = dr["productSTOCK"].ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadingForm(perm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolmenuLogout_Click(object sender, EventArgs e)
        {
            var logForm = new Log();
            logForm.Show();
            this.Hide();
        }

        private void toolmenuLog_Click(object sender, EventArgs e)
        {

        }

        private void toolmenuSign_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchForm = new Search(perm);
            searchForm.Show();
            this.Hide();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var delForm = new Del(perm);
            delForm.Show();
            this.Hide();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var upForm = new Update(perm);
            upForm.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private int GetSelectedRow(string masp)
        {
            for (int i = 0; i < mainProduct.Rows.Count; i++)
            {
                if (mainProduct.Rows[i].Cells[0].Value.ToString() == masp)
                {
                    return i;
                }
            }
            return -1;
        }

        private bool CheckDuplicateProductInCart(int userid, string masp)
        {
            conn = new SqlConnection(strcnn);
            conn.Open();
            string sqlCart = ("Select * from cart where userCARTID = '" + userid + "' and productID = '" + masp + "'");
            SqlDataAdapter adapterCart = new SqlDataAdapter(sqlCart, conn);
            DataTable tableCart = new DataTable();
            adapterCart.Fill(tableCart);
            if (tableCart.Rows.Count >= 1)
            {
                return true;
            }
            else return false;
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            if (txtSoluong.Text != "")
            {
                DataGridViewRow row = this.mainProduct.Rows[selectedRow];
                if (Convert.ToInt32(txtSoluong.Text) <= Convert.ToInt32(row.Cells[4].Value.ToString()))
                {
                    conn = new SqlConnection(strcnn);
                    conn.Open();
                    if (!CheckDuplicateProductInCart(userCARTID, row.Cells[0].Value.ToString()))
                    {
                        String queryCart = "INSERT INTO cart (userCARTID,productID,productAMOUNT) VALUES (@id,@productID,@productAMOUNT)";
                        using (SqlCommand command = new SqlCommand(queryCart, conn))
                        {
                            command.Parameters.AddWithValue("@id", userCARTID.ToString());
                            command.Parameters.AddWithValue("@productID", row.Cells[0].Value.ToString());
                            command.Parameters.AddWithValue("@productAMOUNT", txtSoluong.Text);
                            try
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Bạn đã thêm x" + txtSoluong.Text + " " + row.Cells[1].Value.ToString() + " vào giỏ hàng!", "Thông Báo", MessageBoxButtons.OK);
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
                            }
                        }
                    } else
                    {
                        string sqlCart = ("Select * from cart where userCARTID = '" + userCARTID.ToString() + "' and productID = '" + row.Cells[0].Value.ToString() + "'");
                        SqlDataAdapter adapterCart = new SqlDataAdapter(sqlCart, conn);
                        DataTable tableCart = new DataTable();
                        adapterCart.Fill(tableCart);
                        int newSoluong = Convert.ToInt32(tableCart.Rows[0]["productAMOUNT"].ToString()) + Convert.ToInt32(txtSoluong.Text);
                        String query = "UPDATE cart SET productAMOUNT  = '" + newSoluong.ToString() + "'WHERE userCARTID = '" + userCARTID.ToString() + "' AND productID = '" + row.Cells[0].Value.ToString() + "'";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            try
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Bạn đã thêm x" + txtSoluong.Text + " " + row.Cells[1].Value.ToString() + " vào giỏ hàng!", "Thông Báo", MessageBoxButtons.OK);
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng vượt quá số lượng sản phẩm đang có!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập số lượng trước khi thêm vào giỏ hàng!","Thông Báo",MessageBoxButtons.OK);
            }
        }

        private void mainProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.mainProduct.Rows[e.RowIndex];
                btnAddCart.Enabled = true;
                txtSoluong.Enabled = true;
                selectedRow = GetSelectedRow(row.Cells[0].Value.ToString());
            }
        }
    }
}
