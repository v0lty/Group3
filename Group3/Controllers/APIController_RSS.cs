using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.ServiceModel.Syndication;
using Group3.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Group3.Controllers
{
    public partial class APIController : Controller
    {
        [HttpGet]
        [Route("GetRSS")]
        public async Task<JsonResult> GetRSS()
        {     
            var feed = new SyndicationFeed("Software Development News", "Description", new Uri("http://localhost:13021/feed.xml"), "RSSUrl", DateTime.Now);
            feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Year} Group 3");
            var items = new List<SyndicationItem>();

            var categories = dbContext.Categories
                .Where(x => x.Name == "News")
                .Include(cat => cat.Topics)
                .ThenInclude(topic => topic.Subjects)
                .ThenInclude(subject => subject.Posts)
                .ToList();

            foreach (var category in categories)
            {
                foreach (var topic in category.Topics)
                {
                    foreach (var subject in topic.Subjects)
                    {
                        var post = subject.Posts.FirstOrDefault();
                        items.Add(new SyndicationItem(subject.Name, post.Text, new Uri($"http://localhost:13021/post/{post.Id}"), $"http://localhost:13021", post.Time));                      
                    }
                }
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

                string fileName = "feed.xml";
                string rootPath = Path.Combine(hostEnvironment.ContentRootPath, "ClientApp\\public\\");
                string filePath = Path.Combine(rootPath, fileName);

                using (var file = new FileStream(filePath, FileMode.Create))
                {
                    stream.WriteTo(file);
                }

                return new JsonResult(fileName);
            }
        }
    }
}
