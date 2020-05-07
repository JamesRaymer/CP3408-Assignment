using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDraw : MonoBehaviour{

    public GameObject player;
    public float drawTime;
    public bool draw;
    public float speedDifference;

    float dTimer;
    float speed;

    float size;

    void Start(){

        draw = false;
    }
    void Update(){

        if (draw){ //player has eaten draw powerup
            print("In Draw");
            
            float size = player.transform.localScale.x;
            Vector3 target = player.transform.position;
            speed = player.GetComponent<PlayerMove>().speed;

            //if food is size or smaller, bring food to player position
            if(transform.localScale.x <= size){

                transform.position = Vector3.MoveTowards(transform.position, target, (speed + speedDifference) * Time.deltaTime);

            }
            dTimer += Time.deltaTime;

            print("DrawTimer: " + dTimer);

            if(dTimer >= drawTime){

                draw = false;
                dTimer = 0;
            }
        }
    }
}
