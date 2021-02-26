using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelLogic : MonoBehaviour
{
    //Level Logic class, controls target color, objective counters, level score and point mutliplier's
    //will also have methods to check that an object being hit is the correct target, if it is a target at all
    int levelCount;
    string objectiveColor;
    int levelScore;
    int objectiveGoal; //number of correct targets that needs to be hit to beat the level
    int objectiveCount; //how many correct targets have been hit already
    double objectiveChance; //odds that the correct type of target is spawned
    int scoreMultiplier;
    float targetTimer; //how often a new wave of targets appears

    List<string> objectiveOptions = new List<string>() { "red", "blue", "green", "yellow", "purple"}; //color options, bomb targets will be set to black
    System.Random random = new System.Random(); //for objective randomization

    public Attacks attacks;
    public ObjectPool objectPool;


    //default constructor
    public LevelLogic()
    {
        levelCount = 0;
        objectiveColor = "null";
        levelScore = 0;
        objectiveGoal = -1; //to prevent immediate spawn of the next level, since levels will move on once the number of targets hit equals the objective goal
        objectiveCount = 0;
        objectiveChance = 1; //1 being 100% chance
        scoreMultiplier = 1;
        targetTimer = 0;

    }

    //pararameterized constructor
    //odds for target spawns, number of targets needed to hit for the level, and target movement speeds and spawn rate are determined by game logic and passed in
    //game logic will track what overall level the player is on and pass the difficulty settings for the level into level logic
    public LevelLogic(int inputLevelCount, int inputGoal, double inputChance, float inputTimer)
    {
        levelCount = inputLevelCount;
        objectiveGoal = inputGoal;
        objectiveChance = inputChance;
        targetTimer = inputTimer;
        levelScore = 0;
        scoreMultiplier = 1;
        objectiveCount = 0;

        int randomPos = random.Next(objectiveOptions.Count); 
        objectiveColor = objectiveOptions[randomPos];
    }


    // Start is called before the first frame update
    void Start()
    {
        //call game or ui class to display the level start panel
        //SetOdds();
        StartCoroutine(SpawnAttacks());
        StartCoroutine(SpawnTargets());
    }

    // Update is called once per frame
    void Update() //call the level complete check and method to add level score to the total score
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
            hitTarget.isHit = true;
            hitTarget.gameObject.SetActive(false);
        }
        //if the target is the correct color 
        else
        {
            hitTarget.isHit = true;
            hitTarget.gameObject.SetActive(false);
            //add points and point multiplier
            objectiveCount += 1;
        }

        if (hitTarget.isBomb == true) //if the target is a bomb, call destroy all method
        {
            DestroyAll();
        }
    }

    //method that will set the chances of objectives and attacks spawning, DO THIS LAST
    public void SetOdds()
    {

    }

    //Method to spawn targets every x amount of seconds, setting this to 5 currently until I work out the odds calculation
    IEnumerator SpawnTargets()
    {
        //grab 5 random targets from the object pool, create a list of them, set all of them to active, and apply an upward force to them
        //random access 5 objects from the pool, change their properties by level odds, set them to active, launch them upwards
        //afterwards worry about how targets will be returned, clear the new small list of objects after turning them off

        while (true)
        {
            List<GameObject> targetsToLaunch = new List<GameObject>();
            for (int i = 0; i < 5; i++)
            {
                int randPos = random.Next(0, ObjectPool.pooledTargets.Count);
                targetsToLaunch.Add(ObjectPool.pooledTargets[randPos]);
            }

            foreach (GameObject launchTarget in targetsToLaunch)
            {
                launchTarget.gameObject.SetActive(true);
                Rigidbody targetRigidBody = launchTarget.GetComponent<Rigidbody>();
                targetRigidBody.AddForce(0, 1, 0, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(5f);
        }
    }

    //coroutine for spawning attacks every x amount of intervals (making it 13 seconds just for testing)
    IEnumerator SpawnAttacks()
    {
        while (true)
        {
            if (random.Next(0, 2) == 0)
            {
                attacks.SpawnWave();
            }
            else
            {
                attacks.SpawnDragon();
            }

            yield return new WaitForSeconds(13f);
        }
    }

       
    //Method called if the hit target is an bomb, will destroy all other targets onscreen and player's score will increase accordingly
    //figure out how to get all of the targets currently onscreen
    //using pooling, you can look at all active objects and turn them off instead of destroying them
    public void DestroyAll()
    {
        //check all targets in the object pool and set them to false
        foreach(GameObject targetToDisable in ObjectPool.pooledTargets){
            targetToDisable.gameObject.SetActive(false);
        }
        
    }


   //check for level complete method to end level when objective is reached
   //stops the level (maybe similar to pause) and shows the end of level ui
   //sends info back to game logic so the next level can be started
   //have individual methods to set things to 0 or reset
   //returns entire level to game logic so its score and level number can be stored
   public LevelLogic LevelComplete()
    {
        //call whichever methods stop the game and reset things like level score and pause spawns
        DestroyAll();
        return this;
    }


}
