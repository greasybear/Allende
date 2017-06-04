using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {
    public int damage;
    GameObject player;
    PlayerHealth playerHealth;
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
        Destroy(gameObject);

    }

}
