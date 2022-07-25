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

namespace libManagement.mainPage
{
    public partial class mainpage : Form
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


        public mainpage()
        {
            InitializeComponent();
        }

        private void Mainpage_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 20, 20));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 40, 40));
            panel6.Region = panel5.Region;

            foreach (Control item in panel3.Controls)
            {
                item.Region = button1.Region;
            }
        }



        private Form activeform = null;
        private void openchildform(Form childform)
        {
            if (activeform != null)
            {
                activeform.Close();
            }

            panel4.Controls.Clear();


            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel4.Controls.Add(childform);
            panel4.Tag = childform;
            childform.Show();







        }


        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.MediumSlateBlue;
            button1.ForeColor = Color.Snow;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Lavender;
            button1.ForeColor = Color.DarkGray;
        }

        private void Button2_MouseMove(object sender, MouseEventArgs e)
        {

            button2.BackColor = Color.MediumSlateBlue;
            button2.ForeColor = Color.Snow;
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Lavender;
            button2.ForeColor = Color.DarkGray;
        }

        private void Button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.MediumSlateBlue;
            button3.ForeColor = Color.Snow;
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Lavender;
            button3.ForeColor = Color.DarkGray;
        }

        private void Button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.MediumSlateBlue;
            button4.ForeColor = Color.Snow;
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Lavender;
            button4.ForeColor = Color.DarkGray;

        }

        private void Button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.MediumSlateBlue;
            button5.ForeColor = Color.Snow;
        }

        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Lavender;
            button5.ForeColor = Color.DarkGray;
        }

        private void Button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.MediumSlateBlue;
            button6.ForeColor = Color.Snow;
        }

        private void Button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Lavender;
            button6.ForeColor = Color.DarkGray;
        }

        private void Button7_MouseMove(object sender, MouseEventArgs e)
        {
            button7.BackColor = Color.MediumSlateBlue;
            button7.ForeColor = Color.Snow;
        }

        private void Button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.Lavender;
            button7.ForeColor = Color.DarkGray;
        }

        private void Button8_MouseMove(object sender, MouseEventArgs e)
        {
            button8.BackColor = Color.MediumSlateBlue;
            button8.ForeColor = Color.Snow;
        }

        private void Button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Lavender;
            button8.ForeColor = Color.DarkGray;
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

