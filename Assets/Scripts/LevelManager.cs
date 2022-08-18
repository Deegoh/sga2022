using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    public Dictionary<char, int> Alphabet = new();
    [Header("Sentences")]
    [SerializeField] private Sentences sentences;
    [SerializeField] private GameObject prefabParticles;
    public int failedInputs;

    [Header("Sprites for Stars")]
    public char letter;
    [SerializeField] public List<Sprite> starSprites;
    
    public enum GameState
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    public int level;

    public Sentences Paragraphs
    {
        get => sentences;
        set => sentences = value;
    }

    private void Update()
    {
        // Update is checking for user input and comparing the char with the paragraph
        foreach (char c in Input.inputString)
        {
            foreach (var star in Paragraphs.stars)
            {
                if (Char.ToLower(star.personalLetter) == c)
                {
                    Instantiate(prefabParticles, star.transform.position, Quaternion.identity);
                    Paragraphs.stars.Remove(star);
                    // LevelManager.Instance.Paragraphs.removeChar(LevelManager.Instance.letter);
                    Destroy(star.gameObject);
                    return;
                }
                else
                {
                    failedInputs++;
                    Thread.Sleep(100);
                    Debug.Log("The number of failed inputs: " + failedInputs);
                }
            }
        }
    }

    private void Awake()
    {
        Instance = this;
        int i = 0;
        for (char letter = 'a'; letter < 'z'; letter++)
            Alphabet.Add(letter, i++);
    }
}