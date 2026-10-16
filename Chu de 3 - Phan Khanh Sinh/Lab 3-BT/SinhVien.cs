using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Lab_3_BT
{
    public class SinhVien
    {
        public string MSSV { get; set; }           // 7 chữ số: AABBCCC
        public string HoVaTenLot { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SoCMND { get; set; }         // 9 chữ số
        public string SoDT { get; set; }           // 10 chữ số
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }         // true: Nam, false: Nữ
        public List<string> MonHocDangKy { get; set; }

        public SinhVien()
        {
            MonHocDangKy = new List<string>();
        }

        public SinhVien(string mssv, string hoLot, string ten, DateTime ngaySinh,
                        string lop, string cmnd, string sdt, string diaChi,
                        bool gioiTinh, List<string> monHoc)
        {
            MSSV = mssv;
            HoVaTenLot = hoLot;
            Ten = ten;
            NgaySinh = ngaySinh;
            Lop = lop;
            SoCMND = cmnd;
            SoDT = sdt;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            MonHocDangKy = monHoc ?? new List<string>();
        }

        // Lấy 2 số cuối năm nhập học từ Tên Lớp (VD: Lớp CTK44 -> Khóa 44 -> Nhập học 2020 -> "20")
        public static string LayMaNamNhapHocTuLop(string tenLop)
        {
            if (string.IsNullOrEmpty(tenLop)) return "20";

            var match = Regex.Match(tenLop, @"\d+");
            if (match.Success && int.TryParse(match.Value, out int khoa))
            {
                // Công thức khóa ĐH Đà Lạt: Năm nhập học = 1976 + Khóa (VD: K44 -> 1976 + 44 = 2020 -> lấy "20")
                int namNhapHoc = 1976 + khoa;
                return (namNhapHoc % 100).ToString("D2");
            }
            return "20"; // Giá trị mặc định phòng ngừa
        }

        public static bool KiemTraHopLeMSSV(string mssv, string tenLop, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrEmpty(mssv) || mssv.Length != 7 || !mssv.All(char.IsDigit))
            {
                error = "MSSV bắt buộc phải gồm đúng 7 chữ số!";
                return false;
            }

            string aaChuan = LayMaNamNhapHocTuLop(tenLop);
            string aa = mssv.Substring(0, 2);
            string bb = mssv.Substring(2, 2);

            if (aa != aaChuan)
            {
                error = $"2 chữ số đầu của MSSV (AA) phải là '{aaChuan}' (dựa trên năm nhập học của lớp {tenLop})!";
                return false;
            }

            if (bb != "10")
            {
                error = "2 chữ số tiếp theo (BB) của MSSV bắt buộc phải là '10'!";
                return false;
            }

            return true;
        }

        // Xuất dòng text định dạng .txt / .csv
        public string ToFileLine(char delimiter = '|')
        {
            string dsMon = string.Join(";", MonHocDangKy);
            string gt = GioiTinh ? "1" : "0";
            return $"{MSSV}{delimiter}{HoVaTenLot}{delimiter}{Ten}{delimiter}{NgaySinh:MM/dd/yyyy}{delimiter}{Lop}{delimiter}{SoCMND}{delimiter}{SoDT}{delimiter}{DiaChi}{delimiter}{gt}{delimiter}{dsMon}";
        }

        public static SinhVien FromFileLine(string line, char delimiter = '|')
        {
            string[] parts = line.Split(delimiter);
            if (parts.Length < 10) return null;

            var sv = new SinhVien
            {
                MSSV = parts[0].Trim(),
                HoVaTenLot = parts[1].Trim(),
                Ten = parts[2].Trim(),
                NgaySinh = DateTime.ParseExact(parts[3].Trim(), "MM/dd/yyyy", null),
                Lop = parts[4].Trim(),
                SoCMND = parts[5].Trim(),
                SoDT = parts[6].Trim(),
                DiaChi = parts[7].Trim(),
                GioiTinh = parts[8].Trim() == "1"
            };

            if (!string.IsNullOrEmpty(parts[9]))
                sv.MonHocDangKy = new List<string>(parts[9].Split(';'));

            return sv;
        }
    }
}
