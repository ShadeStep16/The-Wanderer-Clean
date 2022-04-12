using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool Dead = false;

    public GameObject DeathMenuUI;
    public GameObject HUDUI;
    public GameObject PauseMenuUI;
    public GameObject WinMenuUI;

    public void Start()
    {
        Dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Cursor.lockState = CursorLockMode.Confined;
        HUDUI.SetActive(false);
        DeathMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }


    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HUDUI.SetActive(true);
        DeathMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.Paused = false;
        Dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        HUDUI.SetActive(true);
        DeathMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
        Dead = false;
        SceneManager.LoadScene("Menu Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
