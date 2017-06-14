using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {
    
    public Transform[] patrolPoints;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    EnemyMovmentSlow enemyMovement;
    public bool playerVisible;
    Transform player;
    Transform enemy;
    Patrol patrol;
    public float breakDistance = 20f;
    public bool breakPatrol = false;
    EnemyHealthSlowGun enemyHealth;

    void Awake()
    {
        patrol = GetComponent<Patrol>();
        enemy = this.gameObject.transform;
        enemyMovement = GetComponent<EnemyMovmentSlow>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement.enabled = false;
        enemyHealth = GetComponent<EnemyHealthSlowGun>();

        GoToNextPoint();
    }
    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;
        agent.destination = patrolPoints[destPoint].position;

        destPoint = (destPoint + 1) % patrolPoints.Length;
    }
  

    void Update()
    {
        float dist = Vector3.Distance(player.position, enemy.position);
        
        if (!agent.pathPending && agent.remainingDistance < 3f)
            GoToNextPoint();
        NavMeshHit hit;
        if (!agent.Raycast(player.position, out hit))
        { playerVisible = true; }
        else { playerVisible = false; }

        if (playerVisible && dist < breakDistance )
        {

            breakPatrol = true;
        }
        if (Input.GetButtonDown("Fire1") && dist< breakDistance)
        {
            breakPatrol = true;
        }
        if (enemyHealth.beingShot)
        { breakPatrol = true; }
        
        if(breakPatrol)
        {
            enemyMovement.enabled = true;
            patrol.enabled = false;
        }

    }
	
}
