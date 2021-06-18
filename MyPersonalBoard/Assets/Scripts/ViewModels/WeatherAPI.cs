using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Models;
using Newtonsoft.Json;
using TrelloWebService.TrelloClasses;
using UnityEngine;

public class WeatherAPI
{

	private const string KEY = "132947285fb021dfd8a5a85e59f3ce8a";
	private HttpClient _client;

	public WeatherAPI()
	{
		_client = new HttpClient();
		_client.BaseAddress = new Uri("http://api.openweathermap.org");
		//Hier werden alle Sachen gesetzt für den Client (usw)
	}

    public float GetWeatherTemperatur()
	{
		var requestGet = new HttpRequestMessage(HttpMethod.Get, "/data/2.5/weather?q=Magdeburg&appid=" + KEY);
		var response = _client.SendAsync(requestGet);
		//Wird ausgeführt, wenn der Server geantwortet hat
		var result = response.Result.Content.ReadAsStringAsync().Result; //Json Format
		var weatherContainer = JsonConvert.DeserializeObject<WeatherContainer>(result);
		return weatherContainer.main.temp - 273.15f;
	}
}
