using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cop : MonoBehaviour
{

    private NavMeshAgent _agent;
    private Animator _animator;
    public Path path;

    private int pointIndex;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Patrol();
    }

    public void Patrol()
    {
        if (_agent.remainingDistance < 0.2f)
        {
            if (pointIndex < path.waypints.Count - 1 )
            {
                if (pointIndex == 0 || pointIndex == 2)
                {
                    _agent.speed = 2;
                    _animator.SetBool("isRunning", false);
                }
                else
                {
                    _agent.speed = 4;
                    _animator.SetBool("isRunning", true);
                }
                pointIndex++;
            }
            else
            {
                _agent.speed = 4;
                _animator.SetBool("isRunning", true);
                pointIndex = 0;
            }
            _agent.SetDestination(path.waypints[pointIndex].position);
        }
    }
}
