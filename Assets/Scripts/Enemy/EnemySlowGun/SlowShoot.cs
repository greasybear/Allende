using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShoot : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets;
    public float range = 100f;


    float timer;
  
    ParticleSystem gunParticles;
    
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public bool startShooting = false;
    public float shotSpeed = 50f;
    public GameObject bullet;
    EnemyMovmentSlow enemyMovement;
    EnemyAttackGun enemyAttack;
    Transform player;
    Transform enemy;
    public float beginShooting = 20f;
    public GameObject enemyRocket;
    public bool gunshot = true;
    public bool rockets = false;

    void Awake()
    {
        enemy = this.gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gunParticles = GetComponent<ParticleSystem>();
        timeBetweenBullets = Random.Range(.5f, 1f); 
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        enemyAttack = GetComponentInParent<EnemyAttackGun>();
        enemyMovement = GetComponentInParent<EnemyMovmentSlow>();
    }
    void shootRocket()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();



        GameObject shooter = Instantiate(enemyRocket, transform.position + (transform.forward * 2), transform.rotation * Quaternion.Euler(0, 90, 90)) as GameObject;
        shooter.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
    }

    void Update()
    {
        if (rockets)
        {
            gunshot = false;
            timeBetweenBullets = 3f;
        }
        if (gunshot)
        {
            rockets = false;
            timeBetweenBullets = Random.Range(.5f, 1f); ;
        }
        timer += Time.deltaTime;

        float dist = Vector3.Distance(player.position, enemy.position);
        if (dist < beginShooting)
        { startShooting = true; }
        else if (dist > beginShooting)
        { startShooting = false; }

        if (startShooting && timer >= timeBetweenBullets && Time.timeScale != 0 && enemyAttack.playerInRange && enemyMovement.playerVisible && gunshot)
        {
            Shoot();
        }
        else if (startShooting && timer >= timeBetweenBullets && Time.timeScale != 0 && enemyAttack.playerInRange && enemyMovement.playerVisible && rockets)
        { shootRocket(); }


        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
       
        gunLight.enabled = false;
    }



    public void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        int accurate = Random.Range(1, 10);


        GameObject shooter = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        shooter.transform.Rotate(0, accurate, 0);
        shooter.GetComponent<Rigidbody>().AddForce(shooter.transform.forward * shotSpeed);
    }
}

