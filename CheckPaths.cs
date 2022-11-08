using System.IO;
using System.Windows.Forms;

namespace GrandiaRandomizer
{
    public class CheckPaths
    {
        public static void CheckGrandiaExe(string path, string language)
        {
            if (!File.Exists(path))
            {
                if (language is "English")
                {
                    MessageBox.Show("Grandia.exe was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (language is "Français")
                {
                    MessageBox.Show("Grandia.exe est introuvable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
