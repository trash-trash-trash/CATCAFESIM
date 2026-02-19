using System.Collections.Generic;
using UnityEngine;

public class CatsTracker : MonoBehaviour
{
    public GridManager gridManager;

    public GameObject catPrefab;
    public int numberOfCats = 3;
    
    public List<GameObject> spawnedCats = new List<GameObject>();

    private void Start()
    {
        gridManager.AnnounceFloorBuilt += SpawnCats;
    }

    private void SpawnCats()
    {
        int spawned = 0;
        int safety = 0; // prevents infinite loop

        while (spawned < numberOfCats && safety < 1000)
        {
            safety++;

            int randomX = Random.Range(0, gridManager.width);
            int randomZ = Random.Range(0, gridManager.height);

            Vector2Int randomPos = new Vector2Int(randomX, randomZ);

            GridTile tile = gridManager.GetTile(randomPos);

            if (tile.IsOccupied)
                continue;

            // Spawn cat
            Vector3 worldPos = tile.transform.position + Vector3.up * 0.5f;
            GameObject newCat = Instantiate(catPrefab, worldPos, Quaternion.identity);

            // Mark tile occupied
            tile.SetOccupied(true);

            spawnedCats.Add(newCat);
            
            spawned++;
        }

        if (safety >= 1000)
        {
            Debug.LogWarning("Stopped cat spawning due to safety limit.");
        }
    }
}