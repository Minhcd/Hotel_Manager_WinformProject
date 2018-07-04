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
    public partial class FrmDatPhong : MaterialForm
    {
        
        public FrmDatPhong()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        QLKSDataContext db = new QLKSDataContext();
        private void FrmDatPhong_Load(object sender, EventArgs e)
        {
            cbbLoaiPhong.SelectedIndex = 0;
            cbbGioiTinh.SelectedIndex = 0;
            LoadDSPT();
            dgvPhongTrong.ReadOnly = true;
        }
        private void LoadDSPT()
        {
            dgvPhongTrong.DataSource = db.PhongKs.Where(p => p.TinhTrang == "Trống").Select(p => new
            {
                p.MaPhong,
                p.TenPhong,
                p.LoaiPhong,
                p.GiaPhong,
            });
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvPhongTrong.DataSource = db.PhongKs.Where(p => p.TinhTrang == "Trống" && p.LoaiPhong == cbbLoaiPhong.SelectedItem.ToString()).Select(p => new
            {
                p.MaPhong,
                p.TenPhong,
                p.LoaiPhong,
                p.GiaPhong,
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDSPT();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = new KhachHang
                {
                    HoTen = txtHoTen.Text,
                    DiaChi = txtDiaChi.Text,
                    CMND = txtCMND.Text,
                    SDT = txtSDT.Text,
                    GioiTinh = cbbGioiTinh.SelectedItem.ToString(),
                    ThanhToan = "Chưa thanh toán"
                };

                PhongK ph = db.PhongKs.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text.Trim());

                ThuePhong tp = new ThuePhong
                {
                    TenNV = txtTenNV.Text,
                    CMND = txtCMND.Text,
                    Ngayden = dtpNgayNhan.Value,
                    Ngaydi = null,
                    GiaPhong = ph.GiaPhong,
                    ThanhToan = "Chưa thanh toán",  
                    MaPhong = txtMaPhong.Text,
                    HotenKH = txtHoTen.Text
                };

                if (txtSDT.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || txtCMND.Text == "" || db.KhachHangs.Where(p => p.CMND == kh.CMND).SingleOrDefault() != null)
                {
                    MessageBox.Show("Một số thông tin nhập còn thiếu hoặc CMND bị trùng. Xin kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ph.TinhTrang = "Có khách";
                    db.ThuePhongs.InsertOnSubmit(tp);
                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    LoadDSPT();
                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHoTen.Clear();
                    txtCMND.Clear();
                    txtDiaChi.Clear();
                    txtSDT.Clear();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu! Xin vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhongTrong_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            PhongK ph = new PhongK();
            dgvr = dgvPhongTrong.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtMaPhong.Text = dgvr.Cells[0].Value.ToString();
                cbbLoaiPhong.Text = dgvr.Cells[2].Value.ToString();
            }
            ph = db.PhongKs.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text.Trim());
        }

        private void btnDatPhong_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnDatPhong, "Đặt phòng");
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThoat, "Trở về màn hình chính");
        }
    }
}
