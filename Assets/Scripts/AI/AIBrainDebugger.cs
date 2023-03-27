using UnityEngine;

public class AIBrainDebugger : MonoBehaviour
{
    [SerializeField] private AIBrain _AIBrain;
    [SerializeField] private Transform _target;
    
    [ContextMenu("Test move to target")]
    public void SetDestination()
    {
        _AIBrain.SetDestination(_target.position);
    }
}
