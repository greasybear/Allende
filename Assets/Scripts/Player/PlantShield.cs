using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShield : MonoBehaviour {
    public GameObject plantedShield;
    public float shieldCount = 3f;
    

    void Update () {

        if (Input.GetKeyDown(KeyCode.T)&& shieldCount > 0f)
            {
            
                Instantiate(plantedShield, transform.position + transform.forward*1 +transform.up*1, transform.rotation); 

                shieldCount -= 1;
        }
    }
}
