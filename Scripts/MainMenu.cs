using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string lvlName;
	// Use this for initialization
	public void StartGame()
    {
        Application.LoadLevel(lvlName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
