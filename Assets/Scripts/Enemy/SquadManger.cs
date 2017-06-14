using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadManger : MonoBehaviour {

    public GameObject[] squadMembers;
    
    
    void BreakPatrol()
    {
            foreach (GameObject enemy in squadMembers)
            {
                enemy.GetComponent<Patrol>().breakPatrol = true;            
            }
    }

    void Update()
    {
        // if (enemy.GetComponent<Patrol>().breakPatrol)            
        foreach (GameObject enemy in squadMembers)
        {
            if (enemy.GetComponent<Patrol>().breakPatrol)
            { BreakPatrol(); }
        }

    }
}
