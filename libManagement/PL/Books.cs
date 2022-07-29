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
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PL.Lib_Content fn = new Lib_Content();
            fn.ShowDialog();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            PL.Lib_Content fn = new Lib_Content();
            fn.ShowDialog();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            btn_add_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_add_content.Width, btn_add_content.Height,15,15));
            btn_Delete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Delete.Width, btn_Delete.Height, 15,15));
            btn_Edit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Edit.Width, btn_Edit.Height, 15,15));
        }
    }
}
