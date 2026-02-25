using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class UIBounce : MonoBehaviour
{
    public float bounceHeight = 0.25f;
    public float duration = 0.8f;
    public Ease easeType = Ease.InOutSine;

    private Vector3 startWorldPos;
    private Tween bounceTween;

    public Transform spriteTransform;

    private void Awake()
    {
        startWorldPos = spriteTransform.position;
    }

    private void OnEnable()
    {
        StartBounce();
    }

    private void OnDisable()
    {
        bounceTween?.Kill();
        spriteTransform.position = startWorldPos;
    }

    private void StartBounce()
    {
        float randomOffset = Random.Range(0f, 0.2f);
        float finalDuration = duration + randomOffset;

        bounceTween = spriteTransform
            .DOMoveY(startWorldPos.y + bounceHeight, finalDuration)
            .SetEase(easeType)
            .SetLoops(-1, LoopType.Yoyo);
    }
}