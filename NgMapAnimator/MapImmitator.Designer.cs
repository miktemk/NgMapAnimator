namespace NgMapAnimator
{
    partial class MapImmitator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MapImmitator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.DoubleBuffered = true;
            this.Name = "MapImmitator";
            this.Size = new System.Drawing.Size(1409, 859);
            this.Load += new System.EventHandler(this.MapImmitator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapImmitator_Paint);
            this.MouseLeave += new System.EventHandler(this.MapImmitator_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapImmitator_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapImmitator_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
