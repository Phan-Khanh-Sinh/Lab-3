using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_3_BT
{
    public class StudentStorage
    {
        public interface IStudentStorage
        {
            List<SinhVien> DocFile(string path);
            void GhiFile(string path, List<SinhVien> list);
        }

        // a. Tập tin văn bản thông thường (*.txt)
        public class TxtStudentStorage : IStudentStorage
        {
            public List<SinhVien> DocFile(string path)
            {
                var list = new List<SinhVien>();
                if (!File.Exists(path)) return list;

                foreach (var line in File.ReadAllLines(path, Encoding.UTF8))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var sv = SinhVien.FromFileLine(line, '|');
                    if (sv != null) list.Add(sv);
                }
                return list;
            }

            public void GhiFile(string path, List<SinhVien> list)
            {
                using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    foreach (var sv in list) sw.WriteLine(sv.ToFileLine('|'));
                }
            }
        }

        // b. Tập tin XML (*.xml)
        public class XmlStudentStorage : IStudentStorage
        {
            public List<SinhVien> DocFile(string path)
            {
                if (!File.Exists(path)) return new List<SinhVien>();
                var serializer = new XmlSerializer(typeof(List<SinhVien>));
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    return (List<SinhVien>)serializer.Deserialize(fs);
                }
            }

            public void GhiFile(string path, List<SinhVien> list)
            {
                var serializer = new XmlSerializer(typeof(List<SinhVien>));
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    serializer.Serialize(fs, list);
                }
            }
        }

        // c. Tập tin JSON (*.json) 
        public class JsonStudentStorage : IStudentStorage
        {
            public List<SinhVien> DocFile(string path)
            {
                var list = new List<SinhVien>();
                if (!File.Exists(path)) return list;

                foreach (Match m in Regex.Matches(File.ReadAllText(path, Encoding.UTF8), @"\{[^{}]+\}"))
                {
                    string b = m.Value;
                    string Val(string k) => Regex.Match(b, $"\"{k}\"\\s*:\\s*\"([^\"]*)\"").Groups[1].Value;

                    var sv = new SinhVien
                    {
                        MSSV = Val("MSSV"),
                        HoVaTenLot = Val("HoVaTenLot"),
                        Ten = Val("Ten"),
                        Lop = Val("Lop"),
                        SoCMND = Val("SoCMND"),
                        SoDT = Val("SoDT"),
                        DiaChi = Val("DiaChi"),
                        GioiTinh = Regex.Match(b, @"""GioiTinh""\s*:\s*true").Success
                    };
                    if (DateTime.TryParse(Val("NgaySinh"), out DateTime d)) sv.NgaySinh = d;

                    string monStr = Regex.Match(b, @"""MonHocDangKy""\s*:\s*\[(.*?)\]").Groups[1].Value;
                    sv.MonHocDangKy = Regex.Matches(monStr, @"""([^""]+)""").Cast<Match>().Select(x => x.Groups[1].Value).ToList();

                    if (!string.IsNullOrEmpty(sv.MSSV)) list.Add(sv);
                }
                return list;
            }

            public void GhiFile(string path, List<SinhVien> list)
            {
                var items = list.Select(sv =>
                    "  {\n" +
                    $"    \"MSSV\": \"{sv.MSSV}\", \"HoVaTenLot\": \"{sv.HoVaTenLot}\", \"Ten\": \"{sv.Ten}\",\n" +
                    $"    \"NgaySinh\": \"{sv.NgaySinh:MM/dd/yyyy}\", \"Lop\": \"{sv.Lop}\", \"SoCMND\": \"{sv.SoCMND}\",\n" +
                    $"    \"SoDT\": \"{sv.SoDT}\", \"DiaChi\": \"{sv.DiaChi}\", \"GioiTinh\": {sv.GioiTinh.ToString().ToLower()},\n" +
                    $"    \"MonHocDangKy\": [{string.Join(", ", sv.MonHocDangKy.Select(m => $"\"{m}\""))}]\n" +
                    "  }");

                File.WriteAllText(path, "[\n" + string.Join(",\n", items) + "\n]", Encoding.UTF8);
            }
        }

        // d. Optional: Tập tin CSV (*.csv)
        public class CsvStudentStorage : IStudentStorage
        {
            public List<SinhVien> DocFile(string path)
            {
                var list = new List<SinhVien>();
                if (!File.Exists(path)) return list;

                foreach (var line in File.ReadAllLines(path, Encoding.UTF8))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var sv = SinhVien.FromFileLine(line, ',');
                    if (sv != null) list.Add(sv);
                }
                return list;
            }

            public void GhiFile(string path, List<SinhVien> list)
            {
                using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    foreach (var sv in list) sw.WriteLine(sv.ToFileLine(','));
                }
            }
        }

        // Factory tự động chọn bộ đọc/ghi dựa vào phần mở rộng file
        public static class StorageFactory
        {
            public static IStudentStorage GetStorage(string path)
            {
                string ext = Path.GetExtension(path).ToLower();
                switch (ext)
                {
                    case ".xml": return new XmlStudentStorage();
                    //case ".json": return new JsonStudentStorage();
                    case ".csv": return new CsvStudentStorage();
                    default: return new TxtStudentStorage();
                }
            }
        }
    }
}
