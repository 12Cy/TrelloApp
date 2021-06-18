using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TrelloWebService.TrelloClasses;
using UnityEngine;

[System.Serializable]
public class TrelloAPI
{
	string key = "2a1614fc5d7a3f220d33a345354de280";
	string token = "19edef199ba07aba8d63c62f6f0f5781bce3584c030ebdf06a58ad21dac8cb4c";
	private HttpClient _client = default;

	public TrelloAPI()
	{
		_client = new HttpClient();
		_client.BaseAddress = new Uri("https://api.trello.com/");
	}

	public IEnumerable<TrelloCard> GetTrelloCards()
	{
		var requestGet = new HttpRequestMessage(HttpMethod.Get, "1/lists/60912143c1ac6f0757dc42e9/cards/?key=" + key + "&token=" + token);
		var response = _client.SendAsync(requestGet);
				//Wird ausgeführt, wenn der Server geantwortet hat
		var result = response.Result.Content.ReadAsStringAsync().Result; //Json Format
		var cardsFromList = JsonConvert.DeserializeObject<TrelloCard[]>(result);
		return cardsFromList;
	}

	public void CreateNewCard(string name, string description)
	{
		var requestPost = new HttpRequestMessage(HttpMethod.Post, "1/cards?key=" + key + "&token=" + token + "&name=" + name + "&idList=60912143c1ac6f0757dc42e9");
		
		Dictionary<string, string> dic = new Dictionary<string, string>
		{
				{
						"desc", description
				}
		};

		

		requestPost.Content = new FormUrlEncodedContent(dic);
		var asd = _client.SendAsync(requestPost);
	}

	public void DestroyTrelloCard(TrelloCard card)
	{
		var requestPost = new HttpRequestMessage(HttpMethod.Delete, "1/cards/"+ card.id +"?key=" + key + "&token=" + token);
		_client.SendAsync(requestPost);

	}
}
