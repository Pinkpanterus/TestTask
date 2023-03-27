using Animancer;
using DG.Tweening;
using Entities;
using UnityEngine;

[RequireComponent(typeof(AnimancerComponent))]
public class AnimatorComponent : MonoBehaviour, IEntityInjective
{
    public MonoEntity Entity { get; set; }
    [SerializeField] private ClipTransition _idleAnimationClip;
    [SerializeField] private ClipTransition _walkAnimationClip;
    private MoveComponent _moveComponent;
    private AnimancerComponent _animancerComponent;
    
    private void Awake()
    {
        _animancerComponent = GetComponent<AnimancerComponent>();
        _animancerComponent.Play(_idleAnimationClip);
    }

    private void Start()
    {
        DOVirtual.DelayedCall(0.1f,() =>
        {
            _moveComponent = Entity.Element<MoveComponent>();
            _moveComponent.OnMovementStarted += () => _animancerComponent.Play(_walkAnimationClip);
            _moveComponent.OnMovementFinished += () => _animancerComponent.Play(_idleAnimationClip);
        });
    }

    private void OnDisable()
    {
        if (_moveComponent)
        {
            _moveComponent.OnMovementStarted -= () => _animancerComponent.Play(_walkAnimationClip);
            _moveComponent.OnMovementFinished -= () => _animancerComponent.Play(_idleAnimationClip);
        }
    }
}
