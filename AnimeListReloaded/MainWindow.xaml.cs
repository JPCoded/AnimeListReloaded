using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
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
          
            var genreDic = new Dictionary<string, int>();
            foreach (var t in animeElements.Select(anime => anime.Element("my_tags")?.Value).Select(genres => genres.Split(',')).SelectMany(temp => temp))
            {
                if (genreDic.ContainsKey(t.Trim()))
                {
                    genreDic[t.Trim()] += 1;
                }
                else
                {
                    genreDic.Add(t.Trim(),1);
                }
            }
          
        }

        private static IEnumerable<XElement> GetElements(string url)
        {
            var animedoc = XElement.Load(url);
            return animedoc.Elements("anime");
        }
    }
}
 