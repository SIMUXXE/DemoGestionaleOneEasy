namespace Gestionale.WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.buttonCreateCustomer = new System.Windows.Forms.Button();
            this.buttonCustomerList = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonOrderList = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlSidebar.Controls.Add(this.buttonOrderList);
            this.pnlSidebar.Controls.Add(this.buttonCreateOrder);
            this.pnlSidebar.Controls.Add(this.buttonCustomerList);
            this.pnlSidebar.Controls.Add(this.buttonCreateCustomer);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(160, 450);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(160, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(640, 450);
            this.pnlContent.TabIndex = 1;
            // 
            // buttonCreateCustomer
            // 
            this.buttonCreateCustomer.AutoSize = true;
            this.buttonCreateCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreateCustomer.Location = new System.Drawing.Point(0, 0);
            this.buttonCreateCustomer.Name = "buttonCreateCustomer";
            this.buttonCreateCustomer.Size = new System.Drawing.Size(160, 40);
            this.buttonCreateCustomer.TabIndex = 0;
            this.buttonCreateCustomer.Text = "CreateCustomer";
            this.buttonCreateCustomer.UseVisualStyleBackColor = true;
            // 
            // buttonCustomerList
            // 
            this.buttonCustomerList.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCustomerList.Location = new System.Drawing.Point(0, 40);
            this.buttonCustomerList.Name = "buttonCustomerList";
            this.buttonCustomerList.Size = new System.Drawing.Size(160, 40);
            this.buttonCustomerList.TabIndex = 1;
            this.buttonCustomerList.Text = "Customer List";
            this.buttonCustomerList.UseVisualStyleBackColor = true;
            this.buttonCustomerList.Click += new System.EventHandler(this.buttonCustomerList_Click_1);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreateOrder.Location = new System.Drawing.Point(0, 80);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(160, 40);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Create Order";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            // 
            // buttonOrderList
            // 
            this.buttonOrderList.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOrderList.Location = new System.Drawing.Point(0, 120);
            this.buttonOrderList.Name = "buttonOrderList";
            this.buttonOrderList.Size = new System.Drawing.Size(160, 40);
            this.buttonOrderList.TabIndex = 3;
            this.buttonOrderList.Text = "OrderList";
            this.buttonOrderList.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button buttonOrderList;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonCustomerList;
        private System.Windows.Forms.Button buttonCreateCustomer;
    }
}