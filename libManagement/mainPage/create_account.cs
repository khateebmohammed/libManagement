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
    public partial class create_account : Form
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
        public create_account()
        {
            InitializeComponent();
            cmb_User_Type.SelectedIndex = 1;
        }

        private void Create_account_Load(object sender, EventArgs e)
        {
            btn_Create_User.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Create_User.Width, btn_Create_User.Height, 30, 30));

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_User_PWD.Text == txt_Conf_User_PWD.Text)
                {
                    if (txt_User_ID.Text != "" && txt_User_PWD.Text != "")
                    {
                        Log_Class.ADD_System_User(txt_User_ID.Text, txt_User_PWD.Text, cmb_User_Type.SelectedItem.ToString());
                        MessageBox.Show("تم إضافة حساب جديد بنجاح", "تأكيد إضافة الحساب", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_User_ID.Clear();
                        txt_User_PWD.Clear();
                        txt_Conf_User_PWD.Clear();
                        cmb_User_Type.SelectedIndex = 1;
                        txt_User_ID.Focus();
                    }
                    else
                    {
                        MessageBox.Show("يجب تعبئة جميع الحقول", "خطأ في إنشاء حساب جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_User_ID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("كلمات المرور غير متطابقة!", "خطأ في كلمة المرور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Conf_User_PWD.Focus();
                }
            }
            catch
            {
                MessageBox.Show("حدث خطأ ما", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
