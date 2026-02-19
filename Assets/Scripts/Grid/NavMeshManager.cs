using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshManager : MonoBehaviour
{
    public NavMeshSurface surface;
    public GridManager gridManager;

    void Start()
    {
        gridManager.AnnounceFloorBuilt += BakeNavMeshFloor;
    }

    private void BakeNavMeshFloor()
    {
        surface.BuildNavMesh();
    }
    
    void OnDisable()
    {
        gridManager.AnnounceFloorBuilt -= BakeNavMeshFloor;
    }
}
