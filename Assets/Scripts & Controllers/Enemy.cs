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
    public float Arange = 2f;

    public float nextHit;
    public float hitRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();

        for (int i = 0; i < GM.CurrentWave; i++)
        {
            Chealth = Bhealth + (20f * GM.CurrentWave);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistance = Vector3.Distance(Player.transform.position, transform.position);

        Anim.SetFloat("PlayerDistance", PlayerDistance);


        if (PlayerDistance < ALock && Dead == false)
        {
            Nav.enabled = true;
            Nav.SetDestination(Player.transform.position);

        }
        else if (PlayerDistance > ALock && Dead == false)
        {
            this.Nav.enabled = false;
        }

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


        if (Attacking == true && Dead == false)
        {
            if (Time.time >= nextHit)
            {
                nextHit = Time.time + 1f / hitRate;
                Hit();
            }
        }

    }

    public void Hit()
    {
        GM.Phealth -= Adamage;
    }


    public void Hurt(float inflict)
    {
        Chealth -= inflict;
        if (Chealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        this.Nav.enabled = false;
        Dead = true;
        Anim.SetBool("Dead", true);
        GameObject.Destroy(gameObject, 5f);
    }

}
