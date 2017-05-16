using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platform;
    public GameObject flippedPlatform;
    public GameObject redPlatform;

    public GameObject northParticle;
    public GameObject southParticle;
    public GameObject eastParticle;
    public GameObject westParticle;

    public int direction;
    public float speed = 50;

    private void Start()
    {
        StartCoroutine(ChangeDirection());
        StartCoroutine(Game());

        northParticle.GetComponent<ParticleSystem>().enableEmission = false;
        southParticle.GetComponent<ParticleSystem>().enableEmission = false;
        eastParticle.GetComponent<ParticleSystem>().enableEmission = false;
        westParticle.GetComponent<ParticleSystem>().enableEmission = false;
    }

    IEnumerator Game()
    {
        float x;
        float y;
        yield return new WaitForSeconds(2);

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

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(1);
        
        while (true)
        {
            direction = Random.Range(1, 4);
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
                northParticle.GetComponent<ParticleSystem>().enableEmission = true;
                southParticle.GetComponent<ParticleSystem>().enableEmission = false;
                eastParticle.GetComponent<ParticleSystem>().enableEmission = false;
                westParticle.GetComponent<ParticleSystem>().enableEmission = false;
                break;

            case 2:
                //South
                northParticle.GetComponent<ParticleSystem>().enableEmission = false;
                southParticle.GetComponent<ParticleSystem>().enableEmission = true;
                eastParticle.GetComponent<ParticleSystem>().enableEmission = false;
                westParticle.GetComponent<ParticleSystem>().enableEmission = false;
                break;

            case 3:
                //East
                northParticle.GetComponent<ParticleSystem>().enableEmission = false;
                southParticle.GetComponent<ParticleSystem>().enableEmission = false;
                eastParticle.GetComponent<ParticleSystem>().enableEmission = true;
                westParticle.GetComponent<ParticleSystem>().enableEmission = false;
                break;
            case 4:
                //West
                northParticle.GetComponent<ParticleSystem>().enableEmission = false;
                southParticle.GetComponent<ParticleSystem>().enableEmission = false;
                eastParticle.GetComponent<ParticleSystem>().enableEmission = true;
                westParticle.GetComponent<ParticleSystem>().enableEmission = false;
                break;
        }
    }

    public void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}