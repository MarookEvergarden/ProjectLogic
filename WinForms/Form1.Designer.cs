using LibVLCSharp.Shared;
namespace WinForms
{
    partial class Form1
    {
       
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
            this.videoView1 = new LibVLCSharp.WinForms.VideoView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openURLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goFullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSchedualeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoView1
            // 
            this.videoView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(0, 27);
            this.videoView1.MediaPlayer = null;
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(800, 435);
            this.videoView1.TabIndex = 0;
            this.videoView1.Text = "videoView1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.toolsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem1,
            this.openURLToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // openFileToolStripMenuItem1
            // 
            this.openFileToolStripMenuItem1.Name = "openFileToolStripMenuItem1";
            this.openFileToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.openFileToolStripMenuItem1.Text = "Open file";
            this.openFileToolStripMenuItem1.Click += new System.EventHandler(this.openFileToolStripMenuItem1_Click);
            // 
            // openURLToolStripMenuItem1
            // 
            this.openURLToolStripMenuItem1.Name = "openURLToolStripMenuItem1";
            this.openURLToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.openURLToolStripMenuItem1.Text = "Open URL";
            this.openURLToolStripMenuItem1.Click += new System.EventHandler(this.openURLToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goFullscreenToolStripMenuItem,
            this.openSchedualeToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // goFullscreenToolStripMenuItem
            // 
            this.goFullscreenToolStripMenuItem.Name = "goFullscreenToolStripMenuItem";
            this.goFullscreenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.goFullscreenToolStripMenuItem.Text = "go Fullscreen";
            this.goFullscreenToolStripMenuItem.Click += new System.EventHandler(this.goFullscreenToolStripMenuItem_Click);
            // 
            // openSchedualeToolStripMenuItem
            // 
            this.openSchedualeToolStripMenuItem.Name = "openSchedualeToolStripMenuItem";
            this.openSchedualeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openSchedualeToolStripMenuItem.Text = "Open scheduale";
            this.openSchedualeToolStripMenuItem.Click += new System.EventHandler(this.openSchedualeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.videoView1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "TV App";
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem openFileToolStripMenuItem1;
        private ToolStripMenuItem openURLToolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem goFullscreenToolStripMenuItem;
        private ToolStripMenuItem openSchedualeToolStripMenuItem;
    }
}