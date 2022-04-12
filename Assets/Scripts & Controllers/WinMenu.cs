using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public static bool Win = false;

    public GameObject DeathMenuUI;
    public GameObject HUDUI;
    public GameObject PauseMenuUI;
    public GameObject WinMenuUI;

    public void Start()
    {
        Win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Win)
        {
            YouWin();
        }
    }

    void YouWin()
    {
        Cursor.lockState = CursorLockMode.Confined;
        HUDUI.SetActive(false);
        WinMenuUI.SetActive(true);
        DeathMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }


    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HUDUI.SetActive(true);
        WinMenuUI.SetActive(false);
        DeathMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.Paused = false;
        Win = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        HUDUI.SetActive(true);
        WinMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        DeathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Win = false;
        SceneManager.LoadScene("Menu Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
