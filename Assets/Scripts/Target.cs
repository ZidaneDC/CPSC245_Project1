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
    public bool isHit; //variable controlling target's appearance after being hit
    public LevelLogic levelLogic; 

    //default constructor 
    public Target()
    {
        targetColor = "null";
        targetSpeed = 0;
        targetValue = 0;
        isBomb = false;
        isHit = false;
    }

    //parameterized constructor
    public Target(string inputColor, int inputSpeed, int inputValue, bool inputIsBomb, bool inputIsBurned)
    {
        targetColor = inputColor;
        targetSpeed = inputSpeed;
        targetValue = inputValue;
        isBomb = inputIsBomb;
        isHit = inputIsBurned;
    }

    // Start is called before the first frame update
    //will call the constructor, and depending on the stats of the level, generate its color, speed, value, etc.
    //targets can use rigid body, add force and let them fall, do in unity editor instead of in a script
    void Start()
    {
        
    }

    //method to be called by level logic to change a targets properties based on level difficulty
    //will change speed, target color, value, and whether it is a bomb target.
    //Speed and value are set values determined by the level, while target color and bomb status are random, but also controlled by level
    //there will be another method in level logic that determines these odds, and passes them into this method
    public void setTargetValues(string inputColor, int inputSpeed, int inputValue, bool inputIsBomb) 
    {
        targetColor = inputColor;
        targetSpeed = inputSpeed;
        targetValue = inputValue;
        isBomb = inputIsBomb;
    }


    //Targets will register when they've been hit individually, then pass that info into level logic which will update the score and handle bomb target behaviour
    //this will be done using OnMouseDown instead of the Hit method below
    private void OnMouseDown()
    {
        //change the target to hit
        isHit = true;
        levelLogic.Hit(this); //pass this target into the level logic hit method, figure out the syntax for this its throwing an error
    }



    // Update is called once per frame
    void Update() //update method should like control how the target moves once it is spawned, and when it despawns if it isn't hit
    {
        
    }
}
