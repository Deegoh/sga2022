using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    [SerializeField] public float playerSpeed;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb.velocity = new Vector3(0,0,playerSpeed);
    }
    public void Stop()
    {
        rb.velocity = new Vector3(0,0,0);
    }
    
    public void SetSpeed(float speed)
    {
        rb.velocity = new Vector3(0,0,speed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
            LevelManager.Instance.Paragraphs.stars.Remove(other.GetComponent<IAStars>());
            Destroy(other.gameObject);
        }
    }
}
