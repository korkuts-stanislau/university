namespace FigureApp
{
    partial class EditSquare
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
            this.Coordinates = new System.Windows.Forms.TextBox();
            this.offsetY = new System.Windows.Forms.TextBox();
            this.offsetX = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Coordinates
            // 
            this.Coordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Coordinates.Location = new System.Drawing.Point(12, 12);
            this.Coordinates.Name = "Coordinates";
            this.Coordinates.ReadOnly = true;
            this.Coordinates.Size = new System.Drawing.Size(189, 26);
            this.Coordinates.TabIndex = 0;
            // 
            // offsetY
            // 
            this.offsetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.offsetY.Location = new System.Drawing.Point(112, 69);
            this.offsetY.Name = "offsetY";
            this.offsetY.Size = new System.Drawing.Size(89, 26);
            this.offsetY.TabIndex = 7;
            // 
            // offsetX
            // 
            this.offsetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.offsetX.Location = new System.Drawing.Point(14, 69);
            this.offsetX.Name = "offsetX";
            this.offsetX.Size = new System.Drawing.Size(89, 26);
            this.offsetX.TabIndex = 6;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(12, 101);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(189, 36);
            this.EditButton.TabIndex = 5;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите смещение X, Y";
            // 
            // EditSquare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 150);
            this.Controls.Add(this.offsetY);
            this.Controls.Add(this.offsetX);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Coordinates);
            this.Name = "EditSquare";
            this.Text = "Изменить квадрат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Coordinates;
        private System.Windows.Forms.TextBox offsetY;
        private System.Windows.Forms.TextBox offsetX;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label label1;
    }
}