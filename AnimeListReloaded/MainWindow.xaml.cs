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
            var genreList = new List<string>();
            var genreDic = new Dictionary<string, int>();
            foreach (var t in from g in animeElements let genres = g.Element("my_tags")?.Value let status = g.Element("my_status")?.Value let temp = genres.Split(',') where status == "Completed" || status == "2" from t in temp select t)
            {
                if (genreDic.ContainsKey(t.Trim()))
                {
                    genreDic[t.Trim()] += 1;
                }
                else
                {
                    genreDic.Add(t.Trim(), 1);
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
 