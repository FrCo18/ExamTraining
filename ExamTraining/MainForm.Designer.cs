namespace ExamTraining
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnRieltors = new System.Windows.Forms.Button();
            this.btnObjRealStates = new System.Windows.Forms.Button();
            this.btnProposals = new System.Windows.Forms.Button();
            this.btnNeeds = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnClients
            // 
            this.btnClients.Location = new System.Drawing.Point(36, 182);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(248, 50);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Клиенты";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnRieltors
            // 
            this.btnRieltors.Location = new System.Drawing.Point(36, 238);
            this.btnRieltors.Name = "btnRieltors";
            this.btnRieltors.Size = new System.Drawing.Size(248, 50);
            this.btnRieltors.TabIndex = 2;
            this.btnRieltors.Text = "Риелторы";
            this.btnRieltors.UseVisualStyleBackColor = true;
            // 
            // btnObjRealStates
            // 
            this.btnObjRealStates.Location = new System.Drawing.Point(36, 294);
            this.btnObjRealStates.Name = "btnObjRealStates";
            this.btnObjRealStates.Size = new System.Drawing.Size(248, 50);
            this.btnObjRealStates.TabIndex = 3;
            this.btnObjRealStates.Text = "Объекты недвижимости";
            this.btnObjRealStates.UseVisualStyleBackColor = true;
            // 
            // btnProposals
            // 
            this.btnProposals.Location = new System.Drawing.Point(36, 350);
            this.btnProposals.Name = "btnProposals";
            this.btnProposals.Size = new System.Drawing.Size(248, 50);
            this.btnProposals.TabIndex = 4;
            this.btnProposals.Text = "Предложения";
            this.btnProposals.UseVisualStyleBackColor = true;
            // 
            // btnNeeds
            // 
            this.btnNeeds.Location = new System.Drawing.Point(36, 406);
            this.btnNeeds.Name = "btnNeeds";
            this.btnNeeds.Size = new System.Drawing.Size(248, 50);
            this.btnNeeds.TabIndex = 5;
            this.btnNeeds.Text = "Потребности";
            this.btnNeeds.UseVisualStyleBackColor = true;
            // 
            // btnTransactions
            // 
            this.btnTransactions.Location = new System.Drawing.Point(36, 462);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(248, 50);
            this.btnTransactions.TabIndex = 6;
            this.btnTransactions.Text = "Сделки";
            this.btnTransactions.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 562);
            this.Controls.Add(this.btnTransactions);
            this.Controls.Add(this.btnNeeds);
            this.Controls.Add(this.btnProposals);
            this.Controls.Add(this.btnObjRealStates);
            this.Controls.Add(this.btnRieltors);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Esoft";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnRieltors;
        private System.Windows.Forms.Button btnObjRealStates;
        private System.Windows.Forms.Button btnProposals;
        private System.Windows.Forms.Button btnNeeds;
        private System.Windows.Forms.Button btnTransactions;
    }
}

