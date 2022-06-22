using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] checkpoint;
    private Transform player;
    public int speed;
    public float howClose;

    public int checkpointIndex;
    private float distanceToCheckpoint;
    private float playerDistance;
    public float distanceToChasePlayer = 10f;
    public bool isChasingPlayer = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        checkpointIndex = 0;
        transform.LookAt(checkpoint[checkpointIndex].position);
        //turn the  front of the cube to look at the next checkpoint it will move towards

        player = GameObject.FindGameObjectWithTag("Player").transform;
        //name the object that has the tag as "player" the player hence informing the enemy to chase it
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);
        //the distance between the player  and enemy

        if (playerDistance <= distanceToChasePlayer)
        {
            isChasingPlayer = true;
            //if the distance between the player and the enemy is less than specificied to tell enemy to run after the player
        }
        else
        {
            isChasingPlayer = false;
            // as the distance is not what is required to chase enemy continue to do what it was doing before
        }
 

        Vector3 myPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 checkPointPos = new Vector3(checkpoint[checkpointIndex].transform.position.x, 0, checkpoint[checkpointIndex].transform.position.z);

        distanceToCheckpoint = Vector3.Distance(myPos, checkPointPos);
        if (distanceToCheckpoint < 3f)
        {
            // if the object is in the range of the checkpoint move onto the next checkpoint
            IncreaseIndex();
        }


        if (isChasingPlayer)
        {
            // if the player is in range of hte enemy starting chasing the player
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void ChasePlayer()
    { 
        agent.SetDestination(player.transform.position);
        agent.speed = (int)200f;

    }

    void Patrol()
    {
        agent.SetDestination(checkpoint[checkpointIndex].position);
        agent.speed = (int)45f;
    }

    void IncreaseIndex()
    {
        checkpointIndex++;
        if(checkpointIndex >= checkpoint.Length)
        {
            checkpointIndex = 0;
        }
        transform.LookAt(checkpoint[checkpointIndex].position);
    }

}
