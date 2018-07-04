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
    public partial class QL_DichVu : MaterialForm
    {
        public QL_DichVu()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        QLKSDataContext db = new QLKSDataContext();
        DichVuPhong dv = new DichVuPhong();
        private void HienThi(bool gt)
        {
            txtMaDV.Enabled = gt;
            txtTenDV.Enabled = gt;
            txtGiaDV.Enabled = gt;
            txtDonVi.Enabled = gt;
        }

        private void QL_DichVu_Load(object sender, EventArgs e)
        {
            HienThi(false);
            btnLuu.Enabled = false;
            btnKLuu.Enabled = false;
            LoadDSDV();
            dgvDichVu.ReadOnly = true;
        }

        private void LoadDSDV()
        {
            dgvDichVu.DataSource = db.DichVuPhongs.OrderBy(p => p.MaDV).Select(p => new
            {
                p.MaDV,
                p.TenDV,
                p.GiaDV,
                p.DVT,
            });
        }

        private void dgvDichVu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr = dgvDichVu.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtMaDV.Text = dgvr.Cells[0].Value.ToString();
                txtTenDV.Text = dgvr.Cells[1].Value.ToString();
                txtGiaDV.Text = dgvr.Cells[2].Value.ToString();
                txtDonVi.Text = dgvr.Cells[3].Value.ToString();
            }
            dv = db.DichVuPhongs.SingleOrDefault(p => p.MaDV == txtMaDV.Text.Trim());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDSDV();
        }

        bool insert = false;
        bool edit = false;
        bool find = false;
        private void Clear_Box()
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtGiaDV.Clear();
            txtDonVi.Clear();
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
            txtMaDV.Focus();
            dgvDichVu.Enabled = false;
        }
        private void ThemDV()
        {
            try
            {
                DichVuPhong dv = new DichVuPhong
                {
                    MaDV = txtMaDV.Text,
                    TenDV = txtTenDV.Text,
                    GiaDV = double.Parse(txtGiaDV.Text),
                    DVT = txtDonVi.Text,
                };

                if (db.DichVuPhongs.Where(p => p.MaDV == txtMaDV.Text).SingleOrDefault() != null)
                {
                    MessageBox.Show("Mã dịch vụ bạn nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtMaDV.Text.Trim() == "" || txtTenDV.Text.Trim() == "" || txtGiaDV.Text.Trim() == "" || txtDonVi.Text.Trim() == "")
                {
                    MessageBox.Show("Một số thông tin còn thiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.DichVuPhongs.InsertOnSubmit(dv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm dịch vụ mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSDV();
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
                ThemDV();
                insert = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvDichVu.Enabled = true;
                HienThi(false);
            }

            if (edit)
            {
                SuaDV();
                edit = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvDichVu.Enabled = true;
                HienThi(false);
            }

            if (find)
            {
                TimDV();
                find = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvDichVu.Enabled = true;
                HienThi(false);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DichVuPhong dv = db.DichVuPhongs.SingleOrDefault(p => p.MaDV == txtMaDV.Text);
                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa dịch vụ " + txtTenDV.Text + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    db.DichVuPhongs.DeleteOnSubmit(dv);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSDV();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dịch vụ này đang được sủ dụng! Không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgvDichVu.Enabled = true;
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
                dgvDichVu.Enabled = true;
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
                dgvDichVu.Enabled = true;
                HienThi(false);
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
            txtMaDV.Enabled = false;
            txtTenDV.Focus();
            dgvDichVu.Enabled = false;
        }
        private void SuaDV()
        {
            try
            {
                DichVuPhong dv = db.DichVuPhongs.SingleOrDefault(p => p.MaDV == txtMaDV.Text);
                {
                    dv.TenDV = txtTenDV.Text;
                    dv.GiaDV = double.Parse(txtGiaDV.Text);
                    dv.DVT = txtDonVi.Text;
                }
                db.SubmitChanges();
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSDV();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu! Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            HienThi(false);
            txtTenDV.Enabled = true;
            txtTenDV.Focus();
            Clear_Box();
            dgvDichVu.Enabled = false;
        }
        private void TimDV()
        {
            if (txtTenDV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvDichVu.DataSource = db.DichVuPhongs.Where(p => p.TenDV.Contains(txtTenDV.Text)).Select(p => new {
                    p.MaDV,
                    p.TenDV,
                    p.GiaDV,
                    p.DVT,
                });
            }
        }

        private void btnThem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThem, "Thêm dịch vụ");
        }

        private void btnXoa_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnXoa, "Xóa dịch vụ");
        }

        private void btnSua_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnSua, "Sửa thông tin dịch vụ");
        }

        private void btnTimKiem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTimKiem, "Tìm kiếm dịch vụ");
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

        private void btnInDSDV_Click(object sender, EventArgs e)
        {
            DSDichVu ds = new DSDichVu();
            ds.ShowDialog();
        }

        private void btnInDSDV_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnInDSDV, "In danh sách dịch vụ");
        }
    }
}
