using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject particle;

    private int direction;

    private void Awake()
    {
        StartCoroutine(ChangeDirection());        
    }  

    #region MenuMethods
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Leaderscore()
    {
        SceneManager.LoadScene("Leaderscore");
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

    private void ChangeEmission()
    {
        switch (direction)
        {
            case 1:
                //North
                ParticleSystem.VelocityOverLifetimeModule aux = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux.x = -8;
                aux.y = 0;
                break;

            case 2:
                //South
                ParticleSystem.VelocityOverLifetimeModule aux1 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux1.x = 8;
                aux1.y = 0;
                break;

            case 3:
                //East
                ParticleSystem.VelocityOverLifetimeModule aux2 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux2.x = 0;
                aux2.y = -8;
                break;
            case 4:
                //West
                ParticleSystem.VelocityOverLifetimeModule aux3 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux3.x = 0;
                aux3.y = 8;
                break;
            case 5:
                //NorthWest
                ParticleSystem.VelocityOverLifetimeModule aux4 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux4.x = -8;
                aux4.y = 8;
                break;
            case 6:
                //NorthEast
                ParticleSystem.VelocityOverLifetimeModule aux5 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux5.x = -8;
                aux5.y = -8;
                break;
            case 7:
                //SouthEast
                ParticleSystem.VelocityOverLifetimeModule aux6 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux6.x = 8;
                aux6.y = -8;
                break;
            case 8:
                //SouthWest
                ParticleSystem.VelocityOverLifetimeModule aux7 = particle.GetComponent<ParticleSystem>().velocityOverLifetime;

                aux7.x = 8;
                aux7.y = 8;
                break;
        }
    }
    #endregion
}
