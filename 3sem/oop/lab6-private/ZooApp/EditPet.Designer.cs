﻿namespace ZooApp
{
    partial class EditPet
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
            this.editButton = new System.Windows.Forms.Button();
            this.houseBox = new System.Windows.Forms.ComboBox();
            this.skinBox = new System.Windows.Forms.ComboBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(12, 245);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(252, 38);
            this.editButton.TabIndex = 17;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // houseBox
            // 
            this.houseBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.houseBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.houseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.houseBox.FormattingEnabled = true;
            this.houseBox.Items.AddRange(new object[] {
            "домик",
            "клетка",
            "террариум",
            "нет"});
            this.houseBox.Location = new System.Drawing.Point(12, 194);
            this.houseBox.Name = "houseBox";
            this.houseBox.Size = new System.Drawing.Size(252, 28);
            this.houseBox.TabIndex = 16;
            // 
            // skinBox
            // 
            this.skinBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.skinBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.skinBox.FormattingEnabled = true;
            this.skinBox.Items.AddRange(new object[] {
            "шерсть",
            "оперение",
            "чешуя"});
            this.skinBox.Location = new System.Drawing.Point(12, 140);
            this.skinBox.Name = "skinBox";
            this.skinBox.Size = new System.Drawing.Size(252, 28);
            this.skinBox.TabIndex = 15;
            // 
            // typeBox
            // 
            this.typeBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "кошка",
            "собака",
            "попугай",
            "сова",
            "ящерица",
            "черепаха"});
            this.typeBox.Location = new System.Drawing.Point(12, 86);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(252, 28);
            this.typeBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Жильё";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Кожн. покров";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Вид";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(12, 34);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(252, 26);
            this.nameBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Имя";
            // 
            // EditPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 304);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.houseBox);
            this.Controls.Add(this.skinBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Name = "EditPet";
            this.Text = "Редактировать";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ComboBox houseBox;
        private System.Windows.Forms.ComboBox skinBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
    }
}