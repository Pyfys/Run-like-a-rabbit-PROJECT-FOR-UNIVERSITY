using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObjectBee;
    public GameObject pooledObjectCarrot;
    public GameObject pooledObjectTree;
    public GameObject pooledObjectBackground;
    public GameObject[] pooledObjectPlatfroms;
   
    public int size;

    private int platform;
    private int sizeOfArray;
    List<GameObject> pooledObjectsBees;
    List<GameObject> pooledObjectsCarrots;
    List<GameObject> pooledObjectsTrees;
    List<GameObject> pooledObjectsBackgrounds;
    List<GameObject> pooledObjectsPlatforms;
    private GameObject[,] ListOfPooledObjectsPlatforms;

    // Use this for initialization
    void Start () {
        pooledObjectsTrees = new List<GameObject>();

        pooledObjectsBackgrounds = new List<GameObject>();

        pooledObjectsPlatforms = new List<GameObject>();

        ListOfPooledObjectsPlatforms = new GameObject[size,pooledObjectPlatfroms.Length];

        pooledObjectsCarrots = new List<GameObject>();

        pooledObjectsBees = new List<GameObject>();

        for(int i = 0; i < size; i++)
        {
            GameObject tree = (GameObject)Instantiate(pooledObjectTree);
            GameObject background = (GameObject)Instantiate(pooledObjectBackground);
            GameObject carrot = (GameObject)Instantiate(pooledObjectCarrot);
            GameObject bee = (GameObject)Instantiate(pooledObjectBee);

            for (int j = 0; j < pooledObjectPlatfroms.Length; j++)
            {
                GameObject platform = (GameObject)Instantiate(pooledObjectPlatfroms[i]);
                platform.SetActive(false);
                ListOfPooledObjectsPlatforms[i,j] = platform;
            }

            carrot.SetActive(false);
            tree.SetActive(false);
            background.SetActive(false);
            bee.SetActive(false);
            pooledObjectsBees.Add(bee);
            pooledObjectsCarrots.Add(carrot);
            pooledObjectsTrees.Add(tree);
            pooledObjectsBackgrounds.Add(background);
        }
	}
	
	public GameObject getPooledObjectTree()
    {
        for(int i = 0; i < pooledObjectsTrees.Count; i++)
        {
            if (!pooledObjectsTrees[i].activeInHierarchy)
            {
                return pooledObjectsTrees[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObjectTree);
        obj.SetActive(false);
        pooledObjectsTrees.Add(obj);
        return obj;

    }
    public GameObject getPooledObjectBackground()
    {
        for (int i = 0; i < pooledObjectsBackgrounds.Count; i++)
        {
            if (!pooledObjectsBackgrounds[i].activeInHierarchy)
            {
                return pooledObjectsBackgrounds[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObjectBackground);
        obj.SetActive(false);
        pooledObjectsBackgrounds.Add(obj);
        return obj;

    }
    public GameObject getPooledObjectPlatform(int platform)
    {
        this.platform = platform;
        sizeOfArray = ListOfPooledObjectsPlatforms.GetLength(0);
        for (int i = 0; i < ListOfPooledObjectsPlatforms.GetLength(0); i++)
        {
            if (!ListOfPooledObjectsPlatforms[platform,i].activeInHierarchy)
            {
                return ListOfPooledObjectsPlatforms[platform,i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObjectPlatfroms[platform]);
        obj.SetActive(false);
        pooledObjectsPlatforms.Add(obj);
        return obj;

    }

    public GameObject getPooledObjectCarrot()
    {
        for (int i = 0; i < pooledObjectsCarrots.Count; i++)
        {
            if (!pooledObjectsCarrots[i].activeInHierarchy)
            {
                return pooledObjectsCarrots[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObjectCarrot);
        obj.SetActive(false);
        pooledObjectsCarrots.Add(obj);
        return obj;
    }

    public GameObject getPooledObjectBee()
    {
        for (int i = 0; i < pooledObjectsBees.Count; i++)
        {
            if (!pooledObjectsBees[i].activeInHierarchy)
            {
                return pooledObjectsBees[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObjectBee);
        obj.SetActive(false);
        pooledObjectsBees.Add(obj);
        return obj;
    }

}
