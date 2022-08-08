using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Group3.Models
{
    public class NewsPosts
    {
        public static IEnumerable<News> GetBlogPosts()
        {
            var posts = new List<News>();
            posts.Add(new News()
            {
                Title = "A Professional ASP.NET Core - RSS",
                UrlSlug = "a-professional-asp.net-core-rss",
                Description = "RSS feeds provide an excellent mechanism for websites to publish their content for consumption by others.",
                CreatedDate = new DateTime(2020, 10, 9)
            });
            posts.Add(new News()
            {
                Title = "A Professional ASP.NET Core API - Caching",
                UrlSlug = "a-professional-asp.net-core-api-caching",
                Description = "Caching is a technique of storing the frequently accessed/used data so that the future requests for those sets of data can be served much faster to the client..",
                CreatedDate = new DateTime(2020, 10, 5)
            });
            posts.Add(new News()
            {
                Title = "Using Tailwind CSS with Aurelia 2 and Webpack",
                UrlSlug = "aurelia-2-with-tailwindcss-and-webpack",
                Description = "Tailwind CSS is a highly customizable, low-level CSS framework that gives you all of the building blocks you need to build bespoke designs without any annoying opinionated styles you have to fight to override.",
                CreatedDate = new DateTime(2020, 7, 23)
            });
            return posts;
        }
    }
}
