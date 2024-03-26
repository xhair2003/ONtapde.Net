using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapDe01
{
    public partial class frm_HoSo : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public frm_HoSo()
        {
            InitializeComponent();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng?", "Xác nhận đóng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void LoadTT()
        {
            string sql = "Select * From KHACHHANG";
            data_ThongTin.DataSource = lopchung.LoadDL(sql);
        }

        private void data_ThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_TenKH.Text = data_ThongTin.CurrentRow.Cells["HOTEN"].Value.ToString();
            txt_MaKH.Text = data_ThongTin.CurrentRow.Cells["MSKH"].Value.ToString();
            txt_DiaChi.Text = data_ThongTin.CurrentRow.Cells["DIACHI"].Value.ToString();
            dtPicker_NgaySinh.Text = data_ThongTin.CurrentRow.Cells["NGAYSINH"].Value.ToString();
            cb_TenGV.SelectedValue = data_ThongTin.CurrentRow.Cells["MSGVHD"].Value.ToString();
        }

        private void frm_HoSo_Load(object sender, EventArgs e)
        {
            LoadTT();
            string sql = "Select *From GIAOVIEN";
            cb_TenGV.DataSource = lopchung.LoadDL(sql);
            cb_TenGV.ValueMember = "MSGVHD";
            cb_TenGV.DisplayMember = "TENGVHD";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = "insert into KHACHHANG values ('" + txt_MaKH.Text + "','" + txt_TenKH.Text + "','" + txt_DiaChi.Text + "',Convert(datetime,'" + dtPicker_NgaySinh.Text + "',103),'" + cb_TenGV.SelectedValue + "')";
                int kq = lopchung.ThemXoaSua(sql);
                if (kq >= 1) MessageBox.Show("Thêm thành công");
                else MessageBox.Show("Thêm thất bại");
                LoadTT();
            }
            catch
            {
                MessageBox.Show("Mã khách hàng đã tồn tại !!!");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql = "Update KHACHHANG set HOTEN = '" + txt_TenKH.Text + "', DIACHI = '" + txt_DiaChi.Text + "', NGAYSINH = convert(datetime,'" + dtPicker_NgaySinh.Text + "',103), MSGVHD = '" + cb_TenGV.SelectedValue + "' where MSKH = '"+txt_MaKH.Text+"' ";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Sửa thành công");
            else MessageBox.Show("Sửa thất bại");
            LoadTT();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete KHACHHANG where MSKH = '" + txt_MaKH.Text + "' ";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Xoa thành công");
            else MessageBox.Show("Xoa thất bại");
            LoadTT();
        }

        private void txt_TenKH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
