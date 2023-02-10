using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Start1PlayerGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Game Rework");
    }

    public void ExitGame()
    {
        Debug.Log("Exited Game.");
        Application.Quit();
    }
}
