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
        ZTText.text = "ZTokens: " + ZTokens;

        HealthSlider.maxValue = MaxPhealth;
        HealthSlider.value = Phealth;

        int HPPercent = Mathf.RoundToInt((Phealth / MaxPhealth) * 100);
        HPText.text = HPPercent + "%";



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

        if (Input.GetKeyDown(KeyCode.G) && ZTokens >= 500)
        {
            PHeal();
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

    void PHeal()
    {
        if (Phealth < MaxPhealth)
        {
            Phealth = MaxPhealth;

            ZTokens -= 500;
        }
    }



    void GameOver()
    {
        DeathMenu.Dead = true;

    }


}
