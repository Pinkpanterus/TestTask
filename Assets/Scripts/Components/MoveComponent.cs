using System;
using System.Collections;
using DG.Tweening;
using Entities;
using UnityEngine;
using UnityEngine.AI;

public class MoveComponent : MonoBehaviour, IEntityInjective
{
    public Action OnMovementStarted;
    public Action OnMovementFinished;
    public MonoEntity Entity { get; set; }
    [SerializeField] private float distanceError = 0.25f;
    private NavMeshAgent _navMeshAgent;
    private NavMeshObstacle _navMeshObstacle;

    private void Start()
    {
        _navMeshAgent = Entity.GetComponent<NavMeshAgent>();
        if (_navMeshAgent.isOnNavMesh == false) _navMeshAgent.Warp(transform.position);
        
        _navMeshObstacle = Entity.GetComponent<NavMeshObstacle>();
        _navMeshObstacle.enabled = false;
        _navMeshObstacle.carveOnlyStationary = false;
        _navMeshObstacle.carving = true;
    }

    public void MoveToPosition(Vector3 position)
    {
        StartCoroutine(MoveToPositionCoroutine(position));
    }

    private IEnumerator MoveToPositionCoroutine(Vector3 position)
    {
        SetMovable(true);
        yield return new WaitUntil(() => _navMeshAgent.enabled);

        OnMovementStarted?.Invoke();
        _navMeshAgent.destination = position;
        
        StartCoroutine(CheckDestinationReachedCoroutine(position));
    }

    private IEnumerator CheckDestinationReachedCoroutine(Vector3 position)
    {
        while (true)
        {
            if(Vector3.Distance(transform.position, position) <= distanceError)
            {
                OnMovementFinished?.Invoke();
                SetMovable(false);
                yield break;
            }

            yield return null;
        }
    }

    private void SetMovable(bool isMovable)
    {
        if (isMovable)
        {
            _navMeshObstacle.enabled = !isMovable;
            DOVirtual.DelayedCall(Time.deltaTime, () => _navMeshAgent.enabled = isMovable);
        }
        else
        {
            _navMeshAgent.enabled = isMovable;
            _navMeshObstacle.enabled = !isMovable;
        }
    }
}
