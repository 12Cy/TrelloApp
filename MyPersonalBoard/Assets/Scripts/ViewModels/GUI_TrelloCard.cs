using System.Collections;
using System.Collections.Generic;
using TMPro;
using TrelloWebService.TrelloClasses;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;

public class GUI_TrelloCard : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text = default;
	[SerializeField]
	private Button _button = default;

	public Button GetButton()
	{
		return _button;}


	public void Init(TrelloCard trelloCard)
	{
		_text.text = trelloCard.name;
	}
}
