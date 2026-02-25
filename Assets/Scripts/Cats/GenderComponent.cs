using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public enum GenderType
{
    Female,
    Male
}

[Serializable]
public enum SexType
{
    Kitten,
    BreedingInHeat,
    BreedingNotInHeat,
    Mature
}

[Serializable]
public struct GenderInfo
{
    public GenderType catGender;
    public SexType catSex;

    public bool IsInHeat => catSex == SexType.BreedingInHeat;
    public bool IsKitten => catSex == SexType.Kitten;
}

public class GenderComponent : MonoBehaviour
{
    [SerializeField] private GenderType catGenderType;
    [SerializeField] private SexType catSexType;

    public GenderType CatGenderType => catGenderType;
    public SexType CatSexType => catSexType;

    private void Awake()
    {
        catGenderType = AssignRandomGender();
        catSexType = SexType.Kitten;
    }

    private GenderType AssignRandomGender()
    {
        return Random.value < 0.5f ? GenderType.Female : GenderType.Male;
    }

    public GenderInfo GetGenderInfo()
    {
        return new GenderInfo
        {
            catGender = catGenderType,
            catSex = catSexType
        };
    }

    public static bool CanBreed(GenderComponent a, GenderComponent b)
    {
        if (a == null || b == null) return false;

        GenderInfo infoA = a.GetGenderInfo();
        GenderInfo infoB = b.GetGenderInfo();

        return infoA.catGender != infoB.catGender &&
               infoA.IsInHeat &&
               infoB.IsInHeat;
    }
}