using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFourPlant : MonoBehaviour {
    public bool close;
    public GameObject c4;
    public GameObject blowUp;
    public Transform player;
    public static bool isDestroyed = false;
    public GameObject explosion;
    public GameObject buildingParts; 
    
    
    

	void Awake()
    { player = GameObject.FindGameObjectWithTag("Player").transform; }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist < 2f)
        { close = true; }
        else { close = false; }


        if (blowUp == null)
        {
            GameObject parts = Instantiate(buildingParts, transform.position, Quaternion.identity);
            Destroy(parts, 5);
        }

        if (close && Input.GetButtonDown("Fire2") && CFour.c4Aquired)
        {
            Instantiate(c4, transform.position, Quaternion.identity);


            isDestroyed = true;
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            
           
            Destroy(c4,5);
            Destroy(exp, 5);
            Destroy(blowUp, 5);
            

            
            
            

        }

    }

}
