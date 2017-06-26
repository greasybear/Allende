using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFourPlant : MonoBehaviour {
    bool close;
    public GameObject c4;
    public GameObject blowUp;
    public Transform player;
    public static bool isDestroyed = false;
    
    

	void Awake()
    { player = GameObject.FindGameObjectWithTag("Player").transform; }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist < 2f)
        { close = true; }
        else { close = false; }

        if (close && Input.GetButtonDown("Fire2") && CFour.c4Aquired)
        {
            Instantiate(c4);

            isDestroyed = true;
            Destroy(blowUp);
            
            

        }

    }

}
