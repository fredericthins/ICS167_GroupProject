using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // PauseMenu was worked on by Dale
    public void BackToTitle()
    {
        SceneManager.LoadScene("Start Menu");
        Time.timeScale = 1; // Unpauses game
        GameManager.isPaused = false;
    }
}
