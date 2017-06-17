namespace ModTool
{
    partial class FormLanguage
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
            this.listBoxID = new System.Windows.Forms.ListBox();
            this.lblId = new System.Windows.Forms.Label();
            this.boxEn = new System.Windows.Forms.TextBox();
            this.boxZh = new System.Windows.Forms.TextBox();
            this.boxMy = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxID
            // 
            this.listBoxID.FormattingEnabled = true;
            this.listBoxID.ItemHeight = 12;
            this.listBoxID.Location = new System.Drawing.Point(12, 12);
            this.listBoxID.Name = "listBoxID";
            this.listBoxID.Size = new System.Drawing.Size(120, 532);
            this.listBoxID.TabIndex = 0;
            this.listBoxID.SelectedIndexChanged += new System.EventHandler(this.listBoxID_SelectedIndexChanged);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(147, 12);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(35, 12);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "lblId";
            // 
            // boxEn
            // 
            this.boxEn.Location = new System.Drawing.Point(149, 47);
            this.boxEn.Multiline = true;
            this.boxEn.Name = "boxEn";
            this.boxEn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.boxEn.Size = new System.Drawing.Size(619, 53);
            this.boxEn.TabIndex = 2;
            this.boxEn.Text = "444444444444444444444444444444444444444444444444444444444444444444444444444444444" +
    "44444444444444444444444444444444444444444444444444444444444444444444444444444444" +
    "444";
            // 
            // boxZh
            // 
            this.boxZh.Location = new System.Drawing.Point(149, 127);
            this.boxZh.Multiline = true;
            this.boxZh.Name = "boxZh";
            this.boxZh.Size = new System.Drawing.Size(619, 65);
            this.boxZh.TabIndex = 3;
            // 
            // boxMy
            // 
            this.boxMy.Location = new System.Drawing.Point(149, 221);
            this.boxMy.Multiline = true;
            this.boxMy.Name = "boxMy";
            this.boxMy.Size = new System.Drawing.Size(619, 271);
            this.boxMy.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(693, 520);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(303, 520);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(419, 519);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // FormLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.boxMy);
            this.Controls.Add(this.boxZh);
            this.Controls.Add(this.boxEn);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.listBoxID);
            this.Name = "FormLanguage";
            this.Text = "ModLanguage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxID;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox boxEn;
        private System.Windows.Forms.TextBox boxZh;
        private System.Windows.Forms.TextBox boxMy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}