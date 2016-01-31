namespace NgMapAnimator
{
    partial class AnimatorWindow
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
            this.txtCommands = new System.Windows.Forms.RichTextBox();
            this.lblJsonFile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolderFullRes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoadFinishImage = new System.Windows.Forms.Button();
            this.pictureBoxFinishing = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtZoomF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtZoomFinish = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOffsetX = new System.Windows.Forms.TextBox();
            this.txtOffsetY = new System.Windows.Forms.TextBox();
            this.chkReverse = new System.Windows.Forms.CheckBox();
            this.mapImmitatorControl = new NgMapAnimator.MapImmitator();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoldFirst = new System.Windows.Forms.TextBox();
            this.txtHoldLast = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFinishing)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCommands
            // 
            this.txtCommands.Location = new System.Drawing.Point(12, 190);
            this.txtCommands.Name = "txtCommands";
            this.txtCommands.Size = new System.Drawing.Size(838, 701);
            this.txtCommands.TabIndex = 0;
            this.txtCommands.Text = "";
            // 
            // lblJsonFile
            // 
            this.lblJsonFile.AutoSize = true;
            this.lblJsonFile.Location = new System.Drawing.Point(12, 25);
            this.lblJsonFile.Name = "lblJsonFile";
            this.lblJsonFile.Size = new System.Drawing.Size(317, 32);
            this.lblJsonFile.TabIndex = 2;
            this.lblJsonFile.Text = "No JSON file loaded yet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 56);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(335, 91);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(1530, 38);
            this.txtFolder.TabIndex = 4;
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image folder (full size)";
            // 
            // txtFolderFullRes
            // 
            this.txtFolderFullRes.Location = new System.Drawing.Point(335, 140);
            this.txtFolderFullRes.Name = "txtFolderFullRes";
            this.txtFolderFullRes.Size = new System.Drawing.Size(1530, 38);
            this.txtFolderFullRes.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 915);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Finishing Image";
            // 
            // btnLoadFinishImage
            // 
            this.btnLoadFinishImage.Location = new System.Drawing.Point(234, 904);
            this.btnLoadFinishImage.Name = "btnLoadFinishImage";
            this.btnLoadFinishImage.Size = new System.Drawing.Size(170, 52);
            this.btnLoadFinishImage.TabIndex = 6;
            this.btnLoadFinishImage.Text = "Load...";
            this.btnLoadFinishImage.UseVisualStyleBackColor = true;
            this.btnLoadFinishImage.Click += new System.EventHandler(this.btnLoadFinishImage_Click);
            // 
            // pictureBoxFinishing
            // 
            this.pictureBoxFinishing.BackColor = System.Drawing.Color.Black;
            this.pictureBoxFinishing.Location = new System.Drawing.Point(58, 977);
            this.pictureBoxFinishing.Name = "pictureBoxFinishing";
            this.pictureBoxFinishing.Size = new System.Drawing.Size(311, 198);
            this.pictureBoxFinishing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFinishing.TabIndex = 7;
            this.pictureBoxFinishing.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 915);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Output folder";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(661, 908);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(1204, 38);
            this.txtOutputFolder.TabIndex = 9;
            // 
            // btnRender
            // 
            this.btnRender.BackColor = System.Drawing.Color.Chartreuse;
            this.btnRender.Location = new System.Drawing.Point(1661, 1117);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(204, 89);
            this.btnRender.TabIndex = 10;
            this.btnRender.Text = "RENDER!";
            this.btnRender.UseVisualStyleBackColor = false;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1410, 36);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatus.Size = new System.Drawing.Size(460, 32);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Waiting for you to press RENDER...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 977);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Zoom factor";
            // 
            // txtZoomF
            // 
            this.txtZoomF.Location = new System.Drawing.Point(661, 970);
            this.txtZoomF.Name = "txtZoomF";
            this.txtZoomF.Size = new System.Drawing.Size(157, 38);
            this.txtZoomF.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(474, 1031);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Zoom finish";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(870, 977);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 32);
            this.label7.TabIndex = 12;
            this.label7.Text = "Offset X";
            // 
            // txtZoomFinish
            // 
            this.txtZoomFinish.Location = new System.Drawing.Point(661, 1028);
            this.txtZoomFinish.Name = "txtZoomFinish";
            this.txtZoomFinish.Size = new System.Drawing.Size(157, 38);
            this.txtZoomFinish.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(870, 1028);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 32);
            this.label8.TabIndex = 12;
            this.label8.Text = "Offset Y";
            // 
            // txtOffsetX
            // 
            this.txtOffsetX.Location = new System.Drawing.Point(993, 971);
            this.txtOffsetX.Name = "txtOffsetX";
            this.txtOffsetX.Size = new System.Drawing.Size(157, 38);
            this.txtOffsetX.TabIndex = 13;
            // 
            // txtOffsetY
            // 
            this.txtOffsetY.Location = new System.Drawing.Point(993, 1022);
            this.txtOffsetY.Name = "txtOffsetY";
            this.txtOffsetY.Size = new System.Drawing.Size(157, 38);
            this.txtOffsetY.TabIndex = 13;
            // 
            // chkReverse
            // 
            this.chkReverse.AutoSize = true;
            this.chkReverse.Location = new System.Drawing.Point(1508, 1170);
            this.chkReverse.Name = "chkReverse";
            this.chkReverse.Size = new System.Drawing.Size(147, 36);
            this.chkReverse.TabIndex = 14;
            this.chkReverse.Text = "reverse";
            this.chkReverse.UseVisualStyleBackColor = true;
            this.chkReverse.CheckedChanged += new System.EventHandler(this.chkReverse_CheckedChanged);
            // 
            // mapImmitatorControl
            // 
            this.mapImmitatorControl.BackColor = System.Drawing.Color.Gray;
            this.mapImmitatorControl.ImageFolderRelativePath = null;
            this.mapImmitatorControl.Location = new System.Drawing.Point(876, 190);
            this.mapImmitatorControl.Name = "mapImmitatorControl";
            this.mapImmitatorControl.Size = new System.Drawing.Size(989, 701);
            this.mapImmitatorControl.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1224, 977);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 32);
            this.label9.TabIndex = 15;
            this.label9.Text = "Hold first frame";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1224, 1025);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 32);
            this.label10.TabIndex = 15;
            this.label10.Text = "Hold last frame";
            // 
            // txtHoldFirst
            // 
            this.txtHoldFirst.Location = new System.Drawing.Point(1436, 970);
            this.txtHoldFirst.Name = "txtHoldFirst";
            this.txtHoldFirst.Size = new System.Drawing.Size(180, 38);
            this.txtHoldFirst.TabIndex = 16;
            // 
            // txtHoldLast
            // 
            this.txtHoldLast.Location = new System.Drawing.Point(1437, 1022);
            this.txtHoldLast.Name = "txtHoldLast";
            this.txtHoldLast.Size = new System.Drawing.Size(180, 38);
            this.txtHoldLast.TabIndex = 16;
            // 
            // AnimatorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1882, 1218);
            this.Controls.Add(this.txtHoldLast);
            this.Controls.Add(this.txtHoldFirst);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkReverse);
            this.Controls.Add(this.txtZoomFinish);
            this.Controls.Add(this.txtOffsetY);
            this.Controls.Add(this.txtOffsetX);
            this.Controls.Add(this.txtZoomF);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBoxFinishing);
            this.Controls.Add(this.btnLoadFinishImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFolderFullRes);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblJsonFile);
            this.Controls.Add(this.mapImmitatorControl);
            this.Controls.Add(this.txtCommands);
            this.Name = "AnimatorWindow";
            this.Text = "NgMap animator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFinishing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCommands;
        private MapImmitator mapImmitatorControl;
        private System.Windows.Forms.Label lblJsonFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolderFullRes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoadFinishImage;
        private System.Windows.Forms.PictureBox pictureBoxFinishing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtZoomF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtZoomFinish;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOffsetX;
        private System.Windows.Forms.TextBox txtOffsetY;
        private System.Windows.Forms.CheckBox chkReverse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHoldFirst;
        private System.Windows.Forms.TextBox txtHoldLast;
    }
}

