using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPick : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager score;

	// Use this for initialization
	void Start () {

        score = FindObjectOfType<ScoreManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D carrot)
    {
        if(carrot.gameObject.tag == "Player")
        {
            score.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }
    }

}
