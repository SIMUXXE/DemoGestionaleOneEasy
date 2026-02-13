using Gestionale.WinForm.Models;
using Gestionale.WinForm.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionale.WinForm.UserControls
{
    public partial class CreateUserControl : UserControl
    {
        private CustomerRepository _customerRepository;
        public CreateUserControl()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (IsFormValid() == true)
            {
                try
                {
                    Customer customer = new Customer();
                    customer.FirstName = textBoxFirstName.Text;
                    customer.LastName = textBoxLastName.Text;
                    customer.Email = textBoxEmail.Text;
                    _customerRepository.Create(customer);
                    MessageBox.Show("Customer registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while executing command: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || !textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("A valid Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }   

        private void ClearForm()
        {
            textBoxFirstName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
        }
    }
}
