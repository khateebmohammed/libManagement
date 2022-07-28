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
    public partial class Lib_Content : Form
    {
        public Lib_Content()
        {
            InitializeComponent();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            PL.Books fn = new PL.Books();
            fn.ShowDialog();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {

            PL.Books fn = new PL.Books();
            fn.ShowDialog();
        
    }
    }
}
