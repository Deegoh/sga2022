using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public int indexOfDeath;
	public bool ending = false;

	private void Awake()
	{
		Cursor.visible = false; 
		Cursor.lockState = CursorLockMode.Locked;
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
		SceneManager.LoadScene("Level");
	}
	
	public void ShowCredits()
	{
		SceneManager.LoadScene("Credit");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void ReturnMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void DeathScreen()
	{
		SceneManager.LoadScene("DeathScreen");
	}
}
