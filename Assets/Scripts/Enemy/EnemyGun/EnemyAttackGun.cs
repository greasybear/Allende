using UnityEngine;
using System.Collections;

public class EnemyAttackGun : MonoBehaviour
{
    GameObject player;
    public bool playerInRange;
    EnemyMovmentSlow enemyMovementSlow;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMovementSlow = GetComponent<EnemyMovmentSlow>();
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && enemyMovementSlow.playerVisible)
        {
            playerInRange = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            
            
        }
    }
}
