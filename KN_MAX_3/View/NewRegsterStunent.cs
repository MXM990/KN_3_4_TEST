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
    public partial class NewRegsterStunent : Form
    {
        MainUI m_Main;
        GetData m_Get_data;
        List<model> m_Class_choes;
        Insert m_add;
        CheackData Ch_D;
        public NewRegsterStunent()
        {
            InitializeComponent();
            FillComboBoxUi();
        }
        private void FillComboBoxUi()
        {
            m_Class_choes = new List<model>();
            m_Get_data = new GetData();
            m_Get_data.GetClass(m_Class_choes);
            foreach (var item in m_Class_choes)
            {
                Class_Select.Items.Add(item.Name);
            }
        }

        private void ADD_bt_Click(object sender, EventArgs e)
        {
            if (name_stu.Text != string.Empty && !string.IsNullOrEmpty(Class_Select.Text))
            {
                Ch_D = new CheackData();
                if (Ch_D.IsNameExist(name_stu.Text))
                {
                    Guid Class_Guid = new Guid();
                    for (int i = 0; i < m_Class_choes.Count; i++)
                    {
                        if (m_Class_choes[i].Name == Class_Select.Text)
                        {
                            Class_Guid = m_Class_choes[i].ID;
                        }
                    }
                    m_add = new Insert();
                    if (m_add.InsertStudentInClass(Class_Guid, Ch_D.m_model.ID))
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
                    MessageBox.Show("not Found User", "the user " + name_stu.Text + " is not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Fill all data", "Empty Fild ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BACK_BT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
