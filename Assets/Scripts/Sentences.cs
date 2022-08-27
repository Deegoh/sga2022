using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Sentences
{
    public List<string> sentences;
    private int _i = 0;
    public List<IAStars> stars;

    public string CurrentSentence => sentences[_i];

    // Start is called before the first frame update
    void Start()
    {
        _i = 0;
    }

    public void removeChar(char c)
    {
        int index = sentences[_i].IndexOf(c);
        if (index != -1)
        {
            sentences[_i] = sentences[_i].Remove(index, 1);
            Debug.Log("The current sentence is: " + sentences[_i]);
            if (String.IsNullOrEmpty(sentences[_i]))
            {
                _i++;
                LevelChangeManager.Instance.ChangeLevelHandler();
            }
        }
    }

    public char choseRandomChar()
    {
        if (LevelManager.Instance.Paragraphs.sentences.Count == TextManager.Instance.currentTextIndex)
            return 'e' ;
        int randomIndex = Random.Range(0, LevelManager.Instance.Paragraphs.sentences[TextManager.Instance.currentTextIndex].Length);
        return LevelManager.Instance.Paragraphs.sentences[TextManager.Instance.currentTextIndex][randomIndex];
    }
}
