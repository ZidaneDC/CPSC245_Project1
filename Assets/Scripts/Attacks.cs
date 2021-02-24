using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject wave;
    public GameObject dragon;
    //public float thrust = 300f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
        SpawnDragon();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SpawnWave()
    {
        Instantiate(wave, new Vector3(-10, 0.4f, 0), Quaternion.identity);
        Rigidbody waveRigidbody = wave.GetComponent<Rigidbody>();
        waveRigidbody.AddForce(Vector3.right * 1000f);
    }

    public void SpawnDragon()
    {
        Instantiate(dragon, new Vector3(-10, 1, 0), Quaternion.identity);
        Rigidbody dragonRigidbody = dragon.GetComponent<Rigidbody>();
        dragonRigidbody.AddForce(Vector3.right * 300f);
    }

}
