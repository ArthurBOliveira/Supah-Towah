using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject GameOverUI;    

    private Camera cam;
    private GameController gc;
    private GameObject player;

    void Start()
    {
        Time.timeScale = 1;
        GameOverUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();

    }

    void Update()
    {
        if (gc.time > 0)
        {

        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gc.StopCourotines();
        //Time.timeScale = 0;
        GameOverUI.SetActive(true);
        player.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void Leaderscore()
    {
        SceneManager.LoadScene("Leaderscore");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
}
