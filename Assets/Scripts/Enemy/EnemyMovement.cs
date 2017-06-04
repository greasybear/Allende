using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    EnemyAttack enemyAttack;
    

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        enemyAttack = GetComponent<EnemyAttack>();
        
    }


    void Update()
    {
        
       if (enemyAttack.playerInRange)
        {
            nav.enabled = false;

        }
        else if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !enemyAttack.playerInRange)
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
        }



    }

}
