using Gestionale.WinForm.Models;
using Gestionale.WinForm.Repositories;
using System;
using System.Windows.Forms;

namespace Gestionale.WinForm.UserControls
{
    public partial class CustomerEditForm : UserControl
    {
        private CustomerRepository _customerRepository;
        private Helpers.Uitls.Operations _operation;
        private Customer _customerToEdit;
        public CustomerEditForm(Helpers.Uitls.Operations operation, Customer customerToEdit = null)
        {
            InitializeComponent();

            _customerRepository = new CustomerRepository();

            if (customerToEdit != null)
                _customerToEdit = customerToEdit;

            _operation = operation;
            switch (_operation)
            {
                case Helpers.Uitls.Operations.Create:
                    labelTitle.Text = "Create New Customer";
                    textBoxEmail.Text = string.Empty;
                    textBoxFirstName.Text = string.Empty;
                    textBoxLastName.Text = string.Empty;
                    buttonClear.Enabled = true;
                    break;
                case Helpers.Uitls.Operations.Edit:
                    labelTitle.Text = "Edit Customer";
                    textBoxEmail.Text = _customerToEdit.Email;
                    textBoxFirstName.Text = _customerToEdit.FirstName;
                    textBoxLastName.Text = _customerToEdit.LastName;
                    buttonClear.Enabled = false;
                    break;
                default:
                    throw new ArgumentException("Invalid operation type");
            }

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
            if (!IsFormValid())
                return;

            switch (_operation)
            {
                case Helpers.Uitls.Operations.Create:
                    CreateCustomer();
                    break;
                case Helpers.Uitls.Operations.Edit:
                    EditCustomer();
                    break;
                default:
                    return;
            }
        }

        private void CreateCustomer()
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

        private void EditCustomer()
        {
            try
            {
                if (!textBoxFirstName.Text.Equals(_customerToEdit.FirstName))
                    _customerToEdit.FirstName = textBoxFirstName.Text;

                if (!textBoxLastName.Text.Equals(_customerToEdit.LastName))
                    _customerToEdit.LastName = textBoxLastName.Text;

                if (!textBoxEmail.Text.Equals(_customerToEdit.Email))
                    _customerToEdit.Email = textBoxEmail.Text;

                _customerRepository.Update(_customerToEdit);
                MessageBox.Show("Customer Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while executing command: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
