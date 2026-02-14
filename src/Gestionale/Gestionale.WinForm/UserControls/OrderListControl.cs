using Gestionale.WinForm.Models;
using Gestionale.WinForm.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gestionale.WinForm.UserControls
{
    public partial class OrderListControl : UserControl
    {
        private OrderRepository _repository;
        private List<Order> _orders;

        public event EventHandler<Order> EditOrderRequested;

        public OrderListControl()
        {
            InitializeComponent();
            _repository = new OrderRepository();
            _orders = new List<Order>();
            LoadData();
        }

        private void LoadData()
        {
            _orders.Clear();
            _orders = _repository.GetAll();
            dataGridViewOrders.DataSource = null;
            dataGridViewOrders.DataSource = _orders;
        }
        private Order GetSelectedOrder()
        {
            if (dataGridViewOrders.Rows.Count == 0)
            {
                MessageBox.Show("No no orders available.");
                return null;
            }

            if (dataGridViewOrders.CurrentRow == null)
                return null;

            return (Order)dataGridViewOrders.CurrentRow.DataBoundItem;
        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            var order = GetSelectedOrder();

            if (order == null)
            {
                MessageBox.Show($"Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var confirmResult = MessageBox.Show($"Are you sure to delete customer {order.Id}?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    _repository.Delete(order.Id);
                    LoadData();
                    MessageBox.Show("Order Deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while executing command: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var order = GetSelectedOrder();

            EditOrderRequested?.Invoke(this, order);
        }
    }
}
