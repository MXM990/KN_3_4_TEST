using KN_MAX_3.Contol;
using KN_MAX_3.SQL;
using KN_MAX_3.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KN_MAX_3
{
    public partial class MainUI : Form
    {

        public MainUI()
        {
            InitializeComponent();
        }
        private void ADD_ST_bt_Click(object sender, EventArgs e)
        {
            new AddStudnt().ShowDialog();
        }

        private void ADD_GR_BT_Click(object sender, EventArgs e)
        {
            new AddGender().ShowDialog();
        }

        private void ADD_CL_BT_Click(object sender, EventArgs e)
        {
            new add_Class().ShowDialog();
        }

        private void ADD_TECH_BT_Click(object sender, EventArgs e)
        {
            new ADD__Tech().ShowDialog();
        }
        private void EXIT_BT_Click(object sender, EventArgs e)
        {
            DialogResult end = MessageBox.Show("You Want Exit", "Make Suer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (end == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void Test_bt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SQL_DO_IT.Sql_conn))
            {
                SQL_DO_IT.Conntion_now();
                SQL_DO_IT.GetCon();
            }

            if (SQL_DO_IT.OpenConntion())
            {
                MessageBox.Show($"تم الاتصال بنجاح!\nحالة الاتصال: {SQL_DO_IT.CON_all.State}", "اختبار الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQL_DO_IT.CloseConntion();
            }
            else
            {
                MessageBox.Show("فشل الاتصال بقاعدة البيانات!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reg_bt_Click(object sender, EventArgs e)
        {
            new Regster_UI().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Create_DB_UI().ShowDialog();
        }
    }
}
