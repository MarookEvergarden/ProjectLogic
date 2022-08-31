using BusinessLogic;
using LibVLCSharp.Forms.Shared;
using LibVLCSharp.Shared;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public LibVLC _libVLC;
        public MediaPlayer _mp;
        public Media media;

        public bool isFullscreen = false;
        public bool isPlaying = false;
        public Size oldVideoSize;
        public Size oldFormSize;
        public Point oldVideoLocation;

        public Form1()
        {
            InitializeComponent();

            Core.Initialize();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(ShortcutEvent);

            oldVideoSize = videoView1.Size;
            oldFormSize = this.Size;
            oldVideoLocation = videoView1.Location;

            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC);

            videoView1.MediaPlayer = _mp;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Hello");
        }
        public void ShortcutEvent(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape && isFullscreen) 
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.Size = oldVideoSize;
                menuStrip2.Visible = true;
                videoView1.Size = oldVideoSize;
                videoView1.Location = oldVideoLocation;
                isFullscreen = false;
            }

            if (isPlaying) 
            {
                if(e.KeyCode == Keys.Space) 
                {
                    if(_mp.State == VLCState.Playing)
                    {
                        _mp.Pause();
                    }
                    else 
                    {
                        _mp.Play();
                    }
                }
                if(e.KeyCode == Keys.J) 
                {
                    _mp.Position -= 0.01f;
                }
                if (e.KeyCode == Keys.L) 
                {
                    _mp.Position += 0.01f;
                }
            }
            
        }


        private void openFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PlayFile(ofd.FileName);
            }
        }

        private void openURLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           Form2 url_ofd = new Form2();
            url_ofd.Show();
        }

        private void PlayFile(string fileName)
        {
            _mp.Play(new Media(_libVLC, fileName));
            isPlaying = true;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void goFullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;
            videoView1.Size = this.Size;
            videoView1.Location = new Point(0, 0);  
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            isFullscreen = true;
        }
        public void PlayURLFile(string file) 
        {
            _mp.Play(new Media(_libVLC, new Uri(file)));
            isPlaying = true;
        }

        private void openSchedualeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 schedule = new Form3();
            schedule.Show();
        }
    }
}