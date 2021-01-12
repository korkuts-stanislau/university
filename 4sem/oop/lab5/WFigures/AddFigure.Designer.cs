namespace WFigures
{
    partial class AddFigure
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
            this.colorBox = new System.Windows.Forms.ComboBox();
            this.figureBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.verticesBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radiusBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цвет";
            // 
            // colorBox
            // 
            this.colorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorBox.FormattingEnabled = true;
            this.colorBox.Location = new System.Drawing.Point(86, 42);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(168, 24);
            this.colorBox.TabIndex = 1;
            // 
            // figureBox
            // 
            this.figureBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.figureBox.FormattingEnabled = true;
            this.figureBox.Items.AddRange(new object[] {
            "Circle",
            "Star",
            "Rectangle"});
            this.figureBox.Location = new System.Drawing.Point(86, 12);
            this.figureBox.Name = "figureBox";
            this.figureBox.Size = new System.Drawing.Size(168, 24);
            this.figureBox.TabIndex = 3;
            this.figureBox.SelectedIndexChanged += new System.EventHandler(this.figureBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фигура";
            // 
            // verticesBox
            // 
            this.verticesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.verticesBox.Location = new System.Drawing.Point(86, 102);
            this.verticesBox.Name = "verticesBox";
            this.verticesBox.ReadOnly = true;
            this.verticesBox.Size = new System.Drawing.Size(168, 24);
            this.verticesBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Вершины";
            // 
            // radiusBox
            // 
            this.radiusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radiusBox.Location = new System.Drawing.Point(86, 72);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.ReadOnly = true;
            this.radiusBox.Size = new System.Drawing.Size(168, 24);
            this.radiusBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Радиус";
            // 
            // widthBox
            // 
            this.widthBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widthBox.Location = new System.Drawing.Point(86, 162);
            this.widthBox.Name = "widthBox";
            this.widthBox.ReadOnly = true;
            this.widthBox.Size = new System.Drawing.Size(168, 24);
            this.widthBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ширина";
            // 
            // heightBox
            // 
            this.heightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heightBox.Location = new System.Drawing.Point(86, 132);
            this.heightBox.Name = "heightBox";
            this.heightBox.ReadOnly = true;
            this.heightBox.Size = new System.Drawing.Size(168, 24);
            this.heightBox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Высота";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(15, 201);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(239, 38);
            this.addButton.TabIndex = 16;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddFigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 249);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.verticesBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radiusBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.figureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.label1);
            this.Name = "AddFigure";
            this.Text = "AddFigure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox colorBox;
        private System.Windows.Forms.ComboBox figureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox verticesBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox radiusBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addButton;
    }
}