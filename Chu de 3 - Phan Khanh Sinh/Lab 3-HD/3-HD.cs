using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lab_3_HD
{
    public partial class frmDocTuFile : Form
    {
        public frmDocTuFile()
        {
            InitializeComponent();
        }

        private void btnReadJSON_Click(object sender, EventArgs e)
        {
            string Str = ""; // chuỗi lưu trữ
            string Path = "../../students.json"; // Đường dẫn tập tin

            List<StudentInfo> List = LoadJSON(Path); // Gọi phương thức

            for (int i = 0; i < List.Count; i++) // Đọc danh sách
            {
                StudentInfo info = List[i];
                Str += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2}, " +
                    "- điểm TB: {3}\r\n", (i + 1), info.MSSV, info.Hoten, info.Diem);
            }
            MessageBox.Show(Str);
        }

        /// <summary>
        /// Phương thức đọc tập tin JSON
        /// </summary>
        /// <param name="Path">Đường dẫn tập tin</param>
        /// <returns>Danh sách các đối tượng từ tập tin JSON</returns>
        private List<StudentInfo> LoadJSON(string Path)
        {
            // Khai báo danh sách lưu trữ
            List<StudentInfo> List = new List<StudentInfo>();

            // Đối tượng đọc tập tin
            StreamReader r = new StreamReader(Path);
            string json = r.ReadToEnd(); // Đọc hết

            // Chuyển về thành mảng các đối tượng
            var array = (JObject)JsonConvert.DeserializeObject(json);

            // Lấy đối tượng sinhvien
            var students = array["sinhvien"].Children();
            foreach (var item in students) // Duyệt mảng
            {
                // Lấy các thành phần
                string mssv = item["MSSV"].Value<string>();
                string hoten = item["hoten"].Value<string>();
                int tuoi = item["tuoi"].Value<int>();
                double diem = item["diem"].Value<double>();
                bool tongiao = item["tongiao"].Value<bool>();

                // Chuyển vào đối tượng StudentInfo
                StudentInfo info = new StudentInfo(mssv, hoten, tuoi, diem, tongiao);
                List.Add(info); // Thêm vào danh sách
            }
            return List;
        }

    }
}
