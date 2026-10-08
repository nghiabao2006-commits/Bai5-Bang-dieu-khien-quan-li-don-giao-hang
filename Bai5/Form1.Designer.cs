namespace Bai5
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabControlLeft = new System.Windows.Forms.TabControl();
            this.tabPageCustomer = new System.Windows.Forms.TabPage();
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.tabPageShipping = new System.Windows.Forms.TabPage();
            this.groupBoxShipping = new System.Windows.Forms.GroupBox();
            this.comboShipping = new System.Windows.Forms.ComboBox();
            this.labelShipping = new System.Windows.Forms.Label();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTotalQty = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTotalWeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTotalAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlLeft.SuspendLayout();
            this.tabPageCustomer.SuspendLayout();
            this.groupBoxCustomer.SuspendLayout();
            this.tabPageShipping.SuspendLayout();
            this.groupBoxShipping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabControlLeft);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.dataGridViewItems);
            this.splitContainerMain.Size = new System.Drawing.Size(800, 428);
            this.splitContainerMain.SplitterDistance = 260;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tabControlLeft
            // 
            this.tabControlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLeft.Controls.Add(this.tabPageCustomer);
            this.tabControlLeft.Controls.Add(this.tabPageShipping);
            this.tabControlLeft.Location = new System.Drawing.Point(0, 0);
            this.tabControlLeft.Name = "tabControlLeft";
            this.tabControlLeft.SelectedIndex = 0;
            this.tabControlLeft.Size = new System.Drawing.Size(260, 428);
            this.tabControlLeft.TabIndex = 0;
            // 
            // tabPageCustomer
            // 
            this.tabPageCustomer.Controls.Add(this.groupBoxCustomer);
            this.tabPageCustomer.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustomer.Name = "tabPageCustomer";
            this.tabPageCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomer.Size = new System.Drawing.Size(252, 402);
            this.tabPageCustomer.TabIndex = 0;
            this.tabPageCustomer.Text = "Khách hàng";
            this.tabPageCustomer.UseVisualStyleBackColor = true;
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Controls.Add(this.txtCustomer);
            this.groupBoxCustomer.Controls.Add(this.labelCustomer);
            this.groupBoxCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCustomer.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Size = new System.Drawing.Size(246, 100);
            this.groupBoxCustomer.TabIndex = 0;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Thông tin khách hàng";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(9, 40);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(228, 20);
            this.txtCustomer.TabIndex = 1;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(6, 24);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(92, 13);
            this.labelCustomer.TabIndex = 0;
            this.labelCustomer.Text = "Tên khách hàng:";
            // 
            // tabPageShipping
            // 
            this.tabPageShipping.Controls.Add(this.groupBoxShipping);
            this.tabPageShipping.Location = new System.Drawing.Point(4, 22);
            this.tabPageShipping.Name = "tabPageShipping";
            this.tabPageShipping.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShipping.Size = new System.Drawing.Size(252, 402);
            this.tabPageShipping.TabIndex = 1;
            this.tabPageShipping.Text = "Vận chuyển";
            this.tabPageShipping.UseVisualStyleBackColor = true;
            // 
            // groupBoxShipping
            // 
            this.groupBoxShipping.Controls.Add(this.comboShipping);
            this.groupBoxShipping.Controls.Add(this.labelShipping);
            this.groupBoxShipping.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxShipping.Location = new System.Drawing.Point(3, 3);
            this.groupBoxShipping.Name = "groupBoxShipping";
            this.groupBoxShipping.Size = new System.Drawing.Size(246, 100);
            this.groupBoxShipping.TabIndex = 0;
            this.groupBoxShipping.TabStop = false;
            this.groupBoxShipping.Text = "Loại vận chuyển";
            // 
            // comboShipping
            // 
            this.comboShipping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboShipping.FormattingEnabled = true;
            this.comboShipping.Items.AddRange(new object[] {
            "Tiêu chuẩn",
            "Nhanh",
            "Qua đêm"});
            this.comboShipping.Location = new System.Drawing.Point(9, 40);
            this.comboShipping.Name = "comboShipping";
            this.comboShipping.Size = new System.Drawing.Size(228, 21);
            this.comboShipping.TabIndex = 1;
            // 
            // labelShipping
            // 
            this.labelShipping.AutoSize = true;
            this.labelShipping.Location = new System.Drawing.Point(6, 24);
            this.labelShipping.Name = "labelShipping";
            this.labelShipping.Size = new System.Drawing.Size(84, 13);
            this.labelShipping.TabIndex = 0;
            this.labelShipping.Text = "Loại vận chuyển:";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = true;
            this.dataGridViewItems.AllowUserToDeleteRows = true;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemName,
            this.colQuantity,
            this.colWeight,
            this.colUnitPrice,
            this.colTotal});
            this.dataGridViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewItems.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.Size = new System.Drawing.Size(536, 428);
            this.dataGridViewItems.TabIndex = 0;
            // 
            // colItemName
            // 
            this.colItemName.HeaderText = "Tên hàng";
            this.colItemName.Name = "colItemName";
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Số lượng";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 80;
            // 
            // colWeight
            // 
            this.colWeight.HeaderText = "Trọng lượng (kg)";
            this.colWeight.Name = "colWeight";
            this.colWeight.Width = 80;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.HeaderText = "Đơn giá";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 90;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Thành tiền";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 110;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusTime,
            this.toolStripStatusTotalQty,
            this.toolStripStatusTotalWeight,
            this.toolStripStatusTotalAmount});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusTime
            // 
            this.toolStripStatusTime.Name = "toolStripStatusTime";
            this.toolStripStatusTime.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusTime.Text = "Thời gian: --/--/---- --:--:--";
            // 
            // toolStripStatusTotalQty
            // 
            this.toolStripStatusTotalQty.Name = "toolStripStatusTotalQty";
            this.toolStripStatusTotalQty.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusTotalQty.Text = "Tổng SL: 0";
            // 
            // toolStripStatusTotalWeight
            // 
            this.toolStripStatusTotalWeight.Name = "toolStripStatusTotalWeight";
            this.toolStripStatusTotalWeight.Size = new System.Drawing.Size(125, 17);
            this.toolStripStatusTotalWeight.Text = "Tổng trọng lượng: 0.00 kg";
            // 
            // toolStripStatusTotalAmount
            // 
            this.toolStripStatusTotalAmount.Name = "toolStripStatusTotalAmount";
            this.toolStripStatusTotalAmount.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusTotalAmount.Text = "Tổng tiền: 0.00";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStrip);
            this.Name = "Form1";
            this.Text = "Bảng Quản lý Đơn giao hàng";
            this.KeyPreview = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControlLeft.ResumeLayout(false);
            this.tabPageCustomer.ResumeLayout(false);
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBoxCustomer.PerformLayout();
            this.tabPageShipping.ResumeLayout(false);
            this.groupBoxShipping.ResumeLayout(false);
            this.groupBoxShipping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabControlLeft;
        private System.Windows.Forms.TabPage tabPageCustomer;
        private System.Windows.Forms.TabPage tabPageShipping;
        private System.Windows.Forms.GroupBox groupBoxCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.GroupBox groupBoxShipping;
        private System.Windows.Forms.ComboBox comboShipping;
        private System.Windows.Forms.Label labelShipping;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTotalQty;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTotalWeight;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTotalAmount;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Timer timerClock;
    }
}

