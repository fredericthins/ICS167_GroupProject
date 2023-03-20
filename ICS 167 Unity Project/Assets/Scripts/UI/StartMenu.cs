using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // StartMenu was worked on by Dale

    public void StartLocalGame()
    {
        SceneManager.LoadScene("Game Rework");
        //GameManager.resetGame(); // Loads default settings for game
        GameManager.disableMultiplayer();
    }
    public void StartNetworkGame()
    {
        SceneManager.LoadScene("Loading");
        //GameManager.resetGame(); // Loads default settings for game
        GameManager.enableMultiplayer();
    }

    public void ExitGame()
    {
        Debug.Log("Exited Game.");
        Application.Quit();
    }

}
