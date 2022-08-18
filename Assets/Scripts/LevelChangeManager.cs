using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeManager : MonoBehaviour
{
    public static LevelChangeManager Instance;
    
    public struct EvolvingElements
    {
        
    }
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    public void ChangeLevelHandler()
    {
        if (LevelManager.Instance.level != 0)
            LevelSuccess();
        TextManager.Instance.UpdateText();
        if (TextManager.Instance.currentTextIndex != 1 && TextManager.Instance.currentTextIndex % 2 == 0)
            LevelManager.Instance.level++;
    }

    private void LevelSuccess()
    {
        if (LevelManager.Instance.failedInputs > LevelManager.Instance.Paragraphs.sentences[LevelManager.Instance.level - 1].Length)
        {
            Debug.Log("You failed loooser");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
