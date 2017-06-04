using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {
    PlantShield plantShield;
    public bool inRange;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        plantShield = player.GetComponent<PlantShield>();
    }

    void OnTriggerEnter()
    {
        inRange = true;
        plantShield.enabled = false;
    }

    void OnTriggerExit()
    {
        inRange = false;
        plantShield.enabled = true;

    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.T))
        {
            plantShield.shieldCount += 1f;
            plantShield.enabled = true;
            Destroy(gameObject);
        
        }

    }
	
}
