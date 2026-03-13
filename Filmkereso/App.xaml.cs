using System.Configuration;
using System.Data;
using System.Windows;
using System.IO;

namespace Filmkereso
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string[] filmek { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string filePath = "filmek.txt";
            if (File.Exists(filePath))
            {
                filmek = File.ReadAllLines(filePath);
            }
        }
    }

}
