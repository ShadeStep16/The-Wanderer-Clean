using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public float fireRate = 5f;

    public Camera playerCam;
    public ParticleSystem muzzle;
    public AudioSource SFX;


    private float nextFire = 0f;

    private void Start()
    {
        SFX = GetComponent<AudioSource>();
    }


    private void Update()
    {
        //if shoot not on cooldown, fire gun
        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Fire();
        }
    }

    //shooting function
    void Fire()
    {
        //play sfx and muzzle flash
        muzzle.Play();
        SFX.Play();

        //raycast from camera, straight out in front - record information of hit gameobject
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            //if the gameobject was an enemy (has an enemy script component) then hurt that enemy
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.Hurt(damage);
            }

            //Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));


        }
    }


}
