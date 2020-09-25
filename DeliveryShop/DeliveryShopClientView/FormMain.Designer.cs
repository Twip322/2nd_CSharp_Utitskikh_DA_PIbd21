﻿namespace DeliveryShopClientView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.UpdateDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshOrderListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateDataToolStripMenuItem,
            this.CreateOrderToolStripMenuItem,
            this.RefreshOrderListToolStripMenuItem,
            this.MessagesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.menuStrip.Size = new System.Drawing.Size(1500, 37);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // UpdateDataToolStripMenuItem
            // 
            this.UpdateDataToolStripMenuItem.Name = "UpdateDataToolStripMenuItem";
            this.UpdateDataToolStripMenuItem.Size = new System.Drawing.Size(173, 29);
            this.UpdateDataToolStripMenuItem.Text = "Изменить данные";
            this.UpdateDataToolStripMenuItem.Click += new System.EventHandler(this.UpdateDataToolStripMenuItem_Click);
            // 
            // CreateOrderToolStripMenuItem
            // 
            this.CreateOrderToolStripMenuItem.Name = "CreateOrderToolStripMenuItem";
            this.CreateOrderToolStripMenuItem.Size = new System.Drawing.Size(141, 29);
            this.CreateOrderToolStripMenuItem.Text = "Создать заказ";
            this.CreateOrderToolStripMenuItem.Click += new System.EventHandler(this.CreateOrderToolStripMenuItem_Click);
            // 
            // RefreshOrderListToolStripMenuItem
            // 
            this.RefreshOrderListToolStripMenuItem.Name = "RefreshOrderListToolStripMenuItem";
            this.RefreshOrderListToolStripMenuItem.Size = new System.Drawing.Size(239, 29);
            this.RefreshOrderListToolStripMenuItem.Text = "Обновить список заказов";
            this.RefreshOrderListToolStripMenuItem.Click += new System.EventHandler(this.RefreshOrderListToolStripMenuItem_Click);
            // 
            // MessagesToolStripMenuItem
            // 
            this.MessagesToolStripMenuItem.Name = "MessagesToolStripMenuItem";
            this.MessagesToolStripMenuItem.Size = new System.Drawing.Size(124, 29);
            this.MessagesToolStripMenuItem.Text = "Сообщения";
            this.MessagesToolStripMenuItem.Click += new System.EventHandler(this.MessagesToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 37);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.Size = new System.Drawing.Size(1500, 636);
            this.dataGridView.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 673);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormMain";
            this.Text = "Форма заказов";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem UpdateDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshOrderListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MessagesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}