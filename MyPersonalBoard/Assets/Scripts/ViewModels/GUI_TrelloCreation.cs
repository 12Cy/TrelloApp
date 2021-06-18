using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_TrelloCreation : MonoBehaviour
{
	[SerializeField]
	private TMPro.TMP_InputField _name;

	[SerializeField]
	private TMPro.TMP_InputField _description;
	[SerializeField]
	private Button _createButton;
	[SerializeField]
	private Button _backButton;

	public TMP_InputField GetName => _name;
	public TMP_InputField GetDescription => _description;
	public Button GetCreateButton => _createButton;
	public Button GetBackButton => _backButton;
}
