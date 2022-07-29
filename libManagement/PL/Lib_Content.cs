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
    public partial class Lib_Content : Form
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
        public Lib_Content()
        {
            InitializeComponent();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lib_Content_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 40, 40));
            button10.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button10.Width, button10.Height, 10, 10));
            btn_New.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_New.Width, btn_New.Height, 30, 30));
            btn_Save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 30, 30));

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
