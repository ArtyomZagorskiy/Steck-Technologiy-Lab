namespace Lab_4_Threads
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
            this.selectFilebutton = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblTime = new System.Windows.Forms.Label();
            this.encryptionButton = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.Label();
            this.decryptionButton = new System.Windows.Forms.Button();
            this.pauseResumeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.changePriorityButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectFilebutton
            // 
            this.selectFilebutton.Font = new System.Drawing.Font("Lato", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectFilebutton.Location = new System.Drawing.Point(12, 110);
            this.selectFilebutton.Name = "selectFilebutton";
            this.selectFilebutton.Size = new System.Drawing.Size(127, 28);
            this.selectFilebutton.TabIndex = 0;
            this.selectFilebutton.Text = "Обрати  файл";
            this.selectFilebutton.UseVisualStyleBackColor = true;
            this.selectFilebutton.Click += new System.EventHandler(this.selectFilebutton_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(12, 68);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(247, 23);
            this.textBoxKey.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 268);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(436, 23);
            this.progressBar.TabIndex = 2;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(13, 241);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 15);
            this.lblTime.TabIndex = 3;
            // 
            // encryptionButton
            // 
            this.encryptionButton.Location = new System.Drawing.Point(123, 163);
            this.encryptionButton.Name = "encryptionButton";
            this.encryptionButton.Size = new System.Drawing.Size(100, 30);
            this.encryptionButton.TabIndex = 4;
            this.encryptionButton.Text = "Шифрувати";
            this.encryptionButton.UseVisualStyleBackColor = true;
            this.encryptionButton.Click += new System.EventHandler(this.encryptionButton_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.AutoSize = true;
            this.txtFilePath.Location = new System.Drawing.Point(150, 117);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(0, 15);
            this.txtFilePath.TabIndex = 5;
            // 
            // decryptionButton
            // 
            this.decryptionButton.Location = new System.Drawing.Point(229, 163);
            this.decryptionButton.Name = "decryptionButton";
            this.decryptionButton.Size = new System.Drawing.Size(113, 30);
            this.decryptionButton.TabIndex = 6;
            this.decryptionButton.Text = "Розшифрувати";
            this.decryptionButton.UseVisualStyleBackColor = true;
            this.decryptionButton.Click += new System.EventHandler(this.decryptionButton_Click);
            // 
            // pauseResumeButton
            // 
            this.pauseResumeButton.Location = new System.Drawing.Point(292, 237);
            this.pauseResumeButton.Name = "pauseResumeButton";
            this.pauseResumeButton.Size = new System.Drawing.Size(75, 23);
            this.pauseResumeButton.TabIndex = 7;
            this.pauseResumeButton.Text = "pause";
            this.pauseResumeButton.UseVisualStyleBackColor = true;
            this.pauseResumeButton.Click += new System.EventHandler(this.pauseResumeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(373, 237);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // changePriorityButton
            // 
            this.changePriorityButton.Location = new System.Drawing.Point(290, 68);
            this.changePriorityButton.Name = "changePriorityButton";
            this.changePriorityButton.Size = new System.Drawing.Size(158, 23);
            this.changePriorityButton.TabIndex = 9;
            this.changePriorityButton.Text = "Normal";
            this.changePriorityButton.UseVisualStyleBackColor = true;
            this.changePriorityButton.Click += new System.EventHandler(this.changePriorityButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(150, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Шифрувальник";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lato", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Введіть ключ(16 символів)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lato", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(300, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Пріорітет процессу";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 301);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changePriorityButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.pauseResumeButton);
            this.Controls.Add(this.decryptionButton);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.encryptionButton);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.selectFilebutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button selectFilebutton;
        private TextBox textBoxKey;
        private ProgressBar progressBar;
        private Label lblTime;
        private Button encryptionButton;
        private Label txtFilePath;
        private Button decryptionButton;
        private Button pauseResumeButton;
        private Button cancelButton;
        private Button changePriorityButton;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}