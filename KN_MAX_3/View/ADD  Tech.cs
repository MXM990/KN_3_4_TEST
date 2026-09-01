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
    public partial class ADD__Tech : Form
    {
        MainUI m_Main;
        GetData m_Get_data;
        List<model> m_Gender;
        Insert m_add;

        public ADD__Tech()
        {
            InitializeComponent();
            FillComboBoxUi();
        }
        private void FillComboBoxUi()
        {
            m_Gender = new List<model>();
            m_Get_data = new GetData();
            m_Get_data.GetGender(m_Gender);
            foreach (var item in m_Gender)
            {
                Gender_Select.Items.Add(item.type);
            }
        }
        private void ADD_bt_Click(object sender, EventArgs e)
        {
            m_add = new Insert();
            if (!m_add.InsertTech(name_th.Text, phone_th.Text, Gender_Select.Text))
            {
                MessageBox.Show("ADD Done");
            }
            else
            {
                MessageBox.Show("Error!!!", "You Can't ADD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BACK_BT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
