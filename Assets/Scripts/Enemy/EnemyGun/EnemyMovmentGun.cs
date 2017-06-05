using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovmentGun : MonoBehaviour {
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    public UnityEngine.AI.NavMeshAgent nav;
    EnemyAttackGun enemyAttack;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttackGun>();

    }
    public void FindPlayer()
    {
        nav.enabled = true;
        nav.SetDestination(player.position);
    }


    void Update()
    {

        if (enemyAttack.playerInRange && !enemyHealth.isDead)
        {
            nav.enabled = false;
            transform.LookAt(player);
        }   
        else if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !enemyAttack.playerInRange )
        {
            FindPlayer();
            //nav.enabled = true;
            //nav.SetDestination(player.position);
        }

        if (enemyHealth.isDead)
        { nav.enabled = false;
            }



    }

}

