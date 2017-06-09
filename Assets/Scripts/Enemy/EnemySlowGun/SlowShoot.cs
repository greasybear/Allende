using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShoot : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets;
    public float range = 100f;

    GameObject player;
    float timer;
  
    ParticleSystem gunParticles;
    
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public bool startShooting = false;
    public float shotSpeed = 50f;

    public GameObject bullet;

    void Awake()
    {

        
        gunParticles = GetComponent<ParticleSystem>();
        timeBetweenBullets = Random.Range(.15f, 1f);
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player");

    }


    void Update()
    {
        timer += Time.deltaTime;

        if (startShooting && timer >= timeBetweenBullets && Time.timeScale != 0)
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            startShooting = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            startShooting = false;
        }
    }



    public void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        GameObject shooter = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        shooter.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
    }
}

