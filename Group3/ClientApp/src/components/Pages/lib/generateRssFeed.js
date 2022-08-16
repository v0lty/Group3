import { writeFileSync } from "fs";
import RSS from "rss";
import API from "../API";

export default async function getRSS() {
    const siteURL = "http://localhost:13021";
    const allNews = API.getAllPosts();

    const feed = new RSS({
        title: "Software development communnity",
        description: "A forum for a software development community",
        site_url: siteURL,
        feed_url: `${siteURL}/feed.xml`,
        language: "en",
        pubDate: new Date(),
        copyright: `All rights reserved ${new Date().getFullYear()}, My Name`,
    });

    allNews.map((post) => {
        feed.item({
            title: post.title,
            url: `${siteURL}/blogs/${post.slug}`,
            date: post.date,
            description: post.excerpt,
        });
    });

    writeFileSync("./public/feed.xml", feed.xml({ indent: true }));
}