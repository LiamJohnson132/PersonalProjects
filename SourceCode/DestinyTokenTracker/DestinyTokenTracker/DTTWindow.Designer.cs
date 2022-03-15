
namespace DestinyTokenTracker
{
    partial class DTTWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DTTWindow));
            this.titleBar = new System.Windows.Forms.Label();
            this.labelCreateLightTokens = new System.Windows.Forms.Label();
            this.labelCreateDarkTokens = new System.Windows.Forms.Label();
            this.buttonCreateTokens = new System.Windows.Forms.Button();
            this.inputLightTokens = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            resources.ApplyResources(this.titleBar, "titleBar");
            this.titleBar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titleBar.Name = "titleBar";
            // 
            // labelCreateLightTokens
            // 
            resources.ApplyResources(this.labelCreateLightTokens, "labelCreateLightTokens");
            this.labelCreateLightTokens.Name = "labelCreateLightTokens";
            // 
            // labelCreateDarkTokens
            // 
            resources.ApplyResources(this.labelCreateDarkTokens, "labelCreateDarkTokens");
            this.labelCreateDarkTokens.Name = "labelCreateDarkTokens";
            // 
            // buttonCreateTokens
            // 
            resources.ApplyResources(this.buttonCreateTokens, "buttonCreateTokens");
            this.buttonCreateTokens.Name = "buttonCreateTokens";
            this.buttonCreateTokens.UseVisualStyleBackColor = true;
            // 
            // inputLightTokens
            // 
            resources.ApplyResources(this.inputLightTokens, "inputLightTokens");
            this.inputLightTokens.Name = "inputLightTokens";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // DTTWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.inputLightTokens);
            this.Controls.Add(this.buttonCreateTokens);
            this.Controls.Add(this.labelCreateDarkTokens);
            this.Controls.Add(this.labelCreateLightTokens);
            this.Controls.Add(this.titleBar);
            this.MaximizeBox = false;
            this.Name = "DTTWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleBar;
        private System.Windows.Forms.Label labelCreateLightTokens;
        private System.Windows.Forms.Label labelCreateDarkTokens;
        private System.Windows.Forms.Button buttonCreateTokens;
        private System.Windows.Forms.TextBox inputLightTokens;
        private System.Windows.Forms.TextBox textBox1;
    }
}

