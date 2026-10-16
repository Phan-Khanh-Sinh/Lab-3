using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_BT
{
    public class TextFileStorage
    {
        private readonly string _filePath;

        public TextFileStorage(string filePath = "students.txt")
        {
            _filePath = filePath;
        }

        public List<SinhVien> ReadList()
        {
            var list = new List<SinhVien>();
            if (!File.Exists(_filePath)) return list;

            var lines = File.ReadAllLines(_filePath, Encoding.UTF8);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var sv = SinhVien.FromFileLine(line);
                if (sv != null) list.Add(sv);
            }
            return list;
        }

        public void SaveList(List<SinhVien> list)
        {
            using (var sw = new StreamWriter(_filePath, false, Encoding.UTF8))
            {
                foreach (var sv in list)
                {
                    sw.WriteLine(sv.ToFileLine());
                }
            }
        }
    }
}
