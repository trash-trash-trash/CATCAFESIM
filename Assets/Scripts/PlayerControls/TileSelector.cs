using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TileSelector : MonoBehaviour, IOccupy
{
    public Transform ReturnSelf => transform;

    public LayerMask raycastLayers;

    public Camera cam;
    [SerializeField] private GridTile currentTile;

    public bool enabled = false;

    // Cat profile UI
    public GameObject catProfileObj;
    public TMP_Text catInfoText;
    public Image catImage;

    public void ToggleEnabled(bool newEnabled)
    {
        enabled = newEnabled;
        if(!enabled)
            ClearMouseTile();
    }

    void Update()
    {
        if (!enabled || Mouse.current == null)
        {
            if (catProfileObj.activeInHierarchy)
                catProfileObj.SetActive(false);
            return;
        }

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 0.1f);

        if (!Physics.Raycast(ray, out RaycastHit hit, 1000f, raycastLayers))
        {
            catProfileObj.SetActive(false);
            ClearMouseTile();
            return;
        }

        GridTile tile = hit.collider.GetComponent<GridTile>();

        if (tile == null)
        {
            catProfileObj.SetActive(false);
            ClearMouseTile();
            return;
        }

// --- PRIORITIZE CAT PROFILE ---
        if (tile.IsOccupied && tile.TileOccupiedType == OccupiedType.Cat)
        {
            ShowCatProfile(tile);

            // DO NOT mark this tile as Mouse-occupied
            ClearMouseTile();
            return;
        }
        else
        {
            // Not a cat, hide profile
            catProfileObj.SetActive(false);
        }

// --- HANDLE MOUSE OCCUPATION ---
        if (!tile.IsOccupied || tile.TileOccupiedType == OccupiedType.Mouse)
        {
            if (currentTile != tile)
            {
                if (currentTile != null && currentTile.TileOccupiedType == OccupiedType.Mouse)
                    currentTile.SetOccupied(null, OccupiedType.Empty, false);

                tile.SetOccupied(this, OccupiedType.Mouse, true);
                currentTile = tile;
            }
        }
        else
        {
            ClearMouseTile();
        }
    }
    
    private void ShowCatProfile(GridTile catTile)
    {
        if (catTile.currentOccupee == null) return;

        Cat cat = catTile.currentOccupee.ReturnSelf.GetComponent<Cat>();
        if (cat == null) return;

        CatInfo catInfo = cat.catInfo;
        string genderSymbol = catInfo.GetGenderString(catInfo.genderInfo.catGender);

        catInfoText.text = $"{catInfo.catName}\n{catInfo.age}\n{genderSymbol}\n{catInfo.genderInfo.catSex}";
        catImage.sprite = catInfo.catSprite;
        catProfileObj.SetActive(true);
    }

    private void ClearMouseTile()
    {
        if (currentTile != null && currentTile.TileOccupiedType == OccupiedType.Mouse)
        {
            currentTile.SetOccupied(null, OccupiedType.Empty, false);
            currentTile = null;
        }
    }
}