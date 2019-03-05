using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public TextMesh scoreText;
    public TextMesh highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public bool scoreIncreasing;

    public float pointsPerSecond;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetFloat("HighScore") != null)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;  
        }

        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
		
	}

    public void AddScore(int point) 
    {
        scoreCount += point;
    }
}
