using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public float accuracy;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public bool shield;
    public bool rocketLauncher = false;
    public bool ak = true;
    public GameObject rocket;
    public float shotSpeed;


    void Awake ()
    {
        
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        
        
    }
    void shootRocket()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        

        GameObject shooter = Instantiate(rocket, transform.position, transform.rotation * Quaternion.Euler(0,90,90)) as GameObject;
        shooter.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed + Random.insideUnitSphere * accuracy);
    }


    void Update ()
    {
        if(rocketLauncher)
        {
            ak = false;
            timeBetweenBullets = 1f;
        }
        if(ak)
        {
            rocketLauncher = false;
            timeBetweenBullets = .15f;
        }

        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && ak)
        {
            Shoot ();
        }
        else if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && rocketLauncher)
        { shootRocket(); }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
        if (Input.GetButton("Fire2"))
        { shield = true; 
        
        }
        else
        { shield = false;
        
        }


    }
    
    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {   if (!shield)
        {
            timer = 0f;

            gunAudio.Play();

            gunLight.enabled = true;

            gunParticles.Stop();
            gunParticles.Play();

            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward +Random.insideUnitSphere * accuracy;

            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }
                gunLine.SetPosition(1, shootHit.point);

                EnemyHealthSlowGun enemyHealthSlowGun = shootHit.collider.GetComponent<EnemyHealthSlowGun>();

                if (enemyHealth || enemyHealthSlowGun != null)
                {
                    enemyHealthSlowGun.TakeDamage(damagePerShot, shootHit.point);
                }
                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }
    }
}
