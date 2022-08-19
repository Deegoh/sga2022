using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	[Header("PauseMenu")]
	[SerializeField] private Button _playButton;
	[SerializeField] private Button _quitButton;
	[SerializeField] private TextMeshProUGUI _play;
	[SerializeField] private TextMeshProUGUI _quit;
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
		_play.color = new Color(0, 242, 255);
		_quit.color = new Color(0, 242, 255);
		switch (_lastselect.name)
		{
			case "Continuer":
				_play.color = new Color(255, 215, 0);
				break;
			case "Quit":
				_quit.color = new Color(255, 215, 0);
				break;
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