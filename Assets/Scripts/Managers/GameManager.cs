using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public int indexOfDeath;

	private void Awake()
	{
		// Cursor.visible = false; 
		// Cursor.lockState = CursorLockMode.Locked;
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
		SceneManager.LoadScene("Level");
	}
	
	public void ShowCredits()
	{
		Debug.Log("credit");
		// SceneManager.LoadScene("Game");
	}

	public void QuitGame()
	{
		Debug.Log("quit");
		Application.Quit();
	}

	public void ReturnMainMenu()
	{
		Debug.Log("mainMenu");
		SceneManager.LoadScene("MainMenu");
	}
}
