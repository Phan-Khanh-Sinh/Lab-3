using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_3_BT.StudentStorage;

namespace Lab_3_BT
{
    public class QLSinhVien
    {
        public List<SinhVien> DanhSach { get; set; }
        private string _currentFilePath;

        public QLSinhVien(string filePath = "students.txt")
        {
            _currentFilePath = filePath;
            LoadFromFile(filePath);
        }

        // Tải danh sách từ bất kỳ định dạng nào (.txt, .xml, .json, .csv)
        public void LoadFromFile(string filePath)
        {
            _currentFilePath = filePath;
            var storage = StorageFactory.GetStorage(filePath);
            DanhSach = storage.DocFile(filePath);
        }

        // Lưu danh sách theo định dạng file hiện tại hoặc file chỉ định
        public void SaveToFile(string filePath = null)
        {
            string path = filePath ?? _currentFilePath;
            var storage = StorageFactory.GetStorage(path);
            storage.GhiFile(path, DanhSach);
        }

        // a. Thêm sinh viên (Kiểm tra trùng MSSV)
        public bool Them(SinhVien sv, out string error)
        {
            error = string.Empty;
            if (DanhSach.Any(s => s.MSSV == sv.MSSV))
            {
                error = $"Mã số sinh viên {sv.MSSV} đã tồn tại!";
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
