using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemyToSpawn;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject == player )
    {
        Instantiate(enemyToSpawn);
        Instantiate(enemyToSpawn);
        Destroy(this.gameObject);
    }
}
}
