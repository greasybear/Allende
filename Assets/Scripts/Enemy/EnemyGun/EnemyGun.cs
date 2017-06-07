using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    GameObject player;
    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public bool startShooting = false;
    public float accuracy = .2f;
     
    
   
    


    void Awake()
    {
       
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
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
        gunLine.enabled = false;
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

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position); 

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward + Random.insideUnitSphere * accuracy;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            PlayerHealth playerHealth = shootHit.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damagePerShot);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            
        }
    }
}
