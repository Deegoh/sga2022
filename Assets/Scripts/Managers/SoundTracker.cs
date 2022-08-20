using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class SoundTracker : MonoBehaviour
{
	public static SoundTracker instance;
	[Header("Sound")]
	public AudioSource[] bgSource;
	public AudioSource[] sfxSource;
	private static int rand = 1;

	void Awake()
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

	public void PlayBgMenu()
	{
		if (!bgSource[0].isPlaying)
		{
			bgSource[0].Play();
		}
		else
		{
			bgSource[0].Stop();
		}
	}

	public void PlayBgShady()
	{
		if (!bgSource[1].isPlaying)
		{
			bgSource[1].Play();
			PlayBgInsect();
		}
		else
		{
			bgSource[1].Stop();
			PlayBgInsect();
		}
	}

	public void PlayBgAmbient()
	{
		if (!bgSource[2].isPlaying)
		{
			bgSource[2].Play();
		}
		else
		{
			bgSource[2].Stop();
		}
	}
	
	public void PlayBgInsect()
	{
		if (!bgSource[3].isPlaying)
		{
			bgSource[3].Play();
		}
		else
		{
			bgSource[3].Stop();
		}
	}

	public void PlayTypebell()
	{
		sfxSource[0].Play();
	}

	public void PlayType()
	{
		int nextRand;
		nextRand = Random.Range(1, 4);
		while (nextRand == rand)
		{
			nextRand = Random.Range(1, 4);
		}
		rand = nextRand;
		sfxSource[rand].Play();
	}

	public void PlayType1()
	{
		sfxSource[1].Play();
	}

	public void PlayType2()
	{
		sfxSource[2].Play();
	}

	public void PlayType3()
	{
		sfxSource[3].Play();
	}
	
	public void PlayMenu()
	{
		sfxSource[4].Play();
	}
}