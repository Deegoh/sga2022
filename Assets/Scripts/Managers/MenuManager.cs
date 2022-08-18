using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[Header("MainMenu")]
	public Button startButton;
	public Button creditButton;
	public Button quitButton;

	void Start()
	{
		startButton.onClick.AddListener(StartGame);
		creditButton.onClick.AddListener(CreditGame);
		quitButton.onClick.AddListener(QuitGame);
	}


	private void OnDestroy()
	{
		startButton.onClick.RemoveListener(StartGame);
		creditButton.onClick.RemoveListener(CreditGame);
		quitButton.onClick.RemoveListener(QuitGame);
	}

	public void StartGame()
	{
		GameManager.instance.StartGame();
	}

	public void CreditGame()
	{
		GameManager.instance.ShowCredits();
	}

	public void QuitGame()
	{
		GameManager.instance.QuitGame();
	}
}
