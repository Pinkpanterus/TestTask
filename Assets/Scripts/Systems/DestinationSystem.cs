using UnityEngine;

public class DestinationSystem : Singleton<DestinationSystem>
{
    [SerializeField] private Transform[] _destinationPoints;

    public Transform GetDestinationPoint()
    {
        return _destinationPoints[Random.Range(0, _destinationPoints.Length)];
    }
}
