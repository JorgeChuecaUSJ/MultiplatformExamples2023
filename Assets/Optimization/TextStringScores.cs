using UnityEngine;
using UnityEngine.UI;

public class TextStringScores1 : MonoBehaviour
{   
    public Text scoreBoard;
    public int score;

    void Update()
    {
        string scoreText = "Score: " + score.ToString();
        scoreBoard.text = scoreText;
    }
}


public class TextStringScores2 
{
    public Text scoreBoard;
    public string scoreText;
    public int score;
    public int oldScore;

    void Update()
    {
        if (score != oldScore)
        {
            scoreText = "Score: " + score.ToString();
            scoreBoard.text = scoreText;
            oldScore = score;
        }
    }
}

public class TextStringScores3 
{
    public Text scoreBoardTitle;
    public Text scoreBoardDisplay;
    public string scoreText;
    public int score;
    public int oldScore;

    void Start()
    {
        scoreBoardTitle.text = "Score: ";

        Mesh mesh = new Mesh();
        var vertices = mesh.vertices;
        for(int i=0; i < vertices.Length; i++)
        {
            float x, y, z;
            x = vertices[i].x;
            y = vertices[i].y;
            z = vertices[i].z;
        }
    }

    void Update()
    {
        var camera = Camera.main;
        if (score != oldScore)
        {
            scoreText = score.ToString();
            scoreBoardDisplay.text = scoreText;
            oldScore = score;
        }
    }
}