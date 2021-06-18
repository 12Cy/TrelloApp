using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI_WeatherAPI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text = default;
	
	private void Start()
	{
		WeatherAPI weatherAPI = new WeatherAPI();
		_text.text = "Temperatur: " + weatherAPI.GetWeatherTemperatur().ToString("0.00");
	}
}
