namespace DoQL.Controls.Panels
{
    partial class DatabasePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.databaseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.databaseType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.databasePassword = new System.Windows.Forms.TextBox();
            this.passwordButton = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(377, 497);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.CausesValidation = false;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label1.Size = new System.Drawing.Size(207, 33);
            this.label1.TabIndex = 9;
            this.label1.Text = "Database name:";
            // 
            // databaseName
            // 
            this.databaseName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.databaseName.Location = new System.Drawing.Point(31, 88);
            this.databaseName.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.databaseName.Name = "databaseName";
            this.databaseName.Size = new System.Drawing.Size(275, 32);
            this.databaseName.TabIndex = 10;
            this.databaseName.TextChanged += new System.EventHandler(this.ChangeDatabaseName);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.CausesValidation = false;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label3.Location = new System.Drawing.Point(24, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label3.Size = new System.Drawing.Size(193, 33);
            this.label3.TabIndex = 12;
            this.label3.Text = "Database type:";
            // 
            // databaseType
            // 
            this.databaseType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.databaseType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.databaseType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.databaseType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.databaseType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.databaseType.FormattingEnabled = true;
            this.databaseType.Items.AddRange(new object[] {
            "SQLite",
            "MySQL",
            "SQL Server"});
            this.databaseType.Location = new System.Drawing.Point(31, 196);
            this.databaseType.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.databaseType.Name = "databaseType";
            this.databaseType.Size = new System.Drawing.Size(275, 32);
            this.databaseType.TabIndex = 11;
            this.databaseType.SelectedIndexChanged += new System.EventHandler(this.ChangeDatabaseType);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.CausesValidation = false;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label2.Location = new System.Drawing.Point(24, 251);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label2.Size = new System.Drawing.Size(136, 33);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password:";
            // 
            // databasePassword
            // 
            this.databasePassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.databasePassword.Location = new System.Drawing.Point(31, 304);
            this.databasePassword.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.databasePassword.Name = "databasePassword";
            this.databasePassword.PasswordChar = '*';
            this.databasePassword.Size = new System.Drawing.Size(275, 32);
            this.databasePassword.TabIndex = 14;
            // 
            // passwordButton
            // 
            this.passwordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.passwordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.passwordButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.passwordButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passwordButton.ForeColor = System.Drawing.Color.White;
            this.passwordButton.Location = new System.Drawing.Point(94, 361);
            this.passwordButton.Margin = new System.Windows.Forms.Padding(70, 5, 0, 0);
            this.passwordButton.Name = "passwordButton";
            this.passwordButton.Size = new System.Drawing.Size(150, 29);
            this.passwordButton.TabIndex = 15;
            this.passwordButton.Text = "Change password";
            this.passwordButton.UseVisualStyleBackColor = false;
            this.passwordButton.Click += new System.EventHandler(this.SetPassword);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(271, 454);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 29);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // DatabasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.databaseName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.databaseType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.databasePassword);
            this.Controls.Add(this.passwordButton);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DatabasePanel";
            this.Size = new System.Drawing.Size(377, 497);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private Label label1;
        private TextBox databaseName;
        private Label label3;
        private ComboBox databaseType;
        private Label label2;
        private TextBox databasePassword;
        private Button passwordButton;
        private Button btnExport;
        private SaveFileDialog saveFileDialog1;
    }
}
