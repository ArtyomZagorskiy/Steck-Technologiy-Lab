namespace Lab_1_Banking_App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.withdrawButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.watchBalancebutton = new System.Windows.Forms.Button();
            this.transactionHistorybutton = new System.Windows.Forms.Button();
            this.putMoneybutton = new System.Windows.Forms.Button();
            this.makeTransactionbutton = new System.Windows.Forms.Button();
            this.nearestATMButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.signOutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // withdrawButton
            // 
            this.withdrawButton.BackColor = System.Drawing.Color.White;
            this.withdrawButton.Font = new System.Drawing.Font("Lato", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.withdrawButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.withdrawButton.Location = new System.Drawing.Point(507, 98);
            this.withdrawButton.Name = "withdrawButton";
            this.withdrawButton.Size = new System.Drawing.Size(297, 55);
            this.withdrawButton.TabIndex = 1;
            this.withdrawButton.Text = "Зняття готівки";
            this.withdrawButton.UseVisualStyleBackColor = false;
            this.withdrawButton.Click += new System.EventHandler(this.withdrawButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(-14, 68);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(890, 6);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // watchBalancebutton
            // 
            this.watchBalancebutton.BackColor = System.Drawing.Color.White;
            this.watchBalancebutton.Font = new System.Drawing.Font("Lato", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.watchBalancebutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.watchBalancebutton.Location = new System.Drawing.Point(-14, 98);
            this.watchBalancebutton.Name = "watchBalancebutton";
            this.watchBalancebutton.Size = new System.Drawing.Size(297, 55);
            this.watchBalancebutton.TabIndex = 5;
            this.watchBalancebutton.Text = "Переглянути баланс";
            this.watchBalancebutton.UseVisualStyleBackColor = false;
            this.watchBalancebutton.Click += new System.EventHandler(this.watchBalancebutton_Click);
            // 
            // transactionHistorybutton
            // 
            this.transactionHistorybutton.BackColor = System.Drawing.Color.White;
            this.transactionHistorybutton.Font = new System.Drawing.Font("Lato", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.transactionHistorybutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.transactionHistorybutton.Location = new System.Drawing.Point(-14, 190);
            this.transactionHistorybutton.Name = "transactionHistorybutton";
            this.transactionHistorybutton.Size = new System.Drawing.Size(297, 55);
            this.transactionHistorybutton.TabIndex = 6;
            this.transactionHistorybutton.Text = "Історія транзакцій";
            this.transactionHistorybutton.UseVisualStyleBackColor = false;
            this.transactionHistorybutton.Click += new System.EventHandler(this.transactionHistorybutton_Click);
            // 
            // putMoneybutton
            // 
            this.putMoneybutton.BackColor = System.Drawing.Color.White;
            this.putMoneybutton.Font = new System.Drawing.Font("Lato", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.putMoneybutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.putMoneybutton.Location = new System.Drawing.Point(507, 190);
            this.putMoneybutton.Name = "putMoneybutton";
            this.putMoneybutton.Size = new System.Drawing.Size(297, 55);
            this.putMoneybutton.TabIndex = 7;
            this.putMoneybutton.Text = "Зарахування готівки";
            this.putMoneybutton.UseVisualStyleBackColor = false;
            this.putMoneybutton.Click += new System.EventHandler(this.putMoneybutton_Click);
            // 
            // makeTransactionbutton
            // 
            this.makeTransactionbutton.BackColor = System.Drawing.Color.White;
            this.makeTransactionbutton.Font = new System.Drawing.Font("Lato", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.makeTransactionbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.makeTransactionbutton.Location = new System.Drawing.Point(507, 283);
            this.makeTransactionbutton.Name = "makeTransactionbutton";
            this.makeTransactionbutton.Size = new System.Drawing.Size(297, 55);
            this.makeTransactionbutton.TabIndex = 8;
            this.makeTransactionbutton.Text = "Зробити трансфер";
            this.makeTransactionbutton.UseVisualStyleBackColor = false;
            this.makeTransactionbutton.Click += new System.EventHandler(this.makeTransactionbutton_Click);
            // 
            // nearestATMButton
            // 
            this.nearestATMButton.BackColor = System.Drawing.Color.White;
            this.nearestATMButton.Font = new System.Drawing.Font("Lato", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nearestATMButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nearestATMButton.Location = new System.Drawing.Point(-14, 283);
            this.nearestATMButton.Name = "nearestATMButton";
            this.nearestATMButton.Size = new System.Drawing.Size(297, 55);
            this.nearestATMButton.TabIndex = 9;
            this.nearestATMButton.Text = "Найближчий банкомат";
            this.nearestATMButton.UseVisualStyleBackColor = false;
            this.nearestATMButton.Click += new System.EventHandler(this.nearestATMButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(223, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Будь ласка, вставте картку";
            // 
            // signOutButton
            // 
            this.signOutButton.BackColor = System.Drawing.Color.White;
            this.signOutButton.Font = new System.Drawing.Font("Lato", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.signOutButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signOutButton.Location = new System.Drawing.Point(311, 398);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(181, 40);
            this.signOutButton.TabIndex = 11;
            this.signOutButton.Text = "Витянути картку";
            this.signOutButton.UseVisualStyleBackColor = false;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.signOutButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nearestATMButton);
            this.Controls.Add(this.makeTransactionbutton);
            this.Controls.Add(this.putMoneybutton);
            this.Controls.Add(this.transactionHistorybutton);
            this.Controls.Add(this.watchBalancebutton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.withdrawButton);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Lato", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button withdrawButton;
        private PictureBox pictureBox2;
        private Button watchBalancebutton;
        private Button transactionHistorybutton;
        private Button putMoneybutton;
        private Button makeTransactionbutton;
        private Button nearestATMButton;
        private Label label1;
        private Button signOutButton;
    }
}