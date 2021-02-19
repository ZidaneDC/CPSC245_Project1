using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //basic object pooling setup, generating different colors will need to be added in
    //attach this to the game controller in unity (or just rewrite this into game logic
    //in the unity editor you will be able to select what game object is pooled, so the target class can  be added to that
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledTargets;
    public GameObject targetToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    public GameObject GetPooledTarget()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (pooledTargets[i].activeInHierarchy)
            {
                return pooledTargets[i];
            }
        }

        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledTargets = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(targetToPool);
            tmp.SetActive(false);
            pooledTargets.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
