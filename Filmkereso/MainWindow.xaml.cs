using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filmkereso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private void filmload()
        {   App app = (App)Application.Current;
            

            if (app.filmek != null)
            {
                foreach (var film in app.filmek)
                {   
                    var filmData = film.Split(';');
                    if (filmData.Length > 0)
                    {
                        filmekdoboz.Items.Add(filmData[0].Trim());
                    }
                  
                }
            }
             

                
 
        }
        public MainWindow()
        {
            InitializeComponent();
            filmload();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = filmekdoboz.SelectedIndex;
            if (index == -1) return;

            var lines = System.IO.File.ReadAllLines("filmek.txt");
            var Filmdata = lines[index].Split(';');

            rendnev.Content = Filmdata[1].Trim();
            mufajnev.Content = Filmdata[2].Trim();
            hossz.Content = $"{Filmdata[3].Trim()} perc";


            var imagePath = $"img/{Filmdata[0].Trim()}.jpg";
            var fallback = "img/fallback.jpg";

            string pathToUse = File.Exists(imagePath) ? imagePath : fallback;
            filmKep.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(pathToUse), UriKind.Absolute));
        }

        private void hozzaada_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            if (filmekdoboz.SelectedItem != null)
            {
                filmekdoboz.Items.Remove(filmekdoboz.SelectedItem);
                System.Windows.MessageBox.Show("Film sikeresen törölve!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("Nincs kiválasztva film a törléshez!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bezar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}