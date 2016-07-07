using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using Cookbook.WebCrawler;

namespace CookBookApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var chefkochWebsiteCrawler = new ChefkochWebsiteCrawler(new WebCrawler(ChefkochWebsiteCrawler.DownloadUrl));
            string title = chefkochWebsiteCrawler.ReceiptName;
            var incredients = chefkochWebsiteCrawler.Incredients;
            string cooking = chefkochWebsiteCrawler.Cooking;
            foreach (var incredient in incredients)
            {
                Console.WriteLine(incredient);
            }
            base.OnStartup(e);
        }
    }
}
