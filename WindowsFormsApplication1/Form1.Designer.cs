namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this._commit.Location = new System.Drawing.Point(173, 149);
            this._commit.Name = "button1";
            this._commit.Size = new System.Drawing.Size(75, 23);
            this._commit.TabIndex = 0;
            this._commit.Text = "button1";
            this._commit.UseVisualStyleBackColor = true;
            this._commit.Click += new System.EventHandler(this.Submit);
            // 
            // label1
            // 
            this._status.AutoSize = true;
            this._status.Location = new System.Drawing.Point(12, 240);
            this._status.Name = "label1";
            this._status.Size = new System.Drawing.Size(41, 12);
            this._status.TabIndex = 1;
            this._status.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._status);
            this.Controls.Add(this._commit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _commit;
        private System.Windows.Forms.Label _status;
    }
}

