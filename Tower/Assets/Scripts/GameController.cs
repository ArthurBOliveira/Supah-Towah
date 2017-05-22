using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject platform;
    public GameObject flippedPlatform;
    public GameObject redPlatform;
    public GameObject redFlippedPlatform;
    public GameObject point; 
    public GameObject particle;

    public Text scoreText;
    public Text timeText;

    public int direction;
    public int score;

    public float time = 60;
    public float speed = 40;

    private float rate;

    private void Awake()
    {
        AddScore(0);

        StartCoroutine(ChangeDirection());
        StartCoroutine(Game());
        StartCoroutine(SpawnPoints());
    }

    private void Update()
    {
        time -= Time.deltaTime;

        int min = (int)time / 60;
        int sec = (int)time % 60;

        timeText.text = min + ":" + sec;
    }

    IEnumerator Game()
    {
        float x;
        float y;
        yield return new WaitForSeconds(1);

        while (true)
        {
            switch (direction)
            {
                case 1:
                    //North
                    x = Random.Range(-4.5f, 4.5f);

                    if(Random.Range(1, 101) < 95)
                        Instantiate(platform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                    else
                        Instantiate(redPlatform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                    break;

                case 2:
                    //South
                    x = Random.Range(-4.5f, 4.5f);

                    if (Random.Range(1, 101) < 95)
                        Instantiate(platform, new Vector3(x, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                    else
                        Instantiate(redPlatform, new Vector3(x, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                    break;

                case 3:
                    //East
                    y = Random.Range(-3f, 3f);

                    if (Random.Range(1, 101) < 95)
                        Instantiate(flippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                    else
                        Instantiate(redFlippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                    break;
                case 4:
                    //West
                    y = Random.Range(-3f, 3f);

                    if (Random.Range(1, 101) < 95)
                        Instantiate(flippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                    else
                        Instantiate(redFlippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                    break;
                case 5:
                    //North - West
                    x = Random.Range(-4.5f, 4.5f);
                    y = Random.Range(-3f, 3f);

                    if (Random.Range(1, 101) < 95)
                    {
                        Instantiate(platform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                        Instantiate(flippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                    }
                    else
                    {
                        Instantiate(redPlatform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                        Instantiate(redFlippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                    }
                    break;
                case 6:
                    //North - East
                    x = Random.Range(-4.5f, 4.5f);
                    y = Random.Range(-3f, 3f);

                    if (Random.Range(1, 101) < 95)
                    {
                        Instantiate(platform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                        Instantiate(flippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                    }
                    else
                    {
                        Instantiate(redPlatform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                        Instantiate(redFlippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                    }
                    break;
                case 7:
                    //South - East
                    x = Random.Range(-4.5f, 4.5f);
                    y = Random.Range(-3f, 3f);

                    if (Random.Range(1, 101) < 95)
                    {
                        Instantiate(platform, new Vector3(x, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                        Instantiate(flippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                    }
                    else
                    {
                        Instantiate(redPlatform, new Vector3(x, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                        Instantiate(redFlippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                    }
                    break;
                case 8:
                    //South - West
                    x = Random.Range(-4.5f, 4.5f);
                    y = Random.Range(-3f, 3f);

                    if (Random.Range(1, 101) < 95)
                    {
                        Instantiate(platform, new Vector3(x, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                        Instantiate(flippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                    }
                    else
                    {
                        Instantiate(redPlatform, new Vector3(x, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                        Instantiate(redFlippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                    }
                    break;
                //case 9:
                //    //North - South
                //    x = Random.Range(-4.5f, 4.5f);
                //    y = Random.Range(-4.5f, 4.5f);

                //    if (Random.Range(1, 101) < 95)
                //    {
                //        Instantiate(platform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                //        Instantiate(platform, new Vector3(y, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                //    }
                //    else
                //    {
                //        Instantiate(redPlatform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                //        Instantiate(redPlatform, new Vector3(y, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                //    }
                //    break;
                //case 10:
                //    //East - West
                //    x = Random.Range(-3f, 3f);
                //    y = Random.Range(-3f, 3f);

                //    if (Random.Range(1, 101) < 95)
                //    {
                //        Instantiate(flippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                //        Instantiate(flippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                //    }
                //    else
                //    {
                //        Instantiate(redFlippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                //        Instantiate(redFlippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                //    }
                //    break;
            }

            yield return new WaitForSeconds(rate);
        }
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            direction = Random.Range(1, 9);
            ChangeEmission();
            yield return new WaitForSeconds(8);
        }
    }

    IEnumerator SpawnPoints()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            Instantiate(point, screenPosition, Quaternion.identity);
            yield return new WaitForSeconds(8);
        }
    }

    private void ChangeEmission()
    {
        switch (direction)
        {
            case 1:
                //North
                ParticleSystem.VelocityOverLifetimeModule aux = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux.x = -8;
                aux.y = 0;
                rate = 0.6f;
                break;

            case 2:
                //South
                ParticleSystem.VelocityOverLifetimeModule aux1 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux1.x = 8;
                aux1.y = 0;
                rate = 0.6f;
                break;

            case 3:
                //East
                ParticleSystem.VelocityOverLifetimeModule aux2 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux2.x = 0;
                aux2.y = -8;
                rate = 0.6f;
                break;
            case 4:
                //West
                ParticleSystem.VelocityOverLifetimeModule aux3 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux3.x = 0;
                aux3.y = 8;
                rate = 0.6f;
                break;
            case 5:
                //NorthWest
                ParticleSystem.VelocityOverLifetimeModule aux4 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux4.x = -8;
                aux4.y = 8;
                rate = 1f;
                break;
            case 6:
                //NorthEast
                ParticleSystem.VelocityOverLifetimeModule aux5 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux5.x = -8;
                aux5.y = -8;
                rate = 1f;
                break;
            case 7:
                //SouthEast
                ParticleSystem.VelocityOverLifetimeModule aux6 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux6.x = 8;
                aux6.y = -8;
                rate = 1f;
                break;
            case 8:
                //SouthWest
                ParticleSystem.VelocityOverLifetimeModule aux7 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux7.x = 8;
                aux7.y = 8;
                rate = 1f;
                break;
        }
    }

    public void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        score = score / 2;
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int addScore)
    {
        score += addScore;

        scoreText.text = "Score: " + score;
    }

    public void AddTime(int n)
    {
        time += n;

        int min = (int)time / 60;
        int sec = (int)time % 60;

        timeText.text = min + ":" + sec;
    }
}