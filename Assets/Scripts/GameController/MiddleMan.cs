using UnityEngine;

public class MiddleMan : MonoBehaviour
{
    public PlayerControls playerControls;
    public TileSelector tileSelector;
    public TimeController timeController;

    void Awake()
    {
        playerControls.AnnounceEscapeHit += PauseUnpause;
    }

    private void PauseUnpause(bool buttonDown)
    {
        //if escape is hit
        //if time controller is paused, unpause it
        //else pause it
        if (buttonDown)
        {
            if (timeController.IsPaused)
            {
                timeController.TogglePause(false);
                tileSelector.ToggleEnabled(false);
            }
            else
            {
                timeController.TogglePause(true);
                tileSelector.ToggleEnabled(true);
            }
        }
    }

    void OnDisable()
    {
        playerControls.AnnounceEscapeHit -= PauseUnpause;
    }
}