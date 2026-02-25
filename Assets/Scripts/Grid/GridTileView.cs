using System.Collections.Generic;
using UnityEngine;

public class GridTileView : MonoBehaviour
{
    public GridTile gridTile;
    
    public Renderer renderer;

    public Material green;
    public Material red;
    public Material yellow;
    public Material brown;
    
    public Dictionary<OccupiedType, Material> materialDict = new Dictionary<OccupiedType, Material>();

    void Awake()
    {
        materialDict.Add(OccupiedType.Empty, green);
        materialDict.Add(OccupiedType.Cat, red);
        materialDict.Add(OccupiedType.Mouse, yellow);
        materialDict.Add(OccupiedType.Poop, brown);

        gridTile.AnnounceOccupiedStatus += SetTileColor;
    }

    private void SetTileColor(OccupiedType obj)
    {
        if (materialDict.TryGetValue(obj, out Material mat))
        {
            renderer.material = mat;
        }
    }

    void OnDisable()
    {
        gridTile.AnnounceOccupiedStatus -= SetTileColor;
    }
}
