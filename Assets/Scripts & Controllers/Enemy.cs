using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float PlayerDistance;
    public bool Dead;
    public bool Attacking;

    public GameManager GM;
    public GameObject Player;
    Animator Anim;
    NavMeshAgent Nav;

    public float Chealth;
    public float Bhealth = 80f;

    public float Adamage = 10f;
    public float ALock = 15f;
    public float ABLock = 15f;
    public float Arange = 2f;
    public float ABrange = 2f;

    public float nextHit;
    public float hitRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();

        Arange = ABrange;

        //every wave, increase the enemy's health and lock-on range that they can target the player from
        for (int i = 0; i < GM.CurrentWave; i++)
        {
            Chealth = Bhealth + (20f * GM.CurrentWave);
            ALock = ABLock + (0.5f * GM.CurrentWave);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get player distance from enemy
        PlayerDistance = Vector3.Distance(Player.transform.position, transform.position);

        Anim.SetFloat("PlayerDistance", PlayerDistance);

        //if player distance is less then lock-on distance, enable NavMesh Agent element
        if (PlayerDistance < ALock && Dead == false)
        {
            Nav.enabled = true;
            Nav.SetDestination(Player.transform.position);

        }
        else if (PlayerDistance > ALock && Dead == false) //if player distance is greater then lock-on distance, disable NavMesh Agent element
        {
            this.Nav.enabled = false;
        }

        //if player distance is less then attack range distance, let the enemy attack the player 
        if (PlayerDistance <= Arange && Dead == false)
        {
            Anim.SetBool("Attacking", true);
            Attacking = true;
        }
        else if (PlayerDistance > Arange && Dead == false)
        {
            Anim.SetBool("Attacking", false);
            Attacking = false;
        }

        //if the enemy is attacking then hurt the player 
        if (Attacking == true && Dead == false)
        {
            if (Time.time >= nextHit)
            {
                nextHit = Time.time + 1f / hitRate;
                Hit();
            }
        }

    }
    //hurt the player
    public void Hit()
    {
        GM.Phealth -= Adamage;
    }

    //get hurt
    public void Hurt(float inflict)
    {
        Chealth -= inflict;
        if (Chealth <= 0 && !Dead)
        {
            Die();
        }
    }

    //die - give player ZTokens, disable navmesh agent, play dead animation and destroy enemy after 5 seconds (save computer resources)
    void Die()
    {
        GM.ZTokens += 10;
        this.Nav.enabled = false;
        Dead = true;
        Anim.SetBool("Dead", true);
        GameObject.Destroy(gameObject, 5f);
    }

}
