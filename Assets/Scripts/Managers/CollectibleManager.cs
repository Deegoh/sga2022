using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public TMP_Text FloatingTextPrefab; // FTP

    // start is called before the first frame update
    void Start()
    {
        
    }

    // update is called once per frame
    void Update()
    {
        CollectiblePopsOut(); // FTP
    }

    public void CollectiblePopsOut()
    {
        if (FloatingTextPrefab) // FTP
        {
            ShowFloatingText();
        }
    }
    
    void ShowFloatingText() // FTP
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        // to add when currentLetter
        // var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        // go.GetComponent<TextMeshPro>().text = currentLetter.ToString();
    }

}
