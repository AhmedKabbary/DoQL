namespace DoQL.Forms
{
    partial class ExportForm
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
            this.btnExport = new System.Windows.Forms.Button();
            this.doqlRadioBtn = new System.Windows.Forms.RadioButton();
            this.sqlRadioBtn = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Export your ERD into:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(131, 247);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 40);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Ok";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // doqlRadioBtn
            // 
            this.doqlRadioBtn.AutoSize = true;
            this.doqlRadioBtn.Checked = true;
            this.doqlRadioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doqlRadioBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.doqlRadioBtn.Location = new System.Drawing.Point(27, 99);
            this.doqlRadioBtn.Name = "doqlRadioBtn";
            this.doqlRadioBtn.Size = new System.Drawing.Size(113, 28);
            this.doqlRadioBtn.TabIndex = 2;
            this.doqlRadioBtn.TabStop = true;
            this.doqlRadioBtn.Text = "DoQL file";
            this.doqlRadioBtn.UseVisualStyleBackColor = true;
            // 
            // sqlRadioBtn
            // 
            this.sqlRadioBtn.AutoSize = true;
            this.sqlRadioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sqlRadioBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sqlRadioBtn.Location = new System.Drawing.Point(27, 156);
            this.sqlRadioBtn.Name = "sqlRadioBtn";
            this.sqlRadioBtn.Size = new System.Drawing.Size(159, 28);
            this.sqlRadioBtn.TabIndex = 3;
            this.sqlRadioBtn.Text = "SQL command";
            this.sqlRadioBtn.UseVisualStyleBackColor = true;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(352, 299);
            this.Controls.Add(this.sqlRadioBtn);
            this.Controls.Add(this.doqlRadioBtn);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(370, 346);
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnExport;
        private RadioButton doqlRadioBtn;
        private RadioButton sqlRadioBtn;
        private SaveFileDialog saveFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}