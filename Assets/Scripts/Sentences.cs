using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Sentences
{
    public List<string> sentences = new List<string> {"lorem", "opsum"};
    int i = 0;
    public List<IAStars> stars = new List<IAStars>(0);

    public string CurrentSentence => sentences[i];

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    public void removeChar(char c)
    {
        if (sentences.Count > i)
        {
            Debug.Log(sentences.Count);
            Debug.Log(i);
            int index = sentences[i].IndexOf(c);
            if (index != -1)
            {
                sentences[i] = sentences[i].Remove(index, 1);
                if (String.IsNullOrEmpty(sentences[i]))
                {
                    i++;
                }
            }
        }
    }

    public char choseRandomChar()
    {
        int randomIndex = Random.Range(0, sentences[i].Length);
        return sentences[i][randomIndex];
    }
}
