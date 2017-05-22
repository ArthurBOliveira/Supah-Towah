using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject GameOverUI;
    public Text txtHighScore;

    private bool paused = false;
    private Camera cam;
    private GameController gc;
    //private Save save;

    void Start()
    {
        //save = new Save();
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
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        //if (save.HighScore() < gc.score)
        //{
        //    txtHighScore.text = "HighScore!";
        //    txtHighScore.color = new Color(241, 255, 0);
        //    save.SaveScore(gc.score);
        //}
        //else
        //{
        //    txtHighScore.text = "HighScore: " + save.HighScore();
        //    txtHighScore.color = new Color(255, 255, 255);
        //}
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
        Time.timeScale = 1;
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
