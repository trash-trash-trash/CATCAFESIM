using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool IsPaused { get; private set; }

    [Range(0f, 5f)]
    public float timeScale = 1f;

    private float previousTimeScale = 1f;

    private void Awake()
    {
        ResumeTime(); // ensure normal time on start
    }

    public void PauseTime()
    {
        if (IsPaused) return;

        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeTime()
    {
        Time.timeScale = timeScale > 0 ? timeScale : previousTimeScale;
        IsPaused = false;
    }

    public void TogglePause(bool pause)
    {
        if (pause)
            PauseTime();
        else
            ResumeTime();
    }

    public void SetTimeScale(float value)
    {
        timeScale = Mathf.Max(0f, value);
        if (!IsPaused)
            Time.timeScale = timeScale;
    }
}