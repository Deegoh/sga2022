using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);    
    }
}
