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
    public partial class Regster_techer : Form
    {
        GetData m_Get_data;
        List<model> m_Class_choes;
        Insert m_add;
        public Regster_techer()
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

            m_add = new Insert();
            Guid Class_Guid = new Guid();
            for (int i = 0; i < m_Class_choes.Count; i++)
            {
                if (m_Class_choes[i].Name == Class_Select.Text)
                {
                    Class_Guid = m_Class_choes[i].ID;
                }
            }
            if (m_add.insertTehcNew(Class_Guid, name_tech.Text))
            {
                MessageBox.Show("add is done", "sound good", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("add is not done", "sound bad", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void BACK_BT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
