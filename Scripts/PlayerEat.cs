using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEat : MonoBehaviour{

    public GameObject FoodSpawner;

    //public Text scoreText;
    public float increase;
    public string PowerUpTag;
    public string FoodTag;
    public string CycloneTag;

    public float doublePointsTime;
    public float halfPointsTime;
    public float immunityTime;

    public bool immunity;
    
    public int score; //public to be accessed by other game objects

    
    float hpTimer; //half points timer
    float iTimer; //immunity timer
    float dpTimer; //double points timer

    bool halfPoints;
    bool doublePoints;

    private void OnTriggerEnter(Collider other){

        //check if collision object is same size or smaller food
        if (other.gameObject.tag == FoodTag && other.gameObject.transform.localScale.x <= transform.localScale.x){
            
            CheckPlayerSize();
            Destroy(other.gameObject);
            GetComponent<PlayerMove>().eatSpeed = true; // slows after eating

            //add score
            if (halfPoints){ //after half points power up

                score += 5;

            } else if (doublePoints){ //after double points powerup

                score += 20;

            } else {

                score += 10;
            }
        //check if collision object is same size or smaller powerup    
        } else if (other.gameObject.tag == PowerUpTag && other.gameObject.transform.localScale.x <= transform.localScale.x){
            
            string powerupName = other.gameObject.name;

            switch (powerupName){ //identify powerup and change player behaviour

                case "DoublePoints(Clone)":

                    print("hit Double Points powerup");

                    doublePoints = true;                   
                    break;

                case "HalfPoints(Clone)":

                    print("hit Half Points powerup");

                    halfPoints = true;
                    break;

                case "Immunity(Clone)":

                    print("hit Immunity powerup");

                    immunity = true;
                    break;

                case "DoubleSpeed(Clone)":

                    print("hit Speed powerup");

                    //access double speed bool in PlayerMove script
                    GetComponent<PlayerMove>().doubleSpeed = true;
                    break;

                case "Draw(Clone)":

                    print("hit Draw powerup");

                    //cycle through food prefabs and turn draw on
                    for(int i = 0; i < FoodSpawner.GetComponent<FoodSpawn>().foodTypesArray.Length; i++){

                        FoodSpawner.GetComponent<FoodSpawn>().foodTypesArray[i].GetComponent<FoodDraw>().draw = true;
                    }                        
                    break;

                case "Invisibility(Clone)":

                    print("hit Invisibility powerup");
                    break;

                default:

                    print("There is a problem");
                    break;
            }
            Destroy(other.gameObject);
            GetComponent<PlayerMove>().eatSpeed = true;

            //check if collision object is same size or smaller cyclone
        } else if (other.gameObject.tag == CycloneTag && other.gameObject.transform.localScale.x <= transform.localScale.x){
            print("Hit smaller cyclone");
            //add score - 100 times cyclone diameter
            score += (int)Mathf.Round(other.gameObject.transform.localScale.x * 100);

            Destroy(other.gameObject);
            GetComponent<PlayerMove>().eatSpeed = true;

            //increase player size
            CheckPlayerSize();
            
        } else if(other.gameObject.tag == CycloneTag){

            if (immunity){

                print("You are immune");

            } else {

                print("PLayer dead"); //move to gameover scene
            }
            

        } else if (other.gameObject.tag == FoodTag) {

            print("Larger Food");

        
        } else {

            print("Something is wrong");
        }
        //scoreText.text = "Score: " + score;
    }
    //limit player size to cat4 so player cannot win
    void CheckPlayerSize(){

        if (transform.localScale.x < 4){

            //increase player size in 3D
            transform.localScale += new Vector3(increase, increase, increase);
        }
    }
    void Update(){

        if (halfPoints){ //time out half points

            hpTimer += Time.deltaTime;

            if(hpTimer == halfPointsTime){

                halfPoints = false;
                hpTimer = 0; //reset timer
            }
        }
        if (immunity){ //time out immunity

            iTimer += Time.deltaTime;

            if (iTimer == immunityTime){

                immunity = false;
                iTimer = 0; //reset timer
            }
        }
        if (doublePoints){ //time out double points

            halfPoints = false; //double points overrides half points
            dpTimer += Time.deltaTime;

            if (dpTimer == doublePointsTime){

                doublePoints = false;
                dpTimer = 0; //reset timer
            }
        }        
    }
}
