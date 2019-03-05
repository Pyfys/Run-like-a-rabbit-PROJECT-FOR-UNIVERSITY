using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGenerator : MonoBehaviour {

    public ObjectPooler carrotPool;

    public float distanceBetween;

    public void SpawnCarrots(Vector3 startPosition)
    {
        GameObject carrot1 = carrotPool.getPooledObjectCarrot();
        carrot1.transform.position = startPosition;
        carrot1.SetActive(true);

        GameObject carrot2 = carrotPool.getPooledObjectCarrot();
        carrot2.transform.position = new Vector3(startPosition.x - distanceBetween,startPosition.y,startPosition.z);
        carrot2.SetActive(true);

        GameObject carrot3 = carrotPool.getPooledObjectCarrot();
        carrot3.transform.position = new Vector3(startPosition.x + distanceBetween, startPosition.y, startPosition.z);
        carrot3.SetActive(true);
    }
}
