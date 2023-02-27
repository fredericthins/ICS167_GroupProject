using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // StartMenu was worked on by Dale

    public void Start1PlayerGame()
    {
        SceneManager.LoadScene("Game Rework");
        GameManager.resetGame(); // Loads default settings for game
        GameManager.disableMultiplayer();
    }
    public void Start2PlayerGame()
    {
        SceneManager.LoadScene("Game Rework");
        GameManager.resetGame(); // Loads default settings for game
        GameManager.enableMultiplayer();
    }

    public void ExitGame()
    {
        Debug.Log("Exited Game.");
        Application.Quit();
    }

}
