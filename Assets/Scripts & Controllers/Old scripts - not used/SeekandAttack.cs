using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekandAttack : MonoBehaviour
{
    public GameObject Player;
    Animator Anim;

    public CombatScript PCS;

    private float PlayerDistance;
    public bool Dead;
    public bool Attacking;

    public float health = 100f;

    public float Adamage = 10f;
    public float ALock = 15f;
    public float Arange = 2f;




    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

        Player = GameObject.FindGameObjectWithTag("Player");
        PCS = Player.GetComponent<CombatScript>();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerDistance = Vector3.Distance(Player.transform.position, transform.position);

        Anim.SetFloat("PlayerDistance", PlayerDistance);


        if (PlayerDistance < ALock && Dead == false)
        {
            transform.LookAt(Player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.005f);
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


    }


}
