namespace FigureApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Add_Button = new System.Windows.Forms.Button();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.Sort_Button = new System.Windows.Forms.Button();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.CalcSquarePerimeters = new System.Windows.Forms.Button();
            this.Figures_Grid = new System.Windows.Forms.DataGridView();
            this.Figure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Figures_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(421, 12);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(169, 32);
            this.Add_Button.TabIndex = 1;
            this.Add_Button.Text = "Добавить";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Location = new System.Drawing.Point(421, 50);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(169, 32);
            this.Edit_Button.TabIndex = 2;
            this.Edit_Button.Text = "Редактировать";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // Sort_Button
            // 
            this.Sort_Button.Location = new System.Drawing.Point(421, 88);
            this.Sort_Button.Name = "Sort_Button";
            this.Sort_Button.Size = new System.Drawing.Size(169, 32);
            this.Sort_Button.TabIndex = 3;
            this.Sort_Button.Text = "Сортировать";
            this.Sort_Button.UseVisualStyleBackColor = true;
            this.Sort_Button.Click += new System.EventHandler(this.Sort_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(421, 126);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(169, 32);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "Удалить";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // CalcSquarePerimeters
            // 
            this.CalcSquarePerimeters.Location = new System.Drawing.Point(421, 374);
            this.CalcSquarePerimeters.Name = "CalcSquarePerimeters";
            this.CalcSquarePerimeters.Size = new System.Drawing.Size(169, 32);
            this.CalcSquarePerimeters.TabIndex = 5;
            this.CalcSquarePerimeters.Text = "Периметры квадратов";
            this.CalcSquarePerimeters.UseVisualStyleBackColor = true;
            this.CalcSquarePerimeters.Click += new System.EventHandler(this.CalcSquarePerimeters_Click);
            // 
            // Figures_Grid
            // 
            this.Figures_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Figures_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Figure});
            this.Figures_Grid.Location = new System.Drawing.Point(12, 8);
            this.Figures_Grid.Name = "Figures_Grid";
            this.Figures_Grid.Size = new System.Drawing.Size(403, 398);
            this.Figures_Grid.TabIndex = 6;
            // 
            // Figure
            // 
            this.Figure.HeaderText = "Фигура";
            this.Figure.Name = "Figure";
            this.Figure.ReadOnly = true;
            this.Figure.Width = 360;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 422);
            this.Controls.Add(this.Figures_Grid);
            this.Controls.Add(this.CalcSquarePerimeters);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Sort_Button);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.Add_Button);
            this.Name = "MainForm";
            this.Text = "Фигуры";
            ((System.ComponentModel.ISupportInitialize)(this.Figures_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Sort_Button;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button CalcSquarePerimeters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Figure;
        public System.Windows.Forms.DataGridView Figures_Grid;
    }
}

