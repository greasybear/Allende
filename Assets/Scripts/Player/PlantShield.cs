using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShield : MonoBehaviour {
    public GameObject plantedShield;
    public float shieldCount = 2f;
    public GameObject shieldy;
    PlayerMovement playerMovement;
    void Update () {

        if (Input.GetKeyDown(KeyCode.T)&& shieldCount > 0f)
            {
            
                Instantiate(plantedShield, transform.position + transform.forward*1 +transform.up*1, transform.rotation); 

                shieldCount -= 1;
            playerMovement.speed += 1;
        }
        if (Input.GetButton("Fire2") && shieldCount > 0f)
        {
            
            shieldy.SetActive(true);
        }
        else
        {
            
            shieldy.SetActive(false);
        }
    }
}
