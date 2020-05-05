using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawn : MonoBehaviour
{

    public GameObject[] foodTypesArray; //array holding food types
    public float speed; //time food gets generated

    void Start()
    {

        //run generate() on start then repeat every speed seconds
        InvokeRepeating("Generate", 0, speed);
    }
    //this generates food in the camera's view
    void Generate()
    {

        //choose food type from Array
        var i = Random.Range(0, foodTypesArray.Length);

        //location chosen randomly on the screen in pixels
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        //convert pixel position to transform co-ordinates
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));

        //x and y positions are set, set z to 0 for 2D Vector3
        target.z = 0;

        //Spawn food at target position with no rotation
        Instantiate(foodTypesArray[i], target, Quaternion.identity);
    }
}
