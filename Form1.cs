using System;
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

            DebugMenu.DebugMenuCheck(checkBox1.Checked);

            bool initialEquipments = checkBox3.Checked;

            Randomizer.RandomizerExecute(language, initialEquipments);

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.GrandiaRandomizerIcon.ToBitmap();
            popup.TitleText = "Grandia Randomize V1.3";

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InternetBrowser.OpenInDefaultBrowser("https://www.twitch.tv/etsuna_");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            InternetBrowser.OpenInDefaultBrowser("https://twitter.com/etsunamattel");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_Checked(object sender, EventArgs e)
        {
            
        }
        private void checkBox1_Unchecked(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_Checked(object sender, EventArgs e)
        {
            
        }
        private void checkBox2_Unchecked(object sender, EventArgs e)
        {
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_Checked(object sender, EventArgs e)
        {
            
        }
        private void checkBox3_Unchecked(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var language = comboBox1.SelectedItem.ToString();

            ZipUnzip.UnzipOriginalFiles();

            DebugMenu.DebugMenuCheck(false);

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.GrandiaRandomizerIcon.ToBitmap();
            popup.TitleText = "Grandia Randomize V1.3";

            if (language == "English")
            {
                popup.ContentText = "Original files restored!";
            }

            if (language == "Français")
            {
                popup.ContentText = "Fichiers originaux réstaurés";
            }
            popup.Popup();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
