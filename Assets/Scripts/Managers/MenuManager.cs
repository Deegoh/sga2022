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
	[SerializeField] private Animator startAnimation;

		[Header("Sound")]
	public AudioSource sfxSource;
	public AudioClip sfxButton;
	private GameObject _lastselect;

	private void Start()
	{
		_startButton.onClick.AddListener(StartGame);
		_creditButton.onClick.AddListener(CreditGame);
		_quitButton.onClick.AddListener(QuitGame);
		sfxSource.clip = sfxButton;
	}

	private void Update()
	{
		// _start.color = Color.white;
		if (!EventSystem.current.currentSelectedGameObject)
		{
			EventSystem.current.SetSelectedGameObject(_lastselect);
		}
		else
		{
			// _lastselect.GetComponentInChildren<TextMeshProUGUI>().color = new Color(255, 215, 0);
			_lastselect = EventSystem.current.currentSelectedGameObject;
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
		// StartCoroutine(sfxPlay());
		startAnimation.SetBool("started", true);
		StartCoroutine(waitForStartingAnimation());
		GameManager.instance.StartGame();
	}
	
	IEnumerator waitForStartingAnimation()
	{
		yield return new WaitForSeconds(5);
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
