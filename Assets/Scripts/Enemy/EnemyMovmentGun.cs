using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovmentGun : MonoBehaviour {
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    EnemyAttackGun enemyAttack;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttackGun>();

    }


    void Update()
    {

        if (enemyAttack.playerInRange && !enemyHealth.isDead)
        {
            nav.enabled = false;
            transform.LookAt(player);
        }
        else if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !enemyAttack.playerInRange)
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
        }

        if (enemyHealth.isDead)
        { nav.enabled = false;
            }



    }

}

