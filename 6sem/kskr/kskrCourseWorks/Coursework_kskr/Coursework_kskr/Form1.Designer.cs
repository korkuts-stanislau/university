namespace Coursework_kskr
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.buttonGrid = new System.Windows.Forms.Button();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.textBoxThickness = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPoissonsRatio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxElasticModulus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxForce = new System.Windows.Forms.TextBox();
            this.radioButtonStress = new System.Windows.Forms.RadioButton();
            this.radioButtonDeformationY = new System.Windows.Forms.RadioButton();
            this.radioButtonDeformationX = new System.Windows.Forms.RadioButton();
            this.radioButtonDeformation = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelStresOk = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelStress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelMaxDeformationY = new System.Windows.Forms.Label();
            this.labelMaxDeformationX = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Длина детали, м.:";
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(167, 24);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(97, 20);
            this.textBoxLength.TabIndex = 9;
            this.textBoxLength.Text = "0,1";
            // 
            // buttonGrid
            // 
            this.buttonGrid.Location = new System.Drawing.Point(12, 397);
            this.buttonGrid.Name = "buttonGrid";
            this.buttonGrid.Size = new System.Drawing.Size(148, 23);
            this.buttonGrid.TabIndex = 13;
            this.buttonGrid.Text = "Отобразить сетку";
            this.buttonGrid.UseVisualStyleBackColor = true;
            this.buttonGrid.Click += new System.EventHandler(this.buttonGrid_Click);
            // 
            // buttonSolve
            // 
            this.buttonSolve.Enabled = false;
            this.buttonSolve.Location = new System.Drawing.Point(516, 397);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(118, 23);
            this.buttonSolve.TabIndex = 14;
            this.buttonSolve.Text = "Получить результат";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // textBoxThickness
            // 
            this.textBoxThickness.Location = new System.Drawing.Point(167, 50);
            this.textBoxThickness.Name = "textBoxThickness";
            this.textBoxThickness.Size = new System.Drawing.Size(97, 20);
            this.textBoxThickness.TabIndex = 16;
            this.textBoxThickness.Text = "0,01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Толщина детали, м.:";
            // 
            // textBoxPoissonsRatio
            // 
            this.textBoxPoissonsRatio.Location = new System.Drawing.Point(167, 128);
            this.textBoxPoissonsRatio.Name = "textBoxPoissonsRatio";
            this.textBoxPoissonsRatio.Size = new System.Drawing.Size(97, 20);
            this.textBoxPoissonsRatio.TabIndex = 20;
            this.textBoxPoissonsRatio.Text = "0,28";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Коэффициент Пуассона";
            // 
            // textBoxElasticModulus
            // 
            this.textBoxElasticModulus.Location = new System.Drawing.Point(167, 102);
            this.textBoxElasticModulus.Name = "textBoxElasticModulus";
            this.textBoxElasticModulus.Size = new System.Drawing.Size(97, 20);
            this.textBoxElasticModulus.TabIndex = 18;
            this.textBoxElasticModulus.Text = "210E9";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Модуль упругости, Па.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Сила, Н.:";
            // 
            // textBoxForce
            // 
            this.textBoxForce.Location = new System.Drawing.Point(167, 76);
            this.textBoxForce.Name = "textBoxForce";
            this.textBoxForce.Size = new System.Drawing.Size(97, 20);
            this.textBoxForce.TabIndex = 18;
            this.textBoxForce.Text = "700";
            // 
            // radioButtonStress
            // 
            this.radioButtonStress.AutoSize = true;
            this.radioButtonStress.Enabled = false;
            this.radioButtonStress.Location = new System.Drawing.Point(652, 374);
            this.radioButtonStress.Name = "radioButtonStress";
            this.radioButtonStress.Size = new System.Drawing.Size(89, 17);
            this.radioButtonStress.TabIndex = 4;
            this.radioButtonStress.TabStop = true;
            this.radioButtonStress.Text = "Напряжение";
            this.radioButtonStress.UseVisualStyleBackColor = true;
            this.radioButtonStress.CheckedChanged += new System.EventHandler(this.radioButtonStress_CheckedChanged);
            // 
            // radioButtonDeformationY
            // 
            this.radioButtonDeformationY.AutoSize = true;
            this.radioButtonDeformationY.Enabled = false;
            this.radioButtonDeformationY.Location = new System.Drawing.Point(652, 351);
            this.radioButtonDeformationY.Name = "radioButtonDeformationY";
            this.radioButtonDeformationY.Size = new System.Drawing.Size(144, 17);
            this.radioButtonDeformationY.TabIndex = 2;
            this.radioButtonDeformationY.TabStop = true;
            this.radioButtonDeformationY.Text = "Перемещение по оси Y";
            this.radioButtonDeformationY.UseVisualStyleBackColor = true;
            this.radioButtonDeformationY.CheckedChanged += new System.EventHandler(this.radioButtonDeformationY_CheckedChanged);
            // 
            // radioButtonDeformationX
            // 
            this.radioButtonDeformationX.AutoSize = true;
            this.radioButtonDeformationX.Enabled = false;
            this.radioButtonDeformationX.Location = new System.Drawing.Point(652, 328);
            this.radioButtonDeformationX.Name = "radioButtonDeformationX";
            this.radioButtonDeformationX.Size = new System.Drawing.Size(144, 17);
            this.radioButtonDeformationX.TabIndex = 1;
            this.radioButtonDeformationX.TabStop = true;
            this.radioButtonDeformationX.Text = "Перемещение по оси X";
            this.radioButtonDeformationX.UseVisualStyleBackColor = true;
            this.radioButtonDeformationX.CheckedChanged += new System.EventHandler(this.radioButtonDeformationX_CheckedChanged);
            // 
            // radioButtonDeformation
            // 
            this.radioButtonDeformation.AutoSize = true;
            this.radioButtonDeformation.Enabled = false;
            this.radioButtonDeformation.Location = new System.Drawing.Point(652, 305);
            this.radioButtonDeformation.Name = "radioButtonDeformation";
            this.radioButtonDeformation.Size = new System.Drawing.Size(92, 17);
            this.radioButtonDeformation.TabIndex = 0;
            this.radioButtonDeformation.TabStop = true;
            this.radioButtonDeformation.Text = "Деформация";
            this.radioButtonDeformation.UseVisualStyleBackColor = true;
            this.radioButtonDeformation.CheckedChanged += new System.EventHandler(this.radioButtonDeformation_CheckedChanged);
            // 
            // labelStresOk
            // 
            this.labelStresOk.AutoSize = true;
            this.labelStresOk.Location = new System.Drawing.Point(127, 96);
            this.labelStresOk.Name = "labelStresOk";
            this.labelStresOk.Size = new System.Drawing.Size(0, 13);
            this.labelStresOk.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Выдержит ли деталь:";
            // 
            // labelStress
            // 
            this.labelStress.AutoSize = true;
            this.labelStress.Location = new System.Drawing.Point(164, 72);
            this.labelStress.Name = "labelStress";
            this.labelStress.Size = new System.Drawing.Size(0, 13);
            this.labelStress.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Максимальное напряжение:";
            // 
            // labelMaxDeformationY
            // 
            this.labelMaxDeformationY.AutoSize = true;
            this.labelMaxDeformationY.Location = new System.Drawing.Point(148, 49);
            this.labelMaxDeformationY.Name = "labelMaxDeformationY";
            this.labelMaxDeformationY.Size = new System.Drawing.Size(0, 13);
            this.labelMaxDeformationY.TabIndex = 3;
            // 
            // labelMaxDeformationX
            // 
            this.labelMaxDeformationX.AutoSize = true;
            this.labelMaxDeformationX.Location = new System.Drawing.Point(148, 25);
            this.labelMaxDeformationX.Name = "labelMaxDeformationX";
            this.labelMaxDeformationX.Size = new System.Drawing.Size(0, 13);
            this.labelMaxDeformationX.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Макс. смещене по оси Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Макс. смещене по оси X:";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(622, 379);
            this.panel.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxLength);
            this.groupBox1.Controls.Add(this.textBoxPoissonsRatio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxThickness);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxForce);
            this.groupBox1.Controls.Add(this.textBoxElasticModulus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(640, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 160);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные данные";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelMaxDeformationX);
            this.groupBox2.Controls.Add(this.labelStresOk);
            this.groupBox2.Controls.Add(this.labelMaxDeformationY);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.labelStress);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(640, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 121);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результат";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(923, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonDeformation);
            this.Controls.Add(this.radioButtonDeformationX);
            this.Controls.Add(this.radioButtonDeformationY);
            this.Controls.Add(this.radioButtonStress);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.buttonGrid);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализ напряженно-деформированного состояния элемента трубопровода ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.Button buttonGrid;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.TextBox textBoxThickness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPoissonsRatio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxElasticModulus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxForce;
        private System.Windows.Forms.RadioButton radioButtonDeformationX;
        private System.Windows.Forms.RadioButton radioButtonDeformation;
        private System.Windows.Forms.RadioButton radioButtonDeformationY;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelMaxDeformationY;
        private System.Windows.Forms.Label labelMaxDeformationX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonStress;
        private System.Windows.Forms.Label labelStress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelStresOk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

