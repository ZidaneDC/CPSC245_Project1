using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    //Level Logic class, controls target spawn rates, obstacle spawn rates, color, level score and point mutliplier's
    //will alos have methods to check that an object being hit is the correct target, if it is a target at all

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Should probab
    void Update()
    {
        
    }
    //Hit method will be here, called when a target's collider is clicked, and will check the target's infomation to calculate the score
    public void DestroyAll() //Method called if the hit target is an bomb, will destroy all other targets onscreen and player's score will increase accordingly
    {

    }
}
