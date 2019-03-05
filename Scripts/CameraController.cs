using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Movement player;

    private Vector3 playerLastPosition;

    private float distanceToMove;


	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Movement>();
        playerLastPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        distanceToMove = player.transform.position.x - playerLastPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        playerLastPosition = player.transform.position;
	}
}
