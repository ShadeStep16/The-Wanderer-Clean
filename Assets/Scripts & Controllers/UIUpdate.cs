using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    public TMP_Text ECText;

    public GameObject DeathMsg;

    public GameObject Player;
    public GameManager GM;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ECText.text = "Enemies: " + GM.enemyCount;
    }
}
