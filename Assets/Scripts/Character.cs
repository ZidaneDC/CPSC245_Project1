using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Collider dragonCollider;
    private int charaacterHappiness;
    private int characterEnergy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"):
            shootFire();

    }

    private void shootFire()
    {
        void OnMouseOver()
        {
            //Target.Hit();
        }
    }

    private void jump()
    {
        //button press for jump
        //character moves a certain height up
    }

    private void duck()
    {
        //button press for duck
        //character has duck animation
    }
}
