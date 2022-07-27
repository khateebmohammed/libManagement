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
    public partial class Shilfs : Form
    {
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




        public Shilfs()
        {
            InitializeComponent();
        }

        private void Btn_New_Click(object sender, EventArgs e)
        {

        }

        private void Shilfs_Load(object sender, EventArgs e)
        {
            btn_New.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_New.Width, btn_New.Height, 30, 30));
            btn_Save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 30, 30));
            btn_Delete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Delete.Width, btn_Delete.Height, 30, 30));
            btn_Edit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Edit.Width, btn_Edit.Height, 30, 30));
        }
    }
}
