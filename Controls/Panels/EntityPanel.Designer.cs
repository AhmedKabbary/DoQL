namespace DoQL.Controls.Panels
{
    partial class EntityPanel
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
            this.entityName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Snow;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(377, 430);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Snow;
            this.label1.CausesValidation = false;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label1.Size = new System.Drawing.Size(166, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Entity name:";
            // 
            // entityName
            // 
            this.entityName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.entityName.Location = new System.Drawing.Point(33, 83);
            this.entityName.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.entityName.Name = "entityName";
            this.entityName.Size = new System.Drawing.Size(275, 32);
            this.entityName.TabIndex = 11;
            this.entityName.TextChanged += new System.EventHandler(this.ChangeEntityName);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Snow;
            this.label3.CausesValidation = false;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label3.Location = new System.Drawing.Point(26, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label3.Size = new System.Drawing.Size(161, 33);
            this.label3.TabIndex = 12;
            this.label3.Text = "Table name:";
            // 
            // tableName
            // 
            this.tableName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableName.Location = new System.Drawing.Point(33, 191);
            this.tableName.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.tableName.Name = "tableName";
            this.tableName.Size = new System.Drawing.Size(275, 32);
            this.tableName.TabIndex = 13;
            this.tableName.TextChanged += new System.EventHandler(this.ChangeTableName);
            // 
            // EntityPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entityName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableName);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EntityPanel";
            this.Size = new System.Drawing.Size(377, 430);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private Label label1;
        private TextBox entityName;
        private Label label3;
        private TextBox tableName;
    }
}
