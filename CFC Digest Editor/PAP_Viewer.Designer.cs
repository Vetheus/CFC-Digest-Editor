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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CropBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CanvaBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BaseViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CropBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CanvaBox)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base Texture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(352, 126);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(720, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "->";
            // 
            // CanvaBox
            // 
            this.CanvaBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CanvaBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CanvaBox.Location = new System.Drawing.Point(755, 12);
            this.CanvaBox.Name = "CanvaBox";
            this.CanvaBox.Size = new System.Drawing.Size(278, 235);
            this.CanvaBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CanvaBox.TabIndex = 6;
            this.CanvaBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(827, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Complete Canva";
            // 
            // PAP_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 301);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CanvaBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CropBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BaseViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PAP_Viewer";
            this.Text = "PAP Editor";
            ((System.ComponentModel.ISupportInitialize)(this.BaseViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CropBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CanvaBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox BaseViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox CropBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.PictureBox CanvaBox;
        private System.Windows.Forms.Label label5;
    }
}