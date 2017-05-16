using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platform;
    public GameObject flippedPlatform;
    public GameObject redPlatform;

    public int direction;
    public float speed = 50;

    private void Start()
    {
        StartCoroutine(Game());
    }

    IEnumerator Game()
    {
        float x;
        float y;
        yield return new WaitForSeconds(3);

        while (true)
        {
            switch (direction)
            {
                case 1:
                    //Downward
                    x = Random.Range(-4.5f, 4.5f);
                    Instantiate(platform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                    break;

                case 2:
                    //Upward
                    x = Random.Range(-4.5f, 4.5f);
                    Instantiate(platform, new Vector3(x, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                    break;

                case 3:
                    //Leftward
                    y = Random.Range(-3f, 3f);
                    Instantiate(flippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                    break;
            }

            yield return new WaitForSeconds(1);
        }
    }

    public void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}