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
    public partial class SuDungDV : MaterialForm
    {
        public SuDungDV()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        QLKSDataContext db = new QLKSDataContext();
        private void SuDungDV_Load(object sender, EventArgs e)
        {
            LoadDSK();
            LoadDSDV();
            LoadSDDV();
        }

        private void LoadDSDV()
        {
            dgvDanhSachDV.DataSource = db.DichVuPhongs.OrderBy(p => p.TenDV).Select(p => new
            {
                p.MaDV,
                p.TenDV,
                p.GiaDV,
                p.DVT
            });
        }

        private void LoadDSK()
        {
            dgvKhach.DataSource = db.ThuePhongs.OrderBy(p => p.MaPhong).Where(p => p.ThanhToan == "Chưa thanh toán").Select(p => new
            {
                p.CMND,
                p.MaPhong,
                p.HotenKH
            });
        }

        private void LoadSDDV()
        {
            dgvSDDV.DataSource = db.SDDVPhongs.OrderBy(p => p.ThanhToan).Select(p => new
            {
                p.CMND,
                p.MaPhong,
                p.MaDV,
                p.TenDV,
                p.SoLuong,
                p.NgaySD,
                p.TongTienDV,
                p.ThanhToan
            });
        }

        private void dgvKhach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            ThuePhong ph = new ThuePhong();
            dgvr = dgvKhach.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtCMND.Text = dgvr.Cells[0].Value.ToString();
                txtMP.Text = dgvr.Cells[1].Value.ToString();
                txtMaPhong.Text = dgvr.Cells[1].Value.ToString();
            }
            ph = db.ThuePhongs.FirstOrDefault(p => p.MaPhong == txtMaPhong.Text.Trim());
        }

        private void dgvDanhSachDV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            DichVuPhong ph = new DichVuPhong();
            dgvr = dgvDanhSachDV.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtMaDV.Text = dgvr.Cells[0].Value.ToString();
                txtTDV.Text = dgvr.Cells[1].Value.ToString();
                txtTenDV.Text = dgvr.Cells[1].Value.ToString();
                txtGiaDV.Text = dgvr.Cells[2].Value.ToString();
                txtDVT.Text = dgvr.Cells[3].Value.ToString();
            }
            ph = db.DichVuPhongs.SingleOrDefault(p => p.MaDV == txtMaDV.Text.Trim());
        }

        private void btnTimKiemPhong_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvKhach.DataSource = db.ThuePhongs.OrderBy(p => p.MaPhong).Where(p => p.MaPhong.Contains(txtMaPhong.Text) && p.ThanhToan == "Chưa thanh toán").Select(p => new {
                    p.CMND,
                    p.MaPhong,
                    p.ThanhToan
                });
            }
        }

        private void btnRefreshPhong_Click(object sender, EventArgs e)
        {
            LoadDSK();
        }

        private void btnTimKiemDV_Click(object sender, EventArgs e)
        {
            if (txtTenDV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvDanhSachDV.DataSource = db.DichVuPhongs.OrderBy(p => p.TenDV).Where(p => p.TenDV.Contains(txtTenDV.Text)).Select(p => new {
                    p.MaDV,
                    p.TenDV,
                    p.GiaDV,
                    p.DVT
                });
            }
        }

        private void btnRefreshDV_Click(object sender, EventArgs e)
        {
            LoadDSDV();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SDDVPhong sd = db.SDDVPhongs.SingleOrDefault(p => p.MaPhong == txtMP.Text && p.MaDV == txtMaDV.Text);
                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    db.SDDVPhongs.DeleteOnSubmit(sd);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSDDV();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải chọn đúng mã phòng và mã dịch vụ ở 2 bảng trên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool insert = false;
        bool edit = false;
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiemDV.Enabled = false;
            btnTimKiemPhong.Enabled = false;
            btnRefreshDV.Enabled = false;
            btnRefreshPhong.Enabled = false;
            btnLuu.Enabled = true;
            btnKLuu.Enabled = true;
            insert = true;
            txtSoLuong.Enabled = true;
            dtpNgaySD.Enabled = true;
            txtSoLuong.Clear();
            txtSoLuong.Focus();
            dgvKhach.Enabled = false;
            dgvDanhSachDV.Enabled = false;
            dgvSDDV.Enabled = false;
        }

        private void ThemSDDV()
        {
            try
            {
                SDDVPhong sd = new SDDVPhong
                {
                    MaPhong = txtMaPhong.Text,
                    CMND = txtCMND.Text,
                    MaDV = txtMaDV.Text,
                    TenDV = txtTenDV.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    NgaySD = dtpNgaySD.Value,
                    TongTienDV = double.Parse(txtGiaDV.Text)*int.Parse(txtSoLuong.Text),
                    ThanhToan = "Chưa thanh toán"
                };
                if (db.SDDVPhongs.Where(p => p.CMND == txtCMND.Text && p.MaDV == txtMaDV.Text).SingleOrDefault() != null)
                {
                    MessageBox.Show("Bạn đã chọn sử dụng dịch vụ này! Vui lòng chọn sửa nếu muốn thay đổi số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.SDDVPhongs.InsertOnSubmit(sd);
                    db.SubmitChanges();
                    MessageBox.Show("Sử dụng dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSDDV();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu! Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (insert)
            {
                ThemSDDV();
                insert = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiemDV.Enabled = true;
                btnTimKiemPhong.Enabled = true;
                btnRefreshDV.Enabled = true;
                btnRefreshPhong.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvSDDV.Enabled = true;
                txtSoLuong.Enabled = false;
                dtpNgaySD.Enabled = false;
                dgvKhach.Enabled = true;
                dgvDanhSachDV.Enabled = true;
                dgvSDDV.Enabled = true;
            }

            if (edit)
            {
                SuaSDDV();
                edit = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiemDV.Enabled = true;
                btnTimKiemPhong.Enabled = true;
                btnRefreshDV.Enabled = true;
                btnRefreshPhong.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvSDDV.Enabled = true;
                txtSoLuong.Enabled = false;
                dgvKhach.Enabled = true;
                dgvDanhSachDV.Enabled = true;
                dgvSDDV.Enabled = true;
            }
        }

        private void btnKLuu_Click(object sender, EventArgs e)
        {
            if (insert)
            {
                insert = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiemDV.Enabled = true;
                btnTimKiemPhong.Enabled = true;
                btnRefreshDV.Enabled = true;
                btnRefreshPhong.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvSDDV.Enabled = true;
                txtSoLuong.Clear();
                txtSoLuong.Enabled = false;
                dtpNgaySD.Enabled = false;
                dgvKhach.Enabled = true;
                dgvDanhSachDV.Enabled = true;
                dgvSDDV.Enabled = true;
            }

            if (edit)
            {
                edit = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiemDV.Enabled = true;
                btnTimKiemPhong.Enabled = true;
                btnRefreshDV.Enabled = true;
                btnRefreshPhong.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvSDDV.Enabled = true;
                txtSoLuong.Clear();
                txtSoLuong.Enabled = false;
                dgvKhach.Enabled = true;
                dgvDanhSachDV.Enabled = true;
                dgvSDDV.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            edit = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiemDV.Enabled = false;
            btnTimKiemPhong.Enabled = false;
            btnRefreshDV.Enabled = false;
            btnRefreshPhong.Enabled = false;
            btnLuu.Enabled = true;
            btnKLuu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtSoLuong.Clear();
            txtSoLuong.Focus();
            dgvKhach.Enabled = false;
            dgvDanhSachDV.Enabled = false;
            dgvSDDV.Enabled = false;
        }

        private void SuaSDDV()
        {
            try
            {
                SDDVPhong sd = db.SDDVPhongs.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text && p.MaDV == txtMaDV.Text);
                {
                    sd.SoLuong = int.Parse(txtSoLuong.Text);
                    sd.TongTienDV = double.Parse(txtGiaDV.Text) * int.Parse(txtSoLuong.Text);
                }
                db.SubmitChanges();
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSDDV();
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải chọn đúng mã phòng và mã dịch vụ ở 2 bảng trên hoặc Dữ liệu bạn nhập bị lỗi! Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemPhong_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTimKiemPhong, "Tìm kiếm phòng");
        }

        private void btnRefreshPhong_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnRefreshPhong, "Tải lại danh sách phòng");
        }

        private void btnTimKiemDV_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTimKiemDV, "Tìm kiếm dịch vụ");
        }

        private void btnRefreshDV_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnRefreshDV, "Tải lại danh sách dịch vụ");
        }

        private void btnThem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThem, "Đăng ký sử dụng dịch vụ");
        }

        private void btnXoa_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnXoa, "Hủy sử dụng dịch vụ");
        }

        private void btnSua_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnSua, "Sửa thông tin sử dụng dịch vụ");
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

        private void btnResSDDV_Click(object sender, EventArgs e)
        {
            LoadSDDV();
        }

        private void btnLocSDDV_Click(object sender, EventArgs e)
        {
            if (txtSDDVCMND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập CMND!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvSDDV.DataSource = db.SDDVPhongs.OrderBy(p => p.MaPhong).Where(p => p.CMND.Contains(txtSDDVCMND.Text)).Select(p => new
                {
                    p.CMND,
                    p.MaPhong,
                    p.MaDV,
                    p.TenDV,
                    p.SoLuong,
                    p.NgaySD,
                    p.TongTienDV,
                    p.ThanhToan
                });
            }
        }

        private void btnLocSDDV_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnLocSDDV, "Tìm kiếm sử dụng dịch vụ");
        }

        private void btnResSDDV_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnResSDDV, "Tải lại danh sách sử dụng dịch vụ");
        }
    }
}
