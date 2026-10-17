using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_3_BT.StudentStorage;

namespace Lab_3_BT
{
    public class QLSinhVien
    {
        public List<SinhVien> DanhSach { get; set; }
        public string CurrentFilePath { get; set; } // Lưu vết đường dẫn file đang dùng

        // Đường dẫn mặc định trỏ thẳng vào bin\Debug\students.txt
        public QLSinhVien(string filePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                CurrentFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.txt");
            }
            else
            {
                CurrentFilePath = filePath;
            }
            LoadFromFile(CurrentFilePath);
        }
        public void LoadFromFile(string filePath)
        {
            CurrentFilePath = Path.GetFullPath(filePath);
            var storage = StorageFactory.GetStorage(CurrentFilePath);
            DanhSach = storage.DocFile(CurrentFilePath);
        }

        public void SaveToFile(string filePath = null)
        {
            string path = filePath ?? CurrentFilePath;
            CurrentFilePath = Path.GetFullPath(path);
            var storage = StorageFactory.GetStorage(CurrentFilePath);
            storage.GhiFile(CurrentFilePath, DanhSach);
        }

        // a. Thêm sinh viên (Kiểm tra trùng MSSV)
        public bool Them(SinhVien sv, out string error)
        {
            error = string.Empty;

            // 1. Kiểm tra trùng MSSV
            if (DanhSach.Any(s => s.MSSV == sv.MSSV))
            {
                error = $"Mã số sinh viên '{sv.MSSV}' đã tồn tại!";
                return false;
            }

            // 2. Kiểm tra trùng Số CMND
            if (DanhSach.Any(s => s.SoCMND == sv.SoCMND))
            {
                error = $"Số CMND '{sv.SoCMND}' đã tồn tại trên hệ thống!";
                return false;
            }

            // 3. Kiểm tra trùng Số điện thoại
            if (DanhSach.Any(s => s.SoDT == sv.SoDT))
            {
                error = $"Số điện thoại '{sv.SoDT}' đã được sử dụng bởi sinh viên khác!";
                return false;
            }

            DanhSach.Add(sv);
            SaveToFile();
            return true;
        }

        // a. Cập nhật sinh viên
        public bool CapNhat(SinhVien sv, out string error)
        {
            error = string.Empty;
            var index = DanhSach.FindIndex(s => s.MSSV == sv.MSSV);
            if (index == -1)
            {
                error = "Không tìm thấy sinh viên có MSSV này để cập nhật!";
                return false;
            }

            // Kiểm tra xem CMND mới có bị trùng với người khác (khác MSSV) không
            if (DanhSach.Any(s => s.MSSV != sv.MSSV && s.SoCMND == sv.SoCMND))
            {
                error = $"Số CMND '{sv.SoCMND}' đã bị trùng với một sinh viên khác!";
                return false;
            }

            // Kiểm tra xem Số ĐT mới có bị trùng với người khác (khác MSSV) không
            if (DanhSach.Any(s => s.MSSV != sv.MSSV && s.SoDT == sv.SoDT))
            {
                error = $"Số điện thoại '{sv.SoDT}' đã bị trùng với một sinh viên khác!";
                return false;
            }

            DanhSach[index] = sv;
            SaveToFile();
            return true;
        }

        // c. Xóa 1 sinh viên
        public bool Xoa(string mssv)
        {
            var sv = DanhSach.FirstOrDefault(s => s.MSSV == mssv);
            if (sv != null)
            {
                DanhSach.Remove(sv);
                SaveToFile();
                return true;
            }
            return false;
        }

        // c. Xóa nhiều sinh viên theo danh sách MSSV
        public void XoaNhieu(List<string> dsMssv)
        {
            DanhSach.RemoveAll(s => dsMssv.Contains(s.MSSV));
            SaveToFile();
        }

        // b. Tìm kiếm linh hoạt theo MSSV, Tên, Lớp (Hoặc đa điều kiện)
        public List<SinhVien> TimKiem(string mssv = null, string hoTen = null, string lop = null, string cmnd = null, string sdt = null, bool? gioiTinh = null)
        {
            var query = DanhSach.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(mssv))
                query = query.Where(s => s.MSSV.IndexOf(mssv.Trim(), StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(hoTen))
            {
                string kw = hoTen.Trim().ToLower();
                query = query.Where(s => s.Ten.ToLower().Contains(kw) ||
                                         s.HoVaTenLot.ToLower().Contains(kw) ||
                                         (s.HoVaTenLot + " " + s.Ten).ToLower().Contains(kw));
            }

            if (!string.IsNullOrWhiteSpace(lop))
                query = query.Where(s => s.Lop.Equals(lop.Trim(), StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(cmnd))
                query = query.Where(s => s.SoCMND.Contains(cmnd.Trim()));

            if (!string.IsNullOrWhiteSpace(sdt))
                query = query.Where(s => s.SoDT.Contains(sdt.Trim()));

            if (gioiTinh.HasValue)
                query = query.Where(s => s.GioiTinh == gioiTinh.Value);

            return query.ToList();
        }

        // Quy tắc sinh/kiểm tra MSSV: AABBCCC (AA: 2 số cuối năm nhập học từ Lớp, BB=10, CCC=3 số bất kỳ)
        public static bool KiemTraQuyTacMSSV(string mssv, string tenLop)
        {
            if (string.IsNullOrEmpty(mssv) || mssv.Length != 7 || !mssv.All(char.IsDigit))
                return false;

            // Kiểm tra BB = 10
            if (mssv.Substring(2, 2) != "10")
                return false;

            return true;
        }
    }
}
