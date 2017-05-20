using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rg2d;
    private TrailRenderer trail;
    private GameController gc;

    private void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }


    private void Update()
    {
        rg2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        trail.time = (gc.score * 0.01f) + 0.1f;
    }
}
