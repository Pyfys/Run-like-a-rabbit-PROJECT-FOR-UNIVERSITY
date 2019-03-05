using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;

    private CarrotGenerator carrotGenerator;
    public float genBorder;
    public float beeGenBorder;


    public int maxDistance;
    public int minDistance;

    private int platformSelector;
    private float[] objectWidths;

    private float minHeight;
    public Transform maxHeighPoint;
    private float maxHeight;
    public float maxHeighChange;
    private float heightChange;

    public ObjectPooler theObjectPool;
    //private float objectWidth;
    // Use this for initialization
    void Start()
    {
        objectWidths = new float[theObjectPool.pooledObjectPlatfroms.Length];

        carrotGenerator = FindObjectOfType<CarrotGenerator>();

        for (int i = 0; i < theObjectPool.pooledObjectPlatfroms.Length; i++)
        {

            objectWidths[i] = theObjectPool.pooledObjectPlatfroms[i].GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeighPoint.position.y;


    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {

            var distanceBetween = Random.Range(minDistance, maxDistance);

            platformSelector = Random.Range(0,theObjectPool.pooledObjectPlatfroms.Length);

            heightChange = transform.position.y + Random.Range(maxHeight, -maxHeight);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;

            } else if(heightChange < minHeight)
            {
                heightChange = minHeight;

            }

            transform.position = new Vector3(transform.position.x + (objectWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            GameObject newPlatform = theObjectPool.getPooledObjectPlatform(platformSelector);
            
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f,100f) < genBorder)
            {
                carrotGenerator.SpawnCarrots(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if(Random.Range(0f,100f) < beeGenBorder)
            {
                if (objectWidths[platformSelector] >= 7)
                {
                    GameObject bee = theObjectPool.getPooledObjectBee();

                    float beeInside = Random.Range((-objectWidths[platformSelector] / 2) + 1, (objectWidths[platformSelector] / 2) - 1);

                    Vector3 beePosition = new Vector3(beeInside, 1f, 0f);

                    bee.transform.position = transform.position + beePosition;
                    bee.transform.rotation = transform.rotation;
                    bee.SetActive(true);
                }
            }
            transform.position = new Vector3(transform.position.x + (objectWidths[platformSelector] / 2), transform.position.y, transform.position.z);


        }
    }
}
