using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void PlayLevelEndless()
    {
        SceneManager.LoadScene("Level Endless");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
