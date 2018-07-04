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
    public partial class LichSu : MaterialForm
    {
        public LichSu()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        QLKSDataContext db = new QLKSDataContext();
        private void LichSu_Load(object sender, EventArgs e)
        {
            cbbNgay.SelectedIndex = 0;
            LoadLS();
        }

        private void LoadLS()
        {
            dgvLichSu.DataSource = db.ThuePhongs.OrderBy(p => p.ThanhToan).Select(p => new
            {
                p.CMND,
                p.HotenKH,
                p.MaPhong,
                p.Ngayden,
                p.Ngaydi,
                p.TenNV,
                p.ThanhToan
            });
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbbNgay.SelectedItem.ToString() == "Ngày nhận")
            {
                dgvLichSu.DataSource = db.ThuePhongs.Where(p => p.Ngayden.Value.Date == dtpNgay.Value.Date).Select(p => new
                {
                    p.CMND,
                    p.HotenKH,
                    p.MaPhong,
                    p.Ngayden,
                    p.Ngaydi,
                    p.TenNV,
                    p.ThanhToan
                });
            }
            else
            {
                dgvLichSu.DataSource = db.ThuePhongs.Where(p => p.Ngaydi.Value.Date == dtpNgay.Value.Date).Select(p => new
                {
                    p.CMND,
                    p.HotenKH,
                    p.MaPhong,
                    p.Ngayden,
                    p.Ngaydi,
                    p.TenNV,
                    p.ThanhToan
                });
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLS();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void btnTimKiem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTimKiem, "Tìm kiếm lịch sử");
        }
        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnRefresh, "Tải lại danh sách");
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThoat, "Trở về màn hình chính");
        }

        private void dgvLichSu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ThuePhong tk = new ThuePhong();
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr = dgvLichSu.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtCMND.Text = dgvr.Cells[0].Value.ToString();
            }
            tk = db.ThuePhongs.SingleOrDefault(p => p.CMND == txtCMND.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ThuePhong tp = db.ThuePhongs.SingleOrDefault(p => p.CMND == txtCMND.Text);
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa lịch sử của khách có CMND: " + txtCMND.Text + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                db.ThuePhongs.DeleteOnSubmit(tp);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLS();
            }
        }

        private void btnXoa_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnXoa, "Xóa lịch sử");
        }
    }
}
