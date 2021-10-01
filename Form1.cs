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

            Randomizer.RandomizerExecute(language);

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.GrandiaRandomizerIcon.ToBitmap();
            popup.TitleText = "Grandia Randomize Beta V0.1";

            if (language == "English")
            {
                popup.ContentText = "Seed OK! Check out your out folder!";
            }
        
            if(language == "Français")
            {
                popup.ContentText = "Seed OK ! Consultez votre dossier out !";
            }
            popup.Popup();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var language = comboBox1.SelectedItem.ToString();
            MakeOriginalFile.OriginalFiles(language);

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.GrandiaRandomizerIcon.ToBitmap();
            popup.TitleText = "Grandia Randomize Beta V0.1";

            if (language == "English")
            {
                popup.ContentText = "Original Files OK! Check out your out folder!";
            }

            if (language == "Français")
            {
                popup.ContentText = "Fichiers Originaux OK ! Consultez le dossier out !";
            }
            popup.Popup();
        }
    }
}
