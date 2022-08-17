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
            var feed = new SyndicationFeed("Title", "Description", new Uri("http://localhost:13021/feed.xml"), "RSSUrl", DateTime.Now);
            feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Year} Group 3");
            var items = new List<SyndicationItem>();

            var categories = dbContext.Categories
                .Include(cat => cat.UserGroup)
                .ThenInclude(x => x.UserGroupEnlistments)
                .ThenInclude(x => x.User)
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
                        foreach (var post in subject.Posts)
                        {
                            // NOTE: Generate SyndicationItem here
                            // items.Add(SyndicationItem);
                        }
                    }
                }
            }

            // This can be removed after generated real items
            var postings = NewsPosts.GetBlogPosts();
            foreach (var item in postings)
            {
                var postUrl = Url.Action("Article", "Blog", new { id = item.UrlSlug }, HttpContext.Request.Scheme);
                var title = item.Title;
                var description = item.Description;
                items.Add(new SyndicationItem(title, description, new Uri(postUrl), item.UrlSlug, item.CreatedDate));
            }

            // Leave this
            feed.Items = items;
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                NewLineHandling = NewLineHandling.Entitize,
                NewLineOnAttributes = true,
                Indent = true
            };

            string fileName = "feed.xml";

            using (var stream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    var rssFormatter = new Rss20FeedFormatter(feed, false);
                    rssFormatter.WriteTo(xmlWriter);
                    xmlWriter.Flush();
                }

                string rootPath = Path.Combine(hostEnvironment.ContentRootPath, "ClientApp\\public\\");
                string filePath = Path.Combine(rootPath, fileName);

                // this causing page to reload..
                using (var file = new FileStream(filePath, FileMode.Create))
                {
                    stream.WriteTo(file);
                }          
            }

            return new JsonResult(fileName);
        }
    }
}
