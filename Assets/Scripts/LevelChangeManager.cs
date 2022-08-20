using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeManager : MonoBehaviour
{
    public static LevelChangeManager Instance;
    [SerializeField] private Animator fadeIn;


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
        // if (isItTheEnd())
        // {
        //     _camera.GetComponent<FollowPlayer>().Stop();
        //     Destroy(spawner);
        //     foreach (var star in LevelManager.Instance.Paragraphs.stars)
        //     {
        //         Destroy(star.gameObject);
        //     }
        //     Debug.Log("C la fin!");
        // }
        //else
        //{
            //for (int i = 0; i < LevelManager.Instance.Paragraphs.stars.Count - 1; i++)
            //{
              //  LevelManager.Instance.Paragraphs.stars.Remove(LevelManager.Instance.Paragraphs.stars[i]);
                //Destroy(LevelManager.Instance.Paragraphs.stars[i].gameObject);
            //}
            //foreach (var star in LevelManager.Instance.Paragraphs.stars)
            //{
             //   Destroy(star.gameObject);
            //    LevelManager.Instance.Paragraphs.stars.Remove(star);
            //}
        //}
    }

    private bool isItTheEnd()
    {
        foreach (var sentence in LevelManager.Instance.Paragraphs.sentences)
        {
            if (sentence.Length != 0)
                return false;
        }
        return true;
    }

    private void CheckLevelSuccess()
    {
        if (LevelManager.Instance.failedInputs > 10)
        {
            GameManager.instance.indexOfDeath = LevelManager.Instance.level;
            StartCoroutine(waitForFade());

        }
    }

    IEnumerator waitForFade()
    {
        fadeIn.SetTrigger("fadeIn 0");
        yield return new WaitForSeconds(4f);
        SoundTracker.instance.PlayBgShady();
        SoundTracker.instance.PlayBgAmbient();
        GameManager.instance.StoryScreen();
    }
}
