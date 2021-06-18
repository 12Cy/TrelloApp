using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using News;
using Newtonsoft.Json;
using UnityEngine;

public class NewsAPI
{
	private string Key = "252765dd469f4d609561d0e0a58e1f64";

	public Article GetNews()
	{
		var url = "https://newsapi.org/v2/top-headlines?" +
		          "country=de&" +
		          "apiKey=252765dd469f4d609561d0e0a58e1f64";

		var json = new WebClient().DownloadString(url);
		var articleContainer = JsonConvert.DeserializeObject<ArticleContainer>(json);

		var rndValue = UnityEngine.Random.Range(0, articleContainer.articles.Length - 1);
		return articleContainer.articles[rndValue];
	}

	public Sprite GetImage(string url)
	{
		var imageRawData = new WebClient().DownloadData(url);

		Texture2D texture = new Texture2D(256, 256);
		texture.LoadImage(imageRawData);
		return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
	}
}
