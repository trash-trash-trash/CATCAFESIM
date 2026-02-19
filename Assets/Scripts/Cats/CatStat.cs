using System;
using UnityEngine;

[Serializable]
public class CatStat
{
    public event Action<int> OnValueChanged;

    [SerializeField] private string statName;
    [SerializeField] private int currentValue = 100;

    public int CurrentValue => currentValue;
    public string StatName => statName;

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
        OnValueChanged?.Invoke(currentValue);
    }

    public void Announce()
    {
        OnValueChanged?.Invoke(currentValue);
    }
}