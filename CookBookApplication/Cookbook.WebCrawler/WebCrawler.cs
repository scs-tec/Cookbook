using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Cookbook.WebCrawler
{
    public class WebCrawler
    {
        private readonly string _url;
        private readonly HtmlDocument _document;

        public WebCrawler(string url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            _url = url;

            HtmlWeb web = new HtmlWeb();
            _document = web.Load(_url);
        }

        public string GetText()
        {

            var htmlNodeCollection = _document.DocumentNode.SelectNodes("//a").Select(link => link.InnerText).ToList();
            return htmlNodeCollection.FirstOrDefault();
        }

        public IList<string> GetDivTextByCSSClass(string cssClass)
        {
            var xpath = $"//div[@class='{cssClass}']";
            return GetTextByCSSClass(xpath);
        }


        public IList<string> GetTableContentByCSSClass(string cssClass)
        {
            var xpath = $"//table[@class='{cssClass}']";
            return GetTextByCSSClass(xpath);
        }

        private IList<string> GetTextByCSSClass(string xpath)
        {
            var nodes = _document.DocumentNode.SelectNodes(xpath);

            return nodes.Select(node => node.InnerText).ToList();
        }

        public string GetDivById(string divId)
        {
            var xpath = $"//div[@id='{divId}']";
            var nodes = _document.DocumentNode.SelectNodes(xpath);
            if (nodes == null)
                return null;

            if (!nodes.Any())
                return null;

            return nodes.Select(x => x.InnerText).FirstOrDefault();
        }
    }
}
