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
    public partial class AddStudnt : Form
    {
       
        GetData m_Get_data;
        List<model> m_Gender;
        Insert m_add;
        CheackData Ch_DD;
        public AddStudnt()
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
                if (item.type != "")
                {
                    Gender_Select.Items.Add(item.type);
                }
           }
        }

        private void BACK_BT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ADD_bt_Click(object sender, EventArgs e)
        {
            Guid Gender_guid = new Guid();
            if (Gender_Select.Text == String.Empty || name_stu.Text == string.Empty || phone_stu.Text == string.Empty)
            {
                MessageBox.Show("Error!!!", "Empty Filed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < m_Gender.Count; i++)
            {
                if (m_Gender[i].type == Gender_Select.Text)
                {
                    Gender_guid = m_Gender[i].ID;
                }
            }
            Ch_DD = new CheackData();
            if (!Ch_DD.IsNameExist(name_stu.Text))
            {
                m_add = new Insert();
                if (m_add.Insertstu(name_stu.Text, phone_stu.Text, Gender_guid))
                {
                    MessageBox.Show("ADD Done");
                }
                else
                {
                    MessageBox.Show("Error!!!", "You Can't ADD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error!!!", "The name Is exist !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
