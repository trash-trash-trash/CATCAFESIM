using Anthill.AI;
using UnityEngine;

public class CatSensor : MonoBehaviour, ISense
{
    public bool hungry = false;
    public bool foodDetected = false;
    public bool inFoodRange = false;
    public bool eating = false;
    
    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        aWorldState.Set(CatScenario.Hungry, hungry);
        aWorldState.Set(CatScenario.FoodDetected, foodDetected);
        aWorldState.Set(CatScenario.InRange, inFoodRange);
        aWorldState.Set(CatScenario.Eating, eating);
    }
}
