using System;
using System.Security.Cryptography;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private Sentences sentences;

    public Sentences Paragraphs
    {
        get => sentences;
        set => sentences = value;
    }

    private void Update()
    {
        var stars = GameObject.FindGameObjectsWithTag("Star");
        foreach (char c in Input.inputString)
        {
            foreach (var star in stars)
            {
                if (Char.ToLower(star.GetComponent<IAStars>()._letter) == c)
                {
                    Destroy(star);
                }
                else
                    Debug.Log("NOT IN STARS");
            }
        }
    }
    private void Awake()
    {
        Instance = this;
    }
}