namespace DoQL.Controls.Panels
{
    partial class RelationshipPanel
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
            this.relationshipName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.updateAction = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.deleteAction = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TblNameLbl = new System.Windows.Forms.Label();
            this.TableName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(348, 793);
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
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label1.Size = new System.Drawing.Size(243, 33);
            this.label1.TabIndex = 62;
            this.label1.Text = "Relationship name:";
            // 
            // relationshipName
            // 
            this.relationshipName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.relationshipName.Location = new System.Drawing.Point(31, 103);
            this.relationshipName.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.relationshipName.Name = "relationshipName";
            this.relationshipName.Size = new System.Drawing.Size(275, 32);
            this.relationshipName.TabIndex = 63;
            this.relationshipName.TextChanged += new System.EventHandler(this.relationshipName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.CausesValidation = false;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label6.Location = new System.Drawing.Point(24, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label6.Size = new System.Drawing.Size(187, 33);
            this.label6.TabIndex = 72;
            this.label6.Text = "Update action:";
            // 
            // updateAction
            // 
            this.updateAction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.updateAction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.updateAction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.updateAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateAction.DisplayMember = "MySQL";
            this.updateAction.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updateAction.FormattingEnabled = true;
            this.updateAction.Items.AddRange(new object[] {
            "NoAction",
            "Restrict",
            "Cascade",
            "SetNull",
            "SetDefault"});
            this.updateAction.Location = new System.Drawing.Point(31, 211);
            this.updateAction.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.updateAction.Name = "updateAction";
            this.updateAction.Size = new System.Drawing.Size(275, 32);
            this.updateAction.TabIndex = 70;
            this.updateAction.SelectedIndexChanged += new System.EventHandler(this.updateAction_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.CausesValidation = false;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label7.Location = new System.Drawing.Point(31, 266);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label7.Size = new System.Drawing.Size(180, 33);
            this.label7.TabIndex = 76;
            this.label7.Text = "Delete action:";
            // 
            // deleteAction
            // 
            this.deleteAction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.deleteAction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.deleteAction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAction.DisplayMember = "MySQL";
            this.deleteAction.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteAction.FormattingEnabled = true;
            this.deleteAction.Items.AddRange(new object[] {
            "NoAction",
            "Restrict",
            "Cascade",
            "SetNull",
            "SetDefault"});
            this.deleteAction.Location = new System.Drawing.Point(31, 319);
            this.deleteAction.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.deleteAction.Name = "deleteAction";
            this.deleteAction.Size = new System.Drawing.Size(275, 32);
            this.deleteAction.TabIndex = 75;
            this.deleteAction.SelectedIndexChanged += new System.EventHandler(this.deleteAction_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.CausesValidation = false;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label3.Location = new System.Drawing.Point(24, 374);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 10);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label3.Size = new System.Drawing.Size(226, 33);
            this.label3.TabIndex = 77;
            this.label3.Text = "Attached entities:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel1.Controls.Add(this.TblNameLbl);
            this.flowLayoutPanel1.Controls.Add(this.TableName);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(24, 420);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(289, 352);
            this.flowLayoutPanel1.TabIndex = 78;
            this.flowLayoutPanel1.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.HideTableNameControls);
            // 
            // TblNameLbl
            // 
            this.TblNameLbl.AutoSize = true;
            this.TblNameLbl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TblNameLbl.CausesValidation = false;
            this.TblNameLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TblNameLbl.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TblNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.TblNameLbl.Location = new System.Drawing.Point(0, 3);
            this.TblNameLbl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.TblNameLbl.Name = "TblNameLbl";
            this.TblNameLbl.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.TblNameLbl.Size = new System.Drawing.Size(161, 33);
            this.TblNameLbl.TabIndex = 80;
            this.TblNameLbl.Text = "Table name:";
            this.TblNameLbl.Visible = false;
            // 
            // TableName
            // 
            this.TableName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TableName.Location = new System.Drawing.Point(7, 56);
            this.TableName.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.TableName.Name = "TableName";
            this.TableName.Size = new System.Drawing.Size(275, 32);
            this.TableName.TabIndex = 81;
            this.TableName.Visible = false;
            this.TableName.TextChanged += new System.EventHandler(this.TableName_TextChanged);
            // 
            // RelationshipPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.relationshipName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.updateAction);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deleteAction);
            this.Controls.Add(this.listView1);
            this.Name = "RelationshipPanel";
            this.Size = new System.Drawing.Size(348, 793);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private Label label1;
        private TextBox relationshipName;
        private Label label6;
        private ComboBox updateAction;
        private Label label7;
        private ComboBox deleteAction;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label TblNameLbl;
        private TextBox TableName;
    }
}
