using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public Animator PlayerAnim;

    public SeekandAttack SAA;

    public bool Attacking;
    public int Kills = 0;

    public int Score = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAnim.SetBool("Attacking", true);
            Attacking = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            PlayerAnim.SetBool("Attacking", false);
            Attacking = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy") && Attacking == true)
        {
            SAA = col.gameObject.GetComponent<SeekandAttack>();

            if (!SAA.Dead)
            {
                Kills++;
                Score += 100;
                SAA.Dead = true;
            }

        }
    }

}
