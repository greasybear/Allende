using UnityEngine;
using System.Collections;

public class EnemyAttackGun : MonoBehaviour
{
    GameObject player;
    public bool playerInRange;
    

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player )
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
