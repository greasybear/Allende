using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public bool exitPatrol;
    public Transform[] patrolPoints;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    EnemyMovmentSlow enemyMovement;
    public bool playerVisible;
    UnityEngine.AI.NavMeshHit hit;
    Transform player;
    Transform enemy;
    Patrol patrol;
    public bool hearingRange;

    void Awake()
    {
        patrol = GetComponent<Patrol>();
        enemy = this.gameObject.transform;
        enemyMovement = GetComponent<EnemyMovmentSlow>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement.enabled = false;

        GoToNextPoint();
    }
    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;
        agent.destination = patrolPoints[destPoint].position;

        destPoint = (destPoint + 1) % patrolPoints.Length;
    }
    
    void OnTriggerEnter()
    {
        hearingRange = true;
    }
    void OnTriggerExit()
    { hearingRange = false;}

    void Update()
    {
        float dist = Vector3.Distance(player.position, enemy.position);
        

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();

        if (!agent.Raycast(player.position, out hit))
        { playerVisible = true; }
        else { playerVisible = false; }


        if (playerVisible && dist < 10f )
        {

            enemyMovement.enabled = true;
            patrol.enabled = false;    
        }
        if (Input.GetButtonDown("Fire1") && hearingRange)
        {
            enemyMovement.enabled = true;
            patrol.enabled = false;
        }

    }
	
}
