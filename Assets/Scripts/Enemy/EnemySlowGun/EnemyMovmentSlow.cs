using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovmentSlow : MonoBehaviour {

    Transform player;
    PlayerHealth playerHealth;
    EnemyHealthSlowGun enemyHealth;
    public NavMeshAgent nav;
    EnemyAttackGun enemyAttack;
    public bool alarmSearch = true;
    public bool playerVisible;
    Transform enemy;
    
    


    void Awake()
    {
        enemy = this.gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealthSlowGun>();
        nav = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttackGun>();
    }

    public void FindPlayer()
    { nav.SetDestination(player.position); } //null here

    void Start()
    {
        
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !enemyAttack.playerInRange)
        {
            FindPlayer();
        }

    }


    void Update()
    {  if (enemyHealth.currentHealth > 0 && !enemyHealth.isDead && alarmSearch) 
        {
            NavMeshHit hit;
         if (!nav.Raycast(player.position, out hit))
            { playerVisible = true; }
            else { playerVisible = false; }

            if (enemyAttack.playerInRange && playerVisible)
            {

                
                transform.LookAt(player);
                nav.SetDestination(enemy.position);

            }
            else if (playerHealth.currentHealth > 0 && !enemyAttack.playerInRange || !playerVisible)
            {


                nav.SetDestination(player.position);
            }

            if (enemyHealth.isDead)
            {
                nav.enabled = false;
            }

        }

    }

}


