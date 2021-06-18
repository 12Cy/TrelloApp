using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI_JokeAPI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text = default;
	private void Start()
	{
		JokeAPI _jokeAPI = new JokeAPI();
		_text.text = _jokeAPI.GetJoke();


	}
}
