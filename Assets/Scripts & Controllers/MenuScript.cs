using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //load scene "level" 1 (wave-based main level)
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    //load scene "Level Endless" ("endless" extra level)
    public void PlayLevelEndless()
    {
        SceneManager.LoadScene("Level Endless");
    }
    //Quit the game (works in build)
    public void QuitGame()
    {
        Application.Quit();
    }

}
