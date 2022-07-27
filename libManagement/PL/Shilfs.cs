using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libManagement.PL
{
    public partial class Shilfs : Form
    {
        Business_Layer.DEPARTEMNET_CLASS dept_CLS = new Business_Layer.DEPARTEMNET_CLASS();
        public Shilfs()
        {
            InitializeComponent();
            try
            {
                Initial();
            }
            catch
            {
                return;
            }
        }
        string saveState;
        public void Initial()
        {
            this.dgv_Shelf_List.DataSource = dept_CLS.Bring_Shilf();
            this.dgv_Shelf_List.Columns[1].Visible = false;
            txt_Shilf_Code.Text = dgv_Shelf_List.Rows[0].Cells[2].Value.ToString();
            DataTable Dt = dept_CLS.Bring_Depts_by_shelf_ID(Convert.ToInt32(dgv_Shelf_List.Rows[0].Cells[1].Value.ToString()));
            cmb_Depts.ValueMember = "Dept_ID";
            cmb_Depts.DisplayMember = "Dept_name";
            cmb_Depts.DataSource = Dt;
            cmb_Depts.Enabled = false;
            txt_Shilf_Descript.Text = dgv_Shelf_List.Rows[0].Cells[4].Value.ToString();
        }
        private void Btn_New_Click(object sender, EventArgs e)
        {
            cmb_Depts.Enabled = true;
            DataTable Dt = dept_CLS.Bring_Depts_for_shelfs();
            cmb_Depts.ValueMember = "Dept_ID";
            cmb_Depts.DisplayMember = "Dept_Name";
            cmb_Depts.DataSource = Dt;
            btn_Save.Text = "حفظ";
            saveState = "save";
            btn_Save.Enabled = true;
            btn_Edit.Enabled = false;
            btn_Delete.Enabled = false;
            txt_Shilf_Code.Clear();
            txt_Shilf_Descript.Clear();
            txt_Shilf_Code.ReadOnly = false;
            txt_Shilf_Descript.ReadOnly = false;
            txt_Shilf_Code.Focus();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل أنت متأكد من حذف الرف المحدد مع جميع مقتنياته؟!!", "عملية الحذف", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    dept_CLS.DELETE_Shelf(Convert.ToInt32(dgv_Shelf_List.CurrentRow.Cells[1].Value.ToString()));
                    MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Initial();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("هناك خطأ في عملية الحذف", "خطأ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                Initial();
            }
        }

        private void Dgv_Shelf_List_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Shilf_Code.Text = dgv_Shelf_List.CurrentRow.Cells[2].Value.ToString();
                txt_Shilf_Descript.Text = dgv_Shelf_List.CurrentRow.Cells[4].Value.ToString();
                txt_Shilf_Code.ReadOnly = true;
                txt_Shilf_Descript.ReadOnly = true;
                DataTable Dt = dept_CLS.Bring_Depts_by_shelf_ID(Convert.ToInt32(dgv_Shelf_List.CurrentRow.Cells[1].Value.ToString()));
                cmb_Depts.ValueMember = "Dept_ID";
                cmb_Depts.DisplayMember = "Dept_name";
                cmb_Depts.DataSource = Dt;
                cmb_Depts.Enabled = false;
                btn_Save.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Save.Text = "حفظ";
            }
            catch
            {
                return;
            }
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            cmb_Depts.Enabled = true;
            DataTable Dt = dept_CLS.Bring_Depts_for_shelfs();
            cmb_Depts.ValueMember = "Dept_ID";
            cmb_Depts.DisplayMember = "Dept_name";
            cmb_Depts.DataSource = Dt;
            txt_Shilf_Code.ReadOnly = false;
            txt_Shilf_Descript.ReadOnly = false;
            txt_Shilf_Code.Focus();
            btn_Save.Enabled = true;
            btn_Save.Text = "حفظ التعديل";
            saveState = "edit";
            btn_Delete.Enabled = false;
        }

        private void Dgv_Shelf_List_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Shilf_Code.Text != "" && txt_Shilf_Descript.Text!="")
                {
                    if (saveState == "edit")
                    {
                        dept_CLS.EDIT_Shelf(Convert.ToInt32(dgv_Shelf_List.CurrentRow.Cells[1].Value.ToString()),txt_Shilf_Code.Text,
                            txt_Shilf_Descript.Text,Convert.ToInt32(cmb_Depts.SelectedValue.ToString()));
                        MessageBox.Show("تمت عملية تعديل الرف بنجاح", "عملية التعديل", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        Initial();
                        txt_Shilf_Code.ReadOnly = true;
                        txt_Shilf_Descript.ReadOnly = true;
                        btn_Save.Enabled = false;
                        btn_Edit.Enabled = true;
                        btn_Delete.Enabled = true;
                        btn_Save.Text = "حفظ";
                    }
                    else
                    {
                        dept_CLS.ADD_Shelf(txt_Shilf_Code.Text, txt_Shilf_Descript.Text,
                                        Convert.ToInt32(cmb_Depts.SelectedValue.ToString()));
                        MessageBox.Show("تمت عملية حفظ الرف بنجاح", "عملية الحفظ", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        Initial();
                        txt_Shilf_Code.ReadOnly = true;
                        txt_Shilf_Descript.ReadOnly = true;
                        btn_Save.Enabled = false;
                        btn_Edit.Enabled = true;
                        btn_Delete.Enabled = true;
                        btn_Save.Text = "حفظ";
                    }
                }
                else
                {
                    MessageBox.Show("يجب إدخال كود الرف ووصفه", "تحذير", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            catch
            {
                MessageBox.Show("حصل خطأ ما ", "خطأ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                Initial();
                txt_Shilf_Code.ReadOnly = true;
                txt_Shilf_Descript.ReadOnly = true;
                btn_Save.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Save.Text = "حفظ";
            }
        }
    }
}
