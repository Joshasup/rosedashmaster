using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStartButton()
    {

        SceneManager.LoadScene("joshScene2");
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("end death");
    }

    public void BackToStartMenu()
    {
        SceneManager.LoadScene("OpeningScene");
    }

    public void WinningScene() 
    {
        SceneManager.LoadScene("CONGRATS");
    }
}
