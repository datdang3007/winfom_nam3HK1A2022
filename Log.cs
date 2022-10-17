using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BanHangDT
{
    public partial class Log : Form
    {
        SqlConnection conn = null;
        string strcnn = "Data Source=DATLAPTOP\\SQLEXPRESS;Initial Catalog=QLDT;Integrated Security=True";
        public Log()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "" || txtMK.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }
            try
            {
                String query = "select * from customer where userACC = '" + txtTK.Text + "' AND userPWD = '" + txtMK.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataRow dr = table.Rows[0];
                if (dr["userPERM"].ToString() == "True")
                {
                    MessageBox.Show("Xin chào ADMIN", "Thông Báo", MessageBoxButtons.OK);
                    this.Hide();
                    var mainForm = new Form1(true);
                    mainForm.Show();
                }
                else if (dr["userPERM"].ToString() == "False")
                {
                    this.Hide();
                    var mainForm = new Form1(false, Convert.ToInt32(dr["userCARTID"].ToString()));
                    mainForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Log_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strcnn);
            conn.Open();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            var signForm = new Sign();
            signForm.Show();
            this.Hide();
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
