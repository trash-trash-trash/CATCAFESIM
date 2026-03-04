using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatStatCanvasObject : MonoBehaviour
{
    public TMP_Text statNameText;
    public Slider statSlider;

    private CatStat boundStat;

    public void Bind(CatStat catStat)
    {
        boundStat = catStat;

        statNameText.text = catStat.StatType.ToString();
        statSlider.value = catStat.CurrentValue;

        catStat.AnnounceValueChanged += OnStatChanged;
    }

    private void OnStatChanged(int value)
    {
        statSlider.value = value;
    }

    private void OnDestroy()
    {
        if (boundStat != null)
            boundStat.AnnounceValueChanged -= OnStatChanged;
    }
}