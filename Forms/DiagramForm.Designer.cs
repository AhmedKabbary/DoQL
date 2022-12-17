using DoQL.Controls;

namespace DoQL.Forms
{
    partial class DiagramForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiagramForm));
            this.diagramPanel = new DoQL.Controls.DiagramPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRelationshipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // diagramPanel
            // 
            this.diagramPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.diagramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagramPanel.Location = new System.Drawing.Point(0, 0);
            this.diagramPanel.Name = "diagramPanel";
            this.diagramPanel.Size = new System.Drawing.Size(1182, 753);
            this.diagramPanel.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEntityToolStripMenuItem,
            this.newAttributeToolStripMenuItem,
            this.newRelationshipToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 76);
            // 
            // newEntityToolStripMenuItem
            // 
            this.newEntityToolStripMenuItem.Name = "newEntityToolStripMenuItem";
            this.newEntityToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.newEntityToolStripMenuItem.Text = "New Entity";
            this.newEntityToolStripMenuItem.Click += new System.EventHandler(this.newEntityToolStripMenuItem_Click);
            // 
            // newAttributeToolStripMenuItem
            // 
            this.newAttributeToolStripMenuItem.Name = "newAttributeToolStripMenuItem";
            this.newAttributeToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.newAttributeToolStripMenuItem.Text = "New Attribute";
            this.newAttributeToolStripMenuItem.Click += new System.EventHandler(this.newAttributeToolStripMenuItem_Click);
            // 
            // newRelationshipToolStripMenuItem
            // 
            this.newRelationshipToolStripMenuItem.Name = "newRelationshipToolStripMenuItem";
            this.newRelationshipToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.newRelationshipToolStripMenuItem.Text = "New Relationship";
            this.newRelationshipToolStripMenuItem.Click += new System.EventHandler(this.newRelationshipToolStripMenuItem_Click);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sidePanel.Controls.Add(this.button1);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(300, 753);
            this.sidePanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.diagramPanel);
            this.Name = "DiagramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diagram";
            this.contextMenuStrip1.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DiagramPanel diagramPanel;
        private Panel sidePanel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem newEntityToolStripMenuItem;
        private ToolStripMenuItem newAttributeToolStripMenuItem;
        private ToolStripMenuItem newRelationshipToolStripMenuItem;
        private Button button1;
    }
}