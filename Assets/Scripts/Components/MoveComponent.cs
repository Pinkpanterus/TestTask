using System;
using System.Collections;
using Entities;
using UnityEngine;
using UnityEngine.AI;

public class MoveComponent : MonoBehaviour, IEntityInjective
{
    public MonoEntity Entity { get; set; }
    public Action OnMovementStarted;
    public Action OnMovementFinished;
    private NavMeshAgent _navMeshAgent;


    /*private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }*/

    private void Start()
    {
        _navMeshAgent = Entity.GetComponent<NavMeshAgent>();
    }

    public void MoveToPosition(Vector3 position)
    {
        if (_navMeshAgent.isOnNavMesh == false)
        {                  
            _navMeshAgent.Warp(transform.position);
        }

        OnMovementStarted?.Invoke();
        _navMeshAgent.destination = position;
        
        StartCoroutine(CheckDestinationReachedCoroutine(position));
    }

    private IEnumerator CheckDestinationReachedCoroutine(Vector3 position)
    {
        while (true)
        {
            if(Vector3.Distance(transform.position, position) <= 0.1f)
            //if (_navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                Debug.Log("Destination reached");
                OnMovementFinished?.Invoke();
                yield break;
            }

            yield return null;
        }
    }
}
