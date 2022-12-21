using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BaiTapOnTap.DTO;

namespace BaiTapOnTap.DAO
{
    class NhanVienDAO
    {
        public static List<NhanVienDTO> LayNhanVien()
        {
            DataProvider.Connect();
            string chuoiTruyVan = "select MaNhanVien, HoTenNhanVien, NgaySinh, DiaChi, DienThoai, TenBangCap from NHANVIEN, BangCap where NHANVIEN.MaBangCap = BangCap.MaBangCap";
            DataTable dt = DataProvider.LayDataTable(chuoiTruyVan);
            if (dt.Rows.Count == 0)
                return null;

            List<NhanVienDTO> lstNV = new List<NhanVienDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVienDTO nv = new NhanVienDTO();

                nv.MaNhanVien = int.Parse(dt.Rows[i]["MaNhanVien"].ToString());
                nv.HoTenNhanVien = dt.Rows[i]["HoTenNhanVien"].ToString();
                nv.NgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                nv.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                nv.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                nv.TenBangCap = dt.Rows[i]["TenBangCap"].ToString();
                lstNV.Add(nv);
            }
            DataProvider.Disconnect();
            return lstNV;
        }

        public static void CbbBangCap(ComboBox cbo)
        {
            DataProvider.Connect();
            string chuoiTruyVan = "Select * from BangCap";
            DataProvider.FillCombo(chuoiTruyVan, cbo, "MaBangCap", "TenBangCap");
            DataProvider.Disconnect();
        }

        public static bool ThemNhanVien(NhanVienDTO nv, ComboBox cb)
        {
            DataProvider.Connect();
            string chuoiTruyVan = "INSERT INTO NhanVien(HoTenNhanVien,NgaySinh,DiaChi,DienThoai, MaBangCap) VALUES(N'"
                + nv.HoTenNhanVien.Trim() + "','" + nv.NgaySinh + "',N'" + nv.DiaChi.Trim() + "','" + nv.DienThoai.Trim() + "', " + cb.SelectedValue.ToString() + ")";
            try
            {
                DataProvider.RunSQL(chuoiTruyVan);
                DataProvider.Disconnect();
                return true;
            }
            catch (Exception)
            {
                DataProvider.Disconnect();
                return false;
            }
        }

        public static bool SuaNhanVien(NhanVienDTO nv, ComboBox cb)
        {
            DataProvider.Connect();
            string chuoiTruyVan = string.Format("update NhanVien set HoTenNhanVien = N'{0}', NgaySinh = '{1}', DiaChi = N'{2}', DienThoai = '{3}', MaBangCap = {4} where MaNhanVien = {5}", nv.HoTenNhanVien.Trim(), nv.NgaySinh, nv.DiaChi.Trim(), nv.DienThoai.Trim(), cb.SelectedValue.ToString(), nv.MaNhanVien);
            try
            {
                DataProvider.RunSQL(chuoiTruyVan);
                DataProvider.Disconnect();
                return true;
            }
            catch (Exception)
            {
                DataProvider.Disconnect();
                return false;
            }
        }

        public static bool XoaNhanVien(NhanVienDTO nv)
        {
            DataProvider.Connect();
            string chuoiTruyVan = string.Format("Delete from NhanVien Where MaNhanVien = N'{0}'", nv.MaNhanVien);
            try
            {
                DataProvider.RunSQL(chuoiTruyVan);
                DataProvider.Disconnect();
                return true;
            }
            catch (Exception)
            {
                DataProvider.Disconnect();
                return false;
            }
        }
    }
}
