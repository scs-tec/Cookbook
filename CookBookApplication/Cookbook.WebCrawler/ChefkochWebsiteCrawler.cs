using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.Utils;

namespace Cookbook.WebCrawler
{
    public class ChefkochWebsiteCrawler
    {
        private WebCrawler _crawler;

        public static string DownloadUrl = "http://www.chefkoch.de/rezepte/784711181727496/Zucchini-Kartoffel-Suppe.html";

        public ChefkochWebsiteCrawler(WebCrawler webCrawler)
        {
            _crawler = webCrawler;

        }

        public string ReceiptName => _crawler.GetDivTextByCSSClass("recipe-title-container a-c").FirstOrDefault()
            .Replace("\t", string.Empty)
            .Replace("\n", string.Empty);

        public string Cooking => _crawler.GetDivById("rezept-zubereitung");

        public IList<string> Incredients
        {
            get
            {
                return _crawler.GetTableContentByCSSClass("incredients").FirstOrDefault()
                    .Replace("\t", string.Empty)
                    .Replace("&nbsp;", " ")
                    .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList()
                    .AggregateSublist((a, b) => string.Concat($"{a} ", b));
            }
        }
    }
}