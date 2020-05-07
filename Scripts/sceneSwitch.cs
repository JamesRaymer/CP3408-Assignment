using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("game");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
        StartCoroutine(CountSeconds());
    }

    IEnumerator CountSeconds()
    {
        
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("game_over");


    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
