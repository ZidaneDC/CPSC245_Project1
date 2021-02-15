﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    //Level Logic class, controls target spawn rates, obstacle spawn rates, color, level score and point mutliplier's
    //will alos have methods to check that an object being hit is the correct target, if it is a target at all
    string objectiveColor;
    int levelScore;
    int objectiveGoal; //number of correect targets that needs to be hit to beat the level
    int objectiveCount; //how many correct targets have been hit already
    double objectiveChance; //odds that the correct type of target is spawned
    int scoreMultiplier;
    float targetTimer; //how often a new wave of targets appears

    //default constructor
    public LevelLogic()
    {
        objectiveColor = "null";
        levelScore = 0;
        objectiveGoal = -1; //to prevent immediate spawn of the next level, since levels will move on once the number of targets hit equals the objective goal
        objectiveCount = 0;
        objectiveChance = 1; //1 being 100% chance
        scoreMultiplier = 1;
        targetTimer = 0;

    }

    //level setup method? or just a constructor? decide which works better, considering that game logic determines some level info

    // Start is called before the first frame update
    void Start()
    {
        //call game or ui class to display the level start panel
    }

    // Update is called once per frame
    void Update() //call the level complete check, as well as the methods for spawning targets
    {
        if(objectiveCount == objectiveGoal)
        {
            LevelComplete();
        }
    }


    //method that handles what happens when a target is hit, pass in a target object to access its variables
    public void Hit(Target hitTarget)
    {
       //if the target is not the correct color
       if(hitTarget.targetColor != objectiveColor)
        {
            //delete the target? or maybe just allow it to fall offscreen and despawn
            //subtract points and point multiplier
        }
        //if the target is the correct color 
        else
        {
            hitTarget.isHit = true;
            //add points and point multiplier
            objectiveCount += 1;
            if (hitTarget.isBomb == true) //if the target is a bomb, call destroy all method
            {
                DestroyAll();
            }
        }

    }

    //Method called if the hit target is an bomb, will destroy all other targets onscreen and player's score will increase accordingly
    //figure out how to get all of the targets currently onscreen
    public void DestroyAll()
    {

    }

   //check for level complete method to end level when objective is reached
   //should their be a marker that changes to true when an objective has been reached and activates this method?
   //stops the level (maybe similar to pause) and shows the end of level ui
   public void LevelComplete()
    {

    }

    //another method to spawn targets depending on the level's set rate of probability and rate of spawn, will also control spawned target's speed
    //how will target speed be done? will it be set through the entire level? or be from a certain range each level
    //also how many targets will spawn at once? probably will be picked from a random number from 2-5 ish that adjusts depending on level or game logic
    public void SpawnTarget() //should this have parameters? will this be called every time you want to call targets at a certain time parameter or will it run constantly?
    {

    }

    //will level or game logic how and when targets despawn? if its level there needs to be a method for it and a parameter that causes targets to despawn
}
