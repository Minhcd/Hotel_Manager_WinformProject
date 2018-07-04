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
    public partial class TraPhong : MaterialForm
    {
        public static double tongtienDV = 0;
        public static double tongtien = 0;
        public TraPhong()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        QLKSDataContext db = new QLKSDataContext();
        private void TraPhong_Load(object sender, EventArgs e)
        {
            LoadDST();
            LoadSDDV();
        }

        private void LoadDST()
        {
            dgvPhongThue.DataSource = db.ThuePhongs.OrderBy(p => p.MaPhong).Where(p => p.ThanhToan == "Chưa thanh toán").Select(p => new
            {
                p.CMND,
                p.HotenKH,
                p.MaPhong,
                p.GiaPhong,
                p.Ngayden,
                p.Ngaydi,
                p.ThanhToan
            });
        }

        private void LoadSDDV()
        {
            dgvSDDV.DataSource = db.SDDVPhongs.OrderBy(p => p.MaPhong).Select(p => new
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

        private void dgvPhongThue_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            ThuePhong ph = new ThuePhong();
            dgvr = dgvPhongThue.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtCMND.Text = dgvr.Cells[0].Value.ToString();
                txtHoTen.Text = dgvr.Cells[1].Value.ToString();
                txtMaPhong.Text = dgvr.Cells[2].Value.ToString();
                txtGiaPhong.Text = dgvr.Cells[3].Value.ToString() + " VNĐ";
                dtpNgayden.Value = DateTime.Parse(dgvr.Cells[4].Value.ToString());

                TimeSpan c = DateTime.Now.Subtract(dtpNgayden.Value);
                PhongK pk = new PhongK();
                pk = db.PhongKs.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text);
                double ThanhTien = c.Days * pk.GiaPhong + c.Hours * (pk.GiaPhong / 8);
                txtTongTien.Text = ThanhTien.ToString() + " VNĐ";
                tongtien = ThanhTien;
            }
            ph = db.ThuePhongs.SingleOrDefault(p => p.CMND == txtCMND.Text.Trim());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTKCMND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập CMND!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvPhongThue.DataSource = db.ThuePhongs.OrderBy(p => p.MaPhong).Where(p => p.CMND.Contains(txtTKCMND.Text)).Select(p => new {
                    p.CMND,
                    p.HotenKH,
                    p.MaPhong,
                    p.GiaPhong,
                    p.Ngayden,
                    p.Ngaydi,
                    p.ThanhToan
                });

                dgvSDDV.DataSource = db.SDDVPhongs.OrderBy(p => p.MaPhong).Where(p => p.CMND.Contains(txtTKCMND.Text)).Select(p => new {
                    p.CMND,
                    p.MaPhong,
                    p.MaDV,
                    p.TenDV,
                    p.SoLuong,
                    p.NgaySD,
                    p.TongTienDV,
                    p.ThanhToan
                });

                
                for (int i = 0; i < dgvSDDV.Rows.Count; ++i)
                {
                    tongtienDV += Convert.ToDouble(dgvSDDV.Rows[i].Cells[6].Value);
                }
                txtTTDV.Text = tongtienDV.ToString() + " VNĐ";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDST();
            LoadSDDV();
            txtTTDV.Text = "0 VNĐ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Close();
        }

        private void btnTraP_Click(object sender, EventArgs e)
        {
            ThuePhong tp = db.ThuePhongs.SingleOrDefault(p => p.CMND == txtCMND.Text);
            SDDVPhong sd = db.SDDVPhongs.FirstOrDefault(p => p.CMND == txtCMND.Text);
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thanh toán cho khách hàng " + tp.HotenKH, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tp != null && dr == DialogResult.OK)
            {
                tp.Ngaydi = DateTime.Now;
                tp.ThanhToan = "Đã thanh toán";
                sd.ThanhToan = "Đã thanh toán";
                PhongK ph = db.PhongKs.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text.Trim());
                ph.TinhTrang = "Trống";
                ThemDT();
                db.SubmitChanges();
                LoadDST();
                MessageBox.Show("Bạn đã thanh toán thành công mã phòng " + tp.MaPhong + " của khách hàng " + tp.HotenKH + " vào lúc " + DateTime.Now + " .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThemDT()
        {
            ThuNhap tn = new ThuNhap
            {
                CMND = txtCMND.Text,
                TenKH = txtHoTen.Text,
                Ngayden = dtpNgayden.Value,
                Ngaydi = DateTime.Now,
                TienTT = tongtienDV + tongtien
            };
            db.ThuNhaps.InsertOnSubmit(tn);
        }

        private void btnTimKiem_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTimKiem, "Tìm kiếm");
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnRefresh, "Tải lại danh sách");
        }

        private void btnTraP_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnTraP, "Thanh toán phòng");
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnThoat, "Trở về màn hình chính");
        }
    }
}
