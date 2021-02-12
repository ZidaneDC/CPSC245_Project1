using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject dragon;
    public Rigidbody dragonRigidbody;
    private int charaacterHappiness;
    private int characterEnergy;
    private float thrust = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            shootFire();
        if (Input.GetKeyDown(KeyCode.W))
            jump();
        if (Input.GetKeyDown(KeyCode.S))
            duck();
    }

    private void shootFire()
    {
       //animation trigger
    }

    private void jump()
    {
        //character moves a certain height up
        dragon.transform.position = new Vector3(transform.position.x, 3, transform.position.z);
    }

    private void duck()
    {
        //character moving a certain height down
    }
}
