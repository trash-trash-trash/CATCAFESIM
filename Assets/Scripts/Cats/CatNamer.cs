using System.Collections.Generic;
using UnityEngine;

public class CatNamer : MonoBehaviour
{
    public List<string> allCatNames = new List<string>()
    {
        "Ace",
        "David",
        "Eevee",
        "Fat Fuck",
        "Garfield",
        "Kat",
        "Katrina",
        "Moo Moo",
        "Mr White",
        "Peanut",
        "Poonut",
        "Poonutto",
        "Pixie",
        "Pickle",
        "Pickles",
        "Shadow",
        "Selina",
        "Selina Kyle",
        "T.C.",
        "Top Cat",
        "Tiger",
        "Tigger",
        "Tony",
        "Tony S.",
        "Snowball",
        "Snowy",
        "Yogi"
    };

    public List<string> unusedCatNames = new List<string>();
    public List<string> usedCatNames = new List<string>();

    void Start()
    {
        InitializeNames();
    }

    void InitializeNames()
    {
        unusedCatNames.Clear();
        usedCatNames.Clear();

        // Copy all names into unused
        unusedCatNames.AddRange(allCatNames);
    }

    public string GetRandomUnusedName()
    {
        if (unusedCatNames.Count == 0)
        {
            Debug.LogWarning("No unused cat names left!");
            return null;
        }

        int randomIndex = Random.Range(0, unusedCatNames.Count);
        string selectedName = unusedCatNames[randomIndex];

        // Move to used
        unusedCatNames.RemoveAt(randomIndex);
        usedCatNames.Add(selectedName);

        return selectedName;
    }

    public void ReturnNameToUnused(string name)
    {
        if (usedCatNames.Contains(name))
        {
            usedCatNames.Remove(name);
            unusedCatNames.Add(name);
        }
        else
        {
            Debug.LogWarning($"Name '{name}' was not in used list.");
        }
    }
}