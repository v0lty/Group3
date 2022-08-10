import { writeFileSync } from "fs";
import { getAllPosts } from "./Posts";
import RSS from "rss";
export default async function getRSS() {
    const siteURL = "https://yourdomain.com";
    const allNews = getAllPosts();

    const feed = new RSS({
        title: "Topic",
        description: "Your ´description",
        site_url: siteURL,
        feed_url: `${siteURL}/feel.xml`,
        language: "en",
        pupDate: new Date(),
        copyright: `All rights reserved ${new Date().getFullYear()}, Your Name`,
    });

    allNews.map((post) => {
        feed.item({
            title: post.title,
            url: `${siteURL}/news/${post.slug}`,
            date: post.date,
            description: post.excerpt,
        });
    });

    writeFileSync("./public/feed.xml", feed.xml({ intent: true }));
}