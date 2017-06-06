using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {
    PlantShield plantShield;
    public bool inRange;
    GameObject player;
    PlayerMovement playerMovement;
    Transform distance;
    public float pickUpDistance = 3f;
    public float speedGain = 2f;


    void Awake()
    {
        distance = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindWithTag("Player");
        plantShield = player.GetComponent<PlantShield>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float playerLocation = Vector3.Distance(distance.position, transform.position);
        if (playerLocation < pickUpDistance)
        { inRange = true; plantShield.enabled = false; }
        else { inRange = false; plantShield.enabled = true; }

        if (inRange && Input.GetKeyDown(KeyCode.T))
        {
            playerMovement.shieldCount += 1f;
            playerMovement.speed -= speedGain;
            plantShield.enabled = true;
            Destroy(gameObject);      
        }
    }
}
