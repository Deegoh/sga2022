using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[Header("MainMenu")]
	[SerializeField] private Button _startButton;
	[SerializeField] private Button _creditButton;
	[SerializeField] private Button _quitButton;
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
