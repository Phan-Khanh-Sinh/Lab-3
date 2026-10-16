using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_BT
{
    public partial class Form1 : Form
    {
        private QLSinhVien qlsv;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QLSinhVien("students.txt");

            lvDSSV.SelectedIndexChanged += LvDSSV_SelectedIndexChanged;

            lvDSSV.View = View.Details;
            lvDSSV.GridLines = true;
            lvDSSV.FullRowSelect = true;
            lvDSSV.CheckBoxes = true;

            if (lvDSSV.Columns.Count == 0)
            {
                lvDSSV.Columns.Add("MSSV", 80);
                lvDSSV.Columns.Add("Họ và tên lót", 130);
                lvDSSV.Columns.Add("Tên", 70);
                lvDSSV.Columns.Add("Ngày sinh", 90);
                lvDSSV.Columns.Add("Lớp", 70);
                lvDSSV.Columns.Add("Số CMND", 90);
                lvDSSV.Columns.Add("Số điện thoại", 100);
                lvDSSV.Columns.Add("Địa chỉ liên lạc", 160);
            }

            // Nạp danh sách lớp mẫu
            cmbLop.Items.AddRange(new object[] { "CTK41", "CTK42", "CTK43", "CTK44", "CTK45", "CTK46", "CTK47" });
            if (cmbLop.Items.Count > 0) cmbLop.SelectedIndex = 0;

            // Sự kiện ContextMenu
            menuThemMon.Click += (s, ev) =>
            {
                string monMoi = ShowInputBox("Nhập tên môn học mới:", "Thêm môn học");
                if (!string.IsNullOrWhiteSpace(monMoi) && !clbMonHoc.Items.Contains(monMoi))
                    clbMonHoc.Items.Add(monMoi, true);
            };

            menuXoaMon.Click += (s, ev) =>
            {
                for (int i = clbMonHoc.Items.Count - 1; i >= 0; i--)
                {
                    if (clbMonHoc.GetItemChecked(i))
                        clbMonHoc.Items.RemoveAt(i);
                }
            };

            menuXoaSV.Click += (s, ev) =>
            {
                var dsXoa = lvDSSV.CheckedItems.Cast<ListViewItem>().Select(item => item.SubItems[0].Text).ToList();
                if (dsXoa.Count == 0)
                {
                    MessageBox.Show("Vui lòng tích checkbox sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa {dsXoa.Count} sinh viên đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qlsv.XoaNhieu(dsXoa);
                    HienThiLenListView(qlsv.DanhSach);
                    ResetForm();
                }
            };

            HienThiLenListView(qlsv.DanhSach);
        }

        private void HienThiLenListView(List<SinhVien> list)
        {
            lvDSSV.Items.Clear();
            foreach (var sv in list)
            {
                var item = new ListViewItem(sv.MSSV);
                item.SubItems.Add(sv.HoVaTenLot);
                item.SubItems.Add(sv.Ten);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SoCMND);
                item.SubItems.Add(sv.SoDT);
                item.SubItems.Add(sv.DiaChi);
                item.Tag = sv;
                lvDSSV.Items.Add(item);
            }
        }

        // Lấy thông tin từ Form
        private SinhVien ThuThapThongTin(out string error)
        {
            error = string.Empty;

            string mssv = mtxbMSSV.Text.Trim();
            string hoLot = txbHo.Text.Trim();
            string ten = txbTen.Text.Trim();
            string diaChi = txbDiaChi.Text.Trim();
            string cmnd = mtxbCMND.Text.Trim();
            string sdt = new string(mtxbSDT.Text.Where(char.IsDigit).ToArray());
            string lop = cmbLop.Text.Trim();

            // Validate nhập đầy đủ thông tin (Yêu cầu 2.e)
            if (string.IsNullOrEmpty(mssv) || mssv.Length != 7)
            {
                error = "MSSV phải đủ đúng 7 chữ số!";
                return null;
            }
            if (string.IsNullOrEmpty(hoLot) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diaChi))
            {
                error = "Vui lòng nhập đầy đủ Họ tên và Địa chỉ!";
                return null;
            }
            if (string.IsNullOrEmpty(cmnd) || cmnd.Length != 9)
            {
                error = "Số CMND phải gồm đúng 9 chữ số!";
                return null;
            }
            if (string.IsNullOrEmpty(sdt) || sdt.Length != 10)
            {
                error = "Số điện thoại phải gồm đúng 10 chữ số!";
                return null;
            }

            var dsMon = clbMonHoc.CheckedItems.Cast<string>().ToList();

            return new SinhVien(mssv, hoLot, ten, dtpNgaySinh.Value, lop, cmnd, sdt, diaChi, radNam.Checked, dsMon);
        }

        // Khi chọn 1 sinh viên trên ListView -> Đổ data ngược lại Controls
        private void LvDSSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDSSV.SelectedItems.Count == 0) return;

            ListViewItem item = lvDSSV.SelectedItems[0];
            SinhVien sv = item.Tag as SinhVien;
            if (sv == null) return;

            // Tiêu đề

            item.SubItems.Add(sv.MSSV);
            item.SubItems.Add(sv.HoVaTenLot);
            item.SubItems.Add(sv.Ten);
            item.SubItems.Add(sv.NgaySinh.ToShortDateString());
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.SoCMND);
            item.SubItems.Add(sv.SoDT);
            item.SubItems.Add(sv.DiaChi);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            item.SubItems.Add(gt);

            //

            mtxbMSSV.Text = sv.MSSV;
            txbHo.Text = sv.HoVaTenLot;
            txbTen.Text = sv.Ten;
            dtpNgaySinh.Value = sv.NgaySinh;
            cmbLop.Text = sv.Lop;
            mtxbCMND.Text = sv.SoCMND;
            mtxbSDT.Text = sv.SoDT;
            txbDiaChi.Text = sv.DiaChi;
            radNam.Checked = sv.GioiTinh;
            radNu.Checked = !sv.GioiTinh;

            // Reset và check lại môn học
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                string tenMon = clbMonHoc.Items[i].ToString();
                bool daDangKy = sv.MonHocDangKy != null && sv.MonHocDangKy.Contains(tenMon);
                clbMonHoc.SetItemChecked(i, daDangKy);
            }
        }

        private string ShowInputBox(string prompt, string title)
        {
            using (Form form = new Form())
            {
                form.Width = 360;
                form.Height = 160;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.Text = title;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label lbl = new Label() { Left = 20, Top = 15, Text = prompt, AutoSize = true };
                TextBox txt = new TextBox() { Left = 20, Top = 40, Width = 300 };
                Button btnOk = new Button() { Text = "OK", Left = 150, Width = 80, Top = 75, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Hủy", Left = 240, Width = 80, Top = 75, DialogResult = DialogResult.Cancel };

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnCancel);
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                return form.ShowDialog() == DialogResult.OK ? txt.Text.Trim() : string.Empty;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Tạo Form tìm kiếm
            using (Form fTim = new Form())
            {
                fTim.Text = "Tìm kiếm sinh viên";
                fTim.Size = new System.Drawing.Size(460, 270);
                fTim.StartPosition = FormStartPosition.CenterParent;
                fTim.FormBorderStyle = FormBorderStyle.FixedDialog;
                fTim.MaximizeBox = false;
                fTim.MinimizeBox = false;
                fTim.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);

                // 1. Ô nhập Tên / Từ khóa
                Label lblKey = new Label() { Text = "Từ khóa cần tìm:", Left = 20, Top = 25, AutoSize = true };
                TextBox txtKey = new TextBox() { Left = 160, Top = 22, Width = 250 };

                // 2. Tích chọn điều kiện tìm kiếm
                Label lblTieuChi = new Label() { Text = "Điều kiện tìm kiếm:", Left = 20, Top = 62, AutoSize = true };
                CheckBox chkTen = new CheckBox() { Text = "Theo Tên / Họ", Left = 160, Top = 60, Checked = true, AutoSize = true };
                CheckBox chkMSSV = new CheckBox() { Text = "Theo MSSV", Left = 290, Top = 60, AutoSize = true };

                // 3. Tích lọc theo Lớp + ComboBox chọn Lớp
                CheckBox chkLop = new CheckBox() { Text = "Lọc theo Lớp:", Left = 20, Top = 102, AutoSize = true };
                ComboBox cboLopSearch = new ComboBox() { Left = 160, Top = 100, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList, Enabled = false };

                cboLopSearch.Items.AddRange(cmbLop.Items.Cast<object>().ToArray());
                if (cboLopSearch.Items.Count > 0) cboLopSearch.SelectedIndex = 0;

                chkLop.CheckedChanged += (s, ev) => { cboLopSearch.Enabled = chkLop.Checked; };

                // 4. Các nút bấm
                Button btnXacNhan = new Button() { Text = "Tìm kiếm", Left = 220, Top = 175, Width = 95, Height = 34, DialogResult = DialogResult.OK };
                Button btnDong = new Button() { Text = "Đóng", Left = 325, Top = 175, Width = 85, Height = 34, DialogResult = DialogResult.Cancel };

                fTim.Controls.AddRange(new Control[] { lblKey, txtKey, lblTieuChi, chkTen, chkMSSV, chkLop, cboLopSearch, btnXacNhan, btnDong });
                fTim.AcceptButton = btnXacNhan;

                // Khi người dùng bấm nút [Tìm kiếm]
                if (fTim.ShowDialog() == DialogResult.OK)
                {
                    string kw = txtKey.Text.Trim().ToLower();
                    bool timTheoLop = chkLop.Checked;
                    string lopDaChon = cboLopSearch.Text;

                    // Nếu không nhập từ khóa và không chọn lớp -> nạp lại toàn bộ danh sách
                    if (string.IsNullOrEmpty(kw) && !timTheoLop)
                    {
                        HienThiLenListView(qlsv.DanhSach);
                        return;
                    }

                    // Quét từ khóa qua TẤT CẢ các trường thông tin còn lại (The rest)
                    var ketQua = qlsv.DanhSach.Where(sv =>
                    {
                        bool matchKey = true;
                        if (!string.IsNullOrEmpty(kw))
                        {
                            matchKey = sv.MSSV.ToLower().Contains(kw) ||
                                       sv.Ten.ToLower().Contains(kw) ||
                                       sv.HoVaTenLot.ToLower().Contains(kw) ||
                                       (sv.HoVaTenLot + " " + sv.Ten).ToLower().Contains(kw) ||
                                       sv.SoCMND.Contains(kw) ||
                                       sv.SoDT.Contains(kw) ||
                                       sv.DiaChi.ToLower().Contains(kw) ||
                                       (kw == "nam" && sv.GioiTinh) ||
                                       (kw == "nữ" && !sv.GioiTinh);
                        }

                        // Kết hợp lọc Lớp nếu có tích chọn
                        bool matchLop = true;
                        if (timTheoLop)
                        {
                            matchLop = sv.Lop.Equals(lopDaChon, StringComparison.OrdinalIgnoreCase);
                        }

                        return matchKey && matchLop;
                    }).ToList();

                    // Xử lý thông báo kết quả
                    if (ketQua.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên nào khớp với điều kiện tìm kiếm!",
                                        "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        HienThiLenListView(ketQua);
                        MessageBox.Show($"Tìm thấy {ketQua.Count} kết quả thoả mãn!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var sv = ThuThapThongTin(out string error);
            if (sv == null)
            {
                MessageBox.Show(error, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!qlsv.CapNhat(sv, out string errUpdate))
            {
                MessageBox.Show(errUpdate, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HienThiLenListView(qlsv.DanhSach);
            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            var sv = ThuThapThongTin(out string error);
            if (sv == null)
            {
                MessageBox.Show(error, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!SinhVien.KiemTraHopLeMSSV(sv.MSSV, sv.Lop, out string errMSSV))
            {
                MessageBox.Show(errMSSV, "Quy tắc MSSV không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!qlsv.Them(sv, out string errThem))
            {
                MessageBox.Show(errThem, "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HienThiLenListView(qlsv.DanhSach);
            MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();

            menuThemMon.Click += (s, ev) =>
            {
                string monMoi = ShowInputBox("Thêm môn học", "Nhập tên môn học mới:");
                if (!string.IsNullOrWhiteSpace(monMoi) && !clbMonHoc.Items.Contains(monMoi))
                    clbMonHoc.Items.Add(monMoi, true);
            };
        }
        private void ResetForm()
        {
            mtxbMSSV.Clear();
            txbHo.Clear();
            txbTen.Clear();
            txbDiaChi.Clear();
            mtxbCMND.Clear();
            mtxbSDT.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
                clbMonHoc.SetItemChecked(i, false);
        }
    }
}
