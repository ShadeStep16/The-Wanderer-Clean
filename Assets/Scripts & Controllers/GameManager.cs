using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject HUD;
    public GameObject[] SpawnPoints;
    public GameObject EnemyGroup;

    public TMP_Text ECText;
    public TMP_Text WaveText;

    public GameObject DeathMenuUI;

    public GameObject Torch;

    public float Phealth = 100f;
    public int enemyCount;
    public int CurrentWave = 0;
    public int WaveLim = 10;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level Endless")
        {
            WaveLim = 1000000;
        }

        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = Enemies.Length;

        ECText.text = "Enemies: " + enemyCount;
        WaveText.text = "Wave " + CurrentWave;

        if (enemyCount <= 0)
        {
            SpawnWave();
        }

        if (Phealth <= 0)
        {
            GameOver();
        }

        
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Torch.activeInHierarchy)
            {
                Torch.SetActive(false);
            }
            else if (!Torch.activeInHierarchy)
            {
                Torch.SetActive(true);
            }
            
        }


    }

    void SpawnWave()
    {

        CurrentWave++;

        if (CurrentWave <= WaveLim)
        {
            int i = 0;
            foreach (GameObject SP in SpawnPoints)
            {
                if (i < SpawnPoints.Length)
                {


                    Instantiate(EnemyGroup, SP.transform.position, SP.transform.rotation);
                    i++;
                }

            }
        }
        else if (CurrentWave > WaveLim)
        {
            WinMenu.Win = true;
        }

    }


    void GameOver()
    {
        DeathMenu.Dead = true;

    }


}
