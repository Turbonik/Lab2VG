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
            this.authoriseUserControl1 = new Lab2VG.AuthoriseUserControl();
            this.SuspendLayout();
            // 
            // authoriseUserControl1
            // 
            this.authoriseUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.authoriseUserControl1.Location = new System.Drawing.Point(-8, 1);
            this.authoriseUserControl1.Name = "authoriseUserControl1";
            this.authoriseUserControl1.Size = new System.Drawing.Size(953, 318);
            this.authoriseUserControl1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 331);
            this.Controls.Add(this.authoriseUserControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "АИС Отдел кадров";
            this.ResumeLayout(false);

        }

        #endregion

        private AuthoriseUserControl authoriseUserControl1;
    
    }
}

