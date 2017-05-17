using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platform;
    public GameObject flippedPlatform;
    public GameObject redPlatform;
    public GameObject point; 

    public GameObject particle;

    public int direction;
    public int score = 0;

    public float speed = 50;    

    private void Start()
    {
        score = 0;

        StartCoroutine(ChangeDirection());
        StartCoroutine(Game());

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
                    Instantiate(platform, new Vector3(x, 6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (-1 * speed));
                    break;

                case 2:
                    //South
                    x = Random.Range(-4.5f, 4.5f);
                    Instantiate(platform, new Vector3(x, -6, 0), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, (1 * speed));
                    break;

                case 3:
                    //East
                    y = Random.Range(-3f, 3f);
                    Instantiate(flippedPlatform, new Vector3(8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((-1 * speed), 0);
                    break;
                case 4:
                    //West
                    y = Random.Range(-3f, 3f);
                    Instantiate(flippedPlatform, new Vector3(-8, y, 0), flippedPlatform.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2((1 * speed), 0);
                    break;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            direction = Random.Range(1, 5);
            ChangeEmission();
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

                aux.x = -5;
                aux.y = 0;
                break;

            case 2:
                //South
                ParticleSystem.VelocityOverLifetimeModule aux1 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux1.x = 5;
                aux1.y = 0;
                break;

            case 3:
                //East
                ParticleSystem.VelocityOverLifetimeModule aux2 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux2.x = 0;
                aux2.y = -5;
                break;
            case 4:
                //West
                ParticleSystem.VelocityOverLifetimeModule aux3 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux3.x = 0;
                aux3.y = 5;
                break;
        }
    }

    public void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        score = 0;
    }
}