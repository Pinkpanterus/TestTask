using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshConfigSystem : MonoBehaviour
{
    [SerializeField, Range(0.5f, 5f)] private float _avoidancePredictionTime = 5f;
    [SerializeField, Range(100, 5000)] private int _pathfinfingIterationsPerFrame = 500;
    [SerializeField] private int _navMeshTileSize = 512;
    [SerializeField] private float _navMeshVoxelSize = 0.05f;
    private void Awake()
    {
        NavMesh.avoidancePredictionTime = _avoidancePredictionTime;
        NavMesh.pathfindingIterationsPerFrame = _pathfinfingIterationsPerFrame;

        var navMeshSurface = FindObjectOfType<NavMeshSurface>();
        navMeshSurface.overrideTileSize = true;
        navMeshSurface.tileSize = _navMeshTileSize;
        navMeshSurface.overrideVoxelSize = true;
        navMeshSurface.voxelSize = _navMeshVoxelSize;
    }
}
