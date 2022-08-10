using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.ServiceModel.Syndication;
using Group3.Models;

namespace Group3.Controllers
{
    public class RSSController : Controller
    {
       
        

        [ResponseCache(Duration = 1200)]
        [HttpGet]
        [Route("GetNewsPosts")]
        public IActionResult Rss()
        {
            var feed = new SyndicationFeed("Title", "Description", new Uri("SiteUrl"), "RSSUrl", DateTime.Now);

            feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Year} Group 3");
            var items = new List<SyndicationItem>();
            var postings = NewsPosts.GetBlogPosts();
            foreach (var item in postings)
            {
                var postUrl = Url.Action("Article", "Blog", new { id = item.UrlSlug }, HttpContext.Request.Scheme);
                var title = item.Title;
                var description = item.Description;
                items.Add(new SyndicationItem(title, description, new Uri(postUrl), item.UrlSlug, item.CreatedDate));
            }

            feed.Items = items;
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                NewLineHandling = NewLineHandling.Entitize,
                NewLineOnAttributes = true,
                Indent = true
            };
            using (var stream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    var rssFormatter = new Rss20FeedFormatter(feed, false);
                    rssFormatter.WriteTo(xmlWriter);
                    xmlWriter.Flush();
                }
                return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
            }
        }
        
    }
}
