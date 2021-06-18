using System;
using System.Collections;
using System.Collections.Generic;
using TrelloWebService.TrelloClasses;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;

public class GUI_TrelloAPI : MonoBehaviour
{
	private TrelloAPI _trelloApi;
	[SerializeField]
	private Transform _anchor = default;
	[SerializeField]
	private GUI_TrelloCard _trelloCardPrefab = default;
	private List<GUI_TrelloCard> _trelloCards;
	[SerializeField]
	private Button _refreshButton = default;
	[SerializeField]
	private Button _createButton = default;

	[SerializeField]
	private TrelloInformation _trelloInformationPrefab = default;
	[SerializeField]
	private TrelloCreation _creationPrefab = default;
	[SerializeField]
	private Transform _trelloInformationAnchor = default;
	private ATrelloWindow _currentInstance;

	private float _internTimer = 0.0f;
	private float _timer = 10.0f;

	//ToDo: Outsource interface
	private void Start()
	{
		_trelloCards = new List<GUI_TrelloCard>();
		_trelloApi = new TrelloAPI();
		_refreshButton.onClick.AddListener(RefreshButtonClickedListener);
		_createButton.onClick.AddListener(CreateNewCardListener);
		RefreshTrelloCardInstances();
	}

	private void Update()
	{
		if (_internTimer > _timer)
		{
			_internTimer = 0.0f;
			RefreshTrelloCardInstances();
		}
		else
		{
			_internTimer += Time.deltaTime;
		}
	}

	private void CreateNewCardListener()
	{
		if (_currentInstance != null)
		{
			_currentInstance.DestroyWindow();
		}

		var instance = Instantiate(_creationPrefab, _trelloInformationAnchor);
		instance.GetBackButton().onClick.AddListener(CreationBackButtonListener);
		instance.GetCreate().onClick.AddListener(() => CreateNewCardButton(instance));
		_currentInstance = instance;
	}

	private void CreateNewCardButton(TrelloCreation creationCardWindow)
	{
		_trelloApi.CreateNewCard(creationCardWindow.GetName(), creationCardWindow.GetDescription());
		RefreshTrelloCardInstances();
		CreationBackButtonListener();
	}

	private void CreationBackButtonListener()
	{
		_currentInstance.DestroyWindow();
		_currentInstance = null;
	}

	private void RefreshTrelloCardInstances()
	{
		CleanUpTrelloCards();
		var trellocards = _trelloApi.GetTrelloCards();
		foreach (var item in trellocards)
		{
			var trelloCard = item;
			var instance = Instantiate(_trelloCardPrefab, _anchor);
			instance.Init(trelloCard);
			instance.GetButton().onClick.AddListener(() => ButtonClickedListener(trelloCard));
			_trelloCards.Add(instance);
		}
	}

	private void ButtonClickedListener(TrelloCard item)
	{
		TrelloInformation instance = Instantiate(_trelloInformationPrefab, _trelloInformationAnchor);
		instance.Init(item);
		instance.BackButton().onClick.AddListener(() => TrelloInformationBackButtonPressed(instance));
		instance.DeleteButton().onClick.AddListener(() => TrelloInformationDeletePressed(instance));
		_currentInstance = instance;
	}

	private void TrelloInformationBackButtonPressed(TrelloInformation trelloInformation)
	{
		trelloInformation.DestroyWindow();
		_currentInstance = null;
	}

	private void TrelloInformationDeletePressed(TrelloInformation trelloInformation)
	{
		_trelloApi.DestroyTrelloCard(trelloInformation._trelloCard);
		trelloInformation.DestroyWindow();
		_currentInstance = null;
		RefreshTrelloCardInstances();
	}

	private void CleanUpTrelloCards()
	{
		for (int i = _trelloCards.Count-1; i >= 0; i--)
		{
			var instance = _trelloCards[i];
			_trelloCards.RemoveAt(i);
			Destroy(instance.gameObject);
		}

		if (_trelloCards.Count != 0)
		{
			Debug.LogWarning("TrelloCards are not zero after Clean up");
		}
	}

	private void RefreshButtonClickedListener()
	{
		RefreshTrelloCardInstances();
	}
}
