namespace ModTool
{
    partial class ModView
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chooseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imgShower = new WindowsFormsApplication1.SpinningTriangleControl();
            this.spineShower = new WindowsFormsApplication1.SpinningTriangleControl();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 156);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(133, 316);
            this.listBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chooseFileDialog
            // 
            this.chooseFileDialog.FileName = "openFileDialog1";
            // 
            // imgShower
            // 
            this.imgShower.Location = new System.Drawing.Point(13, 21);
            this.imgShower.Name = "imgShower";
            this.imgShower.Size = new System.Drawing.Size(145, 121);
            this.imgShower.TabIndex = 3;
            this.imgShower.Text = "spinningTriangleControl2";
            // 
            // spineShower
            // 
            this.spineShower.Location = new System.Drawing.Point(329, 12);
            this.spineShower.Name = "spineShower";
            this.spineShower.Size = new System.Drawing.Size(443, 520);
            this.spineShower.TabIndex = 0;
            this.spineShower.Text = "spinningTriangleControl1";
            // 
            // ModView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.imgShower);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.spineShower);
            this.Name = "ModView";
            this.Text = "ModView";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApplication1.SpinningTriangleControl spineShower;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog chooseFileDialog;
        private WindowsFormsApplication1.SpinningTriangleControl imgShower;
    }
}