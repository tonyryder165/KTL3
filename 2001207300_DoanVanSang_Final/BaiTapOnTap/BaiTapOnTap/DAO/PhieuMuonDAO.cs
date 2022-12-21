using BaiTapOnTap.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapOnTap.DAO
{
    public class PhieuMuonDAO
    {
        public static void CbbDocGia(ComboBox cbo)
        {
            DataProvider.Connect();
            string chuoiTruyVan = "select * from DOCGIA";
            DataProvider.FillCombo(chuoiTruyVan, cbo, "MaDocGia", "HoTenDocGia");
            DataProvider.Disconnect();
        }

        public static List<PhieuMuonDTO> LayPhieuMuon()
        {
            DataProvider.Connect();
            string chuoiTruyVan = "select MaPhieuMuon, HoTenDocGia, NgayMuon from PHIEUMUONSACH, DOCGIA where PHIEUMUONSACH.MaDocGia = DOCGIA.MaDocGia";
            DataTable dt = DataProvider.LayDataTable(chuoiTruyVan);
            if (dt.Rows.Count == 0)
                return null;

            List<PhieuMuonDTO> lstPM = new List<PhieuMuonDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuMuonDTO pm = new PhieuMuonDTO();

                pm.MaPhieu = int.Parse(dt.Rows[i]["MaPhieuMuon"].ToString());
                pm.TenDocGia = dt.Rows[i]["HoTenDocGia"].ToString();
                pm.NgayMuon = DateTime.Parse(dt.Rows[i]["NgayMuon"].ToString());
                lstPM.Add(pm);
            }
            DataProvider.Disconnect();
            return lstPM;
        }

        public static int SoDocGia()
        {
            DataProvider.Connect();
            int soluong = 0;
            string chuoiTruyVan = "select Count(*) from DOCGIA";
            soluong = Convert.ToInt32(DataProvider.ThucThiTruyVanScalar(chuoiTruyVan, DataProvider.Con));
            DataProvider.Disconnect();
            return soluong;
        }
    }
}
