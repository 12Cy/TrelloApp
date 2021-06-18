using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_NewsAPI : MonoBehaviour
{
	[SerializeField]
	private Image _targetImage = default;
	[SerializeField]
	private TextMeshProUGUI _text = default;

	void Start()
    {
	    NewsAPI api = new NewsAPI();
	    var news = api.GetNews();
	    _text.text = news.content;

	    _targetImage.sprite = api.GetImage(news.urlToImage);
    }
}
