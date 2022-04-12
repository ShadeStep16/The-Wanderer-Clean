using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject PauseMenuUI;
    public GameObject HUDUI;
    public GameObject DeathMenuUI;
    public GameObject WinMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        HUDUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
        DeathMenuUI.SetActive(false);
        Paused = false;
    }

    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HUDUI.SetActive(true);
        DeathMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        DeathMenu.Dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        HUDUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        WinMenuUI.SetActive(false);
        DeathMenuUI.SetActive(false);
        Paused = true;
    }

    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1f;
        HUDUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
        DeathMenuUI.SetActive(false);
        Paused = false;
        SceneManager.LoadScene("Menu Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
