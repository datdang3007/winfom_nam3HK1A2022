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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BanHangDT
{
    public partial class Sign : Form
    {
        SqlConnection conn = null;
        string strcnn = "Data Source=DATLAPTOP\\SQLEXPRESS;Initial Catalog=QLDT;Integrated Security=True";
        public Sign()
        {
            InitializeComponent();
        }

        private void Sign_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strcnn);
            conn.Open();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            var logForm = new Log();
            logForm.Show();
            this.Hide();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "" && txtMail.Text != "" && txtTK.Text != "" && txtMK.Text != "" && txtMkConfirm.Text !="")
            {
                if (txtMK.Text == txtMkConfirm.Text)
                {
                    String query = "INSERT INTO customer (userNAME,userPHONE,userMAIL,userACC,userPWD,userPERM,userCARTID) VALUES (@ten,@sdt,@mail,@tk,@mk,0,@cartid)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ten", txtName.Text);
                        command.Parameters.AddWithValue("@sdt", txtPhone.Text);
                        command.Parameters.AddWithValue("@mail", txtMail.Text);
                        command.Parameters.AddWithValue("@tk", txtTK.Text);
                        command.Parameters.AddWithValue("@mk", txtMK.Text);
                        command.Parameters.AddWithValue("@cartid", txtPhone.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Chúc mừng quý khách " + txtName.Text + " đã đăng kí thành công!", "Thông Báo", MessageBoxButtons.OK);
                            var logForm = new Log();
                            logForm.Show();
                            this.Hide();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không giống nhau!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void Sign_FormClosing(object sender, FormClosingEventArgs e)
        {
            var logForm = new Log();
            logForm.Show();
            this.Hide();
        }
    }
}
