namespace DoQL.Controls
{
    partial class AttachedEntityControl
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
            this.AttchdName = new System.Windows.Forms.Label();
            this.DeleteAttchd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AttchdName
            // 
            this.AttchdName.AutoSize = true;
            this.AttchdName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AttchdName.ForeColor = System.Drawing.Color.Black;
            this.AttchdName.Location = new System.Drawing.Point(20, 5);
            this.AttchdName.Margin = new System.Windows.Forms.Padding(20, 5, 10, 0);
            this.AttchdName.Name = "AttchdName";
            this.AttchdName.Size = new System.Drawing.Size(135, 21);
            this.AttchdName.TabIndex = 16;
            this.AttchdName.Text = "Phone number";
            // 
            // DeleteAttchd
            // 
            this.DeleteAttchd.BackColor = System.Drawing.Color.White;
            this.DeleteAttchd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteAttchd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteAttchd.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeleteAttchd.ForeColor = System.Drawing.Color.Red;
            this.DeleteAttchd.Location = new System.Drawing.Point(168, 3);
            this.DeleteAttchd.Name = "DeleteAttchd";
            this.DeleteAttchd.Size = new System.Drawing.Size(28, 28);
            this.DeleteAttchd.TabIndex = 17;
            this.DeleteAttchd.Text = "X";
            this.DeleteAttchd.UseVisualStyleBackColor = false;
            this.DeleteAttchd.Click += new System.EventHandler(this.DeleteAttchd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.CausesValidation = false;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label4.Location = new System.Drawing.Point(11, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 10);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label4.Size = new System.Drawing.Size(132, 29);
            this.label4.TabIndex = 31;
            this.label4.Text = "Cardinality:";
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "N"});
            this.comboBox1.Location = new System.Drawing.Point(31, 81);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(20, 3, 3, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 28);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.Text = "1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AttachedEntityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.AttchdName);
            this.Controls.Add(this.DeleteAttchd);
            this.Name = "AttachedEntityControl";
            this.Size = new System.Drawing.Size(203, 116);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label AttchdName;
        private Button DeleteAttchd;
        private Label label4;
        private ComboBox comboBox1;
    }
}
