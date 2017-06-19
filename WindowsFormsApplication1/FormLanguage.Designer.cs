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
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.boxIDFilter = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.checkBoxOnlyEmpty = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.boxTextFilter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxSystemFont = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBoxID
            // 
            this.listBoxID.FormattingEnabled = true;
            this.listBoxID.ItemHeight = 12;
            this.listBoxID.Location = new System.Drawing.Point(12, 156);
            this.listBoxID.Name = "listBoxID";
            this.listBoxID.Size = new System.Drawing.Size(120, 352);
            this.listBoxID.TabIndex = 0;
            this.listBoxID.SelectedIndexChanged += new System.EventHandler(this.listBoxID_SelectedIndexChanged);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(173, 9);
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
            this.boxEn.TabStop = false;
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
            this.boxZh.TabStop = false;
            // 
            // boxMy
            // 
            this.boxMy.Location = new System.Drawing.Point(149, 221);
            this.boxMy.Multiline = true;
            this.boxMy.Name = "boxMy";
            this.boxMy.Size = new System.Drawing.Size(619, 271);
            this.boxMy.TabIndex = 4;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(303, 520);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.TabStop = false;
            this.btnPrev.Text = "Prev(&P)";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(641, 520);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "Next(&N)";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // boxIDFilter
            // 
            this.boxIDFilter.Location = new System.Drawing.Point(12, 47);
            this.boxIDFilter.Name = "boxIDFilter";
            this.boxIDFilter.Size = new System.Drawing.Size(120, 21);
            this.boxIDFilter.TabIndex = 8;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(10, 511);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(59, 12);
            this.lblNum.TabIndex = 9;
            this.lblNum.Text = "9999/9999";
            // 
            // checkBoxOnlyEmpty
            // 
            this.checkBoxOnlyEmpty.AutoSize = true;
            this.checkBoxOnlyEmpty.Location = new System.Drawing.Point(12, 129);
            this.checkBoxOnlyEmpty.Name = "checkBoxOnlyEmpty";
            this.checkBoxOnlyEmpty.Size = new System.Drawing.Size(90, 16);
            this.checkBoxOnlyEmpty.TabIndex = 10;
            this.checkBoxOnlyEmpty.Text = "Unfinished ";
            this.checkBoxOnlyEmpty.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Official English:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "Official Chinese:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "New Text:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "ID Filter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Text Filter";
            // 
            // boxTextFilter
            // 
            this.boxTextFilter.Location = new System.Drawing.Point(14, 91);
            this.boxTextFilter.Name = "boxTextFilter";
            this.boxTextFilter.Size = new System.Drawing.Size(118, 21);
            this.boxTextFilter.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "ID:";
            // 
            // checkBoxSystemFont
            // 
            this.checkBoxSystemFont.AutoSize = true;
            this.checkBoxSystemFont.Checked = true;
            this.checkBoxSystemFont.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSystemFont.Location = new System.Drawing.Point(14, 4);
            this.checkBoxSystemFont.Name = "checkBoxSystemFont";
            this.checkBoxSystemFont.Size = new System.Drawing.Size(114, 16);
            this.checkBoxSystemFont.TabIndex = 18;
            this.checkBoxSystemFont.Text = "Use System Font";
            this.checkBoxSystemFont.UseVisualStyleBackColor = true;
            // 
            // FormLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.checkBoxSystemFont);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.boxTextFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxOnlyEmpty);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.boxIDFilter);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.boxMy);
            this.Controls.Add(this.boxZh);
            this.Controls.Add(this.boxEn);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.listBoxID);
            this.KeyPreview = true;
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
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox boxIDFilter;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.CheckBox checkBoxOnlyEmpty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox boxTextFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxSystemFont;
    }
}