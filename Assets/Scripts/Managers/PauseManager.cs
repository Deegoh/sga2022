using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	[Header("PauseMenu")]
	[SerializeField] private Button _playButton;
	[SerializeField] private Button _quitButton;
	[SerializeField] private Canvas _pauseMenu;
	private bool _isPause;
	private GameObject _lastselect;

	private void Start()
	{
		_playButton.onClick.AddListener(PlayGame);
		_quitButton.onClick.AddListener(QuitGame);
		_pauseMenu.GetComponent<Canvas>();
		_pauseMenu.enabled = false;
	}
	
	private void Update() 
	{
		if (Input.GetKeyUp(KeyCode.Escape)) 
		{
			PlayGame();
		}
		if (!EventSystem.current.currentSelectedGameObject)
		{
			EventSystem.current.SetSelectedGameObject(_lastselect);
		}
		else
		{
			_lastselect = EventSystem.current.currentSelectedGameObject;
		}
	}

	private void OnDestroy()
	{
		_playButton.onClick.RemoveListener(PlayGame);
		_quitButton.onClick.RemoveListener(QuitGame);
	}

	public void QuitGame()
	{
		GameManager.instance.QuitGame();
	}

	public void PlayGame()
	{
		if (_isPause)
		{
			_pauseMenu.enabled = false;
			Time.timeScale = 1;
		}
		else
		{
			Time.timeScale = 0f;
			_pauseMenu.enabled = true;
		}
		_isPause = !_isPause;
	}
}