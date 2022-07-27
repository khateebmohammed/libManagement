using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libManagement.PL
{
    public partial class Books : Form
    {
        Business_Layer.LOGIN_CLASS Log_Class = new Business_Layer.LOGIN_CLASS();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );
        public Books()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            btn_Save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 30, 30));
            btn_Delete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 30, 30));
            btn_Edit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 30, 30));
            btn_New.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 30, 30));

        }
    }
}
