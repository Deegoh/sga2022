using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingTextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textOutput;

    [SerializeField] private string[] DeathText;
    // Start is called before the first frame update
    void Start()
    {
        textOutput.text = DeathText[GameManager.instance.indexOfDeath];
    }
}
