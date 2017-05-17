using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float interval = 3.0f;
    private float timestamp = .0f;

    // Use this for initialization
    void Start()
    {
        timestamp = Time.time;  // save the timestamp when the bullet instantiated
    }

    void Update()
    {
        if (interval < Time.time - timestamp)
        {
            Destroy(gameObject);  // destroy the bullet after {interval} seconds
        }
    }
}
