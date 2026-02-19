using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float tileSize = 1f;

    public GameObject floorTilePrefab;

    public Dictionary<Vector2Int, GridTile> gridDict = new Dictionary<Vector2Int, GridTile>();

    public event Action AnnounceFloorBuilt;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int gridPos = new Vector2Int(x, y);
                Vector3 worldPos = new Vector3(x * tileSize, 0, y * tileSize);

                GameObject obj = Instantiate(floorTilePrefab, worldPos, Quaternion.identity, transform);
                GridTile tile = obj.GetComponent<GridTile>();

                tile.Initialize(gridPos);
                gridDict.Add(gridPos, tile);
            }
        }

        AnnounceFloorBuilt?.Invoke();
    }

    public GridTile GetTile(Vector2Int position)
    {
        gridDict.TryGetValue(position, out GridTile tile);
        return tile;
    }
}