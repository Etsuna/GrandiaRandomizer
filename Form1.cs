using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace GrandiaRandomizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var language = comboBox1.SelectedItem.ToString();

            Randomizer.RandomizerExecute(language);

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.GrandiaRandomizerIcon.ToBitmap();
            popup.TitleText = "Grandia Randomize Beta V0.1";

            if (language == "English")
            {
                popup.ContentText = "Seed Apply! Good Luck & Have Fun!";
            }

            if (language == "Français")
            {
                popup.ContentText = "Seed OK ! Bonne chance et amusez-vous bien !";
            }
            popup.Popup();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            InternetBrowser.OpenInDefaultBrowser("https://pool367.seedbox.fr/files/index.php/s/yNKoszYHCtwPQn2/download");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InternetBrowser.OpenInDefaultBrowser("https://www.twitch.tv/etsuna_");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            InternetBrowser.OpenInDefaultBrowser("https://twitter.com/etsunamattel");
        }
    }
}
