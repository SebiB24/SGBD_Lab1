﻿using System.Data;
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
            textBoxAdr = new TextBox();
            textBoxSup = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            label4 = new Label();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
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
            // textBoxAdr
            // 
            textBoxAdr.Location = new Point(691, 336);
            textBoxAdr.Name = "textBoxAdr";
            textBoxAdr.Size = new Size(187, 27);
            textBoxAdr.TabIndex = 1;
            // 
            // textBoxSup
            // 
            textBoxSup.Location = new Point(691, 403);
            textBoxSup.Name = "textBoxSup";
            textBoxSup.Size = new Size(187, 27);
            textBoxSup.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(691, 313);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 5;
            label1.Text = "Adresa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(691, 449);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 6;
            label2.Text = "Data deschidere";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(691, 380);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 13;
            label3.Text = "Suprafata ";
            // 
            // addButton
            // 
            addButton.Location = new Point(497, 64);
            addButton.Name = "addButton";
            addButton.Size = new Size(381, 45);
            addButton.TabIndex = 9;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(497, 126);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(381, 45);
            updateButton.TabIndex = 11;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(497, 187);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(381, 45);
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
            label4.Text = "LOCATII";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(27, 9);
            label5.Name = "label5";
            label5.Size = new Size(291, 28);
            label5.TabIndex = 16;
            label5.Text = "LANTURI DE SALI DE FITNESS";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(691, 472);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(187, 27);
            dateTimePicker1.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 548);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxSup);
            Controls.Add(label3);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(dataGridViewChild);
            Controls.Add(addButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxAdr);
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
        private TextBox textBoxAdr;
        private Label label1;
        private Label label2;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Label label3;
        private TextBox textBoxSup;
        private Label label4;
        private Label label5;
        private DateTimePicker dateTimePicker1;
    }
}
