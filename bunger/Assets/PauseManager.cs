using UnityEngine;
using System;

// Simple pause manager that does NOT use Time.timeScale.
// Enemies and other systems should check PauseManager.Instance.IsPaused
// or subscribe to OnPauseChanged to react when pause toggles.
public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }

    public bool IsPaused { get; private set; }

    public event Action<bool> OnPauseChanged;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPaused(bool paused)
    {
        if (IsPaused == paused) return;
        IsPaused = paused;
        OnPauseChanged?.Invoke(IsPaused);
    }

    public void TogglePause()
    {
        SetPaused(!IsPaused);
    }
}
