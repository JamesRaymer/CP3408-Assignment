using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

    public float speed; //movement speed
    public Vector3 target; //allow access by cyclones to target player

    public bool doubleSpeed; //from double speed powerup
    public bool eatSpeed; //speed after eating

    float dsTimer; //double speed timer 2 sec
    float esTimer; //eat speed timer 1 sec

    
    private void Update(){

        //convert mouse position from pixels co-ordinates to transform co-ordinates
        //target is the mouse position
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //change the z position to the mouse position
        target.z = transform.position.z;

        //restrict player to game size
        if(target.x > 100){

            target.x = 100;           
        }
        if (target.x < -100){

            target.x = -100;            
        }
        if (target.y > 100){

            target.y = 100;           
        }
        if (target.y < -100){
            
            target.y = -100;
        }
        if (doubleSpeed) { //player has eaten double speed powerup and goes double speed for 2 secs

            eatSpeed = false; //double speed overrides eat speed

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime * 2); // double speed

            dsTimer += Time.deltaTime; //time out timer

            if (dsTimer >= 2) { //2 sec count

                doubleSpeed = false; //end double speed powerup
                dsTimer = 0; //reset timer
            }
        } else if(eatSpeed){ //player goes half speed for 1 sec after eating

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime / 2); // eat speed

            esTimer += Time.deltaTime; //time out timer
            
            if (esTimer >= 1){ //1 sec count

                eatSpeed = false; //end eat speed powerup
                esTimer = 0; //reset timer
            }
        } else {
            //player moves toward mouse position at normal speed
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }        
    }
}
