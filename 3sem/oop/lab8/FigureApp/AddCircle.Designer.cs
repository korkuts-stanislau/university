namespace FigureApp
{
    partial class AddCircle
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
            this.label1 = new System.Windows.Forms.Label();
            this.Coord_X = new System.Windows.Forms.TextBox();
            this.Coord_Y = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Radius = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Colors_Box = new System.Windows.Forms.ComboBox();
            this.Add_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Координата X";
            // 
            // Coord_X
            // 
            this.Coord_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Coord_X.Location = new System.Drawing.Point(135, 6);
            this.Coord_X.Name = "Coord_X";
            this.Coord_X.Size = new System.Drawing.Size(108, 26);
            this.Coord_X.TabIndex = 1;
            // 
            // Coord_Y
            // 
            this.Coord_Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Coord_Y.Location = new System.Drawing.Point(135, 41);
            this.Coord_Y.Name = "Coord_Y";
            this.Coord_Y.Size = new System.Drawing.Size(108, 26);
            this.Coord_Y.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Координата Y";
            // 
            // Radius
            // 
            this.Radius.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Radius.Location = new System.Drawing.Point(81, 77);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(162, 26);
            this.Radius.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Радиус";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Цвет";
            // 
            // Colors_Box
            // 
            this.Colors_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Colors_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Colors_Box.FormattingEnabled = true;
            this.Colors_Box.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Brown",
            "Blue",
            "Gray",
            "Yellow",
            "Black"});
            this.Colors_Box.Location = new System.Drawing.Point(81, 113);
            this.Colors_Box.Name = "Colors_Box";
            this.Colors_Box.Size = new System.Drawing.Size(162, 28);
            this.Colors_Box.TabIndex = 7;
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(16, 152);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(227, 37);
            this.Add_Button.TabIndex = 8;
            this.Add_Button.Text = "Добавить";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // AddCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 201);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.Colors_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Radius);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Coord_Y);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Coord_X);
            this.Controls.Add(this.label1);
            this.Name = "AddCircle";
            this.Text = "Добавить окружность";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Coord_X;
        private System.Windows.Forms.TextBox Coord_Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Radius;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Colors_Box;
        private System.Windows.Forms.Button Add_Button;
    }
}