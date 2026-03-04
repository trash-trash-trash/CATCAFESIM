using System;
using System.Collections.Generic;
using UnityEngine;

public class CatStatsTracker : MonoBehaviour
{
    public List<CatStat> stats = new List<CatStat>();

    private Dictionary<CatStatType, CatStat> statLookup;

    private void Awake()
    {
        EnsureAllStatsExist();
        BuildLookup();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        EnsureAllStatsExist();
    }
#endif

    private void EnsureAllStatsExist()
    {
        // Create missing stats
        foreach (CatStatType type in Enum.GetValues(typeof(CatStatType)))
        {
            if (!stats.Exists(s => s.StatType == type))
            {
                stats.Add(new CatStat(type));
            }
        }

        // Remove duplicates
        for (int i = stats.Count - 1; i >= 0; i--)
        {
            int duplicateCount = stats.FindAll(s => s.StatType == stats[i].StatType).Count;
            if (duplicateCount > 1)
            {
                stats.RemoveAt(i);
            }
        }
    }

    private void BuildLookup()
    {
        statLookup = new Dictionary<CatStatType, CatStat>();

        foreach (CatStat stat in stats)
        {
            statLookup[stat.StatType] = stat;
        }
    }

    public void ModifyStat(CatStatType type, int amount)
    {
        if (statLookup.TryGetValue(type, out CatStat stat))
            stat.ModifyStat(amount);
    }

    public void SetStat(CatStatType type, int value)
    {
        if (statLookup.TryGetValue(type, out CatStat stat))
            stat.Set(value);
    }

    public int GetStatValue(CatStatType type)
    {
        if (statLookup.TryGetValue(type, out CatStat stat))
            return stat.CurrentValue;

        return 0;
    }
}