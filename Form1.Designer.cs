namespace Lab2VG
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
            this.label1 = new System.Windows.Forms.Label();
            this.authoriseUserControl1 = new Lab2VG.AuthoriseUserControl();
            this.menu1 = new Lab2VG.MenuUserControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // authoriseUserControl1
            // 
            this.authoriseUserControl1.Location = new System.Drawing.Point(-178, 1);
            this.authoriseUserControl1.Name = "authoriseUserControl1";
            this.authoriseUserControl1.Size = new System.Drawing.Size(1212, 527);
            this.authoriseUserControl1.TabIndex = 1;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menu1.Location = new System.Drawing.Point(229, 22);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(741, 474);
            this.menu1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 540);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authoriseUserControl1);
            this.Controls.Add(this.menu1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuUserControl menu1;
        private AuthoriseUserControl authoriseUserControl1;
        public System.Windows.Forms.Label label1;
    }
}

