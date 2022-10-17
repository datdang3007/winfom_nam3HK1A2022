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
    public partial class Search : Form
    {
        private bool perm = false;
        SqlConnection conn = null;
        string strcnn = "Data Source=DATLAPTOP\\SQLEXPRESS;Initial Catalog=QLDT;Integrated Security=True";
        public Search(bool permission)
        {
            InitializeComponent();
            perm = permission;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(strcnn);
            conn.Open();
            string searchVal = txtSearch.Text;
            dtProduct.Rows.Clear();

            string sqlProvider = (" Select * from provider");
            SqlDataAdapter adapterProvider = new SqlDataAdapter(sqlProvider, conn);
            DataTable tableLoai = new DataTable();
            adapterProvider.Fill(tableLoai);

            string sql1 = ("Select * from product WHERE productID like '%" + searchVal + "%'");
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, conn);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            if (table1.Rows.Count > 0)
            {
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    DataRow dr = table1.Rows[i];
                    int index = dtProduct.Rows.Add();
                    dtProduct.Rows[index].Cells[0].Value = dr["productID"].ToString();
                    dtProduct.Rows[index].Cells[1].Value = dr["productNAME"].ToString();
                    dtProduct.Rows[index].Cells[2].Value = dr["productPRICE"].ToString();
                    for (int j = 0; j < tableLoai.Rows.Count; j++)
                    {
                        DataRow drProvider = tableLoai.Rows[j];
                        if (drProvider["providerID"].ToString() == dr["providerID"].ToString())
                        {
                            dtProduct.Rows[index].Cells[3].Value = drProvider["providerNAME"].ToString();
                        }
                    }
                    dtProduct.Rows[index].Cells[4].Value = dr["productSTOCK"].ToString();
                }
            }

            string sql2 = ("Select * from product WHERE productNAME like '%" + searchVal + "%'");
            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            if (table2.Rows.Count > 0)
            {
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    bool add = true;
                    DataRow dr = table2.Rows[i];
                    for (int k = 0; k < this.dtProduct.Rows.Count; k++)
                    {
                        if (dtProduct.Rows[k].Cells[0].Value.ToString() == dr["productID"].ToString())
                        {
                            add = false;
                        }
                    }
                    if (add)
                    {
                        int index = dtProduct.Rows.Add();
                        dtProduct.Rows[index].Cells[0].Value = dr["productID"].ToString();
                        dtProduct.Rows[index].Cells[1].Value = dr["productNAME"].ToString();
                        dtProduct.Rows[index].Cells[2].Value = dr["productPRICE"].ToString();
                        for (int j = 0; j < tableLoai.Rows.Count; j++)
                        {
                            DataRow drProvider = tableLoai.Rows[j];
                            if (drProvider["providerID"].ToString() == dr["providerID"].ToString())
                            {
                                dtProduct.Rows[index].Cells[3].Value = drProvider["providerNAME"].ToString();
                            }
                        }
                        dtProduct.Rows[index].Cells[4].Value = dr["productSTOCK"].ToString();
                    }
                }
            }

            string sql3 = ("Select * from product WHERE productPRICE like '%" + searchVal + "%'");
            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            if (table3.Rows.Count > 0)
            {
                for (int i = 0; i < table3.Rows.Count; i++)
                {
                    bool add = true;
                    DataRow dr = table3.Rows[i];
                    for (int k = 0; k < this.dtProduct.Rows.Count; k++)
                    {
                        if (dtProduct.Rows[k].Cells[0].Value.ToString() == dr["productID"].ToString())
                        {
                            add = false;
                        }
                    }
                    if (add)
                    {
                        int index = dtProduct.Rows.Add();
                        dtProduct.Rows[index].Cells[0].Value = dr["productID"].ToString();
                        dtProduct.Rows[index].Cells[1].Value = dr["productNAME"].ToString();
                        dtProduct.Rows[index].Cells[2].Value = dr["productPRICE"].ToString();
                        for (int j = 0; j < tableLoai.Rows.Count; j++)
                        {
                            DataRow drProvider = tableLoai.Rows[j];
                            if (drProvider["providerID"].ToString() == dr["providerID"].ToString())
                            {
                                dtProduct.Rows[index].Cells[3].Value = drProvider["providerNAME"].ToString();
                            }
                        }
                        dtProduct.Rows[index].Cells[4].Value = dr["productSTOCK"].ToString();
                    }
                }
            }

            string sql4 = ("Select * from product WHERE productSTOCK like '%" + searchVal + "%'");
            SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, conn);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            if (table4.Rows.Count > 0)
            {
                for (int i = 0; i < table4.Rows.Count; i++)
                {
                    bool add = true;
                    DataRow dr = table4.Rows[i];
                    for (int k = 0; k < this.dtProduct.Rows.Count; k++)
                    {
                        if (dtProduct.Rows[k].Cells[0].Value.ToString() == dr["productID"].ToString())
                        {
                            add = false;
                        }
                    }
                    if (add)
                    {
                        int index = dtProduct.Rows.Add();
                        dtProduct.Rows[index].Cells[0].Value = dr["productID"].ToString();
                        dtProduct.Rows[index].Cells[1].Value = dr["productNAME"].ToString();
                        dtProduct.Rows[index].Cells[2].Value = dr["productPRICE"].ToString();
                        for (int j = 0; j < tableLoai.Rows.Count; j++)
                        {
                            DataRow drProvider = tableLoai.Rows[j];
                            if (drProvider["providerID"].ToString() == dr["providerID"].ToString())
                            {
                                dtProduct.Rows[index].Cells[3].Value = drProvider["providerNAME"].ToString();
                            }
                        }
                        dtProduct.Rows[index].Cells[4].Value = dr["productSTOCK"].ToString();
                    }
                }
            }
        }

        private void Search_Load(object sender, EventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            var mainForm = new Form1(perm);
            mainForm.Show();
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var mainForm = new Form1(perm);
            mainForm.Show();
        }
    }
}
