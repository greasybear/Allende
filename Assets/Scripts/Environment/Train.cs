using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    PlayerHealth playerHealth;
    EnemyHealthSlowGun enemyHealth;
    
    void OnTriggerEnter(Collider victim)
    {
        if (victim.tag == "Player")
        {
            victim.GetComponent<PlayerHealth>().Death();
           
        }
        else if (victim.tag =="Enemy")
        {
            victim.transform.GetComponent<EnemyHealthSlowGun>().Death();

        }
    }
    
}
