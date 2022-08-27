using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        "coucou !mec, ",
        ""
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
        // _s = File.ReadAllText("Assets/Text/wordsOnly.txt"); // read .txt to string
        _s = "univers\nneant\nrecherche\nrepere\ncrepuscule\nminuscule\nvide\nexister";
        //_s = "un\nnea\nrec\nre\ncre\nmi\nvi\nex";
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
        //if (LevelManager.Instance.Paragraphs.sentences) 
        if (LevelManager.Instance.Paragraphs.sentences.Count > TextManager.Instance.currentTextIndex + 1)
            textOutput.text = _paragraphs[++currentTextIndex];
        else
        {
            textOutput.text = "Well done !!!";
            textOutput.color = Color.yellow;
        }
        //else
        //  textOutput.text = "";
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
        if (i != -1)
            _remainingLetters[currentTextIndex] = _remainingLetters[currentTextIndex].Remove(i, 1).Insert(i, "*");
    }

    private void Awake()
    {
        Instance = this;
    }
}
