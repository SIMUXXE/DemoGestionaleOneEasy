using Gestionale.WinForm.Helpers;
using Gestionale.WinForm.Models;
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
        private CreateCustomerControl _createUserControl;
        private CreateCustomerControl _editUserControl;
        public MainForm()
        {
            InitializeComponent();
        }

        // Navigation Method
        private void LoadControl(UserControl control)
        {
            pnlContent.Controls.Clear();

            if (control is CustomerListControl customerList)
            {
                customerList.EditCustomerRequested += Control_EditCustomerRequested;
            }

            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
        }


        private void buttonCustomerList_Click_1(object sender, EventArgs e)
        {
            if (_customerListControl == null)
                _customerListControl = new CustomerListControl();

            LoadControl(_customerListControl);

        }

        private void buttonCreateCustomer_Click(object sender, EventArgs e)
        {
            if (_createUserControl == null)
                _createUserControl = new CreateCustomerControl(Helpers.Uitls.Operations.Create);

            LoadControl(_createUserControl);
        }

        private void Control_EditCustomerRequested(object sender, Customer customer)
        {
            if(_editUserControl == null)
                _editUserControl = new CreateCustomerControl(Helpers.Uitls.Operations.Edit, customer);
            LoadControl(_editUserControl);
        }

    }
}
