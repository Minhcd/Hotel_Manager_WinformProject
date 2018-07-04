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
    public partial class QL_Phong : MaterialForm
    {
        public QL_Phong()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        QLKSDataContext db = new QLKSDataContext();
        PhongK ph = new PhongK();
        private void HienThi(bool gt)
        {
            txtMaPhong.Enabled = gt;
            txtTenPhong.Enabled = gt;
            cbbLoaiPhong.Enabled = gt;
            txtGiaPhong.Enabled = gt;
            txtTinhTrang.Enabled = gt;
        }

        private void QL_Phong_Load(object sender, EventArgs e)
        {
            HienThi(false);
            btnLuu.Enabled = false;
            btnKLuu.Enabled = false;
            LoadDSP();
            dgvPhong.ReadOnly = true;
        }

        private void LoadDSP()
        {
            dgvPhong.DataSource = db.PhongKs.OrderBy(p => p.MaPhong).Select(p => new
            {
                p.MaPhong,
                p.TenPhong,
                p.LoaiPhong,
                p.GiaPhong,
                p.TinhTrang,
            });
        }

        private void dgvPhong_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr = dgvPhong.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtMaPhong.Text = dgvr.Cells[0].Value.ToString();
                txtTenPhong.Text = dgvr.Cells[1].Value.ToString();
                cbbLoaiPhong.Text = dgvr.Cells[2].Value.ToString();
                txtGiaPhong.Text = dgvr.Cells[3].Value.ToString();
                txtTinhTrang.Text = dgvr.Cells[4].Value.ToString();
            }
            ph = db.PhongKs.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text.Trim());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDSP();
        }

        bool insert = false;
        bool edit = false;
        bool find = false;
        private void Clear_Box()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtGiaPhong.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThi(true);
            txtTinhTrang.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            btnTaiLai.Enabled = false;
            btnLuu.Enabled = true;
            btnKLuu.Enabled = true;
            insert = true;
            Clear_Box();
            txtTinhTrang.Text = "Trống";
            txtMaPhong.Focus();
            dgvPhong.Enabled = false;
        }

        private void ThemP()
        {
            try
            {
                PhongK pk = new PhongK
                {
                    MaPhong = txtMaPhong.Text,
                    TenPhong = txtTenPhong.Text,
                    LoaiPhong = cbbLoaiPhong.Text,
                    GiaPhong = double.Parse(txtGiaPhong.Text),
                    TinhTrang = txtTinhTrang.Text,
                };

                if (db.PhongKs.Where(p => p.MaPhong == txtMaPhong.Text).SingleOrDefault() != null)
                {
                    MessageBox.Show("Mã phòng bạn nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTenPhong.Text.Trim() == "" || txtGiaPhong.Text.Trim() == "" || txtTinhTrang.Text.Trim() == "" || txtMaPhong.Text.Trim() == "")
                {
                    MessageBox.Show("Một số thông tin còn thiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.PhongKs.InsertOnSubmit(pk);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm phòng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSP();
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
                ThemP();
                insert = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvPhong.Enabled = true;
                HienThi(false);
            }

            if (edit)
            {
                SuaP();
                edit = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvPhong.Enabled = true;
                HienThi(false);
            }

            if (find)
            {
                TimP();
                find = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = true;
                btnTaiLai.Enabled = true;
                btnLuu.Enabled = false;
                btnKLuu.Enabled = false;
                dgvPhong.Enabled = true;
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
                dgvPhong.Enabled = true;
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
                dgvPhong.Enabled = true;
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
                dgvPhong.Enabled = true;
                HienThi(false);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            PhongK pk = db.PhongKs.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text);
            if (pk.TinhTrang == "Trống")
            {
                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa phòng " + txtTenPhong.Text + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    db.PhongKs.DeleteOnSubmit(pk);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSP();
                }
            }
            else
            {
                MessageBox.Show("Có khách ở trong phòng! Không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtMaPhong.Enabled = false;
            txtTenPhong.Focus();
            dgvPhong.Enabled = false;
        }
        private void SuaP()
        {
            try
            {
                PhongK pk = db.PhongKs.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text);
                {
                    pk.TenPhong = txtTenPhong.Text;
                    pk.LoaiPhong = cbbLoaiPhong.Text;
                    pk.GiaPhong = double.Parse(txtGiaPhong.Text);
                    pk.TinhTrang = txtTinhTrang.Text;
                }
                db.SubmitChanges();
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSP();
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
            txtTenPhong.Enabled = true;
            txtTenPhong.Focus();
            Clear_Box();
            dgvPhong.Enabled = false;
        }

        private void TimP()
        {
            if (txtTenPhong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvPhong.DataSource = db.PhongKs.Where(p => p.TenPhong.Contains(txtTenPhong.Text)).Select(p => new {
                    p.MaPhong,
                    p.TenPhong,
                    p.LoaiPhong,
                    p.GiaPhong,
                    p.TinhTrang,
                });
            }
        }

        private void btnThem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThem, "Thêm phòng");
        }

        private void btnXoa_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnXoa, "Xóa phòng");
        }

        private void btnSua_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnSua, "Sửa thông tin phòng");
        }

        private void btnTimKiem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTimKiem, "Tìm kiếm phòng");
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

        private void btnInDSP_Click(object sender, EventArgs e)
        {
            DSPhong ds = new DSPhong();
            ds.ShowDialog();
        }

        private void btnInDSP_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnInDSP, "In danh sách phòng");
        }
    }
}
