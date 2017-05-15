using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().GameOver();
    }
}