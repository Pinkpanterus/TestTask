using DG.Tweening;
using Entities;
using UnityEngine;

public class AIBrain : MonoBehaviour, IEntityInjective
{
    public MonoEntity Entity { get; set; }
    private MoveComponent _moveComponent;

    private void Start()
    {
        DOVirtual.DelayedCall(0.1f, () =>
        {
            _moveComponent = Entity.Element<MoveComponent>();
            _moveComponent.OnMovementFinished += SetNewDestination;
        });

        SetNewDestination();
    }

    private void SetNewDestination()
    {
        DOVirtual.DelayedCall(1f, () => SetDestination());
    }

    private void OnDisable()
    {
        _moveComponent.OnMovementFinished -= SetDestination;
    }

    public void SetDestination(Vector3 destinationPoint)
    {
        _moveComponent.MoveToPosition(destinationPoint);
    }

    public void SetDestination()
    {
        Transform destinationPoint = DestinationSystem.Instance.GetDestinationPoint();
        _moveComponent.MoveToPosition(destinationPoint.position);
    }
}
