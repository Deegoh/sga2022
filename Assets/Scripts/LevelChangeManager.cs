using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // foreach (var star in LevelManager.Instance.Paragraphs.stars)
        // {
        //     if (star)
        //         Destroy(star.gameObject);
        // }
        // if (LevelManager.Instance.level)
        CheckLevelSuccess();
        TextManager.Instance.UpdateText();
        if (TextManager.Instance.currentTextIndex != 1 && TextManager.Instance.currentTextIndex % 2 == 0)
            LevelManager.Instance.level++;
    }

    private void CheckLevelSuccess()
    {
        if (LevelManager.Instance.failedInputs > LevelManager.Instance.Paragraphs.sentences[LevelManager.Instance.level].Length)
        {
            GameManager.instance.indexOfDeath = LevelManager.Instance.level;
            SoundTracker.instance.PlayBgShady();
            SoundTracker.instance.PlayBgAmbient();
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
