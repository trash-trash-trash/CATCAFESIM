using TMPro;
using UnityEngine;

public class CatView : MonoBehaviour
{
    public Cat cat;

    public TMP_Text catNameText;

    void OnEnable()
    {
        cat.AnnounceCatName += SetRandomCatName;
    }

    private void SetRandomCatName(string obj)
    {
        catNameText.text = obj;
    }

    void OnDisable()
    {
        cat.AnnounceCatName -= SetRandomCatName;
    }
}
