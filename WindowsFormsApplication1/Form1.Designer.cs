namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.taskList = new System.Windows.Forms.CheckedListBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сделать как надо";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 195);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(327, 35);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(121, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Готово $1 из $2";
            this.label1.Visible = false;
            // 
            // taskList
            // 
            this.taskList.CheckOnClick = true;
            this.taskList.FormattingEnabled = true;
            this.taskList.Items.AddRange(new object[] {
            "Очистить целевую папку",
            "Преобразовать документы в PDF",
            "Скопировать в целевую папку непреобразованное",
            "Сгенерировать HTML-меню"});
            this.taskList.Location = new System.Drawing.Point(12, 110);
            this.taskList.Name = "taskList";
            this.taskList.Size = new System.Drawing.Size(327, 79);
            this.taskList.TabIndex = 5;
            this.taskList.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(12, 23);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(295, 20);
            this.txtSource.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(313, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Исходная папка:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Целевая папка:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(313, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtDest
            // 
            this.txtDest.Location = new System.Drawing.Point(12, 65);
            this.txtDest.Name = "txtDest";
            this.txtDest.ReadOnly = true;
            this.txtDest.Size = new System.Drawing.Size(295, 20);
            this.txtDest.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Задачи:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.taskList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 300);
            this.MinimumSize = new System.Drawing.Size(370, 300);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All To PDF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox taskList;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Label label4;
    }
}

