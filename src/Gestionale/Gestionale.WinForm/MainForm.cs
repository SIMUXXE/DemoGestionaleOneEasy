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
        private CustomerEditForm _createUserControl;
        private CustomerEditForm _editUserControl;

        private OrderListControl _orderListControl;
        private OrderEditForm _createOrderControl;
        private OrderEditForm _editOrderControl;
        public MainForm()
        {
            InitializeComponent();
        }

        // Navigation Method
        private void LoadControl(UserControl control)
        {
            pnlContent.Controls.Clear();

            if (control is CustomerListControl customerList)
                customerList.EditCustomerRequested += Control_EditCustomerRequested;

            if(control is OrderListControl orderList)
                orderList.EditOrderRequested += OrderList_EditOrderRequested;

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
                _createUserControl = new CustomerEditForm(Helpers.Uitls.Operations.Create);

            LoadControl(_createUserControl);
        }

        private void Control_EditCustomerRequested(object sender, Customer customer)
        {
            if(_editUserControl == null)
                _editUserControl = new CustomerEditForm(Helpers.Uitls.Operations.Edit, customer);
            LoadControl(_editUserControl);
        }

        private void OrderList_EditOrderRequested(object sender, Order order)
        {
            if(_editOrderControl == null)
                _editOrderControl = new OrderEditForm(Helpers.Uitls.Operations.Edit, order);

            LoadControl(_editOrderControl);
        }

        private void buttonOrderList_Click(object sender, EventArgs e)
        {
            if(_orderListControl == null)
                _orderListControl = new OrderListControl();

            LoadControl(_orderListControl);
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            if(_createOrderControl == null)
                _createOrderControl = new OrderEditForm(Helpers.Uitls.Operations.Create);

            LoadControl(_createOrderControl);
        }
    }
}
