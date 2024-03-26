using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapDe02
{
    public partial class frm_DangNhap : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban Co chac muon thoat ?", "Xac nhan thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select COUNT(*) from TAIKHOAN where TENDANGNHAP ='" + txt_TenDangNhap.Text + "' and MATKHAU ='" + txt_MatKhau.Text + "'";
                int kq = (int)lopchung.LayGT(sql);
                if (kq >= 1)
                {
                    MessageBox.Show("Dang Nhap thanh cong!");
                    frm_QLNV QLNV = new frm_QLNV();
                    QLNV.Show();
                    this.Hide();

                }
            }
            catch
            {
                MessageBox.Show("Dang Nhap That bai !!");
            }
        }
    }
}
