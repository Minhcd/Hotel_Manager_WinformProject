using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;

namespace QLKS_Winform
{
    public partial class QL_TaiKhoanNV : MaterialForm
    {
        public QL_TaiKhoanNV()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        QLKSDataContext db = new QLKSDataContext();
        TaiKhoanNV nv = new TaiKhoanNV();

        private void HienThi(bool gt)
        {
            txtTenDN.Enabled = gt;
            txtMK.Enabled = gt;
            txtTenND.Enabled = gt;
            cbbGioiTinh.Enabled = gt;
            txtDiaChi.Enabled = gt;
            txtSDT.Enabled = gt;
            dtpNgaySinh.Enabled = gt;
            cbbChucVu.Enabled = gt;
        }
        private void QL_TaiKhoanNV_Load(object sender, EventArgs e)
        {
            HienThi(false);
            btnLuu.Enabled = false;
            btnKLuu.Enabled = false;
            LoadDSTK();
            dgvNhanVien.ReadOnly = true;
        }

        private void LoadDSTK()
        {
            dgvNhanVien.DataSource = db.TaiKhoanNVs.OrderBy(p => p.Account).Select(p => new
            {
                p.Account,
                p.Pass,
                p.TenND,
                p.GioiTinh,
                p.NgaySinhNV,
                p.DiaChi,
                p.SDT,
                p.ChucVu,
            });
        }

        bool insert = false;
        bool edit = false;
        bool find = false;
        

        private void Clear_Box()
        {
            txtTenDN.Clear();
            txtMK.Clear();
            txtTenND.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThi(true);
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            btnTaiLai.Enabled = false;
            btnLuu.Enabled = true;
            btnKLuu.Enabled = true;
            insert = true;
            Clear_Box();
            txtTenDN.Focus();
            dgvNhanVien.Enabled = false;
        }

        private void ThemTK()
        {
            try
            {
                TaiKhoanNV nv = new TaiKhoanNV
                {
                    Account = txtTenDN.Text,
                    Pass = txtMK.Text,
                    TenND = txtTenND.Text,
                    GioiTinh = cbbGioiTinh.Text,
                    NgaySinhNV = dtpNgaySinh.Value,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    ChucVu = cbbChucVu.Text,
                };

                if (db.TaiKhoanNVs.Where(p => p.Account == txtTenDN.Text).SingleOrDefault() != null)
                {
                    MessageBox.Show("Tên tài khoản bạn nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTenDN.Text.Trim() == "" || txtMK.Text.Trim() == "" || txtTenND.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtSDT.Text.Trim() == "")
                {
                    MessageBox.Show("Một số thông tin còn thiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.TaiKhoanNVs.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSTK();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu! Xin vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (insert)
            {
                ThemTK();
                insert = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvNhanVien.Enabled = true;
                HienThi(false);
            }

            if (edit)
            {
                SuaTK();
                edit = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvNhanVien.Enabled = true;
                HienThi(false);
            }

            if (find)
            {
                TimTK();
                find = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvNhanVien.Enabled = true;
                HienThi(false);
            }
        }

        private void btnKLuu_Click(object sender, EventArgs e)
        {
            if (insert)
            {
                insert = false;
                Clear_Box();
                HienThi(false);
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTaiLai.Enabled = true;
                btnTimKiem.Enabled = true;
                dgvNhanVien.Enabled = true;
            }

            if (edit)
            {
                edit = false;
                Clear_Box();
                HienThi(false);
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                btnTaiLai.Enabled = true;
                btnTimKiem.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                dgvNhanVien.Enabled = true;
            }

            if (find)
            {
                find = false;
                Clear_Box();
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvNhanVien.Enabled = true;
                HienThi(false);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TaiKhoanNV tk = db.TaiKhoanNVs.SingleOrDefault(p => p.Account == txtTenDN.Text);
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa tài khoản "+ txtTenDN.Text + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                db.TaiKhoanNVs.DeleteOnSubmit(tk);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSTK();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            edit = true;
            btnLuu.Enabled = true;
            btnKLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            btnTaiLai.Enabled = false;
            HienThi(true);
            txtTenDN.Enabled = false;
            txtMK.Focus();
            dgvNhanVien.Enabled = false;
        }

        private void SuaTK()
        {
            try {
                TaiKhoanNV tk = db.TaiKhoanNVs.SingleOrDefault(p => p.Account == txtTenDN.Text);
                {
                    tk.Pass = txtMK.Text;
                    tk.TenND = txtTenND.Text;
                    tk.GioiTinh = cbbGioiTinh.Text;
                    tk.NgaySinhNV = dtpNgaySinh.Value;
                    tk.DiaChi = txtDiaChi.Text;
                    tk.SDT = txtSDT.Text;
                    tk.ChucVu = cbbChucVu.Text;
                }
                db.SubmitChanges();
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSTK();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu! Xin vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThem,"Thêm tài khoản");
        }

        private void btnXoa_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnXoa, "Xóa tài khoản");
        }

        private void btnSua_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnSua, "Sửa thông tin tài khoản");
        }

        private void btnLuu_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnLuu, "Lưu thay đổi");
        }

        private void btnKLuu_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnKLuu, "Hủy thao tác");
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThoat, "Trở về màn hình chính");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            find = true;
            btnLuu.Enabled = true;
            btnKLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            btnTaiLai.Enabled = false;
            HienThi(false);
            //txtTenDN.Enabled = true;
            txtTenND.Enabled = true;
            txtTenND.Focus();
            Clear_Box();
            dgvNhanVien.Enabled = false;
        }

        private void TimTK()
        {
            if (txtTenND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvNhanVien.DataSource = db.TaiKhoanNVs.Where(p => p.TenND.Contains(txtTenND.Text)).Select(p => new {
                    p.Account,
                    p.Pass,
                    p.TenND,
                    p.GioiTinh,
                    p.NgaySinhNV,
                    p.DiaChi,
                    p.SDT,
                    p.ChucVu,
                });
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            HienThi(false);
            btnLuu.Enabled = false;
            btnKLuu.Enabled = false;
            LoadDSTK();
            dgvNhanVien.ReadOnly = true;
        }

        private void btnTimKiem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTimKiem, "Tìm kiếm tài khoản");
        }

        private void btnTaiLai_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTaiLai, "Tải lại danh sách");
        }

        private void dgvNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            TaiKhoanNV tk = new TaiKhoanNV();
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr = dgvNhanVien.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtTenDN.Text = dgvr.Cells[0].Value.ToString();
                txtMK.Text = dgvr.Cells[1].Value.ToString();
                txtTenND.Text = dgvr.Cells[2].Value.ToString();
                cbbGioiTinh.Text = dgvr.Cells[3].Value.ToString();
                dtpNgaySinh.Text = dgvr.Cells[4].Value.ToString();
                txtDiaChi.Text = dgvr.Cells[5].Value.ToString();
                txtSDT.Text = dgvr.Cells[6].Value.ToString();
                cbbChucVu.Text = dgvr.Cells[7].Value.ToString();
            }
            tk = db.TaiKhoanNVs.SingleOrDefault(p => p.Account == txtTenND.Text.Trim());
        }

        private void btnInDSTK_Click(object sender, EventArgs e)
        {
            DSTaiKhoan ds = new DSTaiKhoan();
            ds.ShowDialog();
        }

        private void btnInDSTK_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnInDSTK, "In danh sách tài khoản");
        }
    }
}
