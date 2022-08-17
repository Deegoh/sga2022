using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAStars : MonoBehaviour
{
    //[SerializeField] private Sentences sentences;
    public float radius;
    [Header("Letter")]
    [SerializeField] public char _letter;

    private void Start ()
    {
        string currentSentence = LevelManager.Instance.Paragraphs.CurrentSentence;
        Debug.Log("The currentSentence: " + currentSentence);
        _letter = LevelManager.Instance.Paragraphs.choseRandomChar();
        Debug.Log("The letter: " + _letter);
        LevelManager.Instance.Paragraphs.removeChar(_letter);
        //Debug.Log(Sentences.sentences);
    }

    private void Update ()
    {
        // if (!agent.hasPath)
        // {
        //     agent.SetDestination (GetPoint.Instance.GetRandomPoint (transform, radius));
        // }
    }

#if UNITY_EDITOR

    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, radius);
    }

#endif
}
