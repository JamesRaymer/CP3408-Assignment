using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameVars : MonoBehaviour
{

    public Text hiscoreTxt;

    private void Awake()
    {
        //Check for a historic highscore
        if (!PlayerPrefs.HasKey("HiScore"))
        {
            PlayerPrefs.SetInt("HiScore", 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set current score
        PlayerPrefs.SetInt("Score", 0);
        //Set Enemy01score score
        PlayerPrefs.SetInt("Enemy01score", 100);
        //Take highscore and string it
        hiscoreTxt.text = PlayerPrefs.GetInt("HiScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
