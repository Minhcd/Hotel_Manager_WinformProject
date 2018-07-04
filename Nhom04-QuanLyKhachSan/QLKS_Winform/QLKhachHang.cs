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
    public partial class QLKhachHang : MaterialForm
    {
        public QLKhachHang()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        QLKSDataContext db = new QLKSDataContext();
        KhachHang ks = new KhachHang();

        private void HienThi(bool gt)
        {
            txtHoTen.Enabled = gt;
            txtDiaChi.Enabled = gt;
            cbbGioiTinh.Enabled = gt;
            txtSDT.Enabled = gt;
            txtCMND.Enabled = gt;
        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            HienThi(false);
            btnLuu.Enabled = false;
            btnKLuu.Enabled = false;
            LoadDSKH();
            dgvKhachHang.ReadOnly = true;
        }

        private void LoadDSKH()
        {
            dgvKhachHang.DataSource = db.KhachHangs.OrderBy(p => p.HoTen).Select(p => new
            {
                p.HoTen,
                p.DiaChi,
                p.GioiTinh,
                p.SDT,
                p.CMND,
                p.ThanhToan
            });
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void dgvKhachHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            KhachHang kh = new KhachHang();
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr = dgvKhachHang.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtHoTen.Text = dgvr.Cells[0].Value.ToString();
                txtDiaChi.Text = dgvr.Cells[1].Value.ToString();
                cbbGioiTinh.Text = dgvr.Cells[2].Value.ToString();
                txtSDT.Text = dgvr.Cells[3].Value.ToString();
                txtCMND.Text = dgvr.Cells[4].Value.ToString();
            }
            kh = db.KhachHangs.SingleOrDefault(p => p.CMND == txtCMND.Text.Trim());
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDSKH();
        }

        bool insert = false;
        bool edit = false;
        bool find = false;
        private void Clear_Box()
        {
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtCMND.Clear();
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
            btnInDSKH.Enabled = false;
            btnLuu.Enabled = true;
            btnKLuu.Enabled = true;
            insert = true;
            Clear_Box();
            txtHoTen.Focus();
            dgvKhachHang.Enabled = false;
        }

        private void ThemKH()
        {
            try
            {
                KhachHang kh = new KhachHang
                {
                    CMND = txtCMND.Text,
                    HoTen = txtHoTen.Text,
                    GioiTinh = cbbGioiTinh.Text,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    ThanhToan = "Chưa thanh toán"
                };
                if (db.KhachHangs.Where(p => p.CMND == txtCMND.Text).SingleOrDefault() != null)
                {
                    MessageBox.Show("Chứng Minh Nhân Dân bạn nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtHoTen.Text.Trim() == "" || txtCMND.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtSDT.Text.Trim() == "")
                {
                    MessageBox.Show("Một số thông tin còn thiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSKH();
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
                ThemKH();
                insert = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnInDSKH.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvKhachHang.Enabled = true;
                HienThi(false);
            }

            if (edit)
            {
                SuaKH();
                edit = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnInDSKH.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvKhachHang.Enabled = true;
                HienThi(false);
            }

            if (find)
            {
                TimKH();
                find = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnInDSKH.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvKhachHang.Enabled = true;
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
                btnInDSKH.Enabled = true;
                btnTaiLai.Enabled = true;
                btnTimKiem.Enabled = true;
                dgvKhachHang.Enabled = true;
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
                btnInDSKH.Enabled = true;
                dgvKhachHang.Enabled = true;
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
                btnInDSKH.Enabled = true;
                dgvKhachHang.Enabled = true;
                HienThi(false);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            KhachHang kh = db.KhachHangs.SingleOrDefault(p => p.CMND == txtCMND.Text);
            if (kh.ThanhToan != "Chưa thanh toán")
            {
                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa khách hàng " + txtHoTen.Text + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    db.KhachHangs.DeleteOnSubmit(kh);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSKH();
                }
            }
            else
            {

                MessageBox.Show("Khách hàng này vẫn đang thuê phòng! Không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnInDSKH.Enabled = false;
            btnTimKiem.Enabled = false;
            btnTaiLai.Enabled = false;
            HienThi(true);
            txtCMND.Enabled = false;
            txtHoTen.Focus();
            dgvKhachHang.Enabled = false;
        }

        private void SuaKH()
        {
            try
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(p => p.CMND == txtCMND.Text);
                {
                    kh.HoTen = txtHoTen.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    kh.GioiTinh = cbbGioiTinh.Text;
                    kh.SDT = txtSDT.Text;
                    kh.CMND = txtCMND.Text;
                }
                db.SubmitChanges();
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSKH();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu! Xin vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            btnInDSKH.Enabled = false;
            HienThi(false);
            //txtTenDN.Enabled = true;
            txtHoTen.Enabled = true;
            txtHoTen.Focus();
            Clear_Box();
            dgvKhachHang.Enabled = false;
        }

        private void TimKH()
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvKhachHang.DataSource = db.KhachHangs.Where(p => p.HoTen.Contains(txtHoTen.Text)).Select(p => new {
                    p.HoTen,
                    p.DiaChi,
                    p.GioiTinh,
                    p.CMND,
                    p.SDT,
                    p.ThanhToan
                });
            }
        }

        private void btnThem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThem, "Thêm khách hàng");
        }

        private void btnXoa_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnXoa, "Xóa khách hàng");
        }

        private void btnSua_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnSua, "Sửa thông tin khách hàng");
        }

        private void btnTimKiem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTimKiem, "Tìm kiếm khách hàng");
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

        private void btnTaiLai_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTaiLai, "Tải lại danh sách");
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThoat, "Trở về màn hình chính");
        }

        private void btnInDSKH_Click(object sender, EventArgs e)
        {
            DSKhach ds = new DSKhach();
            ds.ShowDialog();
        }

        private void btnInDSKH_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnInDSKH, "In danh sách khách hàng");
        }
    }
}
