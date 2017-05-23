using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Leaderscore : MonoBehaviour
{
    public Text scoresText;
    public InputField inputName;
    public Button btnSave;

    public bool isReading;

    private void Start()
    {
        if (isReading)
            ReadScore();
    }

    public void ReadScore()
    {
        scoresText.text = "";
        FileStream stream = File.OpenRead("./assets/scripts/SupahTowah_Leaderscore.txt");
        StreamReader reader = new StreamReader(stream);
        string content = reader.ReadToEnd();

        List<Score> scores = convertToScores(content);

        int position = 1;
        foreach (Score s in scores)
        {
            scoresText.text += position + " - " + s.name + " : " + s.score + "\r\n";
            position++;
        }

        stream.Close();
    }

    public void SaveScore()
    {
        Score score = new Score();

        string name = inputName.text;
        name = name.Replace('-', ' ');
        name = name.Replace('|', ' ');

        if (name.Length > 8)
            name = name.Substring(0, 8);

        score.name = name;
        score.score = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().score;

        StoreScore(score);
    }

    private void StoreScore(Score score)
    {
        inputName.gameObject.SetActive(false);
        btnSave.gameObject.SetActive(false);

        FileStream stream = File.OpenRead("./assets/scripts/SupahTowah_Leaderscore.txt");
        StreamReader reader = new StreamReader(stream);
        string content = reader.ReadToEnd();
        stream.Close();

        List<Score> scores = convertToScores(content);

        scores.Add(score);
        string text = convertToString(scores);

        StreamWriter file = new StreamWriter("./assets/scripts/SupahTowah_Leaderscore.txt");
        file.Write(text);

        file.Close();
    }

    private List<Score> convertToScores(string text)
    {
        List<Score> result = new List<Score>();

        string[] aux = text.Split('|');

        for (int i = 0; i < aux.Length; i++)
        {
            string[] sub = aux[i].Split('-');

            if (sub.Length > 1)
                result.Add(new Score(sub[0], int.Parse(sub[1])));
        }

        result = result.OrderByDescending(x => x.score).ToList<Score>();

        return result;
    }

    private string convertToString(List<Score> scores)
    {
        string result = "";

        foreach (Score s in scores)
        {
            result += s.name + "-" + s.score + "|";
        }

        return result;
    }
}


public class Score
{
    public string name { get; set; }
    public int score { get; set; }

    public Score() { }

    public Score(string Name, int Score)
    {
        name = Name;
        score = Score;
    }
}