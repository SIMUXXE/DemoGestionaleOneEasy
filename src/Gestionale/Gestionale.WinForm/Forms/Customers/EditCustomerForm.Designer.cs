namespace Gestionale.WinForm.Forms.Customers
{
    partial class EditCustomerForm
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
            this.tableLayoutPanelEditCustomer = new System.Windows.Forms.TableLayoutPanel();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.tableLayoutPanelEditCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelEditCustomer
            // 
            this.tableLayoutPanelEditCustomer.ColumnCount = 2;
            this.tableLayoutPanelEditCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelEditCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelEditCustomer.Controls.Add(this.labelFirstName, 0, 0);
            this.tableLayoutPanelEditCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEditCustomer.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelEditCustomer.Name = "tableLayoutPanelEditCustomer";
            this.tableLayoutPanelEditCustomer.RowCount = 4;
            this.tableLayoutPanelEditCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelEditCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelEditCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelEditCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelEditCustomer.Size = new System.Drawing.Size(1044, 606);
            this.tableLayoutPanelEditCustomer.TabIndex = 0;
            // 
            // labelFirstName
            // 
            this.labelFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(3, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(516, 185);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name";
            // 
            // EditCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 606);
            this.Controls.Add(this.tableLayoutPanelEditCustomer);
            this.Name = "EditCustomerForm";
            this.Text = "EditCustomerForm";
            this.tableLayoutPanelEditCustomer.ResumeLayout(false);
            this.tableLayoutPanelEditCustomer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEditCustomer;
        private System.Windows.Forms.Label labelFirstName;
    }
}