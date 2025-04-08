namespace CFC_Digest_Editor
{
    partial class PAP_Viewer
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
            this.BaseViewer = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CropBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BaseViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CropBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseViewer
            // 
            this.BaseViewer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BaseViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BaseViewer.Location = new System.Drawing.Point(12, 12);
            this.BaseViewer.Name = "BaseViewer";
            this.BaseViewer.Size = new System.Drawing.Size(317, 235);
            this.BaseViewer.TabIndex = 0;
            this.BaseViewer.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "->";
            // 
            // CropBox
            // 
            this.CropBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CropBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CropBox.Location = new System.Drawing.Point(397, 12);
            this.CropBox.Name = "CropBox";
            this.CropBox.Size = new System.Drawing.Size(278, 235);
            this.CropBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CropBox.TabIndex = 3;
            this.CropBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(521, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Crop";
            // 
            // PAP_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 301);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CropBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BaseViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PAP_Viewer";
            this.Text = "PAP Editor";
            ((System.ComponentModel.ISupportInitialize)(this.BaseViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CropBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox BaseViewer;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox CropBox;
        private System.Windows.Forms.Label label3;
    }
}