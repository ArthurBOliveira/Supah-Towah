using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platform;
    public GameObject redPlatform;

    private float x;

    private void Start()
    {
        StartCoroutine(Game());
    }

    IEnumerator Game()
    {
        yield return new WaitForSeconds(3);

        while (true)
        {
            x = Random.Range(-4.5f, 4.5f);
            Instantiate(platform, new Vector3(x, 6, 0), Quaternion.identity);

            yield return new WaitForSeconds(1);
        }
    }

    public void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}