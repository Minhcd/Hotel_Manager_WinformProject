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
    public partial class DoanhThu : MaterialForm
    {
        public DoanhThu()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        QLKSDataContext db = new QLKSDataContext();
        private void DoanhThu_Load(object sender, EventArgs e)
        {
            LoadDSDT();
        }

        private void LoadDSDT()
        {
            dgvDoanhThu.DataSource = db.ThuNhaps.OrderBy(p => p.MaTN).Select(p => new {
                p.MaTN,
                p.CMND,
                p.TenKH,
                p.Ngayden,
                p.Ngaydi,
                p.TienTT
            });
        }

        private void btnThongKeTheoNgay_Click(object sender, EventArgs e)
        {
            dgvDoanhThu.DataSource = db.ThuNhaps.OrderBy(p => p.MaTN).Where(p => p.Ngaydi.Value >= dtpNgay1.Value && p.Ngaydi.Value <= dtpNgay2.Value).Select(p => new
            {
                p.MaTN,
                p.CMND,
                p.TenKH,
                p.Ngayden,
                p.Ngaydi,
                p.TienTT
            });
            int shd = dgvDoanhThu.Rows.Count;
            lblSoHoaDon.Text = shd.ToString();
            double thanhtien = 0;
            for (int i = 0; i < dgvDoanhThu.Rows.Count; ++i)
            {
                thanhtien += Convert.ToDouble(dgvDoanhThu.Rows[i].Cells[5].Value);
            }
            lblSoThuNhap.Text = thanhtien.ToString() + " VNĐ";
        }

        private void btnThongKeTatCa_Click(object sender, EventArgs e)
        {
            LoadDSDT();
            int shd = dgvDoanhThu.Rows.Count;
            lblSoHoaDon.Text = shd.ToString();
            double thanhtien = 0;
            for (int i = 0; i < dgvDoanhThu.Rows.Count; ++i)
            {
                thanhtien += Convert.ToDouble(dgvDoanhThu.Rows[i].Cells[5].Value);
            }
            lblSoThuNhap.Text = thanhtien.ToString() + " VNĐ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void btnThongKeTheoNgay_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThongKeTheoNgay, "Thống kê theo ngày");
        }

        private void btnThongKeTatCa_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThongKeTatCa, "Thống kê tất cả");
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThoat, "Trở về màn hình chính");
        }

        private void btnBieuDo_Click_1(object sender, EventArgs e)
        {
            BieuDoThongKe bd = new BieuDoThongKe();
            bd.ShowDialog();
        }

        private void btnBieuDo_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnBieuDo, "Xem biểu đồ thống kê");
        }
    }
}
