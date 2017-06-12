using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShoot : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets;
    public float range = 100f;

  //  GameObject player;
    float timer;
  
    ParticleSystem gunParticles;
    
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public bool startShooting = false;
    public float shotSpeed = 50f;
    public float accuracy;
    public GameObject bullet;

    Patrol patrol;
    Transform player;
    Transform enemy;
    public float beginShooting = 25f;

    void Awake()
    {
        enemy = this.gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gunParticles = GetComponent<ParticleSystem>();
        timeBetweenBullets = Random.Range(.5f, 1f); 
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        patrol = GetComponentInParent<Patrol>();

    }


    void Update()
    {
        timer += Time.deltaTime;

        float dist = Vector3.Distance(player.position, enemy.position);
        if (dist < beginShooting)
        { startShooting = true; }
        else if (dist > beginShooting)
        { startShooting = false; }

        if (startShooting && timer >= timeBetweenBullets && Time.timeScale != 0 && patrol.playerVisible)
        {
            Shoot();
        }


        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
       
        gunLight.enabled = false;
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        startShooting = true;
    //    }
    //}


    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        startShooting = false;
    //    }
    //}



    public void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        GameObject shooter = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        shooter.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed + Random.insideUnitSphere*accuracy);
    }
}

