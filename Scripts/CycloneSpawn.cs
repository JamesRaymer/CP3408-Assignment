using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycloneSpawn : MonoBehaviour{
    
    public GameObject cyclone; //cyclone prefab    
    public float cycloneSpawnTime; //time cyclone gets generated    

    void Start(){

        //run generate() 10 secs after start then repeat every speed seconds
        InvokeRepeating("Generate", 10, cycloneSpawnTime);
    }
    //this generates cyclones
    void Generate(){

        //choose random spawn location no further then half way to game ends
        int x = Random.Range(-50, 50);
        int y = Random.Range(-50, 50);

        //set target co-ordinates
        Vector3 target = new Vector3(x, y, 0);

        //x and y positions are set, set z to 0 for 2D Vector3
        target.z = 0;

        //random cyclone size (1 - 4)
        float size = Random.Range(1f, 4f);

        //create cyclone
        cyclone.transform.localScale = new Vector3(size, size, size);       


        //Spawn cyclone at target position with no rotation
        Instantiate(cyclone, target, Quaternion.identity);  
    }
}
