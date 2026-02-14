using Gestionale.WinForm.Helpers;
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
    public partial class CreateOrderControl : UserControl
    {
        private OrderRepository _orderRepository;
        private Helpers.Uitls.Operations _operation;
        private Order _orderToEdit;


        public CreateOrderControl(Uitls.Operations operation, Order orderToEdit = null)
        {
            InitializeComponent();

            _orderRepository = new OrderRepository();

            if (orderToEdit != null)
                _orderToEdit = orderToEdit;

            _operation = operation;
            switch (_operation)
            {
                case Helpers.Uitls.Operations.Create:
                    labelTitle.Text = "Create New Order";
                    textBoxTotalAmount.Text = string.Empty;
                    textBoxCustomerId.Text = string.Empty;
                    textBoxCustomerId.Enabled = true; 
                    labelDateValue.Text = DateTime.UtcNow.ToShortDateString();
                    break;
                case Helpers.Uitls.Operations.Edit:
                    labelTitle.Text = "Edit Order";
                    textBoxTotalAmount.Text = _orderToEdit.TotalAmount.ToString();
                    textBoxCustomerId.Text = _orderToEdit.CustomerId.ToString();
                    textBoxCustomerId.Enabled = false; // CustomerId should not be editable
                    labelDateValue.Text = _orderToEdit.OrderDate.ToShortDateString();
                    break;
                default:
                    throw new ArgumentException("Invalid operation type");
            }

        }

        private void ClearForm()
        {
            textBoxTotalAmount.Text = string.Empty;
            textBoxCustomerId.Text = string.Empty;
            labelDateValue.Text = DateTime.UtcNow.ToShortDateString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void CreateOrder()
        {
            try
            {
                Order order = new Order();
                order.Id = Guid.NewGuid();
                order.OrderDate = DateTime.UtcNow;
                order.CustomerId = Guid.Parse(textBoxCustomerId.Text);
                order.TotalAmount = decimal.Parse(textBoxTotalAmount.Text);

                _orderRepository.Create(order);
                MessageBox.Show("Order registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while executing command: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateOrder()
        {
            try
            {
                var amounToEdit = decimal.Parse(textBoxTotalAmount.Text);
                if (amounToEdit != _orderToEdit.TotalAmount)
                    _orderToEdit.TotalAmount = amounToEdit;

                _orderRepository.Update(_orderToEdit);
                MessageBox.Show("Order Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while executing command: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxTotalAmount.Text) || !decimal.TryParse(textBoxTotalAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid total amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxCustomerId.Text) || !Guid.TryParse(textBoxCustomerId.Text, out _))
            {
                MessageBox.Show("Please enter a valid customer ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
                return;

            switch (_operation)
            {
                case Helpers.Uitls.Operations.Create:
                    CreateOrder();
                    break;
                case Helpers.Uitls.Operations.Edit:
                    UpdateOrder();
                    break;
                default:
                    return;
            }

        }
    }
}
