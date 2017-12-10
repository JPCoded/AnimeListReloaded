using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AnimeListReloaded
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            var animeElements = GetElements($"http://myanimelist.net/malappinfo.php?u={txtUsername.Text}&status=all&type=anime");
          
        }

        private static IEnumerable<XElement> GetElements(string url)
        {
            var animedoc = XElement.Load(url);
            return animedoc.Elements("anime");
        }
    }
}
 