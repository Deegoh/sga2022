using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public int currentTextIndex;
    public static TextManager Instance;
    private string colorMarkupIn = "<color=yellow>";
    private string colorMarkupOut = "</color>";
    [SerializeField] private TMP_Text textOutput;

    private string[] _remainingLetters;
    private string[] _paragraphs = new[]
    {
        // "À l’aube du crépuscule,\nSommeille l’univers,\nVide, à la recherche de lumière,\nOu d’un unique corpuscule",
        "aaa",
        "bbb",
        "c",
        "d"
        // "Un monde sombre,\nC’est dans celui-ci que je vis,\nMais un jour l’on ma dit,\nQue quelqu’un me sortirait de l’ombre",
        // "D’attendre, fut une rude épreuve,\nTel l’arbre, je sentis des racines pousser,\nLes jours, les mois, les années, ne voulurent passer,\nJ’étais à court d’idées neuves"
    };
    // Start is called before the first fr1ame update
    void Start()
    {
        textOutput.text = _paragraphs[0];
        _remainingLetters = (string[])_paragraphs.Clone();
    }

    public void UpdateText()
    {
        Debug.Log("GIGA CHAD LOL");
        textOutput.text = _paragraphs[++currentTextIndex];
    }

    public void OnCorrectLetter(char letter)
    {
        UpdateRemainingLetters(letter);
        ColorLetter(letter);
    }

    private void ColorLetter(char letter)
    {
        string newString = _paragraphs[currentTextIndex];
        int i = 0;
        
        for (int j = 0; j < newString.Length; j++)
        {
            if (_remainingLetters[currentTextIndex][i] == '*')
            {
                // to bypass when i = 0
                if (j > 0)
                {
                    if (_remainingLetters[currentTextIndex][i - 1] == '*')
                    {
                        newString = newString.Insert(j - colorMarkupOut.Length, _paragraphs[currentTextIndex][i].ToString());
                        newString = newString.Remove(j + 1, 1);
                        ++i;
                        continue ;
                    }
                }
                newString = newString.Insert(j, colorMarkupIn + _paragraphs[currentTextIndex][i] + colorMarkupOut);
                j += colorMarkupIn.Length + colorMarkupOut.Length;
                newString = newString.Remove(j + 1, 1);
            }
            ++i;
        }
        textOutput.text = newString;
    }
    
    private void UpdateRemainingLetters(char letter)
    {
        int i = 0;
        
        i = _remainingLetters[currentTextIndex].IndexOf(letter);
  
        _remainingLetters[currentTextIndex] = _remainingLetters[currentTextIndex].Remove(i, 1).Insert(i, "*");
    }

    private void Awake()
    {
        Instance = this;
    }
}
