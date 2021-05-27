using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrelloApp.Models;
using TrelloWebService.TrelloClasses;

namespace TrelloApp.Services
{
	public class TrelloDataStore : IDataStore<Item>
	{
		readonly List<Item> items;
		string key = "2a1614fc5d7a3f220d33a345354de280";
		string token = "19edef199ba07aba8d63c62f6f0f5781bce3584c030ebdf06a58ad21dac8cb4c";

		public TrelloDataStore()
		{
			items = new List<Item>();
		}

		public Task<bool> AddItemAsync(Item item)
		{
			return Task.FromResult(CreateNewCard(item.Text));
		}

		public Task<bool> UpdateItemAsync(Item item)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> DeleteItemAsync(string id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Item> GetItemAsync(string id)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return Task.FromResult(GetTrelloCards());
		}

		private IEnumerable<Item> GetTrelloCards()
		{
			items.Clear();
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://api.trello.com/");
			var requestGet = new HttpRequestMessage(HttpMethod.Get, "1/lists/60912143c1ac6f0757dc42e9/cards/?key=" + key + "&token=" + token);
			var msg = client.GetAsync(requestGet.RequestUri);

			 //Wird ausgeführt, wenn der Server geantwortet hat
			var result = msg.Result.Content.ReadAsStringAsync().Result; //Json Format

			var cardsFromList = JsonConvert.DeserializeObject<TrelloCard[]>(result);
			foreach (var item in cardsFromList)
			{
				var newItem = new Item
				{
						Description = item.desc,
						Text = item.name,
						Id = item.id

				};
				items.Add(newItem);
				yield return newItem;
			}
		}

		private bool CreateNewCard(string name)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://api.trello.com/");
			var requestPost = new HttpRequestMessage(HttpMethod.Post, "1/cards?key=" + key + "&token=" + token + "&name=" + name + "&idList=60912143c1ac6f0757dc42e9");
			//var requestPost = new HttpRequestMessage(HttpMethod.Post,"https://api.trello.com/1/cards?key=2a1614fc5d7a3f220d33a345354de280&token=19edef199ba07aba8d63c62f6f0f5781bce3584c030ebdf06a58ad21dac8cb4c&name=NewCard&idList=60912143c1ac6f0757dc42e9");
			var asd = client.PostAsync(requestPost.RequestUri, new StringContent("")).Result;
			return true;
		}
	}
}
