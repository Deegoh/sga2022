using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditMenu : MonoBehaviour
{
    
	[Header("PauseMenu")]
	[SerializeField] private Button _returnButton;
	[SerializeField] private TextMeshProUGUI _return;
	private GameObject _lastselect;

	void Start()
	{
		_returnButton.onClick.AddListener(ReturnGame);
	}

	private void Update()
	{
		if (!EventSystem.current.currentSelectedGameObject)
		{
			EventSystem.current.SetSelectedGameObject(_lastselect);
		}
		else
		{
			_lastselect = EventSystem.current.currentSelectedGameObject;
		}
		_return.color = new Color(0, 242, 255);
		switch (_lastselect.name)
		{
			case "Retour":
				_return.color = new Color(255, 215, 0);
				break;
		}
	}

	private void OnDestroy()
	{
		_returnButton.onClick.RemoveListener(ReturnGame);
	}

	IEnumerator ReturnMainMenu()
	{
		SoundTracker.instance.PlayTypebell();
		while (SoundTracker.instance.sfxSource[0].isPlaying)
		{
			yield return null;
		}
		GameManager.instance.ReturnMainMenu();
	}

	void ReturnGame()
	{
		StartCoroutine(ReturnMainMenu());
	}
}