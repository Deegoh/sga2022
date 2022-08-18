using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public static bool gameIsPaused;

	private void Awake()
	{
		if (!instance)
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void StartGame()
	{
		Debug.Log("start");
		SceneManager.LoadScene("Ben");
	}
	
	public void ShowCredits()
	{
		Debug.Log("credit");
		// SceneManager.LoadScene("Game");
	}

	public void PauseGame()
	{
		if(gameIsPaused)
		{
			Debug.Log("Play");
			Time.timeScale = 1;
			// AudioListener.pause = true;
		}
		else 
		{
			Debug.Log("Pause");
			// pause.SetActive(true);
			Time.timeScale = 0f;
			// AudioListener.pause = false;
		}
		gameIsPaused = !gameIsPaused;
	}

	public void QuitGame()
	{
		Debug.Log("quit");
		Application.Quit();
	}

	public void ReturnMainMenu()
	{
		Debug.Log("mainMenu");
		// SceneManager.LoadScene("MainMenu");
	}
}
