using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class IAStars : MonoBehaviour
{
    //[SerializeField] private Sentences sentences;
    public float radius;
    public char personalLetter;

    private void Start ()
    {
        string currentSentence = LevelManager.Instance.Paragraphs.CurrentSentence;
        Debug.Log("The currentSentence: " + currentSentence);
        Debug.Log("The letter: " + LevelManager.Instance.letter);
        personalLetter = LevelManager.Instance.letter;
        LevelManager.Instance.Paragraphs.removeChar(LevelManager.Instance.letter);
        LevelManager.Instance.Paragraphs.stars.Add(this);
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
