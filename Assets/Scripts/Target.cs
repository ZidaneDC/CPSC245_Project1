using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //base variables, all public so other methods can access them
    public string targetColor;
    public int targetSpeed;
    public int targetValue;
    public bool isBomb; //
    public bool isBurned; //variable controlling target's appearance after being hit

    //default constructor 
    public Target()
    {
        targetColor = "null";
        targetSpeed = 0;
        targetValue = 0;
        isBomb = false;
        isBurned = false;
    }

    // Start is called before the first frame update
    //will call the constructor, and depending on the stats of the level, generate its color, speed, value, etc.
    void Start()
    {
        
    }

    public void Hit(Target hitTarget) //Method that handles what happens when a target is hit, pass in a target object to access its variables
    {
        
    }

    public void DestroyAll() //Method called if the hit target is an bomb, will destroy all other targets onscreen
    {

    }
    // Update is called once per frame
    void Update() //update method should like control how the target moves once it is spawned, and when it despawns if it isn't hit
    {
        
    }
}
