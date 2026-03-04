using System;
using UnityEngine;

public enum CatStatType
{
    Affection,
    Hunger,
    Thirst,
    Aggression,
    Happiness,
    Poopee
}

[Serializable]
public class CatStat
{
    public event Action<int> AnnounceValueChanged;

    [SerializeField] private CatStatType statType;
    [SerializeField] private int currentValue = 0;
    [SerializeField] private bool revealedToPlayer = true;
    
    public CatStatType StatType => statType;
    public int CurrentValue => currentValue;
    public bool RevealedToPlayer => revealedToPlayer;

    public CatStat(CatStatType type)
    {
        statType = type;
        currentValue = 0;
        revealedToPlayer = false;
    }
    
    public void ModifyStat(int amount)
    {
        Set(currentValue + amount);
    }

    public void Set(int value)
    {
        int clamped = Mathf.Clamp(value, 0, 100);

        if (clamped == currentValue)
            return;

        currentValue = clamped;
        AnnounceValueChanged?.Invoke(currentValue);
    }

    public void RevealStat()
    {
        revealedToPlayer = true;
    }
}