using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerEatScript : MonoBehaviour


{

    public Text scoreTxt;
    int en01score = 0;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // get scores for each enemy type
        en01score = PlayerPrefs.GetInt("Enemy01score");
        print("Enemy score: " + en01score);
        // reset score in UI
        scoreTxt.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //code for entity in eatable range detected here triggering Eat(The ediable entity)
    }

    public void Eat(GameObject id)
    {
        //code for time delayed eating maybe should be co-routine
    }
}
