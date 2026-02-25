using UnityEngine;

public class CatTileTracker : MonoBehaviour
{
    public Cat cat;
    [SerializeField] private float sphereRadius = 0.25f;
    [SerializeField] private float castHeight = 2f;
    [SerializeField] private float castDistance = 5f;
    [SerializeField] private LayerMask gridLayer;
    [SerializeField]private GridTile currentTile;

    private void FixedUpdate()
    {
        Vector3 origin = transform.position + Vector3.up * castHeight;

        if (Physics.SphereCast(origin, sphereRadius, Vector3.down, out RaycastHit hit, castDistance, gridLayer))
        {
            GridTile tile = hit.collider.GetComponent<GridTile>();
            if (tile == null) return;

            if (currentTile != tile)
            {
                // Clear previous
                if (currentTile != null)
                    currentTile.SetOccupied(null, OccupiedType.Empty, false);

                currentTile = tile;
            }

            // Set new if not already Cat
            if (!currentTile.IsOccupied)
                currentTile.SetOccupied(cat, OccupiedType.Cat, true);
        }
    }
}