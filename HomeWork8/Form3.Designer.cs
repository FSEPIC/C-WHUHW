namespace _2020_4_6_one
{
    partial class Form3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userlabel = new System.Windows.Forms.Label();
            this.orderidlabel = new System.Windows.Forms.Label();
            this.ordertime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.orderitemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderitemnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderitempriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderitemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalmoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 234);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ordertime);
            this.panel2.Controls.Add(this.orderidlabel);
            this.panel2.Controls.Add(this.userlabel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 137);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(348, 234);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 137);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderitemidDataGridViewTextBoxColumn,
            this.orderitemnumDataGridViewTextBoxColumn,
            this.orderitempriceDataGridViewTextBoxColumn,
            this.orderitemnameDataGridViewTextBoxColumn,
            this.totalmoneyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.orderItemBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(539, 234);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "保存更改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前订单信息";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "订单ID:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "订单时间：";
            // 
            // userlabel
            // 
            this.userlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.userlabel.AutoSize = true;
            this.userlabel.Location = new System.Drawing.Point(208, 47);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(41, 12);
            this.userlabel.TabIndex = 4;
            this.userlabel.Text = "111111";
            // 
            // orderidlabel
            // 
            this.orderidlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.orderidlabel.AutoSize = true;
            this.orderidlabel.Location = new System.Drawing.Point(210, 77);
            this.orderidlabel.Name = "orderidlabel";
            this.orderidlabel.Size = new System.Drawing.Size(35, 12);
            this.orderidlabel.TabIndex = 5;
            this.orderidlabel.Text = "11111";
            // 
            // ordertime
            // 
            this.ordertime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ordertime.AutoSize = true;
            this.ordertime.Location = new System.Drawing.Point(210, 107);
            this.ordertime.Name = "ordertime";
            this.ordertime.Size = new System.Drawing.Size(41, 12);
            this.ordertime.TabIndex = 6;
            this.ordertime.Text = "111111";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "注:双击想要修改的数据修改";
            // 
            // orderitemidDataGridViewTextBoxColumn
            // 
            this.orderitemidDataGridViewTextBoxColumn.DataPropertyName = "orderitemid";
            this.orderitemidDataGridViewTextBoxColumn.HeaderText = "orderitemid";
            this.orderitemidDataGridViewTextBoxColumn.Name = "orderitemidDataGridViewTextBoxColumn";
            this.orderitemidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderitemnumDataGridViewTextBoxColumn
            // 
            this.orderitemnumDataGridViewTextBoxColumn.DataPropertyName = "orderitemnum";
            this.orderitemnumDataGridViewTextBoxColumn.HeaderText = "orderitemnum";
            this.orderitemnumDataGridViewTextBoxColumn.Name = "orderitemnumDataGridViewTextBoxColumn";
            this.orderitemnumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderitempriceDataGridViewTextBoxColumn
            // 
            this.orderitempriceDataGridViewTextBoxColumn.DataPropertyName = "orderitemprice";
            this.orderitempriceDataGridViewTextBoxColumn.HeaderText = "orderitemprice";
            this.orderitempriceDataGridViewTextBoxColumn.Name = "orderitempriceDataGridViewTextBoxColumn";
            this.orderitempriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderitemnameDataGridViewTextBoxColumn
            // 
            this.orderitemnameDataGridViewTextBoxColumn.DataPropertyName = "orderitemname";
            this.orderitemnameDataGridViewTextBoxColumn.HeaderText = "orderitemname";
            this.orderitemnameDataGridViewTextBoxColumn.Name = "orderitemnameDataGridViewTextBoxColumn";
            this.orderitemnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalmoneyDataGridViewTextBoxColumn
            // 
            this.totalmoneyDataGridViewTextBoxColumn.DataPropertyName = "totalmoney";
            this.totalmoneyDataGridViewTextBoxColumn.HeaderText = "totalmoney";
            this.totalmoneyDataGridViewTextBoxColumn.Name = "totalmoneyDataGridViewTextBoxColumn";
            this.totalmoneyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderItemBindingSource
            // 
            this.orderItemBindingSource.DataSource = typeof(order.OrderItem);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 371);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderitemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderitemnumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderitempriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderitemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalmoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource orderItemBindingSource;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ordertime;
        private System.Windows.Forms.Label orderidlabel;
        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}