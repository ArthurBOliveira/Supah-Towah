using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int secs = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().AddTime(secs);

            Destroy(gameObject);
        }
    }
}
