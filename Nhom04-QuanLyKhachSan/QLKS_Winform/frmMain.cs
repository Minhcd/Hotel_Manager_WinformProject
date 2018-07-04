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
using System.Security.Cryptography;

namespace QLKS_Winform
{
    public partial class frmMain : MaterialForm
    {
        public frmMain()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        QLKSDataContext db = new QLKSDataContext();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát khỏi hệ thống?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                Close();
            }
        }

        public static TaiKhoanNV NV = new TaiKhoanNV();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string id = txtDangNhap.Text;
            string pwd = MD5Hash(txtMatKhau.Text);
            TaiKhoanNV nv = db.TaiKhoanNVs.Where(p => p.Account == id).SingleOrDefault();
            if (nv == null)
            {
                MessageBox.Show("Tài khoản không tồn tại! Vui lòng nhập lại.");
                txtDangNhap.Clear();
                txtMatKhau.Clear();
            }
            else
            {
                if (MD5Hash(nv.Pass) == pwd)
                {
                    MessageBox.Show("Xin chào " + nv.TenND.ToString() + ". Bạn đã đăng nhập thành công");
                    menuStrip1.Visible = true;
                    if (nv.ChucVu == "Quản lý")
                    {
                        quảnLýTàiKhoảnToolStripMenuItem.Visible = true;
                        doanhThuToolStripMenuItem.Visible = true;
                        danhSáchPhòngToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
                        doanhThuToolStripMenuItem.Visible = false;
                        danhSáchPhòngToolStripMenuItem.Visible = false;
                    }
                    panel1.Visible = false;
                    panel2.Visible = false;
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác! Vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK);
                    txtMatKhau.Clear();
                }
            }
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
          if (MessageBox.Show("Bạn có thực sự muốn đăng xuất và thoát khỏi hệ thống?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
          {
            Close();
          }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn đăng xuất khỏi hệ thống?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                menuStrip1.Visible = false;
                panel1.Visible = true;
                panel2.Visible = true;
                txtDangNhap.Clear();
                txtMatKhau.Clear();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QL_TaiKhoanNV qltk = new QL_TaiKhoanNV();
            qltk.ShowDialog();
        }

        private void cbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLKhachHang qlkh = new QLKhachHang();
            qlkh.ShowDialog();
        }

        private void danhSáchPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QL_Phong qlp = new QL_Phong();
            qlp.ShowDialog();
        }

        private void danhSáchDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QL_DichVu dv = new QL_DichVu();
            dv.ShowDialog();
        }

        private void thuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDatPhong dp = new FrmDatPhong();
            dp.ShowDialog();
        }

        private void lịchSửĐặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LichSu ls = new LichSu();
            ls.ShowDialog();
        }

        private void sửDụngDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuDungDV sd = new SuDungDV();
            sd.ShowDialog();
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraPhong tp = new TraPhong();
            tp.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinPhanMem tt = new ThongTinPhanMem();
            tt.ShowDialog();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanhThu dt = new DoanhThu();
            dt.ShowDialog();
        }

        private void ẩnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void hiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn đăng xuất và thoát khỏi hệ thống?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
