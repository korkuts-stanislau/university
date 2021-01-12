namespace FigureApp
{
    partial class EditCircle
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
            this.EditButton = new System.Windows.Forms.Button();
            this.offsetX = new System.Windows.Forms.TextBox();
            this.offsetY = new System.Windows.Forms.TextBox();
            this.CircleInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите смещение X, Y";
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(14, 105);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(190, 37);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // offsetX
            // 
            this.offsetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.offsetX.Location = new System.Drawing.Point(16, 73);
            this.offsetX.Name = "offsetX";
            this.offsetX.Size = new System.Drawing.Size(90, 26);
            this.offsetX.TabIndex = 2;
            // 
            // offsetY
            // 
            this.offsetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.offsetY.Location = new System.Drawing.Point(114, 73);
            this.offsetY.Name = "offsetY";
            this.offsetY.Size = new System.Drawing.Size(90, 26);
            this.offsetY.TabIndex = 3;
            // 
            // CircleInfo
            // 
            this.CircleInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CircleInfo.Location = new System.Drawing.Point(16, 12);
            this.CircleInfo.Name = "CircleInfo";
            this.CircleInfo.ReadOnly = true;
            this.CircleInfo.Size = new System.Drawing.Size(188, 26);
            this.CircleInfo.TabIndex = 4;
            // 
            // EditCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 158);
            this.Controls.Add(this.CircleInfo);
            this.Controls.Add(this.offsetY);
            this.Controls.Add(this.offsetX);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.label1);
            this.Name = "EditCircle";
            this.Text = "Изменить окружность";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.TextBox offsetX;
        private System.Windows.Forms.TextBox offsetY;
        private System.Windows.Forms.TextBox CircleInfo;
    }
}