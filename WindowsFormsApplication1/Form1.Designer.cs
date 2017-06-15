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
            this._commit = new System.Windows.Forms.Button();
            this._status = new System.Windows.Forms.Label();
            this._changeNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._preview)).BeginInit();
            this.SuspendLayout();
            // 
            // _commit
            // 
            this._commit.Location = new System.Drawing.Point(697, 526);
            this._commit.Name = "_commit";
            this._commit.Size = new System.Drawing.Size(75, 23);
            this._commit.TabIndex = 0;
            this._commit.Text = "submit";
            this._commit.UseVisualStyleBackColor = true;
            this._commit.Click += new System.EventHandler(this.Submit);
            // 
            // _status
            // 
            this._status.AutoSize = true;
            this._status.Location = new System.Drawing.Point(12, 540);
            this._status.Name = "_status";
            this._status.Size = new System.Drawing.Size(41, 12);
            this._status.TabIndex = 1;
            this._status.Text = "status";
            // 
            // _changeNote
            // 
            this._changeNote.Location = new System.Drawing.Point(515, 253);
            this._changeNote.Multiline = true;
            this._changeNote.Name = "_changeNote";
            this._changeNote.Size = new System.Drawing.Size(257, 267);
            this._changeNote.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Change Note";
            // 
            // _title
            // 
            this._title.Location = new System.Drawing.Point(14, 35);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(255, 21);
            this._title.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Title";
            // 
            // _description
            // 
            this._description.Location = new System.Drawing.Point(14, 87);
            this._description.Multiline = true;
            this._description.Name = "_description";
            this._description.Size = new System.Drawing.Size(467, 433);
            this._description.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description";
            // 
            // _preview
            // 
            this._preview.Location = new System.Drawing.Point(515, 12);
            this._preview.Name = "_preview";
            this._preview.Size = new System.Drawing.Size(257, 212);
            this._preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._preview.TabIndex = 8;
            this._preview.TabStop = false;
            // 
            // ModTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._preview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._changeNote);
            this.Controls.Add(this._status);
            this.Controls.Add(this._commit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModTool";
            this.Text = "ModTool";
            ((System.ComponentModel.ISupportInitialize)(this._preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _commit;
        private System.Windows.Forms.Label _status;
        private System.Windows.Forms.TextBox _changeNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox _preview;
    }
}

