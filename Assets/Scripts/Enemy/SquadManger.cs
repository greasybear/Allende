using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquadManger : MonoBehaviour {

    public GameObject[] squadMembers;
    public GameObject alarmer;
    public Transform alarm;
    public bool alarmSounded = false;
    
    void BreakPatrol()
    {
        alarmer.GetComponent<Patrol>().breakPatrol = true;
        alarmer.GetComponent<EnemyMovmentSlow>().alarmSearch = false;
        alarmer.GetComponent<EnemyMovmentSlow>().nav.SetDestination(alarm.position);

        foreach (GameObject enemy in squadMembers)
            {
                enemy.GetComponent<Patrol>().breakPatrol = true;            
            }
    }

    void Update()
    {
        float dist = Vector3.Distance(alarm.position, alarmer.transform.position);
        // if (enemy.GetComponent<Patrol>().breakPatrol)            
        foreach (GameObject enemy in squadMembers)
        {
            if (enemy.GetComponent<Patrol>().breakPatrol)
            {
                //alarmer.GetComponent<Patrol>().breakPatrol = true;
                //alarmer.GetComponent<EnemyMovmentSlow>().alarmSearch = false;
                //alarmer.GetComponent<EnemyMovmentSlow>().nav.SetDestination(alarm.position);
                
                BreakPatrol();
            }
            

        }
     

        if (dist < 3f)
        {
            alarmSounded = true;
            
        }

        if (alarmSounded)
        {
            alarmer.GetComponent<EnemyMovmentSlow>().alarmSearch = true;
            alarmer.GetComponent<EnemyMovmentSlow>().FindPlayer();
        }
        

    }
}
