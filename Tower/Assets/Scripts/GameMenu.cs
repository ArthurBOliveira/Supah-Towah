using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject GameOverUI;

    private bool paused = false;
    private Camera cam;
    private GameController gc;

    void Start()
    {
        GameOverUI.SetActive(false);
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
        //if (gc.score > save.HighScore())
        //{
        //    Social.ReportScore(gc.score, SpaceHero.GPGSIds.leaderboard_ranking, (bool success) => {
        //        // handle success or failure
        //    });

        //    save.SaveScore(gc.score);
        //}

        GameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        cam.transform.localPosition = new Vector2(cam.transform.position.x, 0f);
        paused = true;
    }

    public void Resume()
    {
        paused = false;
        cam.transform.localPosition = new Vector2(cam.transform.position.x, 0f);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
}
