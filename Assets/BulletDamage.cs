using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {
    public int damage;
    GameObject player;
    PlayerHealth playerHealth;
    float timer;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);

            Destroy(gameObject);
        }
        else { Destroy(gameObject); }

        
        

    }
    void Update()
    { timer += Time.deltaTime; 

    if (timer > 4)
        {Destroy(gameObject); }
    }

}
