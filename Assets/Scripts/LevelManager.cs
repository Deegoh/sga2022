using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Dictionary<char, int> Alphabet = new();
    [Header("Sentences")] [SerializeField] private Sentences sentences;
    [SerializeField] private GameObject prefabParticles;
    public int failedInputs;

    [Header("Sprites for Stars")] public char letter;
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

    private void OnGUI()
    {
        Event e = Event.current;

        string keyString = e.keyCode.ToString();

        //Check the type of the current event, making sure to take in only the KeyDown of the keystroke.
        //char.IsLetter to filter out all other KeyCodes besides alphabetical.
        bool isAlphabeticalChar = e.type == EventType.KeyDown && keyString.Length == 1 && char.IsLetter(keyString[0]);
        if (!isAlphabeticalChar || PauseManager.Instance._isPause)
            return;
        char c = keyString.ToLower()[0];
        int oldInput = failedInputs;
        List<char> letters = new List<char>();
        foreach (IAStars star in Paragraphs.stars)
        {
            letters.Add(char.ToLower(star.personalLetter));
        }
        foreach (IAStars star in Paragraphs.stars)
        {
            if (char.ToLower(star.personalLetter) == c)
            {
                TextManager.Instance.OnCorrectLetter(c);
                Instantiate(prefabParticles, star.transform.position, Quaternion.identity);
                Paragraphs.stars.Remove(star);
                Instance.Paragraphs.removeChar(c);
                if (star)
                    Destroy(star.gameObject);
                SoundTracker.instance.PlayType();
                break;
            }
            else if (!letters.Contains(c))
            {
                if (failedInputs == oldInput)
                    failedInputs++;
                // Debug.Log("The number of failed inputs: " + failedInputs);
            }
        }
    }

    // private void Update()
    // {
    //     // Update is checking for user input and comparing the char with the paragraph
    //     foreach (char c in Input.inputString)
    //     {
    //         foreach (var star in Paragraphs.stars)
    //         {
    //             if (Char.ToLower(star.personalLetter) == c)
    //             {
    //                 TextManager.Instance.OnCorrectLetter(c);
    //                 Instantiate(prefabParticles, star.transform.position, Quaternion.identity);
    //                 Paragraphs.stars.Remove(star);
    //                 Instance.Paragraphs.removeChar(Instance.letter);
    //                 Destroy(star.gameObject);
    //                 return;
    //             }
    //             else
    //             {
    //                 failedInputs++;
    //                 Thread.Sleep(100);
    //                 Debug.Log("The number of failed inputs: " + failedInputs);
    //             }
    //         }
    //     }
    // }

    private void Awake()
    {
        Instance = this;
        int i = 0;
        for (char letter = 'a'; letter < 'z'; letter++)
            Alphabet.Add(letter, i++);
    }
}