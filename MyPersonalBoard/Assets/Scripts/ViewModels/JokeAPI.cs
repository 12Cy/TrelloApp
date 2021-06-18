using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Models;
using Newtonsoft.Json;
using UnityEngine;

public class JokeAPI
{
	private HttpClient _client;
	public JokeAPI()
	{
		_client = new HttpClient();
	}

	public string GetJoke()
	{
		var url = "https://api.chucknorris.io/jokes/random";

		var requestGet = new HttpRequestMessage(HttpMethod.Get, url);
		var response = _client.SendAsync(requestGet);
		//Wird ausgeführt, wenn der Server geantwortet hat
		var result = response.Result.Content.ReadAsStringAsync().Result; //Json Format
		var rawData = JsonConvert.DeserializeObject<JokeContainer>(result);
		return rawData.value;
	}
}
