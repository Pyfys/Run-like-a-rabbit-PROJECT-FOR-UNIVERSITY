using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrigger : MonoBehaviour
{

    public Transform theBackgroundTreeGenerator;
    private Vector3 theBackgroundTreeStartPoint;

    public Transform theBackgroundGenerator;
    private Vector3 theBackgroundStartPoint;

    public Transform thePlatform;
    private Vector3 thePlatformStartPoint;

    public BackgroundDestruction[] backgrounds;

    public Transform thePlayer;
    private Vector3 thePlayerStartPoint;

    private ScoreManager score;

    public DeathMenu deathMenu;

    // Use this for initialization
    void Start()
    {

        thePlatformStartPoint = thePlatform.position;

        thePlayerStartPoint = thePlayer.transform.position;

        theBackgroundStartPoint = theBackgroundGenerator.position;

        theBackgroundTreeStartPoint = theBackgroundTreeGenerator.position;

        score = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        score.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);

    }

    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);
        theBackgroundGenerator.position = theBackgroundStartPoint;
        theBackgroundTreeGenerator.position = theBackgroundTreeStartPoint;
        thePlayer.transform.position = thePlayerStartPoint;
        thePlatform.position = thePlatformStartPoint;
        backgrounds = FindObjectsOfType<BackgroundDestruction>();
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].gameObject.SetActive(false);
        }
        score.scoreCount = 0;
        score.scoreIncreasing = true;
        thePlayer.gameObject.SetActive(true);
    }

   /* public IEnumerator RestartGameCo()
    {
        score.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        theBackgroundGenerator.position = theBackgroundStartPoint;
        theBackgroundTreeGenerator.position = theBackgroundTreeStartPoint;
        thePlayer.transform.position = thePlayerStartPoint;
        thePlatform.position = thePlatformStartPoint;
        backgrounds = FindObjectsOfType<BackgroundDestruction>();
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].gameObject.SetActive(false);
        }
        score.scoreCount = 0;
        score.scoreIncreasing = true;
        thePlayer.gameObject.SetActive(true);
        
    }
    */

}
