using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private Sentences sentences;
    [SerializeField] private GameObject prefabParticles;
    [SerializeField] private int failedInputs;

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
                if (Char.ToLower(star._letter) == c)
                {
                    Instantiate(prefabParticles, star.transform.position, Quaternion.identity);
                    Destroy(star.gameObject);
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
    }
}