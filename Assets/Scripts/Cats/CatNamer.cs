using System.Collections.Generic;
using UnityEngine;

public class CatNamer : MonoBehaviour
{
    public List<string> allCatNames;

    public List<string> unusedCatNames = new List<string>();
    public List<string> usedCatNames = new List<string>();

    void Start()
    {
        allCatNames = new List<string>()
        {
            "Ace",
            "Anarchy",
            "Bandit",
            "Cookie",
            "Bev",
            "Eric",
            "Exodus",
            "David",
            "Eevee",
            "Fat Fuck",
            "Fettuccine",
            "Fizz",
            "Garfield",
            "Greedy",
            "Guap",
            "Honey",
            "Joe Friday",
            "Kat",
            "Katrina",
            "Larry",
            "Mash",
            "Mephistopheles",
            "Moo Moo",
            "Mayhem",
            "Mucus",
            "Mr White",
            "Peanut",
            "Percocet",
            "Poonut",
            "Poonutto",
            "Pixie",
            "Plasma",
            "Pickle",
            "Pickles",
            "Pistachio",
            "Piss",
            "Rebel",
            "Refreshing Beverage",
            "Renfield",
            "Shadow",
            "Selina",
            "Selina Kyle",
            "Sawyer! :)",
            "Sepsis",
            "Spud",
            "T.C.",
            "Terminator 2: Judgement Day",
            "T2",
            "Top Cat",
            "Tiger",
            "Tigger",
            "Tony",
            "Tony S.",
            "Snowball",
            "Snowy",
            "Yogi"
        };

        InitializeNames();
    }

    void InitializeNames()
    {
        unusedCatNames.Clear();
        usedCatNames.Clear();

        // copy all names into unused
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