using Gestionale.WinForm.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionale.WinForm
{
    public partial class MainForm : Form
    {
        // User Controls
        private CustomerListControl _customerListControl;

        public MainForm()
        {
            InitializeComponent();
        }

        // Navigation Method
        private void LoadControl(UserControl control)
        {
            pnlContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
        }


        private void buttonCustomerList_Click_1(object sender, EventArgs e)
        {
            if (_customerListControl == null)
                _customerListControl = new CustomerListControl();

            LoadControl(_customerListControl);

        }
    }
}
