using System.Data;
using Microsoft.Data.SqlClient;

namespace SGBD_Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewParent = new DataGridView();
            dataGridViewChild = new DataGridView();
            deleteButton = new Button();
            label4 = new Label();
            label5 = new Label();
            updateButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChild).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewParent
            // 
            dataGridViewParent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewParent.Location = new Point(27, 40);
            dataGridViewParent.Name = "dataGridViewParent";
            dataGridViewParent.RowHeadersWidth = 51;
            dataGridViewParent.Size = new Size(433, 214);
            dataGridViewParent.TabIndex = 0;
            // 
            // dataGridViewChild
            // 
            dataGridViewChild.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChild.Location = new Point(27, 304);
            dataGridViewChild.Name = "dataGridViewChild";
            dataGridViewChild.RowHeadersWidth = 51;
            dataGridViewChild.Size = new Size(634, 214);
            dataGridViewChild.TabIndex = 10;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(497, 162);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(164, 92);
            deleteButton.TabIndex = 12;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(27, 273);
            label4.Name = "label4";
            label4.Size = new Size(86, 28);
            label4.TabIndex = 15;
            label4.Text = childTable.ToUpper();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(27, 9);
            label5.Name = "label5";
            label5.Size = new Size(291, 28);
            label5.TabIndex = 16;
            label5.Text = parentTable.ToUpper();
            // 
            // updateButton
            // 
            updateButton.Location = new Point(497, 40);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(164, 94);
            updateButton.TabIndex = 17;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 548);
            Controls.Add(updateButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(deleteButton);
            Controls.Add(dataGridViewChild);
            Controls.Add(dataGridViewParent);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewParent).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChild).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewParent;
        private DataGridView dataGridViewChild;
        private Button deleteButton;
        private Label label4;
        private Label label5;
        private Button updateButton;
    }
}
