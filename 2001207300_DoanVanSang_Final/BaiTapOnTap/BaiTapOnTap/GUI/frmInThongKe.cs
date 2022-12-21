using Microsoft.Reporting.WinForms;
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
    public partial class frmInThongKe : Form
    {
        public frmInThongKe()
        {
            InitializeComponent();
        }

        private void frmInThongKe_Load(object sender, EventArgs e)
        {
            ReportParameter p1 = new ReportParameter("soLuong", frmPhieuMuon.SoDocGia.ToString());

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

            this.DOCGIATableAdapter.Fill(this.dsDocGia.DOCGIA);
            this.DOCGIATableAdapter.Fill(this.dsDocGia.DOCGIA);

            this.reportViewer1.RefreshReport();
        }
    }
}
