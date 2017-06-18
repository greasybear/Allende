using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShield : MonoBehaviour {
    public GameObject plantedShield;
    public GameObject plantedShieldShooter;
    public bool shieldUpgrade = false;
    
    PlayerMovement playerMovement;
    public float speedGain = 2f;

    void Awake()
    { playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); }


    void Update () {

        if(Input.GetKeyDown(KeyCode.P))
        { shieldUpgrade = !shieldUpgrade; }


        if (Input.GetKeyDown(KeyCode.E)&& playerMovement.shieldCount > 0f && !shieldUpgrade)
            {           
               Instantiate(plantedShield, transform.position + transform.forward*1 +transform.up*1, transform.rotation); 

               playerMovement.shieldCount -= 1;
               playerMovement.speed += speedGain;
            }
        else if (Input.GetKeyDown(KeyCode.E) && playerMovement.shieldCount > 0f && shieldUpgrade)
        {
            Instantiate(plantedShieldShooter, transform.position + transform.forward * 1 + transform.up * 1, transform.rotation);

            playerMovement.shieldCount -= 1;
            playerMovement.speed += speedGain;
        }
    }
}
