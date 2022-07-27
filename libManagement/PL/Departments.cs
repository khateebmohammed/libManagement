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
    public partial class Departments : Form
    {
        Business_Layer.DEPARTEMNET_CLASS dept_CLS = new Business_Layer.DEPARTEMNET_CLASS();
        string saveState;
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

        public Departments()
        {
            InitializeComponent();
            try
            {
                this.dgv_Dept_List.DataSource = dept_CLS.Bring_Lib_Dept();
                this.dgv_Dept_List.Columns[1].Visible = false;
                txt_Dept_Name.Text = dgv_Dept_List.Rows[0].Cells[2].Value.ToString();
                txt_Dept_Descript.Text = dgv_Dept_List.Rows[0].Cells[3].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Dept_Name.Text != "")
                {
                    if (saveState == "edit")
                    {
                        dept_CLS.EDIT_Dept(Convert.ToInt32(dgv_Dept_List.CurrentRow.Cells[1].Value.ToString()), txt_Dept_Name.Text
                            ,txt_Dept_Descript.Text);
                        MessageBox.Show("تمت عملية تعديل القسم بنجاح", "عملية التعديل", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        DataTable Dt = dept_CLS.Bring_Lib_Dept();
                        dgv_Dept_List.DataSource = Dt;
                        txt_Dept_Name.Text = dgv_Dept_List.Rows[0].Cells[2].Value.ToString();
                        txt_Dept_Descript.Text = dgv_Dept_List.Rows[0].Cells[3].Value.ToString();
                        txt_Dept_Name.ReadOnly = true;
                        txt_Dept_Descript.ReadOnly = true;
                        btn_Save.Enabled = false;
                        btn_Edit.Enabled = true;
                        btn_Delete.Enabled = true;
                        btn_Save.Text = "حفظ";
                    }
                    else
                    {
                        dept_CLS.ADD_Dept(txt_Dept_Name.Text, txt_Dept_Descript.Text);
                        MessageBox.Show("تمت عملية حفظ القسم بنجاح", "عملية الحفظ", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        DataTable Dt = dept_CLS.Bring_Lib_Dept();
                        dgv_Dept_List.DataSource = Dt;
                        txt_Dept_Name.Text = dgv_Dept_List.Rows[0].Cells[2].Value.ToString();
                        txt_Dept_Descript.Text = dgv_Dept_List.Rows[0].Cells[3].Value.ToString();
                        txt_Dept_Name.ReadOnly = true;
                        txt_Dept_Descript.ReadOnly = true;
                        btn_Save.Enabled = false;
                        btn_Edit.Enabled = true;
                        btn_Delete.Enabled = true;
                        btn_Save.Text = "حفظ";
                    }
                }
                else
                {
                    MessageBox.Show("يجب إدخال أسم للقسم", "تحذير", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            catch
            {
                MessageBox.Show("حصل خطأ ما ", "خطأ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                DataTable Dt = dept_CLS.Bring_Lib_Dept();
                dgv_Dept_List.DataSource = Dt;
                txt_Dept_Name.Text = dgv_Dept_List.Rows[0].Cells[2].Value.ToString();
                txt_Dept_Descript.Text = dgv_Dept_List.Rows[0].Cells[3].Value.ToString();
                txt_Dept_Name.ReadOnly = true;
                txt_Dept_Descript.ReadOnly = true;
                btn_Save.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Save.Text = "حفظ";
            }
        }

        private void Dgv_Dept_List_Click(object sender, EventArgs e)
        {
            txt_Dept_Name.Text = dgv_Dept_List.CurrentRow.Cells[2].Value.ToString();
            txt_Dept_Descript.Text = dgv_Dept_List.CurrentRow.Cells[3].Value.ToString();
            txt_Dept_Name.ReadOnly = true;
            txt_Dept_Descript.ReadOnly = true;
            btn_Save.Enabled = false;
            btn_Edit.Enabled = true;
            btn_Delete.Enabled = true;
            btn_Save.Text = "حفظ";
        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            btn_Save.Text = "حفظ";
            saveState = "save";
            btn_Save.Enabled = true;
            btn_Edit.Enabled = false;
            btn_Delete.Enabled = false;
            txt_Dept_Name.Clear();
            txt_Dept_Descript.Clear();
            txt_Dept_Name.ReadOnly = false;
            txt_Dept_Descript.ReadOnly = false;
            txt_Dept_Name.Focus();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل أنت متأكد من حذف القسم المحدد؟!!", "عملية الحذف", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    dept_CLS.DELETE_Dept(Convert.ToInt32(dgv_Dept_List.CurrentRow.Cells[1].Value.ToString()));
                    MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DataTable Dt = dept_CLS.Bring_Lib_Dept();
                    dgv_Dept_List.DataSource = Dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("هناك خطأ في عملية الحذف ", "خطأ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                DataTable Dt = dept_CLS.Bring_Lib_Dept();
                dgv_Dept_List.DataSource = Dt;
            }
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
           
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            btn_New.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_New.Width, btn_New.Height, 30, 30));
            btn_Save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 30, 30));
            btn_Delete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Delete.Width, btn_Delete.Height, 30, 30));
            btn_Edit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Edit.Width, btn_Edit.Height, 30, 30));

        }

        private void Btn_Edit_Click_1(object sender, EventArgs e)
        {
            txt_Dept_Name.ReadOnly = false;
            txt_Dept_Descript.ReadOnly = false;
            txt_Dept_Name.Focus();
            btn_Save.Enabled = true;
            btn_Save.Text = "حفظ التعديل";
            saveState = "edit";
            btn_Delete.Enabled = false;
        }
        mainPage.mainpage ob = new mainPage.mainpage();
        private void Button1_Click(object sender, EventArgs e)
        {
        }
    }
}
