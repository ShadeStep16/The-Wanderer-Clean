using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject HUD;
    public GameObject[] SpawnPoints;
    public GameObject EnemyGroup;

    public TMP_Text ECText;
    public TMP_Text WaveText;
    public TMP_Text ZTText;
    public TMP_Text HPText;

    public GameObject DeathMenuUI;

    public GameObject Torch;

    public Slider HealthSlider;

    public int ZTokens = 0;

    public float Phealth = 150f;
    public float MaxPhealth = 150f;
    public int enemyCount;
    public int CurrentWave = 0;
    public int WaveLim = 10;


    // Start is called before the first frame update
    void Start()
    {
        //If playing endless mode, then set wave limit to unreachable number
        if (SceneManager.GetActiveScene().name == "Level Endless")
        {
            WaveLim = 1000000;
        }
        //Populate SpawnPoints array for enemy spawning
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy count - alive in scene
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = Enemies.Length;

        //Update HUD UI & Slider
        ECText.text = "Enemies: " + enemyCount;
        WaveText.text = "Wave " + CurrentWave;
        ZTText.text = "ZTokens: " + ZTokens;

        HealthSlider.maxValue = MaxPhealth;
        HealthSlider.value = Phealth;

        int HPPercent = Mathf.RoundToInt((Phealth / MaxPhealth) * 100);
        HPText.text = HPPercent + "%";


        //if no enemies alive, new wave
        if (enemyCount <= 0)
        {
            SpawnWave();
        }

        //if player out of health - game over
        if (Phealth <= 0)
        {
            GameOver();
        }

        //toggle torch
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

        //buy and use heal
        if (Input.GetKeyDown(KeyCode.G) && ZTokens >= 500)
        {
            PHeal();
        }

    }

    //Function for spawning waves
    void SpawnWave()
    {
        //increase current wave by 1
        CurrentWave++;

        //if havent reached wave limit (game isnt over) then spawn enemy groups at the spawnpoints
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
        else if (CurrentWave > WaveLim) //if the wave limit has been reached, then game over and player wins
        {
            WinMenu.Win = true;
        }

    }

    //Heal function
    void PHeal()
    {
        if (Phealth < MaxPhealth)
        {
            //set health back to max
            Phealth = MaxPhealth;
            //spend 500 ZTokens
            ZTokens -= 500;
        }
    }


    //game over function
    void GameOver()
    {
        DeathMenu.Dead = true;

    }


}
