using UnityEngine;
using UnityEngine.InputSystem;

public class TileSelector : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = cam.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GridTile tile = hit.collider.GetComponent<GridTile>();

            if (tile != null)
            {
                Debug.Log($"Tile {tile.GridPosition} Occupied: {tile.IsOccupied}");
            }
        }
    }
}