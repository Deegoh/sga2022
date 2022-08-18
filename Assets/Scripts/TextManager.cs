using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameObject currentText;
    public int currentTextIndex;
    public static TextManager Instance;

    private string[] _paragraphs = new[]
    {
        // "À l’aube du crépuscule,\nSommeille l’univers,\nVide, à la recherche de lumière,\nOu d’un unique corpuscule",
        "a",
        "b",
        "Un monde sombre,\nC’est dans celui-ci que je vis,\nMais un jour l’on ma dit,\nQue quelqu’un me sortirait de l’ombre",
        "D’attendre, fut une rude épreuve,\nTel l’arbre, je sentis des racines pousser,\nLes jours, les mois, les années, ne voulurent passer,\nJ’étais à court d’idées neuves"
    };
    // Start is called before the first fr1ame update
    void Start()
    {
        currentText.GetComponent<TextMeshProUGUI>().text = _paragraphs[0];
    }

    public void UpdateText()
    {
        currentText.GetComponent<TextMeshProUGUI>().text = _paragraphs[currentTextIndex++];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }
}
