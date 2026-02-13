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

namespace Gestionale.WinForm.Forms
{
    public partial class CustomerForm : Form
    {
        private CustomerRepository _customerRepository;
        private List<Customer> customers = new List<Customer>();
        public CustomerForm()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dataGridViewCustomers.DataSource = null;
                dataGridViewCustomers.DataSource = _customerRepository.GetAll();
            }
            catch (Exception ex)
            {
                var errorMessage = string.Concat(ex.Message, ex.InnerException.Message);
                MessageBox.Show(errorMessage);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
