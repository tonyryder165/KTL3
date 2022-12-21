using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapOnTap.BUS;
using BaiTapOnTap.DTO;
using BaiTapOnTap.DAO;

namespace BaiTapOnTap
{
    public partial class frmDSNV : Form
    {
        public frmDSNV()
        {
            InitializeComponent();
        }

        private void frmDSNV_Load(object sender, EventArgs e)
        {
            NhanVienBUS.LoadCbbBangCap(cbbBangCap);
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            List<NhanVienDTO> lstnv = NhanVienBUS.LoadNhanVien();
            dgvNhanVien.DataSource = lstnv;

            if (lstnv == null)
                return;

            dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã NV";
            dgvNhanVien.Columns["HoTenNhanVien"].HeaderText = "Họ Tên";
            dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns["DienThoai"].HeaderText = "Điện thoại";
            dgvNhanVien.Columns["TenBangCap"].HeaderText = "Bằng cấp";
        }
        private void ResetValues()
        {
            txtHoTen.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            ResetValues();
            txtHoTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.HoTenNhanVien = txtHoTen.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            if (NhanVienBUS.ThemNhanVien(nv, cbbBangCap))
            {
                MessageBox.Show("Thêm thành công");
                LoadDataGridView();
                return;
            }
            MessageBox.Show("Thêm thất bại");
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        DataGridViewRow drNhanVien;
        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.HoTenNhanVien = txtHoTen.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            nv.MaNhanVien = int.Parse(drNhanVien.Cells["MaNhanVien"].Value.ToString());
            if (NhanVienBUS.SuaNhanVien(nv, cbbBangCap))
            {
                MessageBox.Show("Sửa thành công");
                LoadDataGridView();
                return;
            }
            MessageBox.Show("Sửa thất bại");
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                drNhanVien = dgvNhanVien.SelectedRows[0];
            }
            catch (Exception)
            {
                return;
            }

            txtHoTen.Text = drNhanVien.Cells["HoTenNhanVien"].Value.ToString();
            txtDiaChi.Text = drNhanVien.Cells["DiaChi"].Value.ToString();
            dtpNgaySinh.Text = drNhanVien.Cells["NgaySinh"].Value.ToString();
            txtDienThoai.Text = drNhanVien.Cells["DienThoai"].Value.ToString();
            cbbBangCap.Text = drNhanVien.Cells["TenBangCap"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNhanVien = int.Parse(drNhanVien.Cells["MaNhanVien"].Value.ToString());
            if (NhanVienBUS.XoaNhanVien(nv))
            {
                MessageBox.Show("Xóa thành công");
                LoadDataGridView();
                ResetValues();
                return;
            }
            MessageBox.Show("Xóa thất bại");
        }
    }
}
