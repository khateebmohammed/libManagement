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

namespace libManagement
{
    public partial class Form1 : Form
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



        public Form1()
        {
            InitializeComponent();
            //  this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.notifyIcon1.Icon = this.Icon;
            this.notifyIcon1.BalloonTipText = "Welcome back";
            this.notifyIcon1.BalloonTipTitle = "Sign In";
            this.notifyIcon1.ShowBalloonTip(5);


        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {





        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_Login.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Login.Width,btn_Login.Height, 30, 30));

        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Login.ForeColor = Color.Snow;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            btn_Login.ForeColor = Color.Indigo;

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {
            
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            mainPage.create_account fn = new mainPage.create_account();
            fn.ShowDialog();
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            DataTable Dt = Log_Class.LOGIN(txt_User_ID.Text, txt_User_PWD.Text);
            try
            {
                if (Dt.Rows.Count > 0)
                {
                   // MessageBox.Show("تم تسجيل دخولك بنجاح", "تأكيد تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainPage.mainpage fn = new mainPage.mainpage();
                    this.Hide();
                    fn.Show();
                  
                }
                else
                {
                    MessageBox.Show("أسم المستخدم أو كلمة المرور غير صحيحة أعد المحاولة!", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_User_ID.Focus();
                }
            }
            catch
            {
                MessageBox.Show("حدث خطأ ما", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void CB_showPWD_CheckedChanged(object sender, EventArgs e)
        {
           
        }
     
        private void Pb_showPWD_Click(object sender, EventArgs e)
        {
            if (txt_User_PWD.PasswordChar == '*')
            {
                txt_User_PWD.PasswordChar = txt_User_ID.PasswordChar;
            }
            else
            {
                txt_User_PWD.PasswordChar = '*';
            }
        }
    }
}
