using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainScene()
    {
        if(PlayerPrefs.HasKey("TutorialDone"))
            SceneManager.LoadScene("MainScene");   
        else
            SceneManager.LoadScene("Tutorial");
    }
    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");    
    }

    public void GoToEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }

}
