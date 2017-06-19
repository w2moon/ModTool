namespace WindowsFormsApplication1
{
    partial class ModTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModTool));
            this._commit = new System.Windows.Forms.Button();
            this._status = new System.Windows.Forms.Label();
            this._changeNote = new System.Windows.Forms.TextBox();
            this._lblChangeNote = new System.Windows.Forms.Label();
            this._title = new System.Windows.Forms.TextBox();
            this._lblTitle = new System.Windows.Forms.Label();
            this._description = new System.Windows.Forms.TextBox();
            this._lblDescription = new System.Windows.Forms.Label();
            this._preview = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnModLanguage = new System.Windows.Forms.Button();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this._preview)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _commit
            // 
            resources.ApplyResources(this._commit, "_commit");
            this._commit.Name = "_commit";
            this._commit.UseVisualStyleBackColor = true;
            this._commit.Click += new System.EventHandler(this.Submit);
            // 
            // _status
            // 
            resources.ApplyResources(this._status, "_status");
            this._status.Name = "_status";
            // 
            // _changeNote
            // 
            resources.ApplyResources(this._changeNote, "_changeNote");
            this._changeNote.Name = "_changeNote";
            // 
            // _lblChangeNote
            // 
            resources.ApplyResources(this._lblChangeNote, "_lblChangeNote");
            this._lblChangeNote.Name = "_lblChangeNote";
            // 
            // _title
            // 
            resources.ApplyResources(this._title, "_title");
            this._title.Name = "_title";
            // 
            // _lblTitle
            // 
            resources.ApplyResources(this._lblTitle, "_lblTitle");
            this._lblTitle.Name = "_lblTitle";
            // 
            // _description
            // 
            resources.ApplyResources(this._description, "_description");
            this._description.Name = "_description";
            // 
            // _lblDescription
            // 
            resources.ApplyResources(this._lblDescription, "_lblDescription");
            this._lblDescription.Name = "_lblDescription";
            // 
            // _preview
            // 
            resources.ApplyResources(this._preview, "_preview");
            this._preview.Name = "_preview";
            this._preview.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zhToolStripMenuItem,
            this.enToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            resources.ApplyResources(this.ToolStripMenuItem, "ToolStripMenuItem");
            // 
            // zhToolStripMenuItem
            // 
            this.zhToolStripMenuItem.Name = "zhToolStripMenuItem";
            resources.ApplyResources(this.zhToolStripMenuItem, "zhToolStripMenuItem");
            this.zhToolStripMenuItem.Click += new System.EventHandler(this.zhToolStripMenuItem_Click);
            // 
            // enToolStripMenuItem
            // 
            this.enToolStripMenuItem.Name = "enToolStripMenuItem";
            resources.ApplyResources(this.enToolStripMenuItem, "enToolStripMenuItem");
            this.enToolStripMenuItem.Click += new System.EventHandler(this.enToolStripMenuItem_Click);
            // 
            // btnModLanguage
            // 
            resources.ApplyResources(this.btnModLanguage, "btnModLanguage");
            this.btnModLanguage.Name = "btnModLanguage";
            this.btnModLanguage.UseVisualStyleBackColor = true;
            this.btnModLanguage.Click += new System.EventHandler(this.btnModLanguage_Click);
            // 
            // lblLink
            // 
            resources.ApplyResources(this.lblLink, "lblLink");
            this.lblLink.Name = "lblLink";
            this.lblLink.TabStop = true;
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // ModTool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.btnModLanguage);
            this.Controls.Add(this._preview);
            this.Controls.Add(this._lblDescription);
            this.Controls.Add(this._description);
            this.Controls.Add(this._lblTitle);
            this.Controls.Add(this._title);
            this.Controls.Add(this._lblChangeNote);
            this.Controls.Add(this._changeNote);
            this.Controls.Add(this._status);
            this.Controls.Add(this._commit);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ModTool";
            ((System.ComponentModel.ISupportInitialize)(this._preview)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _commit;
        private System.Windows.Forms.Label _status;
        private System.Windows.Forms.TextBox _changeNote;
        private System.Windows.Forms.Label _lblChangeNote;
        private System.Windows.Forms.TextBox _title;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.TextBox _description;
        private System.Windows.Forms.Label _lblDescription;
        private System.Windows.Forms.PictureBox _preview;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enToolStripMenuItem;
        private System.Windows.Forms.Button btnModLanguage;
        private System.Windows.Forms.LinkLabel lblLink;
    }
}

