using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;
	// Use this for initialization
	public void RestartGame () {
        FindObjectOfType<GameTrigger>().Reset();
	}
	
	// Update is called once per frame
	public void QuitToMain () {
        Application.LoadLevel(mainMenuLevel);
	}
}
