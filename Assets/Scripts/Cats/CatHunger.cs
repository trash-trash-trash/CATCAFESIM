using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHunger : MonoBehaviour
{
    [Header("Hunger Settings")]
    [Tooltip("Base hunger increase per second.")]
    [SerializeField] private float baseHungerPerSecond = 1f;

    [Tooltip("Cat-specific metabolism multiplier.")]
    [SerializeField] private float metabolism = 1f;

    public CatStatsTracker stats;
    private float hungerTimer;

    public int currentHunger = 0;

    private void Awake()
    {StartHunger();
    }

    private void StartHunger()
    {
        StartCoroutine(HungerTick());
    }

    private IEnumerator HungerTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            stats.ModifyStat(CatStatType.Hunger, Mathf.RoundToInt(baseHungerPerSecond * metabolism));
            currentHunger = stats.GetStatValue(CatStatType.Hunger);
        }
    }

    public void Feed(int mealValue)
    {
        stats.ModifyStat(CatStatType.Hunger, -mealValue);
    }
}