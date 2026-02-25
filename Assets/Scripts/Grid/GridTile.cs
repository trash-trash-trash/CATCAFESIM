using System;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public IOccupy currentOccupee;
    
    public Vector2Int GridPosition { get; private set; }

    public bool IsOccupied { get; private set; }
    
    public OccupiedType TileOccupiedType { get; private set; }

    public event Action<OccupiedType> AnnounceOccupiedStatus;

    public void Initialize(Vector2Int position)
    {
        GridPosition = position;
        SetOccupied(null, OccupiedType.Empty, false);
    }

    public void SetOccupied(IOccupy occuppier, OccupiedType type, bool value)
    {
        IsOccupied = value;
        TileOccupiedType = type;
        
        if(occuppier!=null)
            currentOccupee = occuppier;
        
        AnnounceOccupiedStatus?.Invoke(type);
    }
}

public enum OccupiedType
{
    Empty,
    Mouse,
    Cat,
    Furniture,
    Poop
}