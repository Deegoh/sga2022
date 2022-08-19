using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[Header("MainMenu")]
	[SerializeField] private Button _startButton;
	[SerializeField] private Button _creditButton;
	[SerializeField] private Button _quitButton;
	[SerializeField] private TextMeshProUGUI _start;
	[SerializeField] private TextMeshProUGUI _credit;
	[SerializeField] private TextMeshProUGUI _quit;
	private GameObject _lastselect;
	[Header("Animator")]
	[SerializeField] private Animator startAnimation;

	private void Start()
	{
		_startButton.onClick.AddListener(StartGame);
		_creditButton.onClick.AddListener(CreditGame);
		_quitButton.onClick.AddListener(QuitGame);
		if (!SoundTracker.instance.bgSource[0].isPlaying)
			SoundTracker.instance.PlayBgMenu();
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
		_start.color = new Color(0, 242, 255);
		_credit.color = new Color(0, 242, 255);
		_quit.color = new Color(0, 242, 255);
		switch (_lastselect.name)
		{
			case "StartButton":
				_start.color = new Color(255, 215, 0);
				break;
			case "CreditButton":
				_credit.color = new Color(255, 215, 0);
				break;
			case "EndButton":
				_quit.color = new Color(255, 215, 0);
				break;
		}
	}

	private void OnDestroy()
	{
		_startButton.onClick.RemoveListener(StartGame);
		_creditButton.onClick.RemoveListener(CreditGame);
		_quitButton.onClick.RemoveListener(QuitGame);
	}

	IEnumerator Strat()
	{
		SoundTracker.instance.PlayTypebell();
		while (SoundTracker.instance.sfxSource[0].isPlaying)
		{
			yield return null;
		}
		SoundTracker.instance.PlayBgMenu();
		SoundTracker.instance.PlayBgShady();
		GameManager.instance.StartGame();
	}
	
	private IEnumerator Credit()
	{
		SoundTracker.instance.PlayTypebell();
		while (SoundTracker.instance.sfxSource[0].isPlaying)
		{
			yield return null;
		}
		GameManager.instance.ShowCredits();
	}

	private IEnumerator Quit()
	{
		SoundTracker.instance.PlayTypebell();
		while (SoundTracker.instance.sfxSource[0].isPlaying)
		{
			yield return null;
		}
		GameManager.instance.QuitGame();
	}

	IEnumerator waitForStartingAnimation()
	{
		startAnimation.SetBool("started", true);
		yield return new WaitForSeconds(4.5f);
		GameManager.instance.StartGame();
	}

	public void StartGame()
	{
		StartCoroutine(Strat());
		StartCoroutine(waitForStartingAnimation());
	}

	public void CreditGame()
	{
		StartCoroutine(Credit());
	}

	public void QuitGame()
	{
		StartCoroutine(Quit());
	}
}
