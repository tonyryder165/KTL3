using BaiTapOnTap.DAO;
using BaiTapOnTap.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapOnTap.BUS
{
    public class PhieuMuonBUS
    {
        public static void CbbDocGia(ComboBox cbb)
        {
            PhieuMuonDAO.CbbDocGia(cbb);
        }

        public static List<PhieuMuonDTO> LoadPhieuMuon()
        {
            return PhieuMuonDAO.LayPhieuMuon();
        }

        public static int SoDocGia()
        {
            return PhieuMuonDAO.SoDocGia();
        }
    }
}
