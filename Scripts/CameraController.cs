using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{

    public GameObject player;
    public float factor = 0.35f; //set camera move out factor so player looks the same size after eating

    Vector3 offset;

    float score; //player score
    float size; //camera orthographic size

    // Start is called before the first frame update
    void Start(){

        //get difference between camera and player positions
        offset = transform.position - player.transform.position;

        //get player score
        score = player.GetComponent<PlayerEat>().score;

        //get camera orthographic size
        size = GetComponent<Camera>().orthographicSize;
    }
    // LateUpdate is called last once per frame
    void LateUpdate(){

        //make camera follow player
        transform.position = player.transform.position + offset;

        //if player eats, camera moves away to keep player same size
        if (score != player.GetComponent<PlayerEat>().score){

            GetComponent<Camera>().orthographicSize += factor; //factor was calculated with a public variable

            score = player.GetComponent<PlayerEat>().score; //reset score
        }
    }
}
