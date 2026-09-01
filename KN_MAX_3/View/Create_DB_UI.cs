using KN_MAX_3.Contol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KN_MAX_3.View
{
    public partial class Create_DB_UI : Form
    {
        public Create_DB_UI()
        {
            InitializeComponent();
        }

        private void ADD_bt_Click(object sender, EventArgs e)
        {
            if (DatabaseInitializer.CreateFullStructure(name_db.Text))
            {
                MessageBox.Show("Create Done ✅" , "Sucssies" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Create Erorr ❎", "filed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BACK_BT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
