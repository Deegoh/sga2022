using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StoryScreenMenu : MonoBehaviour
{
    [SerializeField] private Button _suivantButton;
	[SerializeField] private TextMeshProUGUI _suivant;
    private GameObject _lastselect;

    void Start()
    {
        _suivantButton.onClick.AddListener(Next);
        EventSystem.current.firstSelectedGameObject = _suivantButton.gameObject;
    }

	private void Update()
	{
		// if (!EventSystem.current.currentSelectedGameObject)
		// {
		// 	EventSystem.current.SetSelectedGameObject(_lastselect);
		// }
		// else
		// {
		// 	_lastselect = EventSystem.current.currentSelectedGameObject;
		// }
		// _suivant.color = new Color(0, 242, 255);
		switch (EventSystem.current.currentSelectedGameObject.name)
		{
			case "Suivant":
				_suivant.color = new Color(255, 215, 0);
				break;
		
		}
	}

    private void OnDestroy()
	{
		_suivantButton.onClick.RemoveListener(Next);
	}

    public void Next()
	{
		GameManager.instance.DeathScreen();
	}
}
