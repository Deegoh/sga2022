using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    public Dictionary<char, int> Alphabet = new();
    [SerializeField] private Sentences sentences;
    [SerializeField] private GameObject prefabParticles;
    [SerializeField] private int failedInputs;

    [Header("spritesStars")]
    public char letter;
    [SerializeField] public List<Sprite> starSprites;
    public int gameState;

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
                    Destroy(star.gameObject);
                    return;
                }
                else
                {
                    failedInputs++;
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