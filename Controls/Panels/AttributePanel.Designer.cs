namespace DoQL.Controls.Panels
{
    partial class AttributePanel
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
            this.attributeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.columnName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.attributeDatatype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.autoincreamentCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uniqueCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.notNullCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.primaryChechBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Snow;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(377, 699);
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
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label1.Size = new System.Drawing.Size(204, 33);
            this.label1.TabIndex = 33;
            this.label1.Text = "Attribute name:";
            // 
            // attributeName
            // 
            this.attributeName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attributeName.Location = new System.Drawing.Point(33, 81);
            this.attributeName.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.attributeName.Name = "attributeName";
            this.attributeName.Size = new System.Drawing.Size(275, 32);
            this.attributeName.TabIndex = 34;
            this.attributeName.TextChanged += new System.EventHandler(this.ChangeAttributeName);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Snow;
            this.label3.CausesValidation = false;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label3.Location = new System.Drawing.Point(26, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label3.Size = new System.Drawing.Size(185, 33);
            this.label3.TabIndex = 35;
            this.label3.Text = "Column name:";
            // 
            // columnName
            // 
            this.columnName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.columnName.Location = new System.Drawing.Point(33, 189);
            this.columnName.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.columnName.Name = "columnName";
            this.columnName.Size = new System.Drawing.Size(275, 32);
            this.columnName.TabIndex = 36;
            this.columnName.TextChanged += new System.EventHandler(this.columnName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Snow;
            this.label2.CausesValidation = false;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label2.Location = new System.Drawing.Point(26, 244);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 20);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label2.Size = new System.Drawing.Size(131, 33);
            this.label2.TabIndex = 37;
            this.label2.Text = "Datatype:";
            // 
            // attributeDatatype
            // 
            this.attributeDatatype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.attributeDatatype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.attributeDatatype.BackColor = System.Drawing.Color.Snow;
            this.attributeDatatype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.attributeDatatype.DisplayMember = "MySQL";
            this.attributeDatatype.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attributeDatatype.FormattingEnabled = true;
            this.attributeDatatype.Location = new System.Drawing.Point(33, 297);
            this.attributeDatatype.Margin = new System.Windows.Forms.Padding(7, 0, 0, 20);
            this.attributeDatatype.Name = "attributeDatatype";
            this.attributeDatatype.Size = new System.Drawing.Size(275, 32);
            this.attributeDatatype.TabIndex = 32;
            this.attributeDatatype.SelectedIndexChanged += new System.EventHandler(this.attributeDatatype_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Snow;
            this.label8.CausesValidation = false;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label8.Location = new System.Drawing.Point(26, 352);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 3, 0, 15);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.label8.Size = new System.Drawing.Size(166, 33);
            this.label8.TabIndex = 46;
            this.label8.Text = "Conistraints:";
            // 
            // autoincreamentCheckBox
            // 
            this.autoincreamentCheckBox.AutoSize = true;
            this.autoincreamentCheckBox.Location = new System.Drawing.Point(30, 533);
            this.autoincreamentCheckBox.Margin = new System.Windows.Forms.Padding(30, 0, 10, 10);
            this.autoincreamentCheckBox.Name = "autoincreamentCheckBox";
            this.autoincreamentCheckBox.Size = new System.Drawing.Size(18, 17);
            this.autoincreamentCheckBox.TabIndex = 45;
            this.autoincreamentCheckBox.UseVisualStyleBackColor = true;
            this.autoincreamentCheckBox.CheckedChanged += new System.EventHandler(this.autoincreamentCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Snow;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(53, 529);
            this.label7.Margin = new System.Windows.Forms.Padding(20, 0, 10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "AutoIncrement";
            // 
            // uniqueCheckBox
            // 
            this.uniqueCheckBox.AutoSize = true;
            this.uniqueCheckBox.Location = new System.Drawing.Point(30, 491);
            this.uniqueCheckBox.Margin = new System.Windows.Forms.Padding(30, 0, 10, 10);
            this.uniqueCheckBox.Name = "uniqueCheckBox";
            this.uniqueCheckBox.Size = new System.Drawing.Size(18, 17);
            this.uniqueCheckBox.TabIndex = 43;
            this.uniqueCheckBox.UseVisualStyleBackColor = true;
            this.uniqueCheckBox.CheckedChanged += new System.EventHandler(this.uniqueCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Snow;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(53, 487);
            this.label6.Margin = new System.Windows.Forms.Padding(20, 0, 10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Unique";
            // 
            // notNullCheckBox
            // 
            this.notNullCheckBox.AutoSize = true;
            this.notNullCheckBox.Location = new System.Drawing.Point(30, 445);
            this.notNullCheckBox.Margin = new System.Windows.Forms.Padding(30, 0, 10, 10);
            this.notNullCheckBox.Name = "notNullCheckBox";
            this.notNullCheckBox.Size = new System.Drawing.Size(18, 17);
            this.notNullCheckBox.TabIndex = 42;
            this.notNullCheckBox.UseVisualStyleBackColor = true;
            this.notNullCheckBox.CheckedChanged += new System.EventHandler(this.notNullCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Snow;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(53, 400);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 0, 10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 21);
            this.label4.TabIndex = 38;
            this.label4.Text = "Primary key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Snow;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(53, 445);
            this.label5.Margin = new System.Windows.Forms.Padding(20, 0, 10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 40;
            this.label5.Text = "Not null";
            // 
            // primaryChechBox
            // 
            this.primaryChechBox.AutoSize = true;
            this.primaryChechBox.Location = new System.Drawing.Point(30, 404);
            this.primaryChechBox.Margin = new System.Windows.Forms.Padding(30, 0, 10, 10);
            this.primaryChechBox.Name = "primaryChechBox";
            this.primaryChechBox.Size = new System.Drawing.Size(18, 17);
            this.primaryChechBox.TabIndex = 39;
            this.primaryChechBox.UseVisualStyleBackColor = true;
            this.primaryChechBox.CheckedChanged += new System.EventHandler(this.primaryChechBox_CheckedChanged);
            // 
            // AttributePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.attributeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.columnName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.attributeDatatype);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.primaryChechBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.notNullCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.uniqueCheckBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.autoincreamentCheckBox);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AttributePanel";
            this.Size = new System.Drawing.Size(377, 699);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private Label label1;
        private TextBox attributeName;
        private Label label3;
        private TextBox columnName;
        private Label label2;
        private ComboBox attributeDatatype;
        private Label label8;
        private CheckBox autoincreamentCheckBox;
        private Label label7;
        private CheckBox uniqueCheckBox;
        private Label label6;
        private CheckBox notNullCheckBox;
        private Label label4;
        private Label label5;
        private CheckBox primaryChechBox;
    }
}
