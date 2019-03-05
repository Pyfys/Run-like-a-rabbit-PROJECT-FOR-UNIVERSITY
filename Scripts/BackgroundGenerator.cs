using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    public GameObject background;
    public Transform generationPoint;
    public ObjectPooler objectPooler;

    private float objectWidth;
	// Use this for initialization
	void Start () {
        objectWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;

    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < generationPoint.position.x)
        {

            transform.position = new Vector3(transform.position.x + objectWidth, transform.position.y, transform.position.z);
            //GameObject.Instantiate<GameObject>(background, transform.position, transform.rotation);
            GameObject newBackground = null;
            if (background.tag == "Tree")
            {
                newBackground = objectPooler.getPooledObjectTree();
            }
            else if(background.tag == "background")
            {
                newBackground = objectPooler.getPooledObjectBackground();
            }

            newBackground.transform.position = transform.position;
            newBackground.transform.rotation = transform.rotation;
            newBackground.SetActive(true);

        }
	}
}
