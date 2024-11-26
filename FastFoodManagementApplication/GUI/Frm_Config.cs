using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_Config : Form
    {
        public Frm_Config()
        {
            InitializeComponent();
            cmbServerName.DropDown += CmbServerName_DropDown;
            cmbDBName.DropDown += CmbDBName_DropDown;
            btnSaveConfig.Click += BtnSaveConfig_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txbUsername.Clear();
            txbPassword.Clear();
            cmbServerName.Focus();
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            LoginHelper.ChangeConnectionString(cmbServerName.SelectedItem.ToString(), 
                cmbDBName.SelectedItem.ToString(), txbUsername.Text.Trim(), txbPassword.Text.Trim());
            this.Close();
        }

        private void CmbDBName_DropDown(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbPassword.Text.Trim();
            if (username.Length > 0 && password.Length > 0)
            {
                cmbDBName.Items.Clear();
                List<string> _list = LoginHelper.GetDatabaseName(cmbServerName.SelectedItem.ToString(),
                                                            username, password);
                if (_list == null)
                {
                    MessageBox.Show("Configuration information is not accurate", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (string item in _list)
                {
                    cmbDBName.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Please enter full username and password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void CmbServerName_DropDown(object sender, EventArgs e)
        {
            DataTable dt = LoginHelper.GetServerName();
            
            cmbServerName.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    cmbServerName.Items.Add(row[col]);
                }
            }
        }
    }
}
