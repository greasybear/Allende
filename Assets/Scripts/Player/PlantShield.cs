using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShield : MonoBehaviour {
    public GameObject plantedShield;
    
    PlayerMovement playerMovement;
    public float speedGain = 2f;

    void Awake()
    { playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); }


    void Update () {

        if (Input.GetKeyDown(KeyCode.T)&& playerMovement.shieldCount > 0f)
            {           
               Instantiate(plantedShield, transform.position + transform.forward*1 +transform.up*1, transform.rotation); 

               playerMovement.shieldCount -= 1;
               playerMovement.speed += speedGain;
        }       
    }
}
