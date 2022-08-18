using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update

    private void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }
    // Update is called once per frame
}
