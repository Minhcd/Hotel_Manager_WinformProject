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
    public partial class BieuDoThongKe : MaterialForm
    {
        public BieuDoThongKe()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                QLKSDataContext db = new QLKSDataContext();
                chartThongKe.DataSource = db.ThuNhaps.ToList();
                chartThongKe.Series["VNĐ"].XValueMember = "Ngaydi";
                chartThongKe.Series["VNĐ"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                chartThongKe.Series["VNĐ"].YValueMembers = "TienTT";
                chartThongKe.Series["VNĐ"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnLoad, "Hiển thị biểu đồ");
        }
    }
}
