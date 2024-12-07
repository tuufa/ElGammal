namespace ElGammal
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>


        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelP = new System.Windows.Forms.Label();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labelK = new System.Windows.Forms.Label();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.decryptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelP
            // 
            this.labelP.Location = new System.Drawing.Point(30, 30);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(64, 28);
            this.labelP.TabIndex = 0;
            this.labelP.Text = "Число p:\r\nпростое";
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(100, 30);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(100, 20);
            this.textBoxP.TabIndex = 1;
            // 
            // labelX
            // 
            this.labelX.Location = new System.Drawing.Point(30, 70);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(64, 28);
            this.labelX.TabIndex = 2;
            this.labelX.Text = "Число x:\r\n1 < x < p";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(100, 70);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 3;
            // 
            // labelK
            // 
            this.labelK.Location = new System.Drawing.Point(30, 110);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(64, 37);
            this.labelK.TabIndex = 4;
            this.labelK.Text = "Число k:\r\n1 < k < p-1\r\n";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(100, 110);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(100, 20);
            this.textBoxK.TabIndex = 5;
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(30, 150);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 6;
            this.encryptButton.Text = "Шифровать";
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(599, 150);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить в файл";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(695, 150);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Загрузить из файла";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(30, 190);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(143, 23);
            this.resultLabel.TabIndex = 9;
            this.resultLabel.Text = "Результат шифрования:";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(30, 220);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(740, 180);
            this.textBoxOutput.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(213, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Текст шифрования:";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(216, 30);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(572, 103);
            this.textBoxInput.TabIndex = 12;
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(125, 150);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(224, 23);
            this.decryptButton.TabIndex = 13;
            this.decryptButton.Text = "Расшифровать из текста шифрования";
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.textBoxP);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.textBoxOutput);
            this.Name = "Form1";
            this.Text = "Шифрование Эль-Гаммаля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Элементы управления
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.TextBox textBoxP;

        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBoxX;

        private System.Windows.Forms.Label labelK;
        private System.Windows.Forms.TextBox textBoxK;

        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;

        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button decryptButton;
    }
}
