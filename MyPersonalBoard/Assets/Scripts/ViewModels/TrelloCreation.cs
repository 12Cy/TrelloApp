using System;
using UnityEngine;
using UnityEngine.UI;

public class TrelloCreation : MonoBehaviour, ATrelloWindow
{
	[SerializeField]
	private GUI_TrelloCreation _creation = default;

	private void OnValidate()
	{
		if (_creation == null)
		{
			_creation = GetComponent<GUI_TrelloCreation>();
		}
	}

	public Button GetBackButton()
	{
		return _creation.GetBackButton;
	}
	public Button GetCreate()
	{
		return _creation.GetCreateButton;
	}

	public string GetName()
	{
		return _creation.GetName.text;
	}

	public string GetDescription()
	{
		return _creation.GetDescription.text;
	}

	public void DestroyWindow()
	{
		Destroy(this.gameObject);
	}
}