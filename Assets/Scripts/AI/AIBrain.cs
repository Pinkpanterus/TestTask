using DG.Tweening;
using Entities;
using UnityEngine;

public class AIBrain : MonoBehaviour, IEntityInjective
{
    public MonoEntity Entity { get; set; }
    private MoveComponent _moveComponent;

    private void Start()
    {
        _moveComponent = Entity.Element<MoveComponent>();
        //DOVirtual.DelayedCall(0.1f,() =>_moveComponent = Entity.Element<MoveComponent>());
    }

    public void SetDestination(Vector3 destinationPoint)
    {
        _moveComponent.MoveToPosition(destinationPoint);
    }
}
