using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    private bool follow;
    [SerializeField] List<GameObject> pathPoints;
    int currentPoint = -1;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (follow)
        {
            agent.stoppingDistance = 1.7f;
            agent.speed = 5;
            animator.SetBool("walk", false);
            animator.SetBool("run", true);
            agent.SetDestination(player.transform.position);
        }
        else
        {
            animator.SetBool("run", false);
            animator.SetBool("walk", true);
            agent.speed = 2;
            if (agent.remainingDistance == 0)
            {
                currentPoint++;
                Debug.Log("++");
            }
            if (currentPoint >= pathPoints.Count)
            {
                currentPoint = 0;
            }
            agent.stoppingDistance = 0.0f;
            agent.SetDestination(pathPoints[currentPoint].transform.position);       
        }     
    }

    public void SetFollowState(bool state)
    {
        follow = state;
    }
}
