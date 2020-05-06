using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CycloSpawn : MonoBehaviour{

    public List<GameObject> cyclones; //need cyclone list to know where they are
    
    public GameObject cyclone; //cyclone prefab
    public GameObject counter;
    public float speed; //time cyclone gets generated

    string ID;
    
    void Start(){

        //run generate() 10 secs after start then repeat every speed seconds
        InvokeRepeating("Generate", 10, speed);
    }
    //this generates cyclones
    void Generate(){
        
        //choose random target location
        int x = Random.Range(-30, 30);
        int y = Random.Range(-15, 15);

        //set target co-ordinates
        Vector3 target = new Vector3(x, y, 0);

        //x and y positions are set, set z to 0 for 2D Vector3
        target.z = 0;

        //random cyclone size (1 - 4)
        float size = Random.Range(1f, 4f);

        //create cyclone
        cyclone.transform.localScale = new Vector3(size, size, size);

        cyclone.GetComponent<CycloneID>().ID = cyclone.GetComponent<CycloneID>().Increment();


        //Spawn cyclone at target position with no rotation
        Instantiate(cyclone, target, Quaternion.identity);

        
        

        //add cyclone to list
        cyclones.Add(cyclone);

        

        for (int i = 0; i < cyclones.Count; i++){

            print("Position: " + i + " X: " + cyclone.transform.localScale.x + " Y: " + cyclone.transform.localScale.y);

            
        }       
    }
    

}
