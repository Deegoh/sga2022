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
	[Header("Sound")]
	public AudioSource sfxSource;
	public AudioClip sfxButton;
	private GameObject _lastselect;
	[Header("Animator")]
	[SerializeField] private Animator startAnimation;

	private void Start()
	{
		_startButton.onClick.AddListener(StartGame);
		_creditButton.onClick.AddListener(CreditGame);
		_quitButton.onClick.AddListener(QuitGame);
		sfxSource.clip = sfxButton;
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

	private IEnumerator sfxPlay()
	{
		sfxSource.Play();
		yield return new WaitForSeconds(sfxSource.clip.length);
	}
	public void StartGame()
	{
		StartCoroutine(sfxPlay());
		startAnimation.SetBool("started", true);
		StartCoroutine(waitForStartingAnimation());
	}
	
	IEnumerator waitForStartingAnimation()
	{
		yield return new WaitForSeconds(4.5f);
		GameManager.instance.StartGame();
	}

	public void CreditGame()
	{
		StartCoroutine(sfxPlay());
		GameManager.instance.ShowCredits();
	}

	public void QuitGame()
	{
		StartCoroutine(sfxPlay());
		GameManager.instance.QuitGame();
	}
}
