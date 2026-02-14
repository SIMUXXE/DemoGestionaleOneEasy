using Gestionale.WinForm.Models;
using Gestionale.WinForm.Repositories;
using System;
using Gestionale.WinForm.Helpers;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Gestionale.WinForm.UserControls
{
    public partial class CustomerListControl : UserControl
    {
        private CustomerRepository _customerRepository;
        private List<Customer> _customers = new List<Customer>();

        public event EventHandler<Customer> EditCustomerRequested;

        public CustomerListControl()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
            LoadData();
        }

        private void LoadData()
        { 
            _customers.Clear();
            _customers = _customerRepository.GetAll();
            dataGridViewCustomers.DataSource = _customers;
        }

        private Customer GetSelectedCustomer()
        {
            if (dataGridViewCustomers.Rows.Count == 0)
            { 
                MessageBox.Show("No customers available.");
                return null;
            }

            if(dataGridViewCustomers.CurrentRow == null)
                return null;

            return (Customer)dataGridViewCustomers.CurrentRow.DataBoundItem;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var customer = GetSelectedCustomer();

            if (customer == null)
            {
                MessageBox.Show($"Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            { 
                var confirmResult = MessageBox.Show($"Are you sure to delete customer {customer.Id}?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    _customerRepository.Delete(customer.Id);
                    LoadData();
                    MessageBox.Show("Customer Deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while executing command: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var customer = GetSelectedCustomer();
            EditCustomerRequested?.Invoke(this, customer);
        }
    }
}
