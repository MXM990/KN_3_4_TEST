using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KN_MAX_3.SQL;

namespace KN_MAX_3
{
    public partial class AddGender : Form
    {
        Insert m_add;
        MainUI m_Main;
        public AddGender()
        {
            InitializeComponent();
        }

        private void ADD_bt_Click(object sender, EventArgs e)
        {
            m_add = new Insert();
            if (m_add.InsertGender(name_gr.Text))
            {
                MessageBox.Show("ADD Done");
            }
            else
            {
                MessageBox.Show("Error!!!" , "You Can't ADD" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BACK_BT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
