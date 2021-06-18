using System;
using TrelloWebService.TrelloClasses;
using UnityEngine;
using UnityEngine.UI;

namespace ViewModels
{
	public class TrelloInformation: MonoBehaviour, ATrelloWindow
	{
		[SerializeField]
		private GUI_TrelloInformation _gui;
		public TrelloCard _trelloCard;

		public Button BackButton()
		{
			return _gui.BackButton;
		}

		public Button DeleteButton()
		{
			return _gui.DeleteButton;
		}

		public void Init(TrelloCard trelloCard)
		{
			_gui.Text.text = trelloCard.desc;
			_trelloCard = trelloCard;
		}

		public void DestroyWindow()
		{
			Destroy(this.gameObject);
		}
	}
}
