using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTapOnTap.DTO;
using System.Windows.Forms;
using BaiTapOnTap.DAO;

namespace BaiTapOnTap.BUS
{
    public class NhanVienBUS
    {
        public static List<NhanVienDTO> LoadNhanVien()
        {
            return NhanVienDAO.LayNhanVien();
        }

        public static void LoadCbbBangCap(ComboBox cbb)
        {
            NhanVienDAO.CbbBangCap(cbb);
        }

        public static bool ThemNhanVien(NhanVienDTO nv, ComboBox cbb)
        {
            return NhanVienDAO.ThemNhanVien(nv, cbb);
        }

        public static bool SuaNhanVien(NhanVienDTO nv, ComboBox cbb)
        {
            return NhanVienDAO.SuaNhanVien(nv, cbb);
        }

        public static bool XoaNhanVien(NhanVienDTO nv)
        {
            return NhanVienDAO.XoaNhanVien(nv);
        }
    }
}
