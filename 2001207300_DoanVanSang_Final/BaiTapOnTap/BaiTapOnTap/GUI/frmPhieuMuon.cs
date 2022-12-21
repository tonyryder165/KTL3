using BaiTapOnTap.BUS;
using BaiTapOnTap.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapOnTap.GUI
{
    public partial class frmPhieuMuon : Form
    {
        public frmPhieuMuon()
        {
            InitializeComponent();

        }

        private void LoadDataGridView()
        {
            List<PhieuMuonDTO> lstpm = PhieuMuonBUS.LoadPhieuMuon();
            dataGridView1.DataSource = lstpm;

            if (lstpm == null)
                return;

            dataGridView1.Columns["MaPhieu"].HeaderText = "Mã PM";
            dataGridView1.Columns["TenDocGia"].HeaderText = "Họ Tên";
            dataGridView1.Columns["NgayMuon"].HeaderText = "Ngày mượn";
        }

        private void frmPhieuMuon_Load(object sender, EventArgs e)
        {
            PhieuMuonBUS.CbbDocGia(cbbDocGia);
            LoadDataGridView();
        }


        public static int SoDocGia;
        private void button1_Click(object sender, EventArgs e)
        {
            SoDocGia = PhieuMuonBUS.SoDocGia();
             
            frmInThongKe frmInThongKe = new frmInThongKe();
            frmInThongKe.ShowDialog();
        }
    }
}
