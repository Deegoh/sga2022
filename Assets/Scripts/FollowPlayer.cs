using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    [SerializeField] private float playerSpeed;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb.velocity = new Vector3(0,0,playerSpeed);
    }

    // Update is called once per frame
}