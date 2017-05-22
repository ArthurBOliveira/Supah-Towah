using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public VirtualJoystick moveJoystick;

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
        //Keyboard movement
        rg2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        //Joystick
        //Vector2 direction = new Vector2();
        //if (moveJoystick.InputDirection != Vector3.zero)
        //{
        //    direction = moveJoystick.InputDirection;
        //}

        //Move(direction);

        trail.time = (gc.score * 0.01f) + 0.1f;
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.x = max.x - 0.285f;
        min.x = min.x + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
}
