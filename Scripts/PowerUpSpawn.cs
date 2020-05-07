using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour{

    public GameObject[] powerupTypesArray; //array holding powerup types
    public float powerupSpawnTime; //time between powerups getting generated

    void Start(){

        //run generate() after 10 secs then repeat on time
        InvokeRepeating("Generate", 0, powerupSpawnTime);
    }
    //this generates powerups on the field of play
    void Generate(){

        //choose powerup type from Array
        var i = Random.Range(0, powerupTypesArray.Length);

        //choose random target location
        int x = Random.Range(-30, 30);
        int y = Random.Range(-15, 15);

        //set target co-ordinates
        Vector3 target = new Vector3(x, y, 0);

        //x and y positions are set, set z to 0 for 2D Vector3
        target.z = 0;

        //Spawn powerups at target position with no rotation
        Instantiate(powerupTypesArray[i], target, Quaternion.identity);
    }
}
