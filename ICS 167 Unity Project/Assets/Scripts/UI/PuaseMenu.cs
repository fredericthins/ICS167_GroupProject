using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuaseMenu : MonoBehaviour
{
    public void BackToTitle()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
