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
    public partial class frm_QLNV : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public frm_QLNV()
        {
            InitializeComponent();
        }

        private void data_QLSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_HoTen.Text = data_QLSV.CurrentRow.Cells["HOTEN"].Value.ToString();
            txt_MSNV.Text = data_QLSV.CurrentRow.Cells["MSNV"].Value.ToString();
            txt_ThamNien.Text = data_QLSV.CurrentRow.Cells["THAMNIEN"].Value.ToString();
            dtPicker_NgayVaoLam.Text = data_QLSV.CurrentRow.Cells["NGAYVAOLAM"].Value.ToString();
            cb_TenPhongBan.Text = data_QLSV.CurrentRow.Cells["MAPB"].Value.ToString();
        }

        private void frm_QLNV_Load(object sender, EventArgs e)
        {
            LoadTT();
            string sql = "Select * from PHONGBAN";
            cb_TenPhongBan.DataSource = lopchung.LoadDL(sql);
            cb_TenPhongBan.ValueMember = "MAPB";
            cb_TenPhongBan.DisplayMember = "TENPB";
        }
        public void LoadTT()
        {
            string sql = "Select * from NHANVIEN";
            data_QLSV.DataSource = lopchung.LoadDL(sql);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Insert into NHANVIEN values('" + txt_MSNV.Text + "','" + txt_HoTen.Text + "', '" + cb_TenPhongBan.SelectedValue + "', convert(datetime,'" + dtPicker_NgayVaoLam.Text + "',103),'" + txt_ThamNien.Text + "' ) ";
                int kq = lopchung.ThemSuaXoa(sql);
                if (kq >= 1) MessageBox.Show("Them Thanh Cong");
                else MessageBox.Show("Them That bai");
            }
            catch
            {
                MessageBox.Show("Da ton tai Ma So Nhan Vien");
            }
            LoadTT();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban Co chac muon xoa? ", "Xac nhan thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "Delete NHANVIEN where MSNV = '" + txt_MSNV.Text + "'";
                int kq = lopchung.ThemSuaXoa(sql);
                if (kq >= 1) MessageBox.Show("Xoa Thanh Cong");
                else MessageBox.Show("Xoa That bai");
                LoadTT();
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string sql = " Update NHANVIEN SET HOTEN = N'"+txt_HoTen.Text+"',MAPB = '"+cb_TenPhongBan.SelectedValue+"', NGAYVAOLAM = convert(datetime,'"+dtPicker_NgayVaoLam.Text+"',103), THAMNIEN = '"+txt_ThamNien.Text+"' where MSNV = '"+txt_MSNV.Text+"' ";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Cap Nhat Thanh Cong");
            else MessageBox.Show("Cap Nhat That bai");
            LoadTT();
        }

        private void btn_Dem_Click(object sender, EventArgs e)
        {
            string sql = "select COUNT(*) NHANVIEN";
            int sl = (int) lopchung.LayGT(sql);
            txt_Dem.Text = sl.ToString();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Insert into NHANVIEN values('" + txt_MSNV.Text + "','" + txt_HoTen.Text + "', '" + cb_TenPhongBan.SelectedValue + "', convert(datetime,'" + dtPicker_NgayVaoLam.Text + "',103),'" + txt_ThamNien.Text + "' ) ";
                int kq = lopchung.ThemSuaXoa(sql);
                if (kq >= 1) MessageBox.Show("Them Thanh Cong");
                else MessageBox.Show("Them That bai");
            }
            catch
            {
                MessageBox.Show("Da ton tai Ma So Nhan Vien");
            }
            LoadTT();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = " Update NHANVIEN SET HOTEN = N'" + txt_HoTen.Text + "',MAPB = '" + cb_TenPhongBan.SelectedValue + "', NGAYVAOLAM = convert(datetime,'" + dtPicker_NgayVaoLam.Text + "',103), THAMNIEN = '" + txt_ThamNien.Text + "' where MSNV = '" + txt_MSNV.Text + "' ";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Cap Nhat Thanh Cong");
            else MessageBox.Show("Cap Nhat That bai");
            LoadTT();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban Co chac muon xoa? ", "Xac nhan thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                string sql = "Delete NHANVIEN where MSNV = '" + txt_MSNV.Text + "'";
                int kq = lopchung.ThemSuaXoa(sql);
                if (kq >= 1) MessageBox.Show("Xoa Thanh Cong");
                else MessageBox.Show("Xoa That bai");
                LoadTT();
            }
        }
    }
}
