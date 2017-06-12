using UnityEngine;
using System.Collections;

public class EnemyAttackGun : MonoBehaviour
{
    Transform enemy;
    Transform player;
    public bool playerInRange;
    public float stopAndShoot = 20f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = this.gameObject.transform;

    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, enemy.position);
        if(dist < stopAndShoot)
        { playerInRange = true; }
        else if (dist> stopAndShoot)
        { playerInRange = false; }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == player )
    //    {
    //        playerInRange = true;

    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        playerInRange = false;
            
            
    //    }
    //}
}
