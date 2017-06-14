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
    public float accuracy;
    public GameObject bullet;
    EnemyMovmentSlow enemyMovement;
    EnemyAttackGun enemyAttack;
    Transform player;
    Transform enemy;
    public float beginShooting = 20f;

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


    void Update()
    {
        timer += Time.deltaTime;

        float dist = Vector3.Distance(player.position, enemy.position);
        if (dist < beginShooting)
        { startShooting = true; }
        else if (dist > beginShooting)
        { startShooting = false; }

        if (startShooting && timer >= timeBetweenBullets && Time.timeScale != 0 && enemyAttack.playerInRange && enemyMovement.playerVisible)
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

