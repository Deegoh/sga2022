using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	[Header("PauseMenu")]
	public Button playButton;
	public Button quitButton;
	public Canvas PauseMenu;

	void Start()
	{
		playButton.onClick.AddListener(PlayGame);
		quitButton.onClick.AddListener(QuitGame);
		PauseMenu = GetComponent<Canvas> ();
	}
	
	void Update() 
	{
		if (Input.GetKeyUp(KeyCode.Escape)) 
		{
			PlayGame();
		}
	}

	private void OnDestroy()
	{
		playButton.onClick.RemoveListener(PlayGame);
		quitButton.onClick.RemoveListener(QuitGame);
	}

	public void QuitGame()
	{
		GameManager.instance.QuitGame();
	}

	public void PlayGame()
	{
		PauseMenu.enabled = !PauseMenu.enabled;
		GameManager.instance.PauseGame();
	}
}