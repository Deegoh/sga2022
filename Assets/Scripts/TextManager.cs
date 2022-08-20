using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager Instance;
    public int currentTextIndex;
    private string colorMarkupIn = "<color=yellow>";
    private string colorMarkupOut = "</color>";
    [SerializeField] private TMP_Text textOutput;

    private string[] _remainingLetters;
    private string[] _paragraphs = new[]
    {
        // "À l’aube du crépuscule,\nSommeille l’univers,\nVide, à la recherche de lumière,\nOu d’un unique corpuscule",
        // "au berceau de l’univers,\nou l’air froid du neant est à glacer le sang,\nj’erre, à la recherche d’un sens,\nsans empreinte, sans repere.",
        "salut",
        "de l’aube au crepuscule,\nje me sens minuscule, semblable a une particule,\nvide, je souhaite me retrouver,\na travers cette lumiere, je me sens exister.",
        // "bb"
        // "ccc",
        // "ddd",
        // "Un monde sombre,\nC’est dans celui-ci que je vis,\nMais un jour l’on ma dit,\nQue quelqu’un me sortirait de l’ombre",
        // "D’attendre, fut une rude épreuve,\nTel l’arbre, je sentis des racines pousser,\nLes jours, les mois, les années, ne voulurent passer,\nJ’étais à court d’idées neuves"
    };
    private string _s = String.Empty;
    private List<string> _l = new List<string>();
    private List<string> _par = new List<string>();
    private List<string> _r = new List<string>();
    
    // Start is called before the first fr1ame update
    void Start()
    {
        SetParagraphs();
        textOutput.text = _paragraphs[0];
        _remainingLetters = (string[])_paragraphs.Clone();
    }

    private void SetParagraphs()
    {
        _s = File.ReadAllText("Assets/Text/wordsOnly.txt"); // read .txt to string
        _l = new List<string>(_s.Split('\n')); // string to list

        _r = new List<string>(_l); // create remainingLetters
        for (int i = 0; i < _r.Count; i++)
        {
            _r[i] = _r[i].ToLower(); // remainingLetters to lower
            _r[i] = new Regex("[^a-zA-Z0-9-]").Replace(_r[i], ""); // remainingLetters removed all alphanum
        }

        _par = new List<string>(_l); // create parameters
        for (int j = 0; j < _par.Count; j++)
            _par[j] = _par[j].ToLower();
        
        textOutput.text = _l[0].ToLower(); // update textOutput
        LevelManager.Instance.Paragraphs.sentences = new List<string>(_r); // update sentences 
        _paragraphs = _par.ToArray();
        _remainingLetters = _r.ToArray();
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
                // // to bypass when i = 0
                // if (j > 0)
                // {
                //     if (_remainingLetters[currentTextIndex][i - 1] == '*')
                //     {
                //         newString = newString.Insert(j - colorMarkupOut.Length, _paragraphs[currentTextIndex][i].ToString());
                //         newString = newString.Remove(j + 1, 1);
                //         ++i;
                //         continue ;
                //     }
                // }
                newString = newString.Insert(j, colorMarkupIn + _paragraphs[currentTextIndex][i] + colorMarkupOut);
                j += colorMarkupIn.Length + colorMarkupOut.Length;
                newString = newString.Remove(j + 1, 1);
                // Debug.Log("NEWSTRING IS : " + newString[j + 1]);
                // Debug.Log("REGEX IS : " + new Regex("[a-zA-Z0-9-]"));
                // if (!new Regex("[a-zA-Z0-9 -]").ToString().Contains(newString[j + 1]))
                // {
                //     Debug.Log("INSANE !!");
                //     newString = newString.Insert(j + 1, colorMarkupIn + newString[j + 1] + colorMarkupOut);
                //     j += colorMarkupIn.Length + colorMarkupOut.Length;
                //     newString = newString.Remove(j + 2, 1);
                // }
            }

            ++i;
        }
        textOutput.text = newString;
    }
    
    private void UpdateRemainingLetters(char letter)
    {
        int i = 0;
        
        i = _remainingLetters[currentTextIndex].IndexOf(letter);
        if (i != -1)
            _remainingLetters[currentTextIndex] = _remainingLetters[currentTextIndex].Remove(i, 1).Insert(i, "*");
    }

    private void Awake()
    {
        Instance = this;
    }
}
