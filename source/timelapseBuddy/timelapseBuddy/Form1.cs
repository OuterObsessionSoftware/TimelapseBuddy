using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace TimeLapseBuddy
{

    public partial class Form1 : Form
    {
        string folder = Properties.Settings.Default.LastFolderPath;
        bool timerRunning = false;
        int fileNumber = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(folder)) {
            label1.Text = "Output Folder: " + folder;
            toolTip1.SetToolTip(label1, folder);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                button1.Text = "Start Timelapse";

                //Enable buttons
                numericUpDown1.Enabled = true;
                button2.Enabled = true;

                timer1.Enabled = false;
                timerRunning = false;
            }
            else
            {
                button1.Text = "Stop Timelapse";

                //Disable buttons
                numericUpDown1.Enabled = false;
                button2.Enabled = false;


                InitializeTimer();
                timerRunning = true;
            }
        }

        private void InitializeTimer()
        {
            // Run this procedure in an appropriate event.
            timer1.Interval = 1000 * 60 * (int)numericUpDown1.Value;
            timer1.Enabled = true;
        }

        //Select folder to save images
        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    folder = fbd.SelectedPath;
                    Properties.Settings.Default.LastFolderPath = folder;
                    if (numericUpDown1.Value > 0) button1.Enabled = true;
                    label1.Text = "Output Folder: " + folder;
                    toolTip1.SetToolTip(label1, folder);
                }
            }
        }

        void takeScreenshot()
        {
            // Start the process...
            Bitmap memoryImage;
            memoryImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Size s = new Size(memoryImage.Width, memoryImage.Height);

            // Create graphics
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            // Copy data from screen
            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            //That's it! Save the image in the directory and this will work like charm.
            string str = "";
            try
            {
                str = string.Format(folder + @"\Screenshot-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture) + ".png");
                fileNumber++;
            }
            catch (Exception er)
            {
                System.Windows.Forms.MessageBox.Show("Sorry, there was an error: " + er.Message, "Error");
            }


            // Save it!
            //Console.WriteLine("Saving the image...");
            memoryImage.Save(str);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(folder)) takeScreenshot();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && !string.IsNullOrWhiteSpace(folder))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            notifyIcon1.Visible = false;
            notifyIcon1.Icon = null;
        }
    }
}
