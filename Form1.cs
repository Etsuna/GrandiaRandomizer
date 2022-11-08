using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace GrandiaRandomizer
{
    public partial class Form1 : Form
    {
        private string FileSeedPath { get; set; }
        private string currentDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory()));

        public Form1()
        {
            InitializeComponent();
            if (File.Exists(Path.Combine(currentDirectory, @"../", "grandia.exe")))
            {
                currentDirectory = Path.Combine(currentDirectory, @"../", "grandia.exe");
            }
            else
            {
                currentDirectory = Path.Combine(currentDirectory, @"../../../../", "grandia.exe");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var language = comboBox1.SelectedItem.ToString();
            var difficulty = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Value;

            CheckPaths.CheckGrandiaExe(currentDirectory, language);

            DebugMenu.DebugMenuCheck(checkBox1.Checked);

            bool initialEquipments = checkBox3.Checked;

            Randomizer.RandomizerExecute(language, initialEquipments, FileSeedPath, difficulty);

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.GrandiaRandomizerIcon.ToBitmap();
            popup.TitleText = "Grandia Randomize V1.6";

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
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            if (comboBox1.SelectedItem.ToString() is "English")
            {
                comboSource.Add("0", "Very Easy");
                comboSource.Add("1", "Easy");
                comboSource.Add("2", "Normal");
                comboSource.Add("3", "Hard");
                comboSource.Add("4", "Very Hard");
                

                label1.Text = "Language :";
                label2.Text = "Difficulty :";
                checkBox3.Text = "Randomize Initial Equipments ?";
                button1.Text = "Restore Original Files";
                button3.Text = "Load Seed";
            }

            if(comboBox1.SelectedItem.ToString() is "Français")
            {
                comboSource.Add("0", "Très Facile");
                comboSource.Add("1", "Facile");
                comboSource.Add("2", "Normal");
                comboSource.Add("3", "Difficile");
                comboSource.Add("4", "Très Difficile");

                label1.Text = "Langage :";
                label2.Text = "Difficulté :";
                checkBox3.Text = "Randomizer l'équipment initial ?";
                button1.Text = "Restorer les fichiers";
                button3.Text = "Charger Seed";
            }

            comboSource.Add("5", "Challenge");
            comboBox2.DataSource = new BindingSource(comboSource, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
            comboBox2.SelectedIndex = 2;
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

        private void checkBox3_Checked(object sender, EventArgs e)
        {

        }
        private void checkBox3_Unchecked(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var language = comboBox1.SelectedItem.ToString();

            CheckPaths.CheckGrandiaExe(currentDirectory, language);

            ZipUnzip.UnzipOriginalFiles();

            DebugMenu.DebugMenuCheck(false);

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.GrandiaRandomizerIcon.ToBitmap();
            popup.TitleText = "Grandia Randomize V1.6";

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

        private void button3_Click(object sender, EventArgs e)
        {
            var language = comboBox1.SelectedItem.ToString();
            string seedDirectory = $@"{Path.Combine(currentDirectory, "Seed")}";

            CheckPaths.CheckGrandiaExe(currentDirectory, language);

            if (Directory.Exists(seedDirectory))
            {
                currentDirectory = seedDirectory;
            }

            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = currentDirectory;
                openFileDialog.Filter = "txt files (*.json)|*.json";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                openFileDialog.ToString();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    if (!filePath.Contains("Seed_"))
                    {
                        MessageBox.Show("File Error, Select a seed file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fileContent = string.Empty;
                        return;
                    }

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    checkBox3.Checked = false;
                    checkBox3.Enabled = false;

                    if (language is "English")
                    {
                        MessageBox.Show("The file has been loaded correctly, select the difficulty and click on Randomizer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (language is "Français")
                    {
                        MessageBox.Show("Le fichier a été chargé correctement, Selectionnez la difficulté et cliquez sur Randomizer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            FileSeedPath = filePath;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
