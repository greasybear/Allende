using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : MonoBehaviour {

    float spawnTimer;
    public float timeBetweenSpawns = 3f;
    public GameObject spawner;
    bool crossedTheLine = false;
    public Transform spawnPosition;
    
    

    void Awake()
    {
        spawnTimer = Time.time + timeBetweenSpawns;
        
    }
    
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            crossedTheLine = true;
        }
    }

	void Update () {

        if (crossedTheLine && spawnTimer < Time.time && !CFourPlant.isDestroyed)
        {
            Instantiate(spawner, spawnPosition.position, spawnPosition.rotation);
            spawnTimer = Time.time + timeBetweenSpawns;
        }
		
	}
}
