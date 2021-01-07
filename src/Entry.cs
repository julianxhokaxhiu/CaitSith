using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace CaitSith
{
    public partial class Entry : Form
    {
        private CamData[] camData;
        private FileInfo fileInfo;

        public Entry()
        {
            InitializeComponent();
        }

        private bool parseCamFile(string camFile)
        {
            fileInfo = new FileInfo(camFile);

            camData = new CamData[fileInfo.Length / 40];

            lblTotalFrames.Text = "Total Frames: " + camData.Length;

            FileStream file = fileInfo.OpenRead();

            for (int idx = 0; idx < camData.Length; ++idx)
            {
                camData[idx] = file.ReadStruct<CamData>();
            }

            file.Close();

            return true;
        }

        private bool dumpCamFile(string camFile)
        {
            FileStream file = File.OpenWrite(camFile);

            for (int idx = 0; idx < camData.Length; ++idx)
            {
                // Write Cam Data
                file.WriteStruct<CamData>(camData[idx]);
            }

            file.Close();

            return true;
        }

        private void renderList()
        {
            for (int idx = 0; idx < camData.Length; ++idx)
            {
                string[] item =
                {
                    (idx + 1).ToString(),
                    "( " + camData[idx].eye_x + ", " + camData[idx].eye_y + ", " + camData[idx].eye_z + " )",
                    "( " + camData[idx].target_x + ", " + camData[idx].target_y + ", " + camData[idx].target_z + " )",
                    "( " + camData[idx].up_x + ", " + camData[idx].up_y + ", " + camData[idx].up_z + " )",
                    "( " + camData[idx].pos_x + ", " + camData[idx].pos_y + ", " + camData[idx].pos_z + " )",
                    "( " + camData[idx].pan_x + ", " + camData[idx].pan_y + " )",
                    camData[idx].zoom.ToString()
                };

                lstView.Items.Add(new ListViewItem(item));
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "FF7 CAM file|*.cam|All files (*.*)|*.*";
            openFileDialog.DefaultExt = "cam";
            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                parseCamFile(openFileDialog.FileName);
                renderList();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/julianxhokaxhiu/CaitSith");
        }

        private void Entry_KeyUp(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        lstView.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Selected = true);
                        break;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "FF7 CAM file|*.cam|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "cam";
            saveFileDialog.FileName = fileInfo.Name;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string camFile = saveFileDialog.FileName;

                if (dumpCamFile(camFile))
                    MessageBox.Show("Cam file was successfully saved in:\n\n" + camFile, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
