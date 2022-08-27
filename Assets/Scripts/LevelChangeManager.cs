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
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _spawner;


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
        foreach (var star in LevelManager.Instance.Paragraphs.stars)
        {
             if (star)
                 Destroy(star.gameObject);
        }
        LevelManager.Instance.Paragraphs.stars.Clear();

        CheckLevelSuccess();
        TextManager.Instance.UpdateText();
        if (isItTheEnd())
        {
            Destroy(_spawner);
            _camera.GetComponent<FollowPlayer>().SetSpeed(8);
        }
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
