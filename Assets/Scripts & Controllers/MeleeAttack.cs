using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public SeekandAttack SAA;

    public Animator Anim;
    public bool Attacking;

    public float damage = 50f;



    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Anim.SetBool("Attacking", true);
            Attacking = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Anim.SetBool("Attacking", false);
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
                SAA.health -= 10f;
            }
        }
    }


}
